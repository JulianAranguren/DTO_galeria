import requests
from requests.auth import HTTPBasicAuth

class APIManager:
    BASE_URL = "http://localhost:8090"
    AUTH = HTTPBasicAuth("admin", "admin")

    # ======== ESCULTURAS ========
    @staticmethod
    def listar_esculturas():
        url = f"{APIManager.BASE_URL}/esculturas"
        resp = requests.get(url, auth=APIManager.AUTH)
        return resp.json() if resp.status_code == 200 else []

    @staticmethod
    def obtener_escultura(id):
        url = f"{APIManager.BASE_URL}/esculturas/{id}"
        resp = requests.get(url, auth=APIManager.AUTH)
        return resp.json() if resp.status_code == 200 else None

    @staticmethod
    def crear_escultura(datos):
        url = f"{APIManager.BASE_URL}/esculturas"
        print("🔹 Enviando datos a:", url)
        print("🔹 Cuerpo del request:", datos)

        try:
            resp = requests.post(url, json=datos, auth=APIManager.AUTH)
            print("🔹 Código de respuesta:", resp.status_code)
            print("🔹 Respuesta del servidor:", resp.text)
            return resp.status_code == 201
        except Exception as e:
            print("❌ Error en la petición:", e)
            return False


    @staticmethod
    def actualizar_escultura(id, datos):
        url = f"{APIManager.BASE_URL}/esculturas/{id}"
        resp = requests.put(url, json=datos, auth=APIManager.AUTH)
        return resp.status_code == 200

    @staticmethod
    def eliminar_escultura(id):
        url = f"{APIManager.BASE_URL}/esculturas/{id}"
        resp = requests.delete(url, auth=APIManager.AUTH)
        return resp.status_code in (200, 204)

    @staticmethod
    def buscar_esculturas_por_autor(autor):
        url = f"{APIManager.BASE_URL}/esculturas/search"
        params = {"material": autor} 
        resp = requests.get(url, params=params, auth=APIManager.AUTH)
        return resp.json() if resp.status_code == 200 else []
    
    @staticmethod
    def buscar_esculturas(params):
        url = f"{APIManager.BASE_URL}/esculturas/search"
        resp = requests.get(url, params=params, auth=APIManager.AUTH)
        return resp.json() if resp.status_code == 200 else []


    # ======== PINTURAS ========
    @staticmethod
    def listar_pinturas():
        url = f"{APIManager.BASE_URL}/pinturas"
        resp = requests.get(url, auth=APIManager.AUTH)
        return resp.json() if resp.status_code == 200 else []

    @staticmethod
    def obtener_pintura(id):
        url = f"{APIManager.BASE_URL}/pinturas/{id}"
        resp = requests.get(url, auth=APIManager.AUTH)
        return resp.json() if resp.status_code == 200 else None

    @staticmethod
    def crear_pintura(datos):
        url = f"{APIManager.BASE_URL}/pinturas"
        resp = requests.post(url, json=datos, auth=APIManager.AUTH)
        return resp.status_code == 201

    @staticmethod
    def actualizar_pintura(id, datos):
        url = f"{APIManager.BASE_URL}/pinturas/{id}"
        resp = requests.put(url, json=datos, auth=APIManager.AUTH)
        return resp.status_code == 200

    @staticmethod
    def eliminar_pintura(id):
        url = f"{APIManager.BASE_URL}/pinturas/{id}"
        resp = requests.delete(url, auth=APIManager.AUTH)
        return resp.status_code in (200, 204)

    @staticmethod
    def buscar_pinturas(autor=None, tecnica=None, textura=None, estado=None):
        url = f"{APIManager.BASE_URL}/pinturas/search"
        params = {}
        if autor: params["autor"] = autor
        if tecnica: params["tecnica"] = tecnica
        if textura: params["textura"] = textura
        if estado: params["estado"] = estado
        resp = requests.get(url, params=params, auth=APIManager.AUTH)
        return resp.json() if resp.status_code == 200 else []
    
    @staticmethod
    def filtrar_pinturas(params):
        url = f"{APIManager.BASE_URL}/pinturas/search"
        resp = requests.get(url, params=params, auth=APIManager.AUTH)
        return resp.json() if resp.status_code == 200 else []

