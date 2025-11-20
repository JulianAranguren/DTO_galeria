package com.mycompany.artista_service.service;

import com.mycompany.artista_service.model.Artista;
import com.mycompany.artista_service.repository.ArtistaRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import java.util.List;
import java.util.Optional;

@Service
@Transactional
public class ArtistaService {

    @Autowired
    private ArtistaRepository artistaRepository;

    // CREATE
    public Artista crearArtista(Artista artista) {
        // Validar que el email no exista
        if (artista.getEmail() != null && !artista.getEmail().isBlank()) {
            Optional<Artista> artistaExistente = artistaRepository.findByEmail(artista.getEmail());
            if (artistaExistente.isPresent()) {
                throw new RuntimeException("Ya existe un artista con el email: " + artista.getEmail());
            }
        }
        return artistaRepository.save(artista);
    }

    // READ
    @Transactional(readOnly = true)
    public List<Artista> listarTodos() {
        return artistaRepository.findAll();
    }

    @Transactional(readOnly = true)
    public Optional<Artista> obtenerPorId(Long id) {
        return artistaRepository.findById(id);
    }

    @Transactional(readOnly = true)
    public List<Artista> buscarPorNombre(String nombre) {
        return artistaRepository.findByNombreContainingIgnoreCase(nombre);
    }

    @Transactional(readOnly = true)
    public List<Artista> buscarActivos() {
        return artistaRepository.findByActivoTrue();
    }

    @Transactional(readOnly = true)
    public boolean existePorNombre(String nombre) {
        return artistaRepository.encontrarPorNombreExacto(nombre).isPresent();
    }

    @Transactional(readOnly = true)
    public List<Artista> buscarPorNacionalidad(String nacionalidad) {
        return artistaRepository.findByNacionalidad(nacionalidad);
    }

    // UPDATE
    public Artista actualizarArtista(Long id, Artista artistaActualizado) {
        Optional<Artista> artistaExistente = artistaRepository.findById(id);
        if (artistaExistente.isPresent()) {
            Artista artista = artistaExistente.get();

            // Validar email único si se está cambiando
            if (artistaActualizado.getEmail() != null &&
                    !artistaActualizado.getEmail().equals(artista.getEmail())) {
                Optional<Artista> artistaConEmail = artistaRepository.findByEmail(artistaActualizado.getEmail());
                if (artistaConEmail.isPresent()) {
                    throw new RuntimeException("Ya existe un artista con el email: " + artistaActualizado.getEmail());
                }
            }

            artista.setNombre(artistaActualizado.getNombre());
            artista.setNacionalidad(artistaActualizado.getNacionalidad());
            artista.setFechaNacimiento(artistaActualizado.getFechaNacimiento());
            artista.setEstiloPrincipal(artistaActualizado.getEstiloPrincipal());
            artista.setActivo(artistaActualizado.getActivo());
            artista.setEmail(artistaActualizado.getEmail());

            return artistaRepository.save(artista);
        }
        throw new RuntimeException("Artista no encontrado con ID: " + id);
    }

    // DELETE
    public void eliminarArtista(Long id) {
        if (artistaRepository.existsById(id)) {
            artistaRepository.deleteById(id);
        } else {
            throw new RuntimeException("Artista no encontrado con ID: " + id);
        }
    }

    // Métodos adicionales
    public void desactivarArtista(Long id) {
        Optional<Artista> artista = artistaRepository.findById(id);
        if (artista.isPresent()) {
            artista.get().setActivo(false);
            artistaRepository.save(artista.get());
        } else {
            throw new RuntimeException("Artista no encontrado con ID: " + id);
        }
    }

    @Transactional(readOnly = true)
    public Long contarArtistasActivos() {
        return artistaRepository.countArtistasActivos();
    }
}
