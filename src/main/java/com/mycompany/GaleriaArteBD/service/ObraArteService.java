package com.mycompany.GaleriaArteBD.service;

import com.mycompany.GaleriaArteBD.model.*;
import com.mycompany.GaleriaArteBD.repositories.*;
import jakarta.transaction.Transactional;
import org.springframework.stereotype.Service;

import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;
import java.util.NoSuchElementException;

@Service
@Transactional
public class ObraArteService implements IObraArteService {

    private final PinturaRepository pinturaRepo;
    private final EsculturaRepository esculturaRepo;

    public ObraArteService(PinturaRepository pinturaRepo, EsculturaRepository esculturaRepo) {
        this.pinturaRepo = pinturaRepo;
        this.esculturaRepo = esculturaRepo;
    }

    // ---------- Pintura ----------
    @Override
    public Pintura crearPintura(Pintura p) {
        p.setTipo("Pintura");
        return pinturaRepo.save(p);
    }

    @Override
    public Pintura obtenerPintura(int id) {
        return pinturaRepo.findById(id)
                .orElseThrow(() -> new NoSuchElementException("No existe pintura con id " + id));
    }

    @Override
    public Pintura actualizarPintura(int id, Pintura cambios) {
        Pintura actual = obtenerPintura(id);
        actual.setTitulo(cambios.getTitulo());
        actual.setAutor(cambios.getAutor());
        actual.setPrecio(cambios.getPrecio());
        actual.setEstado(cambios.getEstado());
        if (cambios.getFechaIngreso() != null) actual.setFechaIngreso(cambios.getFechaIngreso());
        actual.setTipo("Pintura");
        actual.setTecnica(cambios.getTecnica());
        actual.setTextura(cambios.getTextura());
        return pinturaRepo.save(actual);
    }

    @Override
    public void eliminarPintura(int id) {
        Pintura p = obtenerPintura(id);
        p.setEstado("Inactivo");
        pinturaRepo.save(p);
    }

    @Override
    public List<Pintura> listarPinturas() {
        return pinturaRepo.findByEstadoIgnoreCaseNot("Inactivo");
    }

    @Override
    public List<Pintura> listarTodasPinturas() {
        return pinturaRepo.findAll();
    }

    @Override
    public List<Pintura> buscarPinturas(String autor, String estado, Double minPrecio,
                                        String tecnica, String textura, LocalDateTime fechaIngreso) {
        // Filtros opcionales: construirlos a mano
        List<Pintura> base = pinturaRepo.findAll();
        List<Pintura> out = new ArrayList<>();
        for (Pintura p : base) {
            if (autor != null && (p.getAutor() == null || !p.getAutor().equalsIgnoreCase(autor))) continue;
            if (estado != null && (p.getEstado() == null || !p.getEstado().equalsIgnoreCase(estado))) continue;
            if (minPrecio != null && p.getPrecio() < minPrecio) continue;
            if (tecnica != null && (p.getTecnica() == null || !p.getTecnica().equalsIgnoreCase(tecnica))) continue;
            if (textura != null && (p.getTextura() == null || !p.getTextura().equalsIgnoreCase(textura))) continue;
            if (fechaIngreso != null && (p.getFechaIngreso() == null || !p.getFechaIngreso().equals(fechaIngreso))) continue;
            out.add(p);
        }
        return out;
    }

    // ---------- Escultura ----------
    @Override
    public Escultura crearEscultura(Escultura e) {
        e.setTipo("Escultura");
        return esculturaRepo.save(e);
    }

    @Override
    public Escultura obtenerEscultura(int id) {
        return esculturaRepo.findById(id)
                .orElseThrow(() -> new NoSuchElementException("No existe escultura con id " + id));
    }

    @Override
    public Escultura actualizarEscultura(int id, Escultura cambios) {
        Escultura actual = obtenerEscultura(id);
        actual.setTitulo(cambios.getTitulo());
        actual.setAutor(cambios.getAutor());
        actual.setPrecio(cambios.getPrecio());
        actual.setEstado(cambios.getEstado());
        if (cambios.getFechaIngreso() != null) actual.setFechaIngreso(cambios.getFechaIngreso());
        actual.setTipo("Escultura");
        actual.setAltura(cambios.getAltura());
        actual.setVolumen(cambios.getVolumen());
        actual.setMaterial(cambios.getMaterial());
        actual.setTipoEscultura(cambios.getTipoEscultura());
        return esculturaRepo.save(actual);
    }

    @Override
    public void eliminarEscultura(int id) {
        Escultura e = obtenerEscultura(id);
        e.setEstado("Inactivo");
        esculturaRepo.save(e);
    }

    @Override
    public List<Escultura> listarEsculturas() {
        return esculturaRepo.findByEstadoIgnoreCaseNot("Inactivo");
    }

    @Override
    public List<Escultura> listarTodasEsculturas() {
        return esculturaRepo.findAll();
    }

    @Override
    public List<Escultura> buscarEsculturas(String material, String tipoEscultura,
                                            String estado, Double minPrecio,
                                            LocalDateTime fechaIngreso) {
        List<Escultura> base = esculturaRepo.findAll();
        List<Escultura> out = new ArrayList<>();
        for (Escultura e : base) {
            if (material != null && (e.getMaterial() == null || !e.getMaterial().equalsIgnoreCase(material))) continue;
            if (tipoEscultura != null && (e.getTipoEscultura() == null || !e.getTipoEscultura().equalsIgnoreCase(tipoEscultura))) continue;
            if (estado != null && (e.getEstado() == null || !e.getEstado().equalsIgnoreCase(estado))) continue;
            if (minPrecio != null && e.getPrecio() < minPrecio) continue;
            if (fechaIngreso != null && (e.getFechaIngreso() == null || !e.getFechaIngreso().equals(fechaIngreso))) continue;
            out.add(e);
        }
        return out;
    }
}
