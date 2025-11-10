package com.mycompany.GaleriaArteBD.repositories;

import com.mycompany.GaleriaArteBD.model.Pintura;
import org.springframework.data.jpa.repository.JpaRepository;

import java.time.LocalDateTime;
import java.util.List;

public interface PinturaRepository extends JpaRepository<Pintura, Integer> {
    List<Pintura> findByEstadoIgnoreCaseNot(String estado); // listar solo activas -> usar "Inactivo"
    List<Pintura> findByAutorIgnoreCaseAndEstadoIgnoreCaseAndPrecioGreaterThanEqualAndTecnicaIgnoreCaseAndTexturaIgnoreCaseAndFechaIngreso(
            String autor, String estado, double minPrecio, String tecnica, String textura, LocalDateTime fechaIngreso
    );
}
