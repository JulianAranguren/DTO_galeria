package com.mycompany.GaleriaArteBD.dto;

import jakarta.validation.constraints.NotBlank;
import jakarta.validation.constraints.Positive;
import lombok.Data;

@Data
public class ObraArteRequestDTO {
    @NotBlank(message = "El título es obligatorio")
    private String titulo;

    @NotBlank(message = "El autor es obligatorio")
    private String autor;  // Nombre del artista

    @Positive(message = "El precio debe ser positivo")
    private double precio;

    private String estado;

    // Campos específicos para Pintura
    private String tecnica;
    private String textura;

    // Campos específicos para Escultura
    private Double altura;
    private Double volumen;
    private String material;
    private String tipoEscultura;
}
