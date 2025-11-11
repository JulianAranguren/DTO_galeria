from core.window_manager import WindowManager
from PyQt5.QtWidgets import QPushButton

class Botones:
    @staticmethod
    def crear_boton(ventana, texto, x, y, fuente, clase_ventana):
        window_manager = WindowManager()
        boton = QPushButton(texto, ventana)
        boton.setFont(fuente)
        boton.move(x, y)
        boton.adjustSize()
        boton.clicked.connect(lambda: window_manager.abrir_ventana(clase_ventana))
