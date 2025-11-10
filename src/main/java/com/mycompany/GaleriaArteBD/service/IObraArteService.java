package com.mycompany.GaleriaArteBD.service;

import com.mycompany.GaleriaArteBD.model.Escultura;
import com.mycompany.GaleriaArteBD.model.Pintura;

import java.time.LocalDateTime;
import java.util.List;


public interface IObraArteService {

    Pintura crearPintura(Pintura p);
    Pintura obtenerPintura(int id);
    Pintura actualizarPintura(int id, Pintura cambios);
    void eliminarPintura(int id); // soft-delete: estado = "Inactivo"

    // Listados
    List<Pintura> listarPinturas();      // solo Activas
    List<Pintura> listarTodasPinturas(); // incluye Inactivas

    // Búsqueda con filtros
    List<Pintura> buscarPinturas(String autor, String estado, Double minPrecio,
                                 String tecnica, String textura,
                                 LocalDateTime fechaIngreso);


    Escultura crearEscultura(Escultura e);
    Escultura obtenerEscultura(int id);
    Escultura actualizarEscultura(int id, Escultura cambios);
    void eliminarEscultura(int id); // soft-delete
    List<Escultura> listarEsculturas();          // solo activas
    List<Escultura> listarTodasEsculturas();     // activas + inactivas
    List<Escultura> buscarEsculturas(String material, String tipoEscultura,
                                     String estado, Double minPrecio,
                                     LocalDateTime fechaIngreso);
}
