package com.mycompany.GaleriaArteBD.dto;

import lombok.Data;
import java.time.LocalDateTime;

@Data
public class ObraArteResponseDTO {
    private Integer id;
    private String titulo;
    private double precio;
    private String estado;
    private LocalDateTime fechaIngreso;
    private String tipo;

    // Información del artista enriquecida
    private ArtistaDTO artista;

    // Campos específicos
    private String tecnica;        // Pintura
    private String textura;        // Pintura
    private Double altura;         // Escultura
    private Double volumen;        // Escultura
    private String material;       // Escultura
    private String tipoEscultura;  // Escultura
}
