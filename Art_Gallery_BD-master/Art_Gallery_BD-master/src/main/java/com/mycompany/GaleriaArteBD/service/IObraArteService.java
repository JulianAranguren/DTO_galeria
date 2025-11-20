package com.mycompany.GaleriaArteBD.service;

import com.mycompany.GaleriaArteBD.dto.ObraArteRequestDTO;
import com.mycompany.GaleriaArteBD.dto.ObraArteResponseDTO;
import com.mycompany.GaleriaArteBD.model.Pintura;
import com.mycompany.GaleriaArteBD.model.Escultura;
import java.util.List;
import java.util.Optional;

public interface IObraArteService {
    // ========== MÉTODOS CON DTOs ==========

    // Crear obras con DTOs
    ObraArteResponseDTO crearPinturaConDTO(ObraArteRequestDTO requestDTO);
    ObraArteResponseDTO crearEsculturaConDTO(ObraArteRequestDTO requestDTO);

    // Obtener obras con información del artista
    ObraArteResponseDTO obtenerObraConArtista(Integer id);
    List<ObraArteResponseDTO> listarTodasLasObrasConArtista();
    List<ObraArteResponseDTO> buscarObrasPorAutorConArtista(String autor);

    // ========== MÉTODOS ORIGINALES (mantener para compatibilidad) ==========

    // Pinturas
    Pintura crearPintura(Pintura pintura);
    Optional<Pintura> obtenerPinturaPorId(Integer id);
    List<Pintura> listarTodasPinturas();
    List<Pintura> buscarPinturasPorAutor(String autor);
    List<Pintura> buscarPinturasPorTitulo(String titulo);
    Pintura actualizarPintura(Integer id, Pintura pintura);
    void eliminarPintura(Integer id);

    // Esculturas
    Escultura crearEscultura(Escultura escultura);
    Optional<Escultura> obtenerEsculturaPorId(Integer id);
    List<Escultura> listarTodasEsculturas();
    List<Escultura> buscarEsculturasPorAutor(String autor);
    List<Escultura> buscarEsculturasPorTitulo(String titulo);
    Escultura actualizarEscultura(Integer id, Escultura escultura);
    void eliminarEscultura(Integer id);

    // Búsquedas combinadas
    List<Object> buscarObrasPorAutor(String autor);
    List<Object> buscarObrasPorTitulo(String titulo);
    List<Object> listarTodasLasObras();
    List<Object> buscarObrasActivas();
}
