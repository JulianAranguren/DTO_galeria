class WindowManager:
    def __init__(self):
        # Diccionario para almacenar ventanas abiertas (opcional)
        self.ventanas_abiertas = {}
        
    def abrir_ventana(self, clase_ventana):
        """Recibe la clase de una ventana y la instancia y muestra."""
        try:
            nombre = clase_ventana.__name__
            if nombre not in self.ventanas_abiertas or not self.ventanas_abiertas[nombre].isVisible():
                ventana = clase_ventana()
                ventana.show()
                self.ventanas_abiertas[nombre] = ventana
            else:
                self.ventanas_abiertas[nombre].raise_()
        except Exception as e:
            print(f"Error al abrir ventana: {e}")
