package com.mycompany.artista_service.model;

import jakarta.persistence.*;
import jakarta.validation.constraints.*;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import java.time.LocalDate;

@Entity
@Table(name = "artistas")
@Data
@NoArgsConstructor
@AllArgsConstructor
public class Artista {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @NotBlank(message = "El nombre es obligatorio")
    @Size(min = 2, max = 120, message = "El nombre debe tener entre 2 y 120 caracteres")
    @Column(nullable = false, length = 120)
    private String nombre;

    @Size(max = 60, message = "La nacionalidad no puede exceder 60 caracteres")
    @Column(length = 60)
    private String nacionalidad;

    @Past(message = "La fecha de nacimiento debe ser en el pasado")
    @Column(name = "fecha_nacimiento")
    private LocalDate fechaNacimiento;

    @Size(max = 80, message = "El estilo principal no puede exceder 80 caracteres")
    @Column(name = "estilo_principal", length = 80)
    private String estiloPrincipal;

    @Column(nullable = false)
    private Boolean activo = true;

    @Email(message = "El formato del email no es válido")
    @Size(max = 150, message = "El email no puede exceder 150 caracteres")
    @Column(length = 150, unique = true)
    private String email;

    @Column(name = "fecha_registro")
    private LocalDate fechaRegistro;

    @PrePersist
    void prePersist() {
        if (activo == null) activo = true;
        if (fechaRegistro == null) fechaRegistro = LocalDate.now();
    }

    // Constructor sin ID para creación
    public Artista(String nombre, String nacionalidad, LocalDate fechaNacimiento,
                   String estiloPrincipal, Boolean activo, String email) {
        this.nombre = nombre;
        this.nacionalidad = nacionalidad;
        this.fechaNacimiento = fechaNacimiento;
        this.estiloPrincipal = estiloPrincipal;
        this.activo = activo;
        this.email = email;
    }
}
