from PyQt5.QtWidgets import QMainWindow, QPushButton, QLabel
from ui.escultura_main import escultura_ventana
from ui.acercade_ventana import acercade_ventana
from ui.pintura_main import pintura_ventana
from core.window_manager import WindowManager 
from core.fuentes import fuente_titulo, fuente_botones
from core.styles import Estilos
from core.ubicaciones import Posicion
from core.botones import Botones

class MainWindow(QMainWindow):
    def __init__(self):
        super().__init__()
        self.setWindowTitle("Galería de Arte")
        self.setFixedSize(1060, 720)
        Estilos.aplicar_estilo_general(self)
        
        

        # Título centrado
        self.label = QLabel("Bienvenido a la Galería de Arte", self)
        self.label.setFont(fuente_titulo)
        Estilos.aplicar_estilo_titulo(self.label)
        Posicion.centrar_texto_arriba(self,self.label)

        # Botones
        Botones.crear_boton(self, "Escultura", 100, 500, fuente_botones, escultura_ventana)
        Botones.crear_boton(self, "Pintura", 860, 500, fuente_botones, pintura_ventana)
        Botones.crear_boton(self, "Acerca de",20, 650, fuente_botones, acercade_ventana)

        

    def crear_boton(self, texto, x, y, fuente, clase_ventana):
        boton = QPushButton(texto, self)
        boton.setFont(fuente)
        boton.move(x, y)
        boton.adjustSize()
        boton.clicked.connect(lambda: self.window_manager.abrir_ventana(clase_ventana))
