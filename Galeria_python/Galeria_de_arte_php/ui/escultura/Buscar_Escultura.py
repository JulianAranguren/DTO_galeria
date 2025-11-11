from PyQt5.QtWidgets import (
    QMainWindow, QLabel, QLineEdit, QComboBox, QPushButton, QMessageBox
)
from PyQt5.QtCore import QDate
from core.styles import Estilos
from core.fuentes import fuente_texto, fuente_botones
from core.ubicaciones import Posicion
from core.api_manager import APIManager


class VentanaBuscarEscultura(QMainWindow):
    def __init__(self):
        super().__init__()
        self.setWindowTitle("Buscar Escultura")
        self.setFixedSize(1060, 720)
        Estilos.aplicar_estilo_general(self)

        # --- Título ---
        self.label_titulo = QLabel("Buscar Escultura", self)
        self.label_titulo.setFont(fuente_texto)
        Estilos.aplicar_estilo_titulo(self.label_titulo)
        Posicion.centrar_texto_arriba(self, self.label_titulo)

        # --- Campo de ID ---
        self._crear_campo("ID:", 150)
        self.txt_id = self._crear_input(250, 150, ancho=300)
        self.txt_id.setEnabled(True)

        # --- Botón Buscar ---
        self.boton_buscar = QPushButton("Buscar", self)
        self.boton_buscar.setFont(fuente_botones)
        self.boton_buscar.move(600, 150)
        self.boton_buscar.resize(120, 30)
        self._estilo_boton(self.boton_buscar)
        self.boton_buscar.clicked.connect(self.buscar_escultura)

        # --- Botón Actualizar ---
        self.boton_actualizar = QPushButton("Actualizar", self)
        self.boton_actualizar.setFont(fuente_botones)
        self.boton_actualizar.move(600, 190)  # ⬅ 40 píxeles más abajo que el de Buscar
        self.boton_actualizar.resize(120, 30)
        self._estilo_boton(self.boton_actualizar)
        self.boton_actualizar.clicked.connect(self.actualizar_escultura)


        # --- Campos resultado ---
        self._crear_campo("Título:", 250)
        self.txt_titulo = self._crear_input(250, 250)

        self._crear_campo("Autor:", 300)
        self.txt_autor = self._crear_input(250, 300)

        self._crear_campo("Precio:", 350)
        self.txt_precio = self._crear_input(250, 350)

        self._crear_campo("Tipo:", 400)
        self.combo_tipo = QComboBox(self)
        self.combo_tipo.addItems(["Clásica", "Moderna", "Abstracta"])
        self.combo_tipo.move(250, 400)
        self.combo_tipo.resize(200, 30)
        self.combo_tipo.setEnabled(False)

        self._crear_campo("Materia:", 450)
        self.combo_materia = QComboBox(self)
        self.combo_materia.addItems(["Mármol", "Bronce", "Madera", "Yeso", "Otro"])
        self.combo_materia.move(250, 450)
        self.combo_materia.resize(200, 30)
        self.combo_materia.setEnabled(False)

        self._crear_campo("Altura (cm):", 500)
        self.txt_altura = self._crear_input(250, 500)

        self._crear_campo("Volumen (cm³):", 550)
        self.txt_volumen = self._crear_input(250, 550)

        self._crear_campo("Estado:", 600)
        self.combo_estado = QComboBox(self)
        self.combo_estado.addItems(["Activo", "Inactivo"])
        self.combo_estado.move(250, 600)
        self.combo_estado.resize(200, 30)
        self.combo_estado.setEnabled(False)

        # Desactivar campos de texto
        self._bloquear_campos()

    # --- Métodos auxiliares ---
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
        """Desactiva edición en los campos de datos."""
        for campo in [
            self.txt_titulo, self.txt_autor, self.txt_precio,
            self.txt_altura, self.txt_volumen
        ]:
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

    # --- Lógica principal ---
    def buscar_escultura(self):
        """Obtiene una escultura del backend según el ID."""
        id_buscar = self.txt_id.text().strip()
        if not id_buscar:
            self._mensaje("Debe ingresar un ID.", "warning")
            return

        escultura = APIManager.obtener_escultura(id_buscar)
        if not escultura:
            self._mensaje("No se encontró ninguna escultura con ese ID.", "warning")
            return

        # Cargar datos
        self.txt_titulo.setText(str(escultura.get("titulo", "")))
        self.txt_autor.setText(str(escultura.get("autor", "")))
        self.txt_precio.setText(str(escultura.get("precio", "")))

        tipo = escultura.get("tipo", None)
        if tipo:
            idx = self.combo_tipo.findText(tipo)
            if idx != -1:
                self.combo_tipo.setCurrentIndex(idx)

        materia = escultura.get("materia", None)
        if materia:
            idx = self.combo_materia.findText(materia)
            if idx != -1:
                self.combo_materia.setCurrentIndex(idx)

        self.txt_altura.setText(str(escultura.get("altura", "")))
        self.txt_volumen.setText(str(escultura.get("volumen", "")))

        estado = escultura.get("estado", "Activo")
        idx = self.combo_estado.findText(estado)
        self.combo_estado.setCurrentIndex(idx)
                # Habilitar edición después de cargar los datos
        for campo in [
            self.txt_titulo, self.txt_autor, self.txt_precio,
            self.txt_altura, self.txt_volumen
        ]:
            campo.setEnabled(True)
        self.combo_tipo.setEnabled(True)
        self.combo_materia.setEnabled(True)
        self.combo_estado.setEnabled(True)



    def actualizar_escultura(self):
        """Actualiza los datos de una escultura en el backend."""
        id_escultura = self.txt_id.text().strip()

        if not id_escultura:
            self._mensaje("Debe buscar una escultura antes de actualizar.", "warning")
            return

        # Recolectar los datos de los campos
        datos = {
            "titulo": self.txt_titulo.text().strip(),
            "autor": self.txt_autor.text().strip(),
            "precio": self.txt_precio.text().strip(),
            "tipo": self.combo_tipo.currentText(),
            "materia": self.combo_materia.currentText(),
            "altura": self.txt_altura.text().strip(),
            "volumen": self.txt_volumen.text().strip(),
            "estado": self.combo_estado.currentText(),
        }

        # Validación mínima
        if not datos["titulo"] or not datos["autor"]:
            self._mensaje("Debe llenar al menos Título y Autor.", "warning")
            return

        # Llamar al método del APIManager
        resultado = APIManager.actualizar_escultura(id_escultura, datos)

        # Mostrar resultado
        if resultado:
            self._mensaje("✅ Escultura actualizada correctamente.")
        else:
            self._mensaje("❌ No se pudo actualizar la escultura. Verifique los datos.", "warning")

