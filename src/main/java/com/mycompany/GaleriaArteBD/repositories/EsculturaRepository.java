package com.mycompany.GaleriaArteBD.repositories;

import com.mycompany.GaleriaArteBD.model.Escultura;
import org.springframework.data.jpa.repository.JpaRepository;

import java.time.LocalDateTime;
import java.util.List;

public interface EsculturaRepository extends JpaRepository<Escultura, Integer> {
    List<Escultura> findByEstadoIgnoreCaseNot(String estado); // activas
    List<Escultura> findByMaterialIgnoreCaseAndTipoEsculturaIgnoreCaseAndEstadoIgnoreCaseAndPrecioGreaterThanEqualAndFechaIngreso(
            String material, String tipoEscultura, String estado, double minPrecio, LocalDateTime fechaIngreso
    );
}