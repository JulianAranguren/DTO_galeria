from PyQt5.QtWidgets import QMainWindow, QLabel
from core.styles import Estilos
from core.fuentes import fuente_texto


class acercade_ventana(QMainWindow):
    def __init__(self):
        super().__init__()
        self.setWindowTitle("Desarrolladores")
        self.setFixedSize(560, 220)
        Estilos.aplicar_estilo_general(self)

        
        self.label = QLabel("Santiago Arciniegas Jiménez - 2220221016", self)
        self.label.setFont(fuente_texto)
        self.label.move(20, 50)
        self.label.adjustSize()
        Estilos.aplicar_estilo_txt(self.label)

        self.label = QLabel("Daniel Mauricio Álvarez Morales - 2420211008", self)
        self.label.setFont(fuente_texto)
        self.label.move(20, 80)
        self.label.adjustSize()
        Estilos.aplicar_estilo_txt(self.label)

        self.label = QLabel("Julián Camilo Aranguren Herrán - 2220231103", self)
        self.label.setFont(fuente_texto)
        self.label.move(20, 110)
        self.label.adjustSize()
        Estilos.aplicar_estilo_txt(self.label)
        
