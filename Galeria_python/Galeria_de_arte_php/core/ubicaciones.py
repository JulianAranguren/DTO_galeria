class Posicion:
    @staticmethod
    def centrar_texto_arriba(ventana,texto):
        x = (ventana.width() - texto.width()) // 2
        texto.move(x, 100)
    
    def texto_derecha(ventana,texto):
        x = (ventana.width() - (texto.width() + texto.width() // 15))
        texto.move(x, 100)
    
    def centrar_texto_formulario(ventana,texto):
        x = (ventana.width() - texto.width()) // 2
        texto.move(x, 50)
