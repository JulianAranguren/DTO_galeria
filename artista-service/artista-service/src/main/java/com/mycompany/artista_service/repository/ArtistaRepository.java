package com.mycompany.artista_service.repository;

import com.mycompany.artista_service.model.Artista;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.time.LocalDate;
import java.util.List;
import java.util.Optional;

@Repository
public interface ArtistaRepository extends JpaRepository<Artista, Long> {

    // Búsquedas básicas
    List<Artista> findByNombreContainingIgnoreCase(String nombre);
    List<Artista> findByNacionalidad(String nacionalidad);
    List<Artista> findByEstiloPrincipal(String estilo);
    List<Artista> findByActivoTrue();
    Optional<Artista> findByEmail(String email);

    // Búsquedas con queries personalizados
    @Query("SELECT a FROM Artista a WHERE LOWER(a.nombre) = LOWER(:nombre)")
    Optional<Artista> encontrarPorNombreExacto(@Param("nombre") String nombre);

    @Query("SELECT a FROM Artista a WHERE a.nacionalidad = :nacionalidad AND a.activo = true")
    List<Artista> findActivosPorNacionalidad(@Param("nacionalidad") String nacionalidad);

    @Query("SELECT a FROM Artista a WHERE a.fechaNacimiento BETWEEN :fechaInicio AND :fechaFin")
    List<Artista> findByFechaNacimientoBetween(@Param("fechaInicio") LocalDate fechaInicio,
                                               @Param("fechaFin") LocalDate fechaFin);

    @Query("SELECT COUNT(a) FROM Artista a WHERE a.activo = true")
    Long countArtistasActivos();
}