package com.mycompany.GaleriaArteBD.model;

import jakarta.persistence.*;
import jakarta.validation.constraints.*;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Entity
@Table(name = "pinturas")
@Data @NoArgsConstructor @AllArgsConstructor
public class Pintura extends ObraArte {

    @NotBlank
    @Column(nullable = false, length = 80)
    private String tecnica;

    @NotBlank
    @Column(nullable = false, length = 80)
    private String textura;
}
