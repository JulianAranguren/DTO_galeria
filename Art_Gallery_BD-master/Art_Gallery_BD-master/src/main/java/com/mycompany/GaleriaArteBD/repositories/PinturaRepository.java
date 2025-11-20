package com.mycompany.GaleriaArteBD.repositories;

import com.mycompany.GaleriaArteBD.model.Pintura;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;
import java.util.List;

@Repository
public interface PinturaRepository extends JpaRepository<Pintura, Integer> {
    List<Pintura> findByAutorContainingIgnoreCase(String autor);
    List<Pintura> findByTituloContainingIgnoreCase(String titulo);
    List<Pintura> findByEstado(String estado);
    List<Pintura> findByTecnica(String tecnica);

    @Query("SELECT p FROM Pintura p WHERE p.precio BETWEEN :precioMin AND :precioMax")
    List<Pintura> findByPrecioBetween(@Param("precioMin") Double precioMin,
                                      @Param("precioMax") Double precioMax);

    @Query("SELECT p FROM Pintura p WHERE p.estado = 'Activo'")
    List<Pintura> findActivePinturas();
}
