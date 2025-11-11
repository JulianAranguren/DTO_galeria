package com.mycompany.GaleriaArteBD.Controller;

import com.mycompany.GaleriaArteBD.model.Escultura;
import com.mycompany.GaleriaArteBD.service.IObraArteService;
import org.springframework.format.annotation.DateTimeFormat;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.time.LocalDateTime;
import java.util.List;

@RestController
@RequestMapping("/esculturas")
public class EsculturaController {

    private final IObraArteService obraArteService;

    public EsculturaController(IObraArteService obraArteService) {
        this.obraArteService = obraArteService;
    }

    @GetMapping("healthCheck")
    public String healthCheck() {
        return "Esculturas OK!";
    }

    // CREATE
    @PostMapping
    public ResponseEntity<Escultura> crear(@RequestBody Escultura e) {
        return ResponseEntity.status(HttpStatus.CREATED).body(obraArteService.crearEscultura(e));
    }

    // READ by id
    @GetMapping("/{id}")
    public Escultura obtener(@PathVariable int id) {
        return obraArteService.obtenerEscultura(id);
    }

    // UPDATE
    @PutMapping("/{id}")
    public Escultura actualizar(@PathVariable int id, @RequestBody Escultura cambios) {
        return obraArteService.actualizarEscultura(id, cambios);
    }

    // DELETE (soft → estado = "Inactivo")
    @DeleteMapping("/{id}")
    public ResponseEntity<Void> eliminar(@PathVariable int id) {
        obraArteService.eliminarEscultura(id);
        return ResponseEntity.noContent().build();
    }

    // LIST (solo activas)
    @GetMapping
    public List<Escultura> listar() {
        return obraArteService.listarEsculturas();
    }

    // LIST (todas, incl. inactivas)
    @GetMapping("/all")
    public List<Escultura> listarTodas() {
        return obraArteService.listarTodasEsculturas();
    }

    // SEARCH con filtros
    @GetMapping("/search")
    public List<Escultura> buscar(
            @RequestParam(required = false) String material,
            @RequestParam(required = false) String tipoEscultura,
            @RequestParam(required = false) String estado,
            @RequestParam(required = false) Double minPrecio,
            @RequestParam(required = false)
            @DateTimeFormat(iso = DateTimeFormat.ISO.DATE_TIME) LocalDateTime fechaIngreso
    ) {
        return obraArteService.buscarEsculturas(material, tipoEscultura, estado, minPrecio, fechaIngreso);
    }
}
