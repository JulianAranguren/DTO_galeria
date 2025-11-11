from PyQt5.QtWidgets import (
    QMainWindow, QLabel, QLineEdit, QComboBox, QPushButton, QMessageBox, QDateEdit
)
from PyQt5.QtCore import QDate
from core.styles import Estilos
        # fuente_texto, fuente_botones y Posicion como ya los tienes
from core.fuentes import fuente_texto, fuente_botones
from core.ubicaciones import Posicion
from core.api_manager import APIManager

class VentanaAgregarPintura(QMainWindow):
    def __init__(self):
        super().__init__()
        self.setWindowTitle("Agregar Pintura")
        self.setFixedSize(1060, 720)
        Estilos.aplicar_estilo_general(self)

        # --- Título ---
        self.label_titulo = QLabel("Agregar Nueva Pintura", self)
        self.label_titulo.setFont(fuente_texto)
        Estilos.aplicar_estilo_titulo(self.label_titulo)
        Posicion.centrar_texto_arriba(self, self.label_titulo)

        # --- Campos básicos ---
        self._crear_campo("ID:", 130)
        self.txt_id = self._crear_input(250, 130)

        self._crear_campo("Título:", 180)
        self.txt_titulo = self._crear_input(250, 180)

        self._crear_campo("Autor:", 230)
        self.txt_autor = self._crear_input(250, 230)

        
        self._crear_campo("Fecha Ingreso:", 280)
        self.fecha_ingreso = QDateEdit(self)
        self.fecha_ingreso.setDate(QDate.currentDate())
        self.fecha_ingreso.setCalendarPopup(True)
        self.fecha_ingreso.move(250, 280)
        self.fecha_ingreso.resize(200, 30)

        self._crear_campo("Precio:", 330)
        self.txt_precio = self._crear_input(250, 330)

        self._crear_campo("Estado:", 380)
        self.combo_estado = QComboBox(self)
        self.combo_estado.addItems(["Activo", "Inactivo"])
        self.combo_estado.move(250, 380)
        self.combo_estado.resize(200, 30)

        # --- Especiales ---
        self._crear_campo("Técnica:", 430)
        self.txt_tecnica = self._crear_input(250, 430)

        self._crear_campo("Textura", 480)
        self.txt_textura = self._crear_input(250, 480)

        

        # --- Botón agregar ---
        self.boton_agregar = QPushButton("Agregar Pintura", self)
        self.boton_agregar.setFont(fuente_botones)
        self.boton_agregar.move(400, 580)
        self.boton_agregar.resize(250, 40)
        self._estilo_boton(self.boton_agregar)
        self.boton_agregar.clicked.connect(self.enviar_datos)

    # --- Auxiliares UI ---
    def _crear_campo(self, texto, y):
        label = QLabel(texto, self)
        label.setFont(fuente_texto)
        label.move(100, y)
        label.adjustSize()
        Estilos.aplicar_estilo_txt(label)

    def _crear_input(self, x, y):
        campo = QLineEdit(self)
        campo.move(x, y)
        campo.resize(300, 30)
        return campo

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

    def _mensaje(self, texto, tipo="info"):
        msg = QMessageBox(self)
        msg.setWindowTitle("Galería de Arte")
        msg.setText(texto)
        msg.setIcon(QMessageBox.Warning if tipo == "warning" else QMessageBox.Information)
        msg.exec_()

    # --- Lógica principal ---
    def enviar_datos(self):
        try:
            datos = {
                "id": int(self.txt_id.text().strip()),
                "titulo": self.txt_titulo.text().strip(),
                "autor": self.txt_autor.text().strip(),
                "fechaIngreso": self.fecha_ingreso.date().toString("yyyy-MM-dd") + "T00:00:00",  
                "precio": float(self.txt_precio.text().strip()),
                "estado": self.combo_estado.currentText(),
                "tecnica": self.txt_tecnica.text().strip(),
                "textura": self.txt_textura.text().strip()
            }

            # Validación mínima
            if not all([datos["id"], datos["titulo"], datos["autor"]]):
                self._mensaje("Debe llenar ID, Título y Autor.", "warning")
                return

            ok = APIManager.crear_pintura(datos)
            if ok:
                self._mensaje("Pintura creada correctamente.", "info")
                self.limpiar_campos()
            else:
                self._mensaje("Error al crear la pintura.", "warning")

        except ValueError:
            self._mensaje("Verifique que ID y Precio sean valores numéricos.", "warning")

    def limpiar_campos(self):
        self.txt_id.clear()
        self.txt_titulo.clear()
        self.txt_autor.clear()
        self.txt_precio.clear()
        self.txt_tecnica.clear()
        self.txt_textura.clear()
        self.combo_estado.setCurrentIndex(0)
        self.fecha_ingreso.setDate(QDate.currentDate())