package com.mycompany.GaleriaArteBD.Controller;

import com.mycompany.GaleriaArteBD.model.Pintura;
import com.mycompany.GaleriaArteBD.service.ObraArteService;
import org.springframework.format.annotation.DateTimeFormat;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.time.LocalDateTime;
import java.util.List;

@RestController
@RequestMapping("/pinturas")
public class PinturaController {

    private final ObraArteService obraArteService;

    public PinturaController(ObraArteService obraArteService) {
        this.obraArteService = obraArteService;
    }

    @GetMapping(value = "healthCheck")
    public String healtCheck(){
        return "Status Ok!";
    }

    @PostMapping
    public ResponseEntity<Pintura> crear(@RequestBody Pintura p) {
        return ResponseEntity.status(HttpStatus.CREATED).body(obraArteService.crearPintura(p));
    }

    @GetMapping("/{id}")
    public Pintura obtener(@PathVariable int id) { return obraArteService.obtenerPintura(id); }

    @PutMapping("/{id}")
    public Pintura actualizar(@PathVariable int id, @RequestBody Pintura cambios) {
        return obraArteService.actualizarPintura(id, cambios);
    }

    // DELETE (soft)
    @DeleteMapping("/{id}")
    public ResponseEntity<Void> eliminar(@PathVariable int id) {
        obraArteService.eliminarPintura(id);
        return ResponseEntity.noContent().build();
    }

    // LIST (solo activas)
    @GetMapping
    public List<Pintura> listar() {
        return obraArteService.listarPinturas();
    }

    // LIST (todas, incl. inactivas)
    @GetMapping("/all")
    public List<Pintura> listarTodas() {
        return obraArteService.listarTodasPinturas();
    }

    // SEARCH con filtros
    @GetMapping("/search")
    public List<Pintura> buscar(
            @RequestParam(required = false) String autor,
            @RequestParam(required = false) String estado,
            @RequestParam(required = false) Double minPrecio,
            @RequestParam(required = false) String tecnica,
            @RequestParam(required = false) String textura,
            @RequestParam(required = false) @DateTimeFormat(iso = DateTimeFormat.ISO.DATE_TIME) LocalDateTime fechaIngreso
    ) {
        return obraArteService.buscarPinturas(autor, estado, minPrecio, tecnica, textura, fechaIngreso);
    }
}


