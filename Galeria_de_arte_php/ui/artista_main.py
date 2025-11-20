from PyQt5.QtWidgets import QMainWindow,QWidget, QLabel
from core.styles import Estilos
from core.fuentes import fuente_texto, fuente_botones
from core.ubicaciones import Posicion
from core.botones import Botones
from ui.artista.Agregar_Artista import VentanaAgregarArtista
from ui.artista.Buscar_Artista import VentanaBuscarArtista
from ui.artista.Listar_Artista import VentanaListarArtista
from ui.artista.Filtrar_Artista import VentanaFiltrarArtista
from ui.artista.Eliminar_Artista import VentanaEliminarArtista

class artista_ventana(QMainWindow):
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
        Botones.crear_boton(self, "Agregar Artista", 100, 100, fuente_botones, VentanaAgregarArtista)
        Botones.crear_boton(self, "Buscar Artista", 100, 200, fuente_botones, VentanaBuscarArtista)
        Botones.crear_boton(self, "Listar Artistas", 100, 300, fuente_botones, VentanaListarArtista)
        Botones.crear_boton(self, "Filtrar Artistas", 100, 400, fuente_botones, VentanaFiltrarArtista)
        Botones.crear_boton(self, "Eliminar Artista", 100, 500, fuente_botones, VentanaEliminarArtista)

        
