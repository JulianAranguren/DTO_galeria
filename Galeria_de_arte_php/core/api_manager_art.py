import requests
from requests.auth import HTTPBasicAuth

class APIManagerArtista:
    BASE_URL = "http://localhost:8091/api/artistas"
    AUTH = HTTPBasicAuth("admin", "admin")

    # === Crear Artista ===
    @staticmethod
    def crear_artista(data):
        url = APIManagerArtista.BASE_URL
        resp = requests.post(url, json=data, auth=APIManagerArtista.AUTH)
        return resp.status_code in (200, 201)

    # === Listar Artistas ===
    @staticmethod
    def listar_artistas():
        resp = requests.get(APIManagerArtista.BASE_URL, auth=APIManagerArtista.AUTH)
        return resp.json() if resp.status_code == 200 else []

    # === Obtener por ID ===
    @staticmethod
    def obtener_artista(id):
        url = f"{APIManagerArtista.BASE_URL}/{id}"
        resp = requests.get(url, auth=APIManagerArtista.AUTH)
        return resp.json() if resp.status_code == 200 else None

    # === Buscar por Nombre ===
    @staticmethod
    def buscar_artista_por_nombre(nombre):
        url = f"{APIManagerArtista.BASE_URL}/buscar/nombre"
        resp = requests.get(url, params={"nombre": nombre}, auth=APIManagerArtista.AUTH)
        return resp.json() if resp.status_code == 200 else []

    # === Buscar por Nacionalidad ===
    @staticmethod
    def buscar_artista_por_nacionalidad(nac):
        url = f"{APIManagerArtista.BASE_URL}/buscar/nacionalidad"
        resp = requests.get(url, params={"nacionalidad": nac}, auth=APIManagerArtista.AUTH)
        return resp.json() if resp.status_code == 200 else []

    # === Actualizar Artista ===
    @staticmethod
    def actualizar_artista(id, data):
        url = f"{APIManagerArtista.BASE_URL}/{id}"
        resp = requests.put(url, json=data, auth=APIManagerArtista.AUTH)
        return resp.status_code == 200

    # === Eliminar ===
    @staticmethod
    def eliminar_artista(id):
        url = f"{APIManagerArtista.BASE_URL}/{id}"
        resp = requests.delete(url, auth=APIManagerArtista.AUTH)
        return resp.status_code in (200, 204)

    # === Desactivar (Soft Delete) ===
    @staticmethod
    def desactivar_artista(id):
        url = f"{APIManagerArtista.BASE_URL}/{id}/desactivar"
        resp = requests.patch(url, auth=APIManagerArtista.AUTH)
        return resp.status_code == 200
