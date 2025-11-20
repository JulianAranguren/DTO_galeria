using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GaleriadeArte
{
    public class ApiService
    {
        private readonly RestClient clientObras;
        private readonly RestClient clientArtistas;

        public ApiService()
        {
            // Cliente para OBRAS DE ARTE (GaleriaArteBD - puerto 8090)
            clientObras = new RestClient(new RestClientOptions("http://localhost:8090/api/obras")
            {
                Authenticator = new HttpBasicAuthenticator("admin", "admin")
            });

            // Cliente para ARTISTAS (artista-service - puerto 8091)
            clientArtistas = new RestClient(new RestClientOptions("http://localhost:8091/api/artistas")
            {
                Authenticator = new HttpBasicAuthenticator("admin", "admin") // Si tiene seguridad
            });
        }

        /* ========================= ARTISTAS ========================= */

        public async Task<List<Artista>> GetArtistasAsync()
        {
            var response = await clientArtistas.ExecuteAsync(new RestRequest("", Method.Get));
            if (!response.IsSuccessful) throw new Exception("Error al listar artistas: " + response.ErrorMessage);
            return JsonConvert.DeserializeObject<List<Artista>>(response.Content);
        }

        public async Task<List<Artista>> GetArtistasActivosAsync()
        {
            var response = await clientArtistas.ExecuteAsync(new RestRequest("activos", Method.Get));
            if (!response.IsSuccessful) throw new Exception("Error al listar artistas activos: " + response.ErrorMessage);
            return JsonConvert.DeserializeObject<List<Artista>>(response.Content);
        }

        public async Task<Artista> GetArtistaAsync(long id)
        {
            var request = new RestRequest("/{id}", Method.Get).AddUrlSegment("id", id);
            var response = await clientArtistas.ExecuteAsync(request);
            if (!response.IsSuccessful) throw new Exception("No se pudo obtener el artista: " + response.ErrorMessage);
            return JsonConvert.DeserializeObject<Artista>(response.Content);
        }

        public async Task<Artista> CrearArtistaAsync(Artista artista)
        {
            var response = await clientArtistas.ExecuteAsync(new RestRequest("", Method.Post).AddJsonBody(artista));
            if (!response.IsSuccessful) throw new Exception("Error al crear artista: " + response.ErrorMessage);
            return JsonConvert.DeserializeObject<Artista>(response.Content);
        }

        public async Task<Artista> ActualizarArtistaAsync(long id, Artista cambios)
        {
            var response = await clientArtistas.ExecuteAsync(new RestRequest("/{id}", Method.Put).AddUrlSegment("id", id).AddJsonBody(cambios));
            if (!response.IsSuccessful) throw new Exception("Error al actualizar artista: " + response.ErrorMessage);
            return JsonConvert.DeserializeObject<Artista>(response.Content);
        }

        public async Task<bool> DesactivarArtistaAsync(long id)
        {
            var response = await clientArtistas.ExecuteAsync(new RestRequest("/{id}/desactivar", Method.Patch).AddUrlSegment("id", id));
            return response.IsSuccessStatusCode;
        }

        public async Task<List<Artista>> BuscarArtistasPorNombreAsync(string nombre)
        {
            var request = new RestRequest("buscar/nombre-dto", Method.Get).AddQueryParameter("nombre", nombre);
            var response = await clientArtistas.ExecuteAsync(request);
            if (!response.IsSuccessful) throw new Exception("Error en la búsqueda de artistas: " + response.ErrorMessage);
            return JsonConvert.DeserializeObject<List<Artista>>(response.Content);
        }

        public async Task<bool> VerificarArtistaExisteAsync(string nombre)
        {
            var request = new RestRequest("existe", Method.Get).AddQueryParameter("nombre", nombre);
            var response = await clientArtistas.ExecuteAsync(request);
            if (!response.IsSuccessful) throw new Exception("Error al verificar artista: " + response.ErrorMessage);
            return JsonConvert.DeserializeObject<bool>(response.Content);
        }

        /* ========================= OBRAS DE ARTE (CON DTOs) ========================= */

        public async Task<List<ObraArteResponse>> GetObrasConArtistasAsync()
        {
            var response = await clientObras.ExecuteAsync(new RestRequest("con-artista", Method.Get));
            if (!response.IsSuccessful) throw new Exception("Error al listar obras con artistas: " + response.ErrorMessage);
            return JsonConvert.DeserializeObject<List<ObraArteResponse>>(response.Content);
        }

        public async Task<ObraArteResponse> GetObraConArtistaAsync(int id)
        {
            var request = new RestRequest("/{id}/con-artista", Method.Get).AddUrlSegment("id", id);
            var response = await clientObras.ExecuteAsync(request);
            if (!response.IsSuccessful) throw new Exception("No se pudo obtener la obra: " + response.ErrorMessage);
            return JsonConvert.DeserializeObject<ObraArteResponse>(response.Content);
        }

        /* ========================= PINTURAS (USANDO DTOs) ========================= */

        public async Task<List<Pintura>> GetPinturasAsync()
        {
            var response = await clientObras.ExecuteAsync(new RestRequest("pinturas", Method.Get));
            if (!response.IsSuccessful) throw new Exception("Error al listar pinturas: " + response.ErrorMessage);
            return JsonConvert.DeserializeObject<List<Pintura>>(response.Content);
        }

        public async Task<Pintura> GetPinturaAsync(int id)
        {
            var request = new RestRequest("pinturas/{id}", Method.Get).AddUrlSegment("id", id);
            var response = await clientObras.ExecuteAsync(request);
            if (!response.IsSuccessful) throw new Exception("No se pudo obtener la pintura: " + response.ErrorMessage);
            return JsonConvert.DeserializeObject<Pintura>(response.Content);
        }

        public async Task<ObraArteResponse> CrearPinturaConDTOAsync(ObraArteRequest requestDTO)
        {
            var response = await clientObras.ExecuteAsync(new RestRequest("pinturas/dto", Method.Post).AddJsonBody(requestDTO));
            if (!response.IsSuccessful) throw new Exception("Error al crear pintura: " + response.ErrorMessage);
            return JsonConvert.DeserializeObject<ObraArteResponse>(response.Content);
        }

        public async Task<Pintura> ActualizarPinturaAsync(int id, Pintura cambios)
        {
            var response = await clientObras.ExecuteAsync(new RestRequest("pinturas/{id}", Method.Put).AddUrlSegment("id", id).AddJsonBody(cambios));
            if (!response.IsSuccessful) throw new Exception("Error al actualizar pintura: " + response.ErrorMessage);
            return JsonConvert.DeserializeObject<Pintura>(response.Content);
        }

        public async Task<bool> EliminarPinturaAsync(int id)
        {
            var response = await clientObras.ExecuteAsync(new RestRequest("pinturas/{id}", Method.Delete).AddUrlSegment("id", id));
            return response.IsSuccessStatusCode;
        }

        /* ========================= ESCULTURAS (USANDO DTOs) ========================= */

        public async Task<List<Escultura>> GetEsculturasAsync()
        {
            var response = await clientObras.ExecuteAsync(new RestRequest("esculturas", Method.Get));
            if (!response.IsSuccessful) throw new Exception("Error al listar esculturas: " + response.ErrorMessage);
            return JsonConvert.DeserializeObject<List<Escultura>>(response.Content);
        }

        public async Task<Escultura> GetEsculturaAsync(int id)
        {
            var request = new RestRequest("esculturas/{id}", Method.Get).AddUrlSegment("id", id);
            var response = await clientObras.ExecuteAsync(request);
            if (!response.IsSuccessful) throw new Exception("No se pudo obtener la escultura: " + response.ErrorMessage);
            return JsonConvert.DeserializeObject<Escultura>(response.Content);
        }

        public async Task<ObraArteResponse> CrearEsculturaConDTOAsync(ObraArteRequest requestDTO)
        {
            var response = await clientObras.ExecuteAsync(new RestRequest("esculturas/dto", Method.Post).AddJsonBody(requestDTO));
            if (!response.IsSuccessful) throw new Exception("Error al crear escultura: " + response.ErrorMessage);
            return JsonConvert.DeserializeObject<ObraArteResponse>(response.Content);
        }

        public async Task<Escultura> ActualizarEsculturaAsync(int id, Escultura cambios)
        {
            var response = await clientObras.ExecuteAsync(new RestRequest("esculturas/{id}", Method.Put).AddUrlSegment("id", id).AddJsonBody(cambios));
            if (!response.IsSuccessful) throw new Exception("Error al actualizar escultura: " + response.ErrorMessage);
            return JsonConvert.DeserializeObject<Escultura>(response.Content);
        }

        public async Task<bool> EliminarEsculturaAsync(int id)
        {
            var response = await clientObras.ExecuteAsync(new RestRequest("esculturas/{id}", Method.Delete).AddUrlSegment("id", id));
            return response.IsSuccessStatusCode;
        }

        /* ========================= BÚSQUEDAS COMBINADAS ========================= */

        public async Task<List<ObraArteResponse>> BuscarObrasPorAutorAsync(string autor)
        {
            var request = new RestRequest("buscar", Method.Get).AddQueryParameter("autor", autor);
            var response = await clientObras.ExecuteAsync(request);
            if (!response.IsSuccessful) throw new Exception("Error en la búsqueda: " + response.ErrorMessage);
            return JsonConvert.DeserializeObject<List<ObraArteResponse>>(response.Content);
        }

        public async Task<List<object>> BuscarObrasPorTituloAsync(string titulo)
        {
            var request = new RestRequest("buscar", Method.Get).AddQueryParameter("titulo", titulo);
            var response = await clientObras.ExecuteAsync(request);
            if (!response.IsSuccessful) throw new Exception("Error en la búsqueda: " + response.ErrorMessage);
            return JsonConvert.DeserializeObject<List<object>>(response.Content);
        }

        /* ========================= HEALTH CHECKS ========================= */

        public async Task<string> HealthCheckObrasAsync()
        {
            var response = await clientObras.ExecuteAsync(new RestRequest("health", Method.Get));
            if (!response.IsSuccessful) throw new Exception("Error de conexión con obras: " + response.ErrorMessage);
            return response.Content;
        }

        public async Task<string> HealthCheckArtistasAsync()
        {
            var response = await clientArtistas.ExecuteAsync(new RestRequest("health", Method.Get));
            if (!response.IsSuccessful) throw new Exception("Error de conexión con artistas: " + response.ErrorMessage);
            return response.Content;
        }
    }
}
