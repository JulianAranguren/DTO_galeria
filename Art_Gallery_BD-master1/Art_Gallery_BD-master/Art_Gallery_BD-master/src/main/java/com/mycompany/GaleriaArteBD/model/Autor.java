package com.mycompany.GaleriaArteBD.model;

import com.fasterxml.jackson.annotation.JsonManagedReference;
import jakarta.persistence.*;
import jakarta.validation.constraints.*;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;

@Entity
@Table(name = "autores")
@Data
@NoArgsConstructor
@AllArgsConstructor
public class Autor {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer id;

    @NotBlank(message = "El nombre es obligatorio")
    @Column(nullable = false, length = 100)
    private String nombre;

    @NotBlank(message = "La nacionalidad es obligatoria")
    @Column(length = 50)
    private String nacionalidad;

    @NotNull(message = "La fecha de nacimiento es obligatoria")
    @Column(name = "fecha_nacimiento")
    private LocalDateTime fechaNacimiento;

    @Positive(message = "Los años de experiencia deben ser positivos")
    @Column(name = "años_experiencia")
    private double añosExperiencia;

    @Column(name = "estilo_principal", length = 50)
    private String estiloPrincipal;

    @Column(nullable = false)
    private boolean activo = true;

    // Evita serialización infinita
    @OneToMany(mappedBy = "autorEntidad", cascade = CascadeType.ALL, fetch = FetchType.LAZY)
    @JsonManagedReference
    private List<Escultura> esculturas = new ArrayList<>();

    @OneToMany(mappedBy = "autorEntidad", cascade = CascadeType.ALL, fetch = FetchType.LAZY)
    @JsonManagedReference
    private List<Pintura> pinturas = new ArrayList<>();
}

