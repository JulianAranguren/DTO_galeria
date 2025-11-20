package com.mycompany.GaleriaArteBD.repositories;

import com.mycompany.GaleriaArteBD.model.Escultura;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;
import java.util.List;

@Repository
public interface EsculturaRepository extends JpaRepository<Escultura, Integer> {
    List<Escultura> findByAutorContainingIgnoreCase(String autor);
    List<Escultura> findByTituloContainingIgnoreCase(String titulo);
    List<Escultura> findByEstado(String estado);
    List<Escultura> findByMaterial(String material);
    List<Escultura> findByTipoEscultura(String tipoEscultura);

    @Query("SELECT e FROM Escultura e WHERE e.precio BETWEEN :precioMin AND :precioMax")
    List<Escultura> findByPrecioBetween(@Param("precioMin") Double precioMin,
                                        @Param("precioMax") Double precioMax);

    @Query("SELECT e FROM Escultura e WHERE e.altura >= :alturaMin")
    List<Escultura> findByAlturaGreaterThanEqual(@Param("alturaMin") Double alturaMin);

    @Query("SELECT e FROM Escultura e WHERE e.estado = 'Activo'")
    List<Escultura> findActiveEsculturas();
}