using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GaleriadeArte
{
    public class ApiServiceAutores
    {
        private readonly RestClient client;

        public ApiServiceAutores()
        {
            client = new RestClient(new RestClientOptions("http://localhost:8090/api/autores")
            {
                Authenticator = new HttpBasicAuthenticator("admin", "admin")
            });
        }

        public async Task<List<Autor>> GetAutoresAsync()
        {
            var response = await client.ExecuteAsync(new RestRequest("", Method.Get));
            if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content))
                throw new Exception("Error al listar autores: " + response.ErrorMessage);
            return JsonConvert.DeserializeObject<List<Autor>>(response.Content);
        }

        public async Task<Autor> CrearAutorAsync(Autor a)
        {
            var response = await client.ExecuteAsync(new RestRequest("", Method.Post).AddJsonBody(a));
            if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content))
                throw new Exception("Error al crear autor: " + response.ErrorMessage);
            return JsonConvert.DeserializeObject<Autor>(response.Content);
        }

        public async Task<Autor> ActualizarAutorAsync(int id, Autor cambios)
        {
            var request = new RestRequest("/{id}", Method.Put).AddUrlSegment("id", id).AddJsonBody(cambios);
            var response = await client.ExecuteAsync(request);
            if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content))
                throw new Exception("Error al actualizar autor: " + response.ErrorMessage);
            return JsonConvert.DeserializeObject<Autor>(response.Content);
        }

        public async Task<bool> EliminarAutorAsync(int id)
        {
            var response = await client.ExecuteAsync(new RestRequest("/{id}", Method.Delete).AddUrlSegment("id", id));
            return response.IsSuccessStatusCode;
        }

        public async Task<Autor> GetAutorAsync(int id)
        {
            var response = await client.ExecuteAsync(new RestRequest("/{id}", Method.Get).AddUrlSegment("id", id));
            if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content))
                throw new Exception("No se pudo obtener el autor: " + response.ErrorMessage);
            return JsonConvert.DeserializeObject<Autor>(response.Content);
        }
    }

    // Modelo Autor para C#
    public class Autor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Nacionalidad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public double AñosExperiencia { get; set; }
        public string EstiloPrincipal { get; set; }
        public bool Activo { get; set; }
    }
}
