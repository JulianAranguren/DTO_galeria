package com.mycompany.GaleriaArteBD.Controller;

import com.mycompany.GaleriaArteBD.model.Autor;
import com.mycompany.GaleriaArteBD.repositories.AutorRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import java.time.LocalDateTime;
import java.util.List;
import java.util.Optional;

@RestController
@RequestMapping("/api/autores")
@CrossOrigin(origins = "*")
public class AutorController {

    @Autowired
    private AutorRepository autorRepository;

    // ✅ GET ALL - Listar todos los autores
    @GetMapping
    public List<Autor> getAllAutores() {
        return autorRepository.findAll();
    }

    // ✅ GET BY ID - Obtener autor por ID
    @GetMapping("/{id}")
    public ResponseEntity<Autor> getAutorById(@PathVariable Integer id) {
        Optional<Autor> autor = autorRepository.findById(id);
        return autor.map(ResponseEntity::ok)
                .orElse(ResponseEntity.notFound().build());
    }

    // ✅ CREATE - Crear nuevo autor
    @PostMapping
    public Autor createAutor(@RequestBody Autor autor) {
        // Establecer valores por defecto si es necesario
        if (autor.getFechaNacimiento() == null) {
            autor.setFechaNacimiento(LocalDateTime.now());
        }
        return autorRepository.save(autor);
    }

    // ✅ UPDATE - Actualizar autor existente
    @PutMapping("/{id}")
    public ResponseEntity<Autor> updateAutor(@PathVariable Integer id, @RequestBody Autor autorDetails) {
        return autorRepository.findById(id)
                .map(autor -> {
                    autor.setNombre(autorDetails.getNombre());
                    autor.setNacionalidad(autorDetails.getNacionalidad());
                    autor.setFechaNacimiento(autorDetails.getFechaNacimiento());
                    autor.setAñosExperiencia(autorDetails.getAñosExperiencia());
                    autor.setEstiloPrincipal(autorDetails.getEstiloPrincipal());
                    autor.setActivo(autorDetails.isActivo());
                    return ResponseEntity.ok(autorRepository.save(autor));
                })
                .orElse(ResponseEntity.notFound().build());
    }

    // ✅ DELETE - Eliminar autor
    @DeleteMapping("/{id}")
    public ResponseEntity<?> deleteAutor(@PathVariable Integer id) {
        return autorRepository.findById(id)
                .map(autor -> {
                    autorRepository.delete(autor);
                    return ResponseEntity.ok().build();
                })
                .orElse(ResponseEntity.notFound().build());
    }

    // ✅ CONSULTAS PERSONALIZADAS

    // Autores activos
    @GetMapping("/activos")
    public List<Autor> getAutoresActivos() {
        return autorRepository.findByActivoTrue();
    }

    // Autores por nacionalidad
    @GetMapping("/nacionalidad/{nacionalidad}")
    public List<Autor> getAutoresPorNacionalidad(@PathVariable String nacionalidad) {
        return autorRepository.findByNacionalidadIgnoreCase(nacionalidad);
    }

    // Autor con todas sus obras (esculturas + pinturas)
    @GetMapping("/{id}/obras")
    public ResponseEntity<Autor> getAutorWithObras(@PathVariable Integer id) {
        return autorRepository.findAutorWithObras(id)
                .map(ResponseEntity::ok)
                .orElse(ResponseEntity.notFound().build());
    }

    // Autores por rango de fechas de nacimiento
    @GetMapping("/por-fecha")
    public List<Autor> getAutoresByRangoFechas(
            @RequestParam LocalDateTime fechaInicio,
            @RequestParam LocalDateTime fechaFin) {
        return autorRepository.findAutoresByRangoFechasNacimiento(fechaInicio, fechaFin);
    }

    // Autores con esculturas activas
    @GetMapping("/con-esculturas-activas")
    public List<Autor> getAutoresConEsculturasActivas() {
        return autorRepository.findAutoresConEsculturasActivas();
    }

    // Autores con pinturas activas
    @GetMapping("/con-pinturas-activas")
    public List<Autor> getAutoresConPinturasActivas() {
        return autorRepository.findAutoresConPinturasActivas();
    }

    // Búsqueda por nombre (parcial)
    @GetMapping("/buscar")
    public List<Autor> buscarAutoresPorNombre(@RequestParam String nombre) {
        return autorRepository.findByNombreContainingIgnoreCase(nombre);
    }
}
