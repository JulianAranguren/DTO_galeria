package com.mycompany.artista_service.dto;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import java.time.LocalDate;

@Data
@NoArgsConstructor
@AllArgsConstructor
public class ArtistaDTO {
    private Long id;
    private String nombre;
    private String nacionalidad;
    private LocalDate fechaNacimiento;
    private String estiloPrincipal;
    private Boolean activo;
    private String email;
    private LocalDate fechaRegistro;
}
