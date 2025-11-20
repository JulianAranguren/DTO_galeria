package com.mycompany.GaleriaArteBD.service;

import com.mycompany.GaleriaArteBD.dto.ArtistaDTO;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Component;
import org.springframework.web.client.RestTemplate;
import org.springframework.http.HttpStatus;

@Component
public class ArtistaServiceClient {

    @Autowired
    private RestTemplate restTemplate;

    @Value("${microservicio.artistas.url:http://localhost:8091}")
    private String artistaServiceUrl;

    public boolean validarArtista(String nombreArtista) {
        try {
            String url = artistaServiceUrl + "/api/artistas/existe?nombre=" + nombreArtista;
            ResponseEntity<Boolean> response = restTemplate.getForEntity(url, Boolean.class);
            return response.getStatusCode() == HttpStatus.OK && Boolean.TRUE.equals(response.getBody());
        } catch (Exception e) {
            System.err.println("Error al validar artista '" + nombreArtista + "': " + e.getMessage());
            return false;
        }
    }

    public String obtenerInformacionArtista(String nombreArtista) {
        try {
            String url = artistaServiceUrl + "/api/artistas/buscar/nombre?nombre=" + nombreArtista;
            ResponseEntity<String> response = restTemplate.getForEntity(url, String.class);
            return response.getBody();
        } catch (Exception e) {
            return "Información del artista no disponible";
        }
    }
    public ArtistaDTO obtenerArtistaPorNombre(String nombreArtista) {
        try {
            String url = artistaServiceUrl + "/api/artistas/buscar/nombre-dto?nombre=" + nombreArtista;
            ResponseEntity<ArtistaDTO[]> response = restTemplate.getForEntity(url, ArtistaDTO[].class);

            if (response.getBody() != null && response.getBody().length > 0) {
                return response.getBody()[0]; // Devuelve el primer artista encontrado
            }
            return null;
        } catch (Exception e) {
            System.err.println("Error al obtener artista '" + nombreArtista + "': " + e.getMessage());
            return null;
        }
    }
}
