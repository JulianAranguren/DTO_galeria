from PyQt5.QtWidgets import (
    QMainWindow, QLabel, QLineEdit, QComboBox, QPushButton, QMessageBox, QDateEdit
)
from PyQt5.QtCore import QDate
from core.styles import Estilos
from core.fuentes import fuente_texto, fuente_botones
from core.ubicaciones import Posicion
from core.api_manager import APIManager


class VentanaEliminarPintura(QMainWindow):
    def __init__(self):
        super().__init__()
        self.setWindowTitle("Eliminar Pintura")
        self.setFixedSize(1060, 720)
        Estilos.aplicar_estilo_general(self)

        # --- Título ---
        self.label_titulo = QLabel("Eliminar Pintura", self)
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
        self.boton_buscar.resize(120, 35)
        self._estilo_boton(self.boton_buscar)
        self.boton_buscar.clicked.connect(self.buscar_pintura)

        # --- Campos de datos (solo lectura) ---
        self._crear_campo("Título:", 250)
        self.txt_titulo = self._crear_input(250, 250)

        self._crear_campo("Autor:", 300)
        self.txt_autor = self._crear_input(250, 300)

        self._crear_campo("Fecha de creación:", 350)
        self.dp_fecha = QDateEdit(self)
        self.dp_fecha.setCalendarPopup(True)
        self.dp_fecha.move(250, 350)
        self.dp_fecha.resize(200, 30)
        self.dp_fecha.setEnabled(False)

        self._crear_campo("Técnica:", 400)
        self.txt_tecnica = self._crear_input(250, 400)

        self._crear_campo("Precio:", 450)
        self.txt_precio = self._crear_input(250, 450)

        self._crear_campo("Estado:", 500)
        self.combo_estado = QComboBox(self)
        self.combo_estado.addItems(["Activo", "Inactivo"])
        self.combo_estado.move(250, 500)
        self.combo_estado.resize(200, 30)
        self.combo_estado.setEnabled(False)

        self._bloquear_campos()

        # --- Botón Eliminar ---
        self.boton_eliminar = QPushButton("Eliminar Pintura", self)
        self.boton_eliminar.setFont(fuente_botones)
        self.boton_eliminar.move(400, 580)
        self.boton_eliminar.resize(250, 40)
        self._estilo_boton(self.boton_eliminar)
        self.boton_eliminar.clicked.connect(self.eliminar_pintura)
        self.boton_eliminar.setEnabled(False)

    # --- Estilo y auxiliares UI ---
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

    def _bloquear_campos(self):
        """Desactiva edición en los campos."""
        for campo in [self.txt_titulo, self.txt_autor, self.txt_tecnica, self.txt_precio]:
            campo.setEnabled(False)

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

    # --- Buscar pintura ---
    def buscar_pintura(self):
        id_buscar = self.txt_id.text().strip()
        if not id_buscar:
            self._mensaje("Debe ingresar un ID.", "warning")
            return

        pintura = APIManager.obtener_pintura(id_buscar)
        if not pintura:
            self._mensaje("No se encontró ninguna pintura con ese ID.", "warning")
            return

        # Cargar datos
        self.txt_titulo.setText(str(pintura.get("titulo", "")))
        self.txt_autor.setText(str(pintura.get("autor", "")))
        self.txt_tecnica.setText(str(pintura.get("tecnica", "")))
        self.txt_precio.setText(str(pintura.get("precio", "")))

        fecha_iso = pintura.get("anioCreacion") or pintura.get("fechaIngreso")
        if fecha_iso:
            fecha = QDate.fromString(fecha_iso.split("T")[0], "yyyy-MM-dd")
            self.dp_fecha.setDate(fecha)

        estado = pintura.get("estado", "Activo")
        idx = self.combo_estado.findText(estado)
        if idx != -1:
            self.combo_estado.setCurrentIndex(idx)

        self.boton_eliminar.setEnabled(True)

    # --- Eliminar pintura ---
    def eliminar_pintura(self):
        id_pintura = self.txt_id.text().strip()
        if not id_pintura:
            self._mensaje("Debe buscar una pintura primero.", "warning")
            return

        respuesta = QMessageBox.question(
            self,
            "Confirmar eliminación",
            "¿Desea eliminar esta pintura?",
            QMessageBox.Yes | QMessageBox.No
        )

        if respuesta == QMessageBox.No:
            return

        exito = APIManager.eliminar_pintura(id_pintura)
        if exito:
            self._mensaje("Pintura eliminada correctamente.", "info")
            self.limpiar_campos()
        else:
            self._mensaje("Error al eliminar la pintura.", "warning")

    def limpiar_campos(self):
        self.txt_id.clear()
        self.txt_titulo.clear()
        self.txt_autor.clear()
        self.txt_tecnica.clear()
        self.txt_precio.clear()
        self.combo_estado.setCurrentIndex(0)
        self.boton_eliminar.setEnabled(False)
