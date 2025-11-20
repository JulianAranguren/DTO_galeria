package com.mycompany.artista_service.controller;

import com.mycompany.artista_service.model.Artista;
import com.mycompany.artista_service.service.ArtistaService;
import jakarta.validation.Valid;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import java.util.List;
import java.util.Optional;
import java.util.stream.Collectors;

import com.mycompany.artista_service.dto.ArtistaDTO;

@RestController
@RequestMapping("/api/artistas")
@CrossOrigin(origins = "*")
public class ArtistaController {

    @Autowired
    private ArtistaService artistaService;

    // CREATE
    @PostMapping
    public ResponseEntity<?> crearArtista(@Valid @RequestBody Artista artista) {
        try {
            Artista nuevoArtista = artistaService.crearArtista(artista);
            return ResponseEntity.status(HttpStatus.CREATED).body(nuevoArtista);
        } catch (RuntimeException e) {
            return ResponseEntity.badRequest().body("Error: " + e.getMessage());
        }
    }

    // READ - Todos los artistas
    @GetMapping
    public List<Artista> listarArtistas() {
        return artistaService.listarTodos();
    }

    // READ - Por ID
    @GetMapping("/{id}")
    public ResponseEntity<Artista> obtenerArtista(@PathVariable Long id) {
        Optional<Artista> artista = artistaService.obtenerPorId(id);
        return artista.map(ResponseEntity::ok)
                .orElse(ResponseEntity.notFound().build());
    }

    // READ - Búsquedas
    @GetMapping("/buscar/nombre")
    public List<Artista> buscarPorNombre(@RequestParam String nombre) {
        return artistaService.buscarPorNombre(nombre);
    }

    @GetMapping("/buscar/nacionalidad")
    public List<Artista> buscarPorNacionalidad(@RequestParam String nacionalidad) {
        return artistaService.buscarPorNacionalidad(nacionalidad);
    }

    @GetMapping("/activos")
    public List<Artista> listarActivos() {
        return artistaService.buscarActivos();
    }

    // READ - Validación de existencia
    @GetMapping("/existe")
    public ResponseEntity<Boolean> existeArtista(@RequestParam String nombre) {
        boolean existe = artistaService.existePorNombre(nombre);
        return ResponseEntity.ok(existe);
    }

    // READ - Contador
    @GetMapping("/contador/activos")
    public ResponseEntity<Long> contarArtistasActivos() {
        Long cantidad = artistaService.contarArtistasActivos();
        return ResponseEntity.ok(cantidad);
    }

    // UPDATE
    @PutMapping("/{id}")
    public ResponseEntity<?> actualizarArtista(@PathVariable Long id,
                                               @Valid @RequestBody Artista artista) {
        try {
            Artista artistaActualizado = artistaService.actualizarArtista(id, artista);
            return ResponseEntity.ok(artistaActualizado);
        } catch (RuntimeException e) {
            if (e.getMessage().contains("no encontrado")) {
                return ResponseEntity.notFound().build();
            }
            return ResponseEntity.badRequest().body("Error: " + e.getMessage());
        }
    }

    // DELETE
    @DeleteMapping("/{id}")
    public ResponseEntity<Void> eliminarArtista(@PathVariable Long id) {
        try {
            artistaService.eliminarArtista(id);
            return ResponseEntity.ok().build();
        } catch (RuntimeException e) {
            return ResponseEntity.notFound().build();
        }
    }

    // UPDATE Parcial - Desactivar
    @PatchMapping("/{id}/desactivar")
    public ResponseEntity<Void> desactivarArtista(@PathVariable Long id) {
        try {
            artistaService.desactivarArtista(id);
            return ResponseEntity.ok().build();
        } catch (RuntimeException e) {
            return ResponseEntity.notFound().build();
        }
    }
    // NUEVO ENDPOINT: Buscar artistas por nombre y devolver DTOs
    @GetMapping("/buscar/nombre-dto")
    public ResponseEntity<List<ArtistaDTO>> buscarArtistasPorNombreDTO(@RequestParam String nombre) {
        List<Artista> artistas = artistaService.buscarPorNombre(nombre);
        List<ArtistaDTO> artistasDTO = artistas.stream()
                .map(this::convertirADTO)
                .collect(Collectors.toList());
        return ResponseEntity.ok(artistasDTO);
    }

    // NUEVO ENDPOINT: Obtener artista por ID como DTO
    @GetMapping("/{id}/dto")
    public ResponseEntity<ArtistaDTO> obtenerArtistaDTO(@PathVariable Long id) {
        Optional<Artista> artista = artistaService.obtenerPorId(id);
        return artista.map(a -> ResponseEntity.ok(convertirADTO(a)))
                .orElse(ResponseEntity.notFound().build());
    }

    // NUEVO ENDPOINT: Listar todos los artistas como DTOs
    @GetMapping("/dto")
    public ResponseEntity<List<ArtistaDTO>> listarArtistasDTO() {
        List<Artista> artistas = artistaService.listarTodos();
        List<ArtistaDTO> artistasDTO = artistas.stream()
                .map(this::convertirADTO)
                .collect(Collectors.toList());
        return ResponseEntity.ok(artistasDTO);
    }

    // MÉTODO PRIVADO para convertir Artista a ArtistaDTO
    private ArtistaDTO convertirADTO(Artista artista) {
        return new ArtistaDTO(
                artista.getId(),
                artista.getNombre(),
                artista.getNacionalidad(),
                artista.getFechaNacimiento(),
                artista.getEstiloPrincipal(),
                artista.getActivo(),
                artista.getEmail(),
                artista.getFechaRegistro()
        );
    }
}
