from PyQt5.QtWidgets import (
    QMainWindow, QLabel, QPushButton, QTableWidget, QTableWidgetItem, QMessageBox
)
from core.styles import Estilos
from core.fuentes import fuente_texto, fuente_botones
from core.ubicaciones import Posicion
from core.api_manager import APIManager


class VentanaListarEsculturas(QMainWindow):
    def __init__(self):
        super().__init__()
        self.setWindowTitle("Listar Esculturas")
        self.setFixedSize(1060, 720)
        Estilos.aplicar_estilo_general(self)

        # --- Título ---
        self.label_titulo = QLabel("Listado de Esculturas Activas", self)
        self.label_titulo.setFont(fuente_texto)
        Estilos.aplicar_estilo_titulo(self.label_titulo)
        Posicion.centrar_texto_arriba(self, self.label_titulo)

        # --- Botón Listar ---
        self.boton_listar = QPushButton("Listar Esculturas", self)
        self.boton_listar.setFont(fuente_botones)
        self.boton_listar.move(800, 100)
        self.boton_listar.resize(220, 40)
        self._estilo_boton(self.boton_listar)
        self.boton_listar.clicked.connect(self.listar_esculturas)

        # --- Tabla ---
        self.tabla = QTableWidget(self)
        self.tabla.setColumnCount(10)
        self.tabla.setHorizontalHeaderLabels([
            "ID", "Título", "Autor", "Fecha Ingreso","Tipo", "Material",
            "Altura", "Volumen","Tipo de Escultura", "Precio"
        ])
        self.tabla.move(50, 180)
        self.tabla.resize(960, 500)
        self._estilo_tabla()

    # --- Estilos ---
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

    # --- Lógica principal ---
    def listar_esculturas(self):
        """Obtiene esculturas activas desde el backend."""
        try:
            esculturas = APIManager.listar_esculturas()
            if not esculturas:
                self._mensaje("No hay esculturas activas registradas.", "info")
                self.tabla.setRowCount(0)
                return

            self.tabla.setRowCount(len(esculturas))
            for fila, e in enumerate(esculturas):
                self.tabla.setItem(fila, 0, QTableWidgetItem(str(e.get("id", ""))))
                self.tabla.setItem(fila, 1, QTableWidgetItem(str(e.get("titulo", ""))))
                self.tabla.setItem(fila, 2, QTableWidgetItem(str(e.get("autor", ""))))

                fecha = e.get("fechaIngreso")
                if fecha and "T" in fecha:
                    fecha = fecha.split("T")[0]
                self.tabla.setItem(fila, 3, QTableWidgetItem(str(fecha)))

                self.tabla.setItem(fila, 4, QTableWidgetItem(str(e.get("tipo", ""))))
                self.tabla.setItem(fila, 5, QTableWidgetItem(str(e.get("material", ""))))
                self.tabla.setItem(fila, 6, QTableWidgetItem(str(e.get("altura", ""))))
                self.tabla.setItem(fila, 7, QTableWidgetItem(str(e.get("volumen", ""))))
                self.tabla.setItem(fila, 8, QTableWidgetItem(str(e.get("tipoEscultura", ""))))
                self.tabla.setItem(fila, 9, QTableWidgetItem(str(e.get("precio", ""))))
        except Exception as e:
            print("❌ Error al listar esculturas:", e)
            self._mensaje("Error al conectarse con el servidor.", "warning")

    def _mensaje(self, texto, tipo="info"):
        msg = QMessageBox(self)
        msg.setWindowTitle("Galería de Arte")
        msg.setText(texto)
        msg.setIcon(QMessageBox.Warning if tipo == "warning" else QMessageBox.Information)
        msg.exec_()
