from PyQt5.QtWidgets import (
    QMainWindow, QLabel, QLineEdit, QPushButton, QMessageBox, QComboBox, QDateEdit
)
from core.styles import Estilos
from core.fuentes import fuente_texto, fuente_botones
from core.ubicaciones import Posicion
from core.api_manager_art import APIManagerArtista
from PyQt5.QtCore import QDate


class VentanaEliminarArtista(QMainWindow):
    def __init__(self):
        super().__init__()
        self.setWindowTitle("Eliminar Artista")
        self.setFixedSize(1060, 720)
        Estilos.aplicar_estilo_general(self)

        # --- Título ---
        self.label_titulo = QLabel("Eliminar Artista", self)
        self.label_titulo.setFont(fuente_texto)
        Estilos.aplicar_estilo_titulo(self.label_titulo)
        Posicion.centrar_texto_arriba(self, self.label_titulo)

        # --- Campo ID ---
        self._crear_campo("ID:", 150)
        self.txt_id = self._crear_input(250, 150)

        # --- Botón Buscar ---
        self.boton_buscar = QPushButton("Buscar", self)
        self.boton_buscar.setFont(fuente_botones)
        self.boton_buscar.move(600, 150)
        self.boton_buscar.resize(130, 35)
        self._estilo_boton(self.boton_buscar)
        self.boton_buscar.clicked.connect(self.buscar_artista)

        # === CAMPOS DEL ARTISTA ===
        self._crear_campo("Nombre:", 250)
        self.txt_nombre = self._crear_input(250, 250)

        self._crear_campo("Nacionalidad:", 300)
        self.txt_nacionalidad = self._crear_input(250, 300)

        self._crear_campo("Estilo Principal:", 350)
        self.txt_estilo = self._crear_input(250, 350)

        self._crear_campo("Años Experiencia:", 400)
        self.txt_experiencia = self._crear_input(250, 400)

        self._crear_campo("Email:", 450)
        self.txt_email = self._crear_input(250, 450)

        self._crear_campo("Estado:", 500)
        self.combo_estado = QComboBox(self)
        self.combo_estado.addItems(["Activo", "Inactivo"])
        self.combo_estado.move(250, 500)
        self.combo_estado.resize(200, 30)
        self.combo_estado.setEnabled(False)

        self._crear_campo("Fecha Registro:", 550)
        self.fecha_registro = QDateEdit(self)
        self.fecha_registro.setCalendarPopup(True)
        self.fecha_registro.move(250, 550)
        self.fecha_registro.resize(200, 30)
        self.fecha_registro.setEnabled(False)

        # Desactivar edición
        for campo in [
            self.txt_nombre, self.txt_nacionalidad, self.txt_estilo,
            self.txt_experiencia, self.txt_email
        ]:
            campo.setEnabled(False)

        # --- Botón Eliminar ---
        self.boton_eliminar = QPushButton("Eliminar Artista", self)
        self.boton_eliminar.setFont(fuente_botones)
        self.boton_eliminar.move(380, 620)
        self.boton_eliminar.resize(300, 45)
        self._estilo_boton(self.boton_eliminar)
        self.boton_eliminar.clicked.connect(self.eliminar_artista)

    # --- AUXILIARES ---
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

    # --- Buscar Artista ---
    def buscar_artista(self):
        id_buscar = self.txt_id.text().strip()
        if not id_buscar:
            self._mensaje("Debe ingresar un ID para buscar.", "warning")
            return

        artista = APIManagerArtista.obtener_artista(id_buscar)
        if not artista:
            self._mensaje("No se encontró ningún artista con ese ID.", "warning")
            return

        # Rellenar campos
        self.txt_nombre.setText(str(artista.get("nombre", "")))
        self.txt_nacionalidad.setText(str(artista.get("nacionalidad", "")))
        self.txt_estilo.setText(str(artista.get("estiloPrincipal", "")))
        self.txt_experiencia.setText(str(artista.get("añosExperiencia", "")))
        self.txt_email.setText(str(artista.get("email", "")))

        estado = "Activo" if artista.get("activo", True) else "Inactivo"
        idx = self.combo_estado.findText(estado)
        self.combo_estado.setCurrentIndex(idx)

        try:
            fechaReg = artista.get("fechaRegistro", "")[:10]
            self.fecha_registro.setDate(QDate.fromString(fechaReg, "yyyy-MM-dd"))
        except:
            pass

    # --- Eliminar Artista ---
    def eliminar_artista(self):
        id_eliminar = self.txt_id.text().strip()
        if not id_eliminar:
            self._mensaje("Debe ingresar un ID antes de eliminar.", "warning")
            return

        confirm = QMessageBox.question(
            self,
            "Confirmar eliminación",
            f"¿Está seguro de eliminar el artista con ID {id_eliminar}?",
            QMessageBox.Yes | QMessageBox.No,
            QMessageBox.No
        )

        if confirm == QMessageBox.No:
            return

        ok = APIManagerArtista.eliminar_artista(id_eliminar)

        if ok:
            self._mensaje("Artista eliminado correctamente.")
            self.combo_estado.setCurrentText("Inactivo")
        else:
            self._mensaje("Error al eliminar el artista.", "warning")
