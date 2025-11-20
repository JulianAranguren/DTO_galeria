from PyQt5.QtWidgets import (
    QMainWindow, QLabel, QLineEdit, QComboBox, QDateEdit, QPushButton, QMessageBox
)
from PyQt5.QtCore import QDate
from core.styles import Estilos
from core.fuentes import fuente_texto, fuente_botones
from core.ubicaciones import Posicion
from core.api_manager_art import APIManagerArtista


class VentanaAgregarArtista(QMainWindow):
    def __init__(self):
        super().__init__()
        self.setWindowTitle("Agregar Artista")
        self.setFixedSize(1060, 720)
        Estilos.aplicar_estilo_general(self)

        # --- Título ---
        self.label_titulo = QLabel("Registrar Nuevo Artista", self)
        self.label_titulo.setFont(fuente_texto)
        Estilos.aplicar_estilo_titulo(self.label_titulo)
        Posicion.centrar_texto_arriba(self, self.label_titulo)

        # === CAMPOS ===
        self._crear_campo("Nombre:", 150)
        self.txt_nombre = self._crear_input(300, 150)

        self._crear_campo("Nacionalidad:", 200)
        self.txt_nacionalidad = self._crear_input(300, 200)

        self._crear_campo("Fecha Nacimiento:", 250)
        self.fecha_nacimiento = QDateEdit(self)
        self.fecha_nacimiento.setCalendarPopup(True)
        self.fecha_nacimiento.setDate(QDate.currentDate())
        self.fecha_nacimiento.move(300, 250)
        self.fecha_nacimiento.resize(200, 30)

        self._crear_campo("Estilo Principal:", 300)
        self.txt_estilo = self._crear_input(300, 300)

        self._crear_campo("Años de Experiencia:", 350)
        self.txt_experiencia = self._crear_input(300, 350)

        self._crear_campo("Estado:", 400)
        self.combo_estado = QComboBox(self)
        self.combo_estado.addItems(["Activo", "Inactivo"])
        self.combo_estado.move(300, 400)
        self.combo_estado.resize(200, 30)

        self._crear_campo("Email:", 450)
        self.txt_email = self._crear_input(300, 450)

        self._crear_campo("Fecha Registro:", 500)
        self.fecha_registro = QDateEdit(self)
        self.fecha_registro.setCalendarPopup(True)
        self.fecha_registro.setDate(QDate.currentDate())
        self.fecha_registro.move(300, 500)
        self.fecha_registro.resize(200, 30)

        # --- Botón Registrar ---
        self.boton_agregar = QPushButton("Agregar Artista", self)
        self.boton_agregar.setFont(fuente_botones)
        self.boton_agregar.move(750, 580)
        self.boton_agregar.resize(280, 45)
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

    # --- Helpers para UI ---
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

    # === Enviar datos al backend ===
    def enviar_datos(self):
        try:
            # Validaciones numéricas
            try:
                experiencia = float(self.txt_experiencia.text().strip())
            except ValueError:
                self._mensaje("Ingrese un valor numérico válido para años de experiencia.", "warning")
                return

            datos = {
                "nombre": self.txt_nombre.text().strip(),
                "nacionalidad": self.txt_nacionalidad.text().strip(),
                "fechaNacimiento": self.fecha_nacimiento.date().toString("yyyy-MM-dd") + "T00:00:00",
                "estiloPrincipal": self.txt_estilo.text().strip(),
                "añosExperiencia": experiencia,
                "activo": True if self.combo_estado.currentText() == "Activo" else False,
                "email": self.txt_email.text().strip(),
                "fechaRegistro": self.fecha_registro.date().toString("yyyy-MM-dd") + "T00:00:00"
            }

            # Validación de campos obligatorios
            if not datos["nombre"] or not datos["nacionalidad"] or not datos["email"]:
                self._mensaje("Los campos Nombre, Nacionalidad y Email son obligatorios.", "warning")
                return

            ok = APIManagerArtista.crear_artista(datos)

            if ok:
                self._mensaje("Artista registrado correctamente.", "success")
                self.limpiar_campos()
            else:
                self._mensaje("Error al registrar el artista.", "warning")

        except Exception as e:
            self._mensaje(f"Error inesperado: {e}", "warning")

    # --- Limpiar campos ---
    def limpiar_campos(self):
        self.txt_nombre.clear()
        self.txt_nacionalidad.clear()
        self.txt_estilo.clear()
        self.txt_email.clear()
        self.txt_experiencia.clear()
        self.combo_estado.setCurrentIndex(0)
        self.fecha_nacimiento.setDate(QDate.currentDate())
        self.fecha_registro.setDate(QDate.currentDate())

    # --- Mensajes ---
    def _mensaje(self, texto, tipo="information"):
        msg = QMessageBox(self)
        msg.setWindowTitle("Galería de Arte")
        msg.setText(texto)

        if tipo == "warning":
            msg.setIcon(QMessageBox.Warning)
        else:
            msg.setIcon(QMessageBox.Information)

        msg.exec_()
