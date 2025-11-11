from PyQt5.QtWidgets import (
    QMainWindow, QLabel, QComboBox, QPushButton,
    QTableWidget, QTableWidgetItem, QMessageBox
)
from core.styles import Estilos
from core.fuentes import fuente_texto, fuente_botones
from core.ubicaciones import Posicion
from core.api_manager import APIManager


class VentanaFiltrarEsculturas(QMainWindow):
    def __init__(self):
        super().__init__()
        self.setWindowTitle("Filtrar Esculturas")
        self.setFixedSize(1060, 720)
        Estilos.aplicar_estilo_general(self)

        # --- Título ---
        self.label_titulo = QLabel("Filtrar Esculturas", self)
        self.label_titulo.setFont(fuente_texto)
        Estilos.aplicar_estilo_titulo(self.label_titulo)
        Posicion.centrar_texto_arriba(self, self.label_titulo)

        # --- Criterio principal ---
        self._crear_campo("Filtrar por:", 130)
        self.combo_criterio = QComboBox(self)
        self.combo_criterio.addItems(["Material", "Tipo", "Estado"])
        self.combo_criterio.move(250, 130)
        self.combo_criterio.resize(200, 30)
        self.combo_criterio.currentIndexChanged.connect(self.cambiar_opciones)

        # --- Combo secundario (valores de filtro) ---
        self._crear_campo("Valor:", 180)
        self.combo_valor = QComboBox(self)
        self.combo_valor.move(250, 180)
        self.combo_valor.resize(200, 30)

        # Inicializar opciones
        self.cambiar_opciones(0)

        # --- Botón Filtrar ---
        self.boton_filtrar = QPushButton("Filtrar", self)
        self.boton_filtrar.setFont(fuente_botones)
        self.boton_filtrar.move(480, 180)
        self.boton_filtrar.resize(120, 35)
        self._estilo_boton(self.boton_filtrar)
        self.boton_filtrar.clicked.connect(self.filtrar)

        # --- Tabla de resultados ---
        self.tabla = QTableWidget(self)
        self.tabla.setColumnCount(8)
        self.tabla.setHorizontalHeaderLabels([
            "ID", "Título", "Autor", "Tipo", "Materia",
            "Altura", "Volumen", "Precio"
        ])
        self.tabla.move(50, 250)
        self.tabla.resize(960, 400)
        self._estilo_tabla()

    # --- Métodos auxiliares ---
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

    def _mensaje(self, texto, tipo="info"):
        msg = QMessageBox(self)
        msg.setWindowTitle("Galería de Arte")
        msg.setText(texto)
        msg.setIcon(QMessageBox.Warning if tipo == "warning" else QMessageBox.Information)
        msg.exec_()

    # --- Actualiza las opciones del combo secundario ---
    def cambiar_opciones(self, index):
        criterio = self.combo_criterio.currentText()
        self.combo_valor.clear()
        if criterio == "Material":
            self.combo_valor.addItems(["Mármol", "Bronce", "Madera", "Yeso", "Otro"])
        elif criterio == "Tipo":
            self.combo_valor.addItems(["Busto", "Estatua", "Relieve", "Figurativa", "Abstracta","Monumento"])
        elif criterio == "Estado":
            self.combo_valor.addItems(["Activo", "Inactivo"])

    # --- Lógica de filtrado ---
    def filtrar(self):
        criterio = self.combo_criterio.currentText()
        valor = self.combo_valor.currentText()

        params = {}
        if criterio == "Material":
            params["material"] = valor
        elif criterio == "Tipo":
            params["tipoEscultura"] = valor
        elif criterio == "Estado":
            params["estado"] = valor

        try:
            esculturas = APIManager.buscar_esculturas(params)
            if not esculturas:
                self._mensaje("No se encontraron esculturas con ese filtro.", "info")
                self.tabla.setRowCount(0)
                return

            self.tabla.setRowCount(len(esculturas))
            for fila, e in enumerate(esculturas):
                self.tabla.setItem(fila, 0, QTableWidgetItem(str(e.get("id", ""))))
                self.tabla.setItem(fila, 1, QTableWidgetItem(str(e.get("titulo", ""))))
                self.tabla.setItem(fila, 2, QTableWidgetItem(str(e.get("autor", ""))))
                self.tabla.setItem(fila, 3, QTableWidgetItem(str(e.get("tipoEscultura", ""))))
                self.tabla.setItem(fila, 4, QTableWidgetItem(str(e.get("material", ""))))
                self.tabla.setItem(fila, 5, QTableWidgetItem(str(e.get("altura", ""))))
                self.tabla.setItem(fila, 6, QTableWidgetItem(str(e.get("volumen", ""))))
                self.tabla.setItem(fila, 7, QTableWidgetItem(str(e.get("precio", ""))))
        except Exception as e:
            print("❌ Error al filtrar esculturas:", e)
            self._mensaje("Error al conectarse con el servidor.", "warning")
