from PyQt5.QtWidgets import (
    QMainWindow, QLabel, QLineEdit, QComboBox, QDateEdit, QPushButton, QMessageBox
)
from PyQt5.QtCore import QDate
from core.styles import Estilos
from core.fuentes import fuente_texto, fuente_botones
from core.ubicaciones import Posicion
from core.api_manager import APIManager  


class VentanaAgregarEscultura(QMainWindow):
    def __init__(self):
        super().__init__()
        self.setWindowTitle("Agregar Escultura")
        self.setFixedSize(1060, 720)
        Estilos.aplicar_estilo_general(self)

        # --- Título ---
        self.label_titulo = QLabel("Agregar Nueva Escultura", self)
        self.label_titulo.setFont(fuente_texto)
        Estilos.aplicar_estilo_titulo(self.label_titulo)
        Posicion.centrar_texto_arriba(self, self.label_titulo)

        # --- Campos ---
        self._crear_campo("ID:", 150)
        self.txt_id = self._crear_input(250, 150)

        self._crear_campo("Título:", 200)
        self.txt_titulo = self._crear_input(250, 200)

        self._crear_campo("Autor:", 250)
        self.txt_autor = self._crear_input(250, 250)

        self._crear_campo("Precio:", 300)
        self.txt_precio = self._crear_input(250, 300)

        self._crear_campo("Estado:", 350)
        self.combo_estado = QComboBox(self)
        self.combo_estado.addItems(["Activo", "Inactivo"])
        self.combo_estado.move(250, 350)
        self.combo_estado.resize(200, 30)

        self._crear_campo("Fecha Ingreso:", 400)
        self.fecha_ingreso = QDateEdit(self)
        self.fecha_ingreso.setDate(QDate.currentDate())
        self.fecha_ingreso.setCalendarPopup(True)
        self.fecha_ingreso.move(250, 400)
        self.fecha_ingreso.resize(200, 30)

        self._crear_campo("Altura:", 450)
        self.txt_altura = self._crear_input(250, 450)

        self._crear_campo("Volumen:", 500)
        self.txt_volumen = self._crear_input(250, 500)

        self._crear_campo("Tipo Escultura:", 550)
        self.combo_tipo = QComboBox(self)
        self.combo_tipo.addItems(["Busto", "Estatua", "Relieve", "Figurativa", "Abstracta","Monumento"])
        self.combo_tipo.move(250, 550)
        self.combo_tipo.resize(200, 30)

        self._crear_campo("Material:", 600)
        self.combo_material = QComboBox(self)
        self.combo_material.addItems(["Marmol", "Bronce", "Madera", "Arcilla", "Resina","Hierro","Pierda"])
        self.combo_material.move(250, 600)
        self.combo_material.resize(200, 30)

        # --- Botón Agregar ---
        self.boton_agregar = QPushButton("Agregar Escultura", self)
        self.boton_agregar.setFont(fuente_botones)
        self.boton_agregar.move(800, 580)
        self.boton_agregar.resize(250, 40)
        self.boton_agregar.setStyleSheet("""
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
        self.boton_agregar.clicked.connect(self.enviar_datos)

    # --- Métodos auxiliares ---
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

    def enviar_datos(self):
        try:
            datos = {
                "id": int(self.txt_id.text().strip()),
                "titulo": self.txt_titulo.text().strip(),
                "autor": self.txt_autor.text().strip(),
                "precio": float(self.txt_precio.text().strip()),
                "estado": self.combo_estado.currentText(),
                "fechaIngreso": self.fecha_ingreso.date().toString("yyyy-MM-dd") + "T00:00:00",
                "altura": self.txt_altura.text().strip(),
                "volumen": self.txt_volumen.text().strip(),
                "material": self.combo_material.currentText(),
                "tipo": self.combo_tipo.currentText(),
            }

            if not all([datos["id"], datos["titulo"], datos["autor"], datos["precio"]]):
                self._mensaje("Todos los campos obligatorios deben estar llenos.", "warning")
                return

            ok = APIManager.crear_escultura(datos)
            if ok:
                self._mensaje("Escultura creada correctamente.", "success")
                self.limpiar_campos()
            else:
                self._mensaje("Error al crear la escultura.", "warning")

        except ValueError:
            self._mensaje("Por favor, ingrese valores numéricos válidos para el ID y el Precio.", "warning")

    def limpiar_campos(self):
        """Limpia todos los campos después de crear."""
        self.txt_id.clear()
        self.txt_titulo.clear()
        self.txt_autor.clear()
        self.txt_precio.clear()
        self.txt_altura.clear()
        self.txt_volumen.clear()
        self.combo_estado.setCurrentIndex(0)
        self.combo_tipo.setCurrentIndex(0)
        self.combo_material.setCurrentIndex(0)
        self.fecha_ingreso.setDate(QDate.currentDate())

    def _mensaje(self, texto, tipo="information"):
        """Muestra un mensaje modal."""
        msg = QMessageBox(self)
        msg.setWindowTitle("Galería de Arte")
        msg.setText(texto)
        if tipo == "warning":
            msg.setIcon(QMessageBox.Warning)
        else:
            msg.setIcon(QMessageBox.Information)
        msg.exec_()
