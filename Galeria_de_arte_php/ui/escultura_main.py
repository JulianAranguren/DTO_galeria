from PyQt5.QtWidgets import QMainWindow,QWidget, QLabel
from core.styles import Estilos
from core.fuentes import fuente_texto, fuente_botones
from core.ubicaciones import Posicion
from core.botones import Botones
from ui.escultura.Agregar_Escultura import VentanaAgregarEscultura
from ui.escultura.Buscar_Escultura import VentanaBuscarEscultura
from ui.escultura.Listar_Escultura import VentanaListarEsculturas
from ui.escultura.Filtrar_Esculturas import VentanaFiltrarEsculturas
from ui.escultura.Eliminar_Escultura import VentanaEliminarEscultura

class escultura_ventana(QMainWindow):
    def __init__(self):
        super().__init__()
        self.setWindowTitle("Escultura")
        self.setFixedSize(1060, 720)
        Estilos.aplicar_estilo_general(self)

        # Texto a la derecha
        self.label = QLabel("Escoja la Operacion que desea realizar", self)
        self.label.setFont(fuente_texto)
        Estilos.aplicar_estilo_txt(self.label)
        Posicion.texto_derecha(self,self.label)

        #Botones
        Botones.crear_boton(self, "Agregar Escultura", 100, 100, fuente_botones, VentanaAgregarEscultura)
        Botones.crear_boton(self, "Buscar Escultura", 100, 200, fuente_botones, VentanaBuscarEscultura)
        Botones.crear_boton(self, "Listar Esculturas", 100, 300, fuente_botones, VentanaListarEsculturas)
        Botones.crear_boton(self, "Filtrar Esculturas", 100, 400, fuente_botones, VentanaFiltrarEsculturas)
        Botones.crear_boton(self, "Eliminar Escultura", 100, 500, fuente_botones, VentanaEliminarEscultura)

        
