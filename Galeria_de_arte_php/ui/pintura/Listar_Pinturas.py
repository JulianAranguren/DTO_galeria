from PyQt5.QtWidgets import (
    QMainWindow, QLabel, QPushButton, QTableWidget, QTableWidgetItem, QMessageBox
)
from core.styles import Estilos
from core.fuentes import fuente_texto, fuente_botones
from core.ubicaciones import Posicion
from core.api_manager import APIManager


class VentanaListarPinturas(QMainWindow):
    def __init__(self):
        super().__init__()
        self.setWindowTitle("Listar Pinturas")
        self.setFixedSize(1060, 720)
        Estilos.aplicar_estilo_general(self)

        # --- Título ---
        self.label_titulo = QLabel("Listado de Pinturas Activas", self)
        self.label_titulo.setFont(fuente_texto)
        Estilos.aplicar_estilo_titulo(self.label_titulo)
        Posicion.centrar_texto_arriba(self, self.label_titulo)

        # --- Botón Listar ---
        self.boton_listar = QPushButton("Listar Pinturas", self)
        self.boton_listar.setFont(fuente_botones)
        self.boton_listar.move(800, 100)
        self.boton_listar.resize(220, 40)
        self._estilo_boton(self.boton_listar)
        self.boton_listar.clicked.connect(self.listar_pinturas)

        # --- Tabla ---
        self.tabla = QTableWidget(self)
        self.tabla.setColumnCount(7)
        self.tabla.setHorizontalHeaderLabels([
            "ID", "Título", "Autor", "Fecha Ingreso", "Técnica",
            "Precio", "Textura"
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

    # --- Mensajes ---
    def _mensaje(self, texto, tipo="info"):
        msg = QMessageBox(self)
        msg.setWindowTitle("Galería de Arte")
        msg.setText(texto)
        msg.setIcon(QMessageBox.Warning if tipo == "warning" else QMessageBox.Information)
        msg.exec_()

    # --- Lógica principal ---
    def listar_pinturas(self):
        """Obtiene las pinturas activas desde el backend."""
        try:
            pinturas = APIManager.listar_pinturas()
            if not pinturas:
                self._mensaje("No hay pinturas activas registradas.", "info")
                self.tabla.setRowCount(0)
                return

            self.tabla.setRowCount(len(pinturas))
            for fila, p in enumerate(pinturas):
                self.tabla.setItem(fila, 0, QTableWidgetItem(str(p.get("id", ""))))
                self.tabla.setItem(fila, 1, QTableWidgetItem(str(p.get("titulo", ""))))
                self.tabla.setItem(fila, 2, QTableWidgetItem(str(p.get("autor", ""))))

                fecha = p.get("fechaIngreso") 
                if fecha and "T" in fecha:
                    fecha = fecha.split("T")[0]
                self.tabla.setItem(fila, 3, QTableWidgetItem(str(fecha)))


                self.tabla.setItem(fila, 4, QTableWidgetItem(str(p.get("tecnica", ""))))
                self.tabla.setItem(fila, 5, QTableWidgetItem(str(p.get("precio", ""))))
                self.tabla.setItem(fila, 6, QTableWidgetItem(str(p.get("textura", ""))))


        except Exception as e:
            print("❌ Error al listar pinturas:", e)
            self._mensaje("Error al conectarse con el servidor.", "warning")
