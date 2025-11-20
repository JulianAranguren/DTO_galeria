from PyQt5.QtWidgets import (
    QMainWindow, QLabel, QLineEdit, QPushButton, QMessageBox, QComboBox
)
from core.styles import Estilos
from core.fuentes import fuente_texto, fuente_botones
from core.ubicaciones import Posicion
from core.api_manager import APIManager


class VentanaEliminarEscultura(QMainWindow):
    def __init__(self):
        super().__init__()
        self.setWindowTitle("Eliminar Escultura")
        self.setFixedSize(1060, 720)
        Estilos.aplicar_estilo_general(self)

        # --- Título ---
        self.label_titulo = QLabel("Eliminar Escultura", self)
        self.label_titulo.setFont(fuente_texto)
        Estilos.aplicar_estilo_titulo(self.label_titulo)
        Posicion.centrar_texto_arriba(self, self.label_titulo)

        # --- Campo ID ---
        self._crear_campo("ID:", 150)
        self.txt_id = self._crear_input(250, 150)
        self.txt_id.setEnabled(True)

        # --- Botón Buscar ---
        self.boton_buscar = QPushButton("Buscar", self)
        self.boton_buscar.setFont(fuente_botones)
        self.boton_buscar.move(600, 150)
        self.boton_buscar.resize(120, 35)
        self._estilo_boton(self.boton_buscar)
        self.boton_buscar.clicked.connect(self.buscar_escultura)

        # --- Campos de visualización ---
        self._crear_campo("Título:", 250)
        self.txt_titulo = self._crear_input(250, 250)

        self._crear_campo("Autor:", 300)
        self.txt_autor = self._crear_input(250, 300)

        self._crear_campo("Materia:", 350)
        self.txt_materia = self._crear_input(250, 350)

        self._crear_campo("Tipo:", 400)
        self.txt_tipo = self._crear_input(250, 400)

        self._crear_campo("Precio:", 450)
        self.txt_precio = self._crear_input(250, 450)

        self._crear_campo("Estado:", 500)
        self.combo_estado = QComboBox(self)
        self.combo_estado.addItems(["Activo", "Inactivo"])
        self.combo_estado.move(250, 500)
        self.combo_estado.resize(200, 30)
        self.combo_estado.setEnabled(False)

        # Desactiva edición de los demás campos
        for campo in [self.txt_titulo, self.txt_autor, self.txt_materia, self.txt_tipo, self.txt_precio]:
            campo.setEnabled(False)

        # --- Botón Eliminar ---
        self.boton_eliminar = QPushButton("Eliminar Escultura", self)
        self.boton_eliminar.setFont(fuente_botones)
        self.boton_eliminar.move(380, 580)
        self.boton_eliminar.resize(300, 40)
        self._estilo_boton(self.boton_eliminar)
        self.boton_eliminar.clicked.connect(self.eliminar_escultura)

    # --- Auxiliares de UI ---
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

    # --- Buscar escultura ---
    def buscar_escultura(self):
        id_buscar = self.txt_id.text().strip()
        if not id_buscar:
            self._mensaje("Debe ingresar un ID para buscar.", "warning")
            return

        escultura = APIManager.obtener_escultura(id_buscar)
        if not escultura:
            self._mensaje("No se encontró ninguna escultura con ese ID.", "warning")
            return

        # Rellenar campos
        self.txt_titulo.setText(str(escultura.get("titulo", "")))
        self.txt_autor.setText(str(escultura.get("autor", "")))
        self.txt_materia.setText(str(escultura.get("material", "")))
        self.txt_tipo.setText(str(escultura.get("tipoEscultura", "")))
        self.txt_precio.setText(str(escultura.get("precio", "")))
        estado = escultura.get("estado", "Activo")
        idx = self.combo_estado.findText(estado)
        self.combo_estado.setCurrentIndex(idx if idx != -1 else 0)

    # --- Eliminar escultura ---
    def eliminar_escultura(self):
        id_eliminar = self.txt_id.text().strip()
        if not id_eliminar:
            self._mensaje("Debe ingresar un ID antes de eliminar.", "warning")
            return

        confirm = QMessageBox.question(
            self,
            "Confirmar eliminación",
            f"¿Está seguro de eliminar la escultura con ID {id_eliminar}?",
            QMessageBox.Yes | QMessageBox.No,
            QMessageBox.No
        )

        if confirm == QMessageBox.No:
            return

        ok = APIManager.eliminar_escultura(id_eliminar)
        if ok:
            self._mensaje("Escultura eliminada correctamente.", "info")
            self.combo_estado.setCurrentText("Inactivo")
        else:
            self._mensaje("Error al eliminar la escultura.", "warning")
