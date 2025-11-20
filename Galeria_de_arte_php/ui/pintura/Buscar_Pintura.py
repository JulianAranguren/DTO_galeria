from PyQt5.QtWidgets import (
    QMainWindow, QLabel, QLineEdit, QComboBox, QDateEdit,
    QPushButton, QMessageBox
)
from PyQt5.QtCore import QDate
from core.styles import Estilos
from core.fuentes import fuente_texto, fuente_botones
from core.ubicaciones import Posicion
from core.api_manager import APIManager


class VentanaBuscarPintura(QMainWindow):
    def __init__(self):
        super().__init__()
        self.setWindowTitle("Buscar Pintura")
        self.setFixedSize(1060, 720)
        Estilos.aplicar_estilo_general(self)

        # --- Título ---
        self.label_titulo = QLabel("Buscar Pintura", self)
        self.label_titulo.setFont(fuente_texto)
        Estilos.aplicar_estilo_titulo(self.label_titulo)
        Posicion.centrar_texto_arriba(self, self.label_titulo)

        # --- Campo ID ---
        self._crear_campo("ID:", 150)
        self.txt_id = self._crear_input(250, 150, ancho=300)
        self.txt_id.setEnabled(True)

        # --- Botón Buscar ---
        self.boton_buscar = QPushButton("Buscar", self)
        self.boton_buscar.setFont(fuente_botones)
        self.boton_buscar.move(600, 150)
        self.boton_buscar.resize(120, 35)
        self._estilo_boton(self.boton_buscar)
        self.boton_buscar.clicked.connect(self.buscar_pintura)

        # --- Botón Actualizar ---
        self.boton_actualizar = QPushButton("Actualizar", self)
        self.boton_actualizar.setFont(fuente_botones)
        self.boton_actualizar.move(600, 190)  # ⬅ 40 píxeles más abajo que el de Buscar
        self.boton_actualizar.resize(120, 30)
        self._estilo_boton(self.boton_actualizar)
        self.boton_actualizar.clicked.connect(self.actualizar_pintura)

        # --- Campos de datos ---
        self._crear_campo("Título:", 250)
        self.txt_titulo = self._crear_input(250, 250)

        self._crear_campo("Autor:", 300)
        self.txt_autor = self._crear_input(250, 300)

        self._crear_campo("Fecha de creación:", 350)
        self.dp_fecha = QDateEdit(self)
        self.dp_fecha.setCalendarPopup(True)
        self.dp_fecha.setDate(QDate.currentDate())
        self.dp_fecha.move(250, 350)
        self.dp_fecha.resize(200, 30)
        self.dp_fecha.setEnabled(False)

        self._crear_campo("Precio:", 400)
        self.txt_precio = self._crear_input(250, 400)

        self._crear_campo("Técnica:", 450)
        self.txt_tecnica = self._crear_input(250, 450)

        self._crear_campo("Dimensiones:", 500)
        self.txt_dimensiones = self._crear_input(250, 500)

        self._crear_campo("Estado:", 550)
        self.combo_estado = QComboBox(self)
        self.combo_estado.addItems(["Activo", "Inactivo"])
        self.combo_estado.move(250, 550)
        self.combo_estado.resize(200, 30)
        self.combo_estado.setEnabled(False)

        # Desactiva edición en los campos
        self._bloquear_campos()

    # --- Auxiliares UI ---
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
            self.txt_tecnica, self.txt_dimensiones
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
    def buscar_pintura(self):
        """Busca una pintura por su ID desde el backend."""
        id_buscar = self.txt_id.text().strip()
        if not id_buscar:
            self._mensaje("Debe ingresar un ID.", "warning")
            return

        pintura = APIManager.obtener_pintura(id_buscar)
        if not pintura:
            self._mensaje("No se encontró ninguna pintura con ese ID.", "warning")
            return

        # Cargar datos obtenidos
        self.txt_titulo.setText(str(pintura.get("titulo", "")))
        self.txt_autor.setText(str(pintura.get("autor", "")))

        # Fecha (si viene en formato ISO)
        fecha_iso = pintura.get("anioCreacion", None)
        if fecha_iso:
            try:
                # si es "2025-10-12T00:00:00"
                fecha = QDate.fromString(fecha_iso.split("T")[0], "yyyy-MM-dd")
                self.dp_fecha.setDate(fecha)
            except Exception:
                self.dp_fecha.setDate(QDate.currentDate())

        self.txt_precio.setText(str(pintura.get("precio", "")))
        self.txt_tecnica.setText(str(pintura.get("tecnica", "")))
        self.txt_dimensiones.setText(str(pintura.get("dimensiones", "")))

        estado = pintura.get("estado", "Activo")
        idx = self.combo_estado.findText(estado)
        if idx != -1:
            self.combo_estado.setCurrentIndex(idx)
                # Habilitar edición después de buscar
        for campo in [
            self.txt_titulo, self.txt_autor, self.txt_precio,
            self.txt_tecnica, self.txt_dimensiones
        ]:
            campo.setEnabled(True)

        self.dp_fecha.setEnabled(True)
        self.combo_estado.setEnabled(True)


    
            
    def actualizar_pintura(self):
        """Actualiza una pintura en el backend con los datos del formulario."""
        id_pintura = self.txt_id.text().strip()

        if not id_pintura:
            self._mensaje("Debe buscar una pintura antes de actualizar.", "warning")
            return

        # Recolectar los datos de los campos
        datos = {
            "titulo": self.txt_titulo.text().strip(),
            "autor": self.txt_autor.text().strip(),
            "anioCreacion": self.dp_fecha.date().toString("yyyy-MM-dd"),
            "precio": self.txt_precio.text().strip(),
            "tecnica": self.txt_tecnica.text().strip(),
            "dimensiones": self.txt_dimensiones.text().strip(),
            "estado": self.combo_estado.currentText(),
        }

        # Validar campos mínimos
        if not datos["titulo"] or not datos["autor"]:
            self._mensaje("Debe llenar al menos Título y Autor.", "warning")
            return

        # Llamar al API
        actualizado = APIManager.actualizar_pintura(id_pintura, datos)

        # Mostrar resultado
        if actualizado:
            self._mensaje("✅ Pintura actualizada correctamente.")
        else:
            self._mensaje("❌ No se pudo actualizar la pintura. Verifique los datos.", "warning")

