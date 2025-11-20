from PyQt5.QtWidgets import (
    QMainWindow, QLabel, QLineEdit, QComboBox, QDateEdit, QPushButton, QMessageBox
)
from PyQt5.QtCore import QDate
from core.styles import Estilos
from core.fuentes import fuente_texto, fuente_botones
from core.ubicaciones import Posicion
from core.api_manager_art import APIManagerArtista


class VentanaBuscarArtista(QMainWindow):
    def __init__(self):
        super().__init__()
        self.setWindowTitle("Buscar Artista")
        self.setFixedSize(1060, 720)
        Estilos.aplicar_estilo_general(self)

        # --- Título ---
        self.label_titulo = QLabel("Buscar Artista", self)
        self.label_titulo.setFont(fuente_texto)
        Estilos.aplicar_estilo_titulo(self.label_titulo)
        Posicion.centrar_texto_arriba(self, self.label_titulo)

        # --- Campo ID ---
        self._crear_campo("ID:", 150)
        self.txt_id = self._crear_input(250, 150, ancho=300)

        # --- Botón Buscar ---
        self.boton_buscar = QPushButton("Buscar", self)
        self.boton_buscar.setFont(fuente_botones)
        self.boton_buscar.move(600, 150)
        self.boton_buscar.resize(120, 30)
        self._estilo_boton(self.boton_buscar)
        self.boton_buscar.clicked.connect(self.buscar_artista)

        # --- Botón Actualizar ---
        self.boton_actualizar = QPushButton("Actualizar", self)
        self.boton_actualizar.setFont(fuente_botones)
        self.boton_actualizar.move(600, 190)
        self.boton_actualizar.resize(120, 30)
        self._estilo_boton(self.boton_actualizar)
        self.boton_actualizar.clicked.connect(self.actualizar_artista)

        # === CAMPOS DEL ARTISTA ===
        self._crear_campo("Nombre:", 250)
        self.txt_nombre = self._crear_input(250, 250)

        self._crear_campo("Nacionalidad:", 300)
        self.txt_nacionalidad = self._crear_input(250, 300)

        self._crear_campo("Fecha Nacimiento:", 350)
        self.fecha_nacimiento = QDateEdit(self)
        self.fecha_nacimiento.setCalendarPopup(True)
        self.fecha_nacimiento.move(250, 350)
        self.fecha_nacimiento.resize(200, 30)

        self._crear_campo("Estilo Principal:", 400)
        self.txt_estilo = self._crear_input(250, 400)

        self._crear_campo("Años Experiencia:", 450)
        self.txt_experiencia = self._crear_input(250, 450)

        self._crear_campo("Email:", 500)
        self.txt_email = self._crear_input(250, 500)

        self._crear_campo("Estado:", 550)
        self.combo_estado = QComboBox(self)
        self.combo_estado.addItems(["Activo", "Inactivo"])
        self.combo_estado.move(250, 550)
        self.combo_estado.resize(200, 30)

        self._crear_campo("Fecha Registro:", 600)
        self.fecha_registro = QDateEdit(self)
        self.fecha_registro.setCalendarPopup(True)
        self.fecha_registro.move(250, 600)
        self.fecha_registro.resize(200, 30)

        self._bloquear_campos()

    # --- Helpers UI ---
    def _crear_campo(self, texto, y):
        label = QLabel(texto, self)
        label.setFont(fuente_texto)
        label.move(100, y)
        label.adjustSize()
        Estilos.aplicar_estilo_txt(label)

    def _crear_input(self, x, y, ancho=300):
        campo = QLineEdit(self)
        campo.move(x, y)
        campo.resize(ancho, 30)
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

    def _bloquear_campos(self):
        for campo in [
            self.txt_nombre, self.txt_nacionalidad, self.txt_estilo,
            self.txt_experiencia, self.txt_email
        ]:
            campo.setEnabled(False)

        self.combo_estado.setEnabled(False)
        self.fecha_nacimiento.setEnabled(False)
        self.fecha_registro.setEnabled(False)

    def _habilitar_campos(self):
        for campo in [
            self.txt_nombre, self.txt_nacionalidad, self.txt_estilo,
            self.txt_experiencia, self.txt_email
        ]:
            campo.setEnabled(True)

        self.combo_estado.setEnabled(True)
        self.fecha_nacimiento.setEnabled(True)
        self.fecha_registro.setEnabled(True)

    # --- Lógica: Buscar Artista ---
    def buscar_artista(self):
        id_artista = self.txt_id.text().strip()

        if not id_artista:
            self._mensaje("Debe ingresar un ID.", "warning")
            return

        artista = APIManagerArtista.obtener_artista(id_artista)
        if not artista:
            self._mensaje("No se encontró un artista con ese ID.", "warning")
            return

        # Rellenar campos
        self.txt_nombre.setText(artista.get("nombre", ""))
        self.txt_nacionalidad.setText(artista.get("nacionalidad", ""))
        self.txt_estilo.setText(artista.get("estiloPrincipal", ""))
        self.txt_email.setText(artista.get("email", ""))

        self.txt_experiencia.setText(str(artista.get("añosExperiencia", "")))

        # estado
        estado = "Activo" if artista.get("activo", True) else "Inactivo"
        idx = self.combo_estado.findText(estado)
        self.combo_estado.setCurrentIndex(idx)

        # fechas
        try:
            fechaN = artista.get("fechaNacimiento", "")[:10]
            self.fecha_nacimiento.setDate(QDate.fromString(fechaN, "yyyy-MM-dd"))
        except:
            pass

        try:
            fechaR = artista.get("fechaRegistro", "")[:10]
            self.fecha_registro.setDate(QDate.fromString(fechaR, "yyyy-MM-dd"))
        except:
            pass

        # Habilitar para editar
        self._habilitar_campos()

    # --- Lógica: Actualizar Artista ---
    def actualizar_artista(self):
        id_artista = self.txt_id.text().strip()

        if not id_artista:
            self._mensaje("Debe buscar un artista antes de actualizar.", "warning")
            return

        try:
            experiencia = float(self.txt_experiencia.text().strip())
        except:
            self._mensaje("Años de experiencia debe ser numérico.", "warning")
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

        ok = APIManagerArtista.actualizar_artista(id_artista, datos)

        if ok:
            self._mensaje("Artista actualizado correctamente.")
        else:
            self._mensaje("No se pudo actualizar el artista.", "warning")
