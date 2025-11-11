using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GaleriadeArte
{
    public class ApiService
    {
        private readonly RestClient clientPinturas;
        private readonly RestClient clientEsculturas;

        public ApiService()
        {
            // Cliente para PINTURAS
            clientPinturas = new RestClient(new RestClientOptions("http://localhost:8090/pinturas")
            {
                Authenticator = new HttpBasicAuthenticator("admin", "admin")
            });

            // Cliente para ESCULTURAS
            clientEsculturas = new RestClient(new RestClientOptions("http://localhost:8090/esculturas")
            {
                Authenticator = new HttpBasicAuthenticator("admin", "admin")
            });
        }

        /* ========================= PINTURAS ========================= */

        public async Task<string> HealthCheckPinturasAsync()
        {
            var response = await clientPinturas.ExecuteAsync(new RestRequest("healthCheck", Method.Get));
            if (!response.IsSuccessful) throw new Exception("Error de conexión: " + response.ErrorMessage);
            return response.Content;
        }

        public async Task<List<Pintura>> GetPinturasAsync()
        {
            var response = await clientPinturas.ExecuteAsync(new RestRequest("", Method.Get));
            if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content)) throw new Exception("Error al listar pinturas: " + response.ErrorMessage);
            return JsonConvert.DeserializeObject<List<Pintura>>(response.Content);
        }

        public async Task<List<Pintura>> GetTodasPinturasAsync()
        {
            var response = await clientPinturas.ExecuteAsync(new RestRequest("all", Method.Get));
            if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content)) throw new Exception("Error al listar todas las pinturas: " + response.ErrorMessage);
            return JsonConvert.DeserializeObject<List<Pintura>>(response.Content);
        }

        public async Task<Pintura> GetPinturaAsync(int id)
        {
            var request = new RestRequest("/{id}", Method.Get).AddUrlSegment("id", id);
            var response = await clientPinturas.ExecuteAsync(request);
            if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content)) throw new Exception("No se pudo obtener la pintura: " + response.ErrorMessage);
            return JsonConvert.DeserializeObject<Pintura>(response.Content);
        }

        public async Task<Pintura> CrearPinturaAsync(Pintura p)
        {
            var response = await clientPinturas.ExecuteAsync(new RestRequest("", Method.Post).AddJsonBody(p));
            if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content)) throw new Exception("Error al crear pintura: " + response.ErrorMessage);
            return JsonConvert.DeserializeObject<Pintura>(response.Content);
        }

        public async Task<Pintura> ActualizarPinturaAsync(int id, Pintura cambios)
        {
            var response = await clientPinturas.ExecuteAsync(new RestRequest("/{id}", Method.Put).AddUrlSegment("id", id).AddJsonBody(cambios));
            if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content)) throw new Exception("Error al actualizar pintura: " + response.ErrorMessage);
            return JsonConvert.DeserializeObject<Pintura>(response.Content);
        }

        public async Task<bool> EliminarPinturaAsync(int id)
        {
            var response = await clientPinturas.ExecuteAsync(new RestRequest("/{id}", Method.Delete).AddUrlSegment("id", id));
            return response.IsSuccessStatusCode;
        }

        public async Task<Pintura> BuscarPinturaPorIdAsync(int id)
        {
            var request = new RestRequest("/{id}", Method.Get).AddUrlSegment("id", id);
            var response = await clientPinturas.ExecuteAsync(request);

            if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content))
                throw new Exception("No se pudo encontrar la pintura con ID " + id + ": " + response.ErrorMessage);

            return JsonConvert.DeserializeObject<Pintura>(response.Content);
        }

        //public async Task<List<Pintura>> BuscarPinturasAsync(string autor = null, string estado = null, double? minPrecio = null, string tecnica = null, string textura = null)
        //{
          //  var request = new RestRequest("search", Method.Get);
            //if (!string.IsNullOrEmpty(autor)) request.AddQueryParameter("autor", autor);
            //if (!string.IsNullOrEmpty(estado)) request.AddQueryParameter("estado", estado);
            //if (minPrecio.HasValue) request.AddQueryParameter("minPrecio", minPrecio.ToString());
            //if (!string.IsNullOrEmpty(tecnica)) request.AddQueryParameter("tecnica", tecnica);
            //if (!string.IsNullOrEmpty(textura)) request.AddQueryParameter("textura", textura);

            //var response = await clientPinturas.ExecuteAsync(request);
            //if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content)) throw new Exception("Error en la búsqueda: " + response.ErrorMessage);
            //return JsonConvert.DeserializeObject<List<Pintura>>(response.Content);
        //}

        /* ========================= ESCULTURAS ========================= */

        public async Task<string> HealthCheckEsculturasAsync()
        {
            var response = await clientEsculturas.ExecuteAsync(new RestRequest("healthCheck", Method.Get));
            if (!response.IsSuccessful) throw new Exception("Error de conexión: " + response.ErrorMessage);
            return response.Content;
        }

        public async Task<List<Escultura>> GetEsculturasAsync()
        {
            var response = await clientEsculturas.ExecuteAsync(new RestRequest("", Method.Get));
            if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content)) throw new Exception("Error al listar esculturas: " + response.ErrorMessage);
            return JsonConvert.DeserializeObject<List<Escultura>>(response.Content);
        }

        public async Task<List<Escultura>> GetTodasEsculturasAsync()
        {
            var response = await clientEsculturas.ExecuteAsync(new RestRequest("all", Method.Get));
            if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content)) throw new Exception("Error al listar todas las esculturas: " + response.ErrorMessage);
            return JsonConvert.DeserializeObject<List<Escultura>>(response.Content);
        }

        public async Task<Escultura> GetEsculturaAsync(int id)
        {
            var request = new RestRequest("/{id}", Method.Get).AddUrlSegment("id", id);
            var response = await clientEsculturas.ExecuteAsync(request);
            if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content)) throw new Exception("No se pudo obtener la escultura: " + response.ErrorMessage);
            return JsonConvert.DeserializeObject<Escultura>(response.Content);
        }

        public async Task<Escultura> CrearEsculturaAsync(Escultura e)
        {
            var response = await clientEsculturas.ExecuteAsync(new RestRequest("", Method.Post).AddJsonBody(e));
            if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content)) throw new Exception("Error al crear escultura: " + response.ErrorMessage);
            return JsonConvert.DeserializeObject<Escultura>(response.Content);
        }

        public async Task<Escultura> ActualizarEsculturaAsync(int id, Escultura cambios)
        {
            var response = await clientEsculturas.ExecuteAsync(new RestRequest("/{id}", Method.Put).AddUrlSegment("id", id).AddJsonBody(cambios));
            if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content)) throw new Exception("Error al actualizar escultura: " + response.ErrorMessage);
            return JsonConvert.DeserializeObject<Escultura>(response.Content);
        }

        public async Task<bool> EliminarEsculturaAsync(int id)
        {
            var response = await clientEsculturas.ExecuteAsync(new RestRequest("/{id}", Method.Delete).AddUrlSegment("id", id));
            return response.IsSuccessStatusCode;
        }


        public async Task<Escultura> BuscarEsculturaPorIdAsync(int id)
        {
            var request = new RestRequest("/{id}", Method.Get).AddUrlSegment("id", id);
            var response = await clientEsculturas.ExecuteAsync(request);

            if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content))
                throw new Exception("No se pudo encontrar la escultura con ID " + id + ": " + response.ErrorMessage);

            return JsonConvert.DeserializeObject<Escultura>(response.Content);
        }


        //**public async Task<List<Escultura>> BuscarEsculturasAsync(string material = null, string tipoEscultura = null, string estado = null, double? minPrecio = null, DateTime? fechaIngreso = null)
        //{
        //  var request = new RestRequest("search", Method.Get);
        //if (!string.IsNullOrEmpty(material)) request.AddQueryParameter("material", material);
        //if (!string.IsNullOrEmpty(tipoEscultura)) request.AddQueryParameter("tipoEscultura", tipoEscultura);
        //if (!string.IsNullOrEmpty(estado)) request.AddQueryParameter("estado", estado);
        //if (minPrecio.HasValue) request.AddQueryParameter("minPrecio", minPrecio.ToString());
        //if (fechaIngreso.HasValue) request.AddQueryParameter("fechaIngreso", fechaIngreso.Value.ToString("yyyy-MM-ddTHH:mm:ss"));

        //var response = await clientEsculturas.ExecuteAsync(request);
        //if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content)) throw new Exception("Error en la búsqueda: " + response.ErrorMessage);
        //return JsonConvert.DeserializeObject<List<Escultura>>(response.Content);
        //} **//
    }
}
