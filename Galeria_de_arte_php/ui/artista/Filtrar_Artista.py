from PyQt5.QtWidgets import (
    QMainWindow, QLabel, QComboBox, QPushButton,
    QTableWidget, QTableWidgetItem, QMessageBox, QLineEdit
)
from core.styles import Estilos
from core.fuentes import fuente_texto, fuente_botones
from core.ubicaciones import Posicion
from core.api_manager_art import APIManagerArtista


class VentanaFiltrarArtista(QMainWindow):
    def __init__(self):
        super().__init__()
        self.setWindowTitle("Filtrar Artistas")
        self.setFixedSize(1060, 720)
        Estilos.aplicar_estilo_general(self)

        # --- Título ---
        self.label_titulo = QLabel("Filtrar Artistas", self)
        self.label_titulo.setFont(fuente_texto)
        Estilos.aplicar_estilo_titulo(self.label_titulo)
        Posicion.centrar_texto_arriba(self, self.label_titulo)

        # --- Criterio principal ---
        self._crear_campo("Filtrar por:", 130)

        self.combo_criterio = QComboBox(self)
        self.combo_criterio.addItems(["Nombre", "Nacionalidad", "Estado"])
        self.combo_criterio.move(250, 130)
        self.combo_criterio.resize(200, 30)
        self.combo_criterio.currentIndexChanged.connect(self.mostrar_opciones)

        # --- Entrada de texto ---
        self.txt_valor = QLineEdit(self)
        self.txt_valor.move(250, 180)
        self.txt_valor.resize(300, 30)

        # --- Combo de estado ---
        self.combo_estado = QComboBox(self)
        self.combo_estado.addItems(["Activo", "Inactivo"])
        self.combo_estado.move(250, 180)
        self.combo_estado.resize(200, 30)
        self.combo_estado.hide()

        # --- Botón Filtrar ---
        self.boton_filtrar = QPushButton("Filtrar", self)
        self.boton_filtrar.setFont(fuente_botones)
        self.boton_filtrar.move(580, 180)
        self.boton_filtrar.resize(120, 35)
        self._estilo_boton(self.boton_filtrar)
        self.boton_filtrar.clicked.connect(self.filtrar)

        # --- Tabla de artistas ---
        self.tabla = QTableWidget(self)
        self.tabla.setColumnCount(7)
        self.tabla.setHorizontalHeaderLabels([
            "ID", "Nombre", "Nacionalidad",
            "Estilo", "Años Experiencia", "Email", "Estado"
        ])
        self.tabla.move(50, 250)
        self.tabla.resize(960, 400)
        self._estilo_tabla()

        self.mostrar_opciones()

    # --- Helpers ---
    def _crear_campo(self, texto, y):
        label = QLabel(texto, self)
        label.setFont(fuente_texto)
        label.move(100, y)
        label.adjustSize()
        Estilos.aplicar_estilo_txt(label)

    def _estilo_boton(self, boton):
        boton.setStyleSheet("""
            QPushButton {
                background-color: #0B2B40;
                color: #89D99D;
                border-radius: 8px;
            }
            QPushButton:hover {
                background-color: #133B5C;
            }
        """)

    def _estilo_tabla(self):
        self.tabla.setStyleSheet("""
            QHeaderView::section {
                background-color: #0B2B40;
                color: #89D99D;
                padding: 5px;
            }
            QTableWidget {
                background-color: #1C3144;
                color: #E8E8E8;
                font-size: 13px;
            }
        """)

    def _mensaje(self, texto, tipo="info"):
        msg = QMessageBox(self)
        msg.setWindowTitle("Galería de Arte")
        msg.setText(texto)
        msg.setIcon(QMessageBox.Warning if tipo == "warning" else QMessageBox.Information)
        msg.exec_()

    # --- Mostrar opciones según criterio ---
    def mostrar_opciones(self):
        criterio = self.combo_criterio.currentText()

        if criterio in ["Nombre", "Nacionalidad"]:
            self.txt_valor.show()
            self.combo_estado.hide()
        else:  # Estado
            self.txt_valor.hide()
            self.combo_estado.show()

    # --- Filtrar artistas ---
    def filtrar(self):
        criterio = self.combo_criterio.currentText()

        # 🔹 Filtro por nombre
        if criterio == "Nombre":
            valor = self.txt_valor.text().strip()
            if not valor:
                self._mensaje("Debe ingresar un nombre.", "warning")
                return
            artistas = APIManagerArtista.buscar_artista_por_nombre(valor)

        # 🔹 Filtro por nacionalidad
        elif criterio == "Nacionalidad":
            valor = self.txt_valor.text().strip()
            if not valor:
                self._mensaje("Debe ingresar una nacionalidad.", "warning")
                return
            artistas = APIManagerArtista.buscar_artista_por_nacionalidad(valor)

        # 🔹 Filtro por estado (backend NO tiene endpoint → se filtra en cliente)
        elif criterio == "Estado":
            estado = self.combo_estado.currentText()
            todos = APIManagerArtista.listar_artistas()

            if estado == "Activo":
                artistas = [a for a in todos if a.get("activo", True)]
            else:
                artistas = [a for a in todos if not a.get("activo", True)]

        # Mostrar en tabla
        if not artistas:
            self._mensaje("No se encontraron artistas con ese filtro.", "info")
            self.tabla.setRowCount(0)
            return

        self.tabla.setRowCount(len(artistas))

        for fila, a in enumerate(artistas):
            self.tabla.setItem(fila, 0, QTableWidgetItem(str(a.get("id", ""))))
            self.tabla.setItem(fila, 1, QTableWidgetItem(str(a.get("nombre", ""))))
            self.tabla.setItem(fila, 2, QTableWidgetItem(str(a.get("nacionalidad", ""))))
            self.tabla.setItem(fila, 3, QTableWidgetItem(str(a.get("estiloPrincipal", ""))))
            self.tabla.setItem(fila, 4, QTableWidgetItem(str(a.get("añosExperiencia", ""))))
            self.tabla.setItem(fila, 5, QTableWidgetItem(str(a.get("email", ""))))

            estado = "Activo" if a.get("activo", True) else "Inactivo"
            self.tabla.setItem(fila, 6, QTableWidgetItem(estado))
