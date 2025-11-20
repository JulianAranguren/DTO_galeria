package com.mycompany.GaleriaArteBD.model;

import jakarta.persistence.*;
import jakarta.validation.constraints.*;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import java.time.LocalDateTime;

@MappedSuperclass
@Data
@NoArgsConstructor
@AllArgsConstructor
public abstract class ObraArte {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer id;

    @NotBlank
    @Column(nullable = false, length = 120)
    private String titulo;

    @NotBlank
    @Column(nullable = false, length = 120)
    private String autor;

    @Positive
    @Column(nullable = false)
    private double precio;

    @NotBlank
    @Column(nullable = false, length = 20)
    private String estado;

    @Column(nullable = false)
    private LocalDateTime fechaIngreso;

    @Column(nullable = false, length = 30)
    private String tipo;

    @PrePersist
    void prePersist() {
        if (fechaIngreso == null) fechaIngreso = LocalDateTime.now();
        if (estado == null || estado.isBlank()) estado = "Activo";
    }
}