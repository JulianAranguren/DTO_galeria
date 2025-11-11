package com.mycompany.GaleriaArteBD.model;

import com.fasterxml.jackson.annotation.JsonBackReference;
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

    // Campo String para compatibilidad
    @Column(length = 120)
    private String autor;

    @Positive
    @Column(nullable = false)
    private double precio;

    @NotBlank
    @Column(nullable = false, length = 20)
    private String estado;  // "Activo" | "Inactivo"

    @Column(nullable = false)
    private LocalDateTime fechaIngreso;

    @Column(nullable = false, length = 30)
    private String tipo; // "Pintura" | "Escultura"

    // Evita serialización infinita
    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "autor_id")
    @JsonBackReference
    private Autor autorEntidad;

    @PrePersist
    void prePersist() {
        if (fechaIngreso == null) fechaIngreso = LocalDateTime.now();
        if (estado == null || estado.isBlank()) estado = "Activo";
        // Sincronizar el campo String autor con el nombre del autorEntidad
        if (autorEntidad != null && (autor == null || autor.isBlank())) {
            autor = autorEntidad.getNombre();
        }
    }

    @PreUpdate
    void preUpdate() {
        if (autorEntidad != null) {
            autor = autorEntidad.getNombre();
        }
    }
}
