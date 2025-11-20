package com.mycompany.GaleriaArteBD.Controller;

import com.mycompany.GaleriaArteBD.dto.ObraArteRequestDTO;
import com.mycompany.GaleriaArteBD.dto.ObraArteResponseDTO;
import com.mycompany.GaleriaArteBD.model.Pintura;
import com.mycompany.GaleriaArteBD.model.Escultura;
import com.mycompany.GaleriaArteBD.service.ObraArteService;
import jakarta.validation.Valid;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import java.util.List;
import java.util.Optional;

@RestController
@RequestMapping("/api/obras")
@CrossOrigin(origins = "*")
public class ObraArteController {

    @Autowired
    private ObraArteService obraArteService;

    // ========== PINTURAS ==========
    @PostMapping("/pinturas")
    public ResponseEntity<Pintura> crearPintura(@Valid @RequestBody Pintura pintura) {
        Pintura nuevaPintura = obraArteService.crearPintura(pintura);
        return ResponseEntity.ok(nuevaPintura);
    }

    @GetMapping("/pinturas")
    public List<Pintura> listarPinturas() {
        return obraArteService.listarTodasPinturas();
    }

    @GetMapping("/pinturas/{id}")
    public ResponseEntity<Pintura> obtenerPintura(@PathVariable Integer id) {
        Optional<Pintura> pintura = obraArteService.obtenerPinturaPorId(id);
        return pintura.map(ResponseEntity::ok)
                .orElse(ResponseEntity.notFound().build());
    }

    @GetMapping("/pinturas/buscar/autor")
    public List<Pintura> buscarPinturasPorAutor(@RequestParam String autor) {
        return obraArteService.buscarPinturasPorAutor(autor);
    }

    @GetMapping("/pinturas/buscar/titulo")
    public List<Pintura> buscarPinturasPorTitulo(@RequestParam String titulo) {
        return obraArteService.buscarPinturasPorTitulo(titulo);
    }

    @PutMapping("/pinturas/{id}")
    public ResponseEntity<Pintura> actualizarPintura(@PathVariable Integer id,
                                                     @Valid @RequestBody Pintura pintura) {
        try {
            Pintura pinturaActualizada = obraArteService.actualizarPintura(id, pintura);
            return ResponseEntity.ok(pinturaActualizada);
        } catch (RuntimeException e) {
            return ResponseEntity.notFound().build();
        }
    }

    @DeleteMapping("/pinturas/{id}")
    public ResponseEntity<Void> eliminarPintura(@PathVariable Integer id) {
        obraArteService.eliminarPintura(id);
        return ResponseEntity.ok().build();
    }

    // ========== ESCULTURAS ==========
    @PostMapping("/esculturas")
    public ResponseEntity<Escultura> crearEscultura(@Valid @RequestBody Escultura escultura) {
        Escultura nuevaEscultura = obraArteService.crearEscultura(escultura);
        return ResponseEntity.ok(nuevaEscultura);
    }

    @GetMapping("/esculturas")
    public List<Escultura> listarEsculturas() {
        return obraArteService.listarTodasEsculturas();
    }

    @GetMapping("/esculturas/{id}")
    public ResponseEntity<Escultura> obtenerEscultura(@PathVariable Integer id) {
        Optional<Escultura> escultura = obraArteService.obtenerEsculturaPorId(id);
        return escultura.map(ResponseEntity::ok)
                .orElse(ResponseEntity.notFound().build());
    }

    @GetMapping("/esculturas/buscar/autor")
    public List<Escultura> buscarEsculturasPorAutor(@RequestParam String autor) {
        return obraArteService.buscarEsculturasPorAutor(autor);
    }

    @GetMapping("/esculturas/buscar/titulo")
    public List<Escultura> buscarEsculturasPorTitulo(@RequestParam String titulo) {
        return obraArteService.buscarEsculturasPorTitulo(titulo);
    }

    @PutMapping("/esculturas/{id}")
    public ResponseEntity<Escultura> actualizarEscultura(@PathVariable Integer id,
                                                         @Valid @RequestBody Escultura escultura) {
        try {
            Escultura esculturaActualizada = obraArteService.actualizarEscultura(id, escultura);
            return ResponseEntity.ok(esculturaActualizada);
        } catch (RuntimeException e) {
            return ResponseEntity.notFound().build();
        }
    }

    @DeleteMapping("/esculturas/{id}")
    public ResponseEntity<Void> eliminarEscultura(@PathVariable Integer id) {
        obraArteService.eliminarEscultura(id);
        return ResponseEntity.ok().build();
    }

    // ========== BÚSQUEDAS COMBINADAS ==========
    @GetMapping
    public List<Object> listarTodasLasObras() {
        return obraArteService.listarTodasLasObras();
    }

    @GetMapping("/buscar/autor")
    public List<Object> buscarObrasPorAutor(@RequestParam String autor) {
        return obraArteService.buscarObrasPorAutor(autor);
    }

    @GetMapping("/buscar/titulo")
    public List<Object> buscarObrasPorTitulo(@RequestParam String titulo) {
        return obraArteService.buscarObrasPorTitulo(titulo);
    }

    @GetMapping("/activas")
    public List<Object> buscarObrasActivas() {
        return obraArteService.buscarObrasActivas();
    }

    // Agregar estos nuevos endpoints al controller
    @PostMapping("/pinturas/dto")
    public ResponseEntity<ObraArteResponseDTO> crearPinturaConDTO(@Valid @RequestBody ObraArteRequestDTO requestDTO) {
        ObraArteResponseDTO response = obraArteService.crearPinturaConDTO(requestDTO);
        return ResponseEntity.status(HttpStatus.CREATED).body(response);
    }

    @PostMapping("/esculturas/dto")
    public ResponseEntity<ObraArteResponseDTO> crearEsculturaConDTO(@Valid @RequestBody ObraArteRequestDTO requestDTO) {
        ObraArteResponseDTO response = obraArteService.crearEsculturaConDTO(requestDTO);
        return ResponseEntity.status(HttpStatus.CREATED).body(response);
    }

    @GetMapping("/con-artista")
    public ResponseEntity<List<ObraArteResponseDTO>> listarObrasConArtista() {
        List<ObraArteResponseDTO> obras = obraArteService.listarTodasLasObrasConArtista();
        return ResponseEntity.ok(obras);
    }

    @GetMapping("/{id}/con-artista")
    public ResponseEntity<ObraArteResponseDTO> obtenerObraConArtista(@PathVariable Integer id) {
        ObraArteResponseDTO obra = obraArteService.obtenerObraConArtista(id);
        return ResponseEntity.ok(obra);
    }
}
