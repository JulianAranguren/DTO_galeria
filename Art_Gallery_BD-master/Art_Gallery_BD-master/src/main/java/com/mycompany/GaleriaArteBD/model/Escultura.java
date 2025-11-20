package com.mycompany.GaleriaArteBD.model;



import jakarta.persistence.*;
import jakarta.validation.constraints.*;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.EqualsAndHashCode;
import lombok.NoArgsConstructor;

@Entity
@Table(name = "esculturas")
@Data @NoArgsConstructor @AllArgsConstructor
public class Escultura extends ObraArte {

    @Positive
    @Column(nullable = false)
    private double altura;

    @Positive
    @Column(nullable = false)
    private double volumen;

    @NotBlank
    @Column(nullable = false, length = 80)
    private String material;

    @NotBlank
    @Column(nullable = false, length = 80)
    private String tipoEscultura;
}
