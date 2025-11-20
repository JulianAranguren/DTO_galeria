class Estilos:
    @staticmethod
    def aplicar_estilo_general(ventana):
        ventana.setStyleSheet("""
            QMainWindow {
                background-color: #164773;
                background-repeat: no-repeat;
                background-position: center;
            }
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
        
    @staticmethod
    def aplicar_estilo_titulo(titulo):
        titulo.setStyleSheet("color: #89D99D;")
        titulo.adjustSize()

    @staticmethod
    def aplicar_estilo_txt(texto):
        texto.setStyleSheet("color: #89D99D;")
        texto.adjustSize()