from PyQt5.QtWidgets import QMainWindow,QWidget, QLabel
from core.styles import Estilos
from core.fuentes import fuente_texto, fuente_botones
from core.ubicaciones import Posicion
from core.botones import Botones
from ui.pintura.Agregar_Pintura import VentanaAgregarPintura
from ui.pintura.Buscar_Pintura import VentanaBuscarPintura
from ui.pintura.Listar_Pinturas import VentanaListarPinturas
from ui.pintura.Filtrar_Pinturas import VentanaFiltrarPinturas
from ui.pintura.Eliminar_Pintura import VentanaEliminarPintura

class pintura_ventana(QMainWindow):
    def __init__(self):
        super().__init__()
        self.setWindowTitle("Pintura")
        self.setFixedSize(1060, 720)
        Estilos.aplicar_estilo_general(self)

        # Texto a la derecha
        self.label = QLabel("Escoja la Operacion que desea realizar", self)
        self.label.setFont(fuente_texto)
        Estilos.aplicar_estilo_txt(self.label)
        Posicion.texto_derecha(self,self.label)

        #Botones
        Botones.crear_boton(self, "Agregar Pintura", 100, 100, fuente_botones, VentanaAgregarPintura)
        Botones.crear_boton(self, "Buscar Pintura", 100, 200, fuente_botones, VentanaBuscarPintura)
        Botones.crear_boton(self, "Listar Pintura", 100, 300, fuente_botones, VentanaListarPinturas)
        Botones.crear_boton(self, "Filtrar Pintura", 100, 400, fuente_botones, VentanaFiltrarPinturas)
        Botones.crear_boton(self, "Eliminar Pintura", 100, 500, fuente_botones, VentanaEliminarPintura)

        
