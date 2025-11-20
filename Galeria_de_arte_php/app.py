from ui.main_window import MainWindow
from PyQt5.QtWidgets import QApplication
import sys


    
if __name__ == "__main__":
    app = QApplication(sys.argv)
    ventana = MainWindow()
    ventana.show()
    sys.exit(app.exec_())
