from PyQt5.QtWidgets import (
    QMainWindow, QLabel, QComboBox, QLineEdit,
    QPushButton, QTableWidget, QTableWidgetItem, QMessageBox
)
from core.styles import Estilos
from core.fuentes import fuente_texto, fuente_botones
from core.ubicaciones import Posicion
from core.api_manager import APIManager


class VentanaFiltrarPinturas(QMainWindow):
    def __init__(self):
        super().__init__()
        self.setWindowTitle("Filtrar Pinturas")
        self.setFixedSize(1060, 720)
        Estilos.aplicar_estilo_general(self)

        # --- Título ---
        self.label_titulo = QLabel("Filtrar Pinturas", self)
        self.label_titulo.setFont(fuente_texto)
        Estilos.aplicar_estilo_titulo(self.label_titulo)
        Posicion.centrar_texto_arriba(self, self.label_titulo)

        # --- Selector de parámetro ---
        self._crear_campo("Filtrar por:", 150)
        self.combo_parametro = QComboBox(self)
        self.combo_parametro.addItems(["Técnica", "Textura", "Autor"])
        self.combo_parametro.move(250, 150)
        self.combo_parametro.resize(200, 30)

        # --- Cuadro de texto para valor ---
        self._crear_campo("Valor:", 200)
        self.txt_valor = QLineEdit(self)
        self.txt_valor.move(250, 200)
        self.txt_valor.resize(250, 30)

        # --- Botón Filtrar ---
        self.boton_filtrar = QPushButton("Filtrar", self)
        self.boton_filtrar.setFont(fuente_botones)
        self.boton_filtrar.move(550, 200)
        self.boton_filtrar.resize(120, 35)
        self._estilo_boton(self.boton_filtrar)
        self.boton_filtrar.clicked.connect(self.filtrar_pinturas)

        # --- Tabla ---
        self.tabla = QTableWidget(self)
        self.tabla.setColumnCount(7)
        self.tabla.setHorizontalHeaderLabels([
            "ID", "Título", "Autor", "Fecha Creación", "Técnica", "Textura", "Estado"
        ])
        self.tabla.move(50, 280)
        self.tabla.resize(960, 400)
        self._estilo_tabla()

    # --- Estilos y mensajes ---
    def _estilo_boton(self, boton):
        boton.setStyleSheet("""
            QPushButton {
                background-color: #0B2B40;
                color: #89D99D;
                border-radius: 8px;
                padding: 8px 12px;
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
                border: none;
            }
            QTableWidget {
                background-color: #1C3144;
                color: #E8E8E8;
                gridline-color: #0B2B40;
                font-size: 13px;
            }
        """)

    def _crear_campo(self, texto, y):
        label = QLabel(texto, self)
        label.setFont(fuente_texto)
        label.move(100, y)
        label.adjustSize()
        Estilos.aplicar_estilo_txt(label)

    def _mensaje(self, texto, tipo="info"):
        msg = QMessageBox(self)
        msg.setWindowTitle("Galería de Arte")
        msg.setText(texto)
        msg.setIcon(QMessageBox.Warning if tipo == "warning" else QMessageBox.Information)
        msg.exec_()

    # --- Lógica principal ---
    def filtrar_pinturas(self):
        filtro = self.combo_parametro.currentText()
        valor = self.txt_valor.text().strip()

        if not valor:
            self._mensaje("Debe ingresar un valor para filtrar.", "warning")
            return

        # Mapeo de parámetros según backend
        params = {}
        if filtro == "Técnica":
            params["tecnica"] = valor
        elif filtro == "Textura":
            params["textura"] = valor
        elif filtro == "Autor":
            params["autor"] = valor

        pinturas = APIManager.filtrar_pinturas(params)

        if not pinturas:
            self._mensaje("No se encontraron pinturas con ese filtro.", "info")
            self.tabla.setRowCount(0)
            return

        self.tabla.setRowCount(len(pinturas))
        for fila, p in enumerate(pinturas):
            self.tabla.setItem(fila, 0, QTableWidgetItem(str(p.get("id", ""))))
            self.tabla.setItem(fila, 1, QTableWidgetItem(str(p.get("titulo", ""))))
            self.tabla.setItem(fila, 2, QTableWidgetItem(str(p.get("autor", ""))))

            fecha = p.get("anioCreacion") or p.get("fechaIngreso") or ""
            if fecha and "T" in fecha:
                fecha = fecha.split("T")[0]
            self.tabla.setItem(fila, 3, QTableWidgetItem(str(fecha)))

            self.tabla.setItem(fila, 4, QTableWidgetItem(str(p.get("tecnica", ""))))
            self.tabla.setItem(fila, 5, QTableWidgetItem(str(p.get("textura", ""))))
            self.tabla.setItem(fila, 6, QTableWidgetItem(str(p.get("estado", ""))))
