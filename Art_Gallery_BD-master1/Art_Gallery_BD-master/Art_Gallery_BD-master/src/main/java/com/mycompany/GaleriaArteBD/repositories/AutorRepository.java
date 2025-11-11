package com.mycompany.GaleriaArteBD.repositories;

import com.mycompany.GaleriaArteBD.model.Autor;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import java.time.LocalDateTime;
import java.util.List;
import java.util.Optional;

public interface AutorRepository extends JpaRepository<Autor, Integer> {

    // Consultas básicas
    List<Autor> findByActivoTrue();
    List<Autor> findByNacionalidadIgnoreCase(String nacionalidad);
    List<Autor> findByEstiloPrincipalContainingIgnoreCase(String estilo);
    List<Autor> findByAñosExperienciaGreaterThanEqual(double añosExperiencia);
    List<Autor> findByNombreContainingIgnoreCase(String nombre);

    // ✅ CONSULTA PERSONALIZADA 1 CORREGIDA: Autor con TODAS sus obras
    @Query("SELECT DISTINCT a FROM Autor a " +
            "LEFT JOIN FETCH a.esculturas " +    // ← CAMBIADO: obras → esculturas
            "LEFT JOIN FETCH a.pinturas " +      // ← CAMBIADO: obras → pinturas
            "WHERE a.id = :autorId")
    Optional<Autor> findAutorWithObras(@Param("autorId") Integer autorId);

    // ✅ CONSULTA PERSONALIZADA 2: Autores por rango de fechas de nacimiento
    @Query("SELECT a FROM Autor a WHERE a.fechaNacimiento BETWEEN :fechaInicio AND :fechaFin")
    List<Autor> findAutoresByRangoFechasNacimiento(@Param("fechaInicio") LocalDateTime fechaInicio,
                                                   @Param("fechaFin") LocalDateTime fechaFin);

    // ✅ CONSULTA CORREGIDA: Autores con obras activas
    @Query("SELECT DISTINCT a FROM Autor a " +
            "JOIN a.esculturas e " +             // ← CAMBIADO: obras → esculturas
            "WHERE e.estado = 'Activo'")
    List<Autor> findAutoresConEsculturasActivas();

    // ✅ NUEVA CONSULTA: Autores con pinturas activas
    @Query("SELECT DISTINCT a FROM Autor a " +
            "JOIN a.pinturas p " +               // ← RELACIÓN CON PINTURAS
            "WHERE p.estado = 'Activo'")
    List<Autor> findAutoresConPinturasActivas();

    // Buscar autor por nombre exacto (para sincronización)
    Optional<Autor> findByNombre(String nombre);
}
