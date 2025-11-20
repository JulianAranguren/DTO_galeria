package com.mycompany.GaleriaArteBD.service;

import com.mycompany.GaleriaArteBD.dto.ObraArteRequestDTO;
import com.mycompany.GaleriaArteBD.dto.ObraArteResponseDTO;
import com.mycompany.GaleriaArteBD.dto.ArtistaDTO;
import com.mycompany.GaleriaArteBD.model.Pintura;
import com.mycompany.GaleriaArteBD.model.Escultura;
import com.mycompany.GaleriaArteBD.model.ObraArte;
import com.mycompany.GaleriaArteBD.repositories.PinturaRepository;
import com.mycompany.GaleriaArteBD.repositories.EsculturaRepository;
// ELIMINAR import de Feign
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

@Service
@Transactional
public class ObraArteService implements IObraArteService {

    @Autowired
    private PinturaRepository pinturaRepository;

    @Autowired
    private EsculturaRepository esculturaRepository;

    @Autowired
    private ArtistaServiceClient artistaServiceClient;

    // ========== MÉTODOS CON DTOs ==========

    @Override
    public ObraArteResponseDTO crearPinturaConDTO(ObraArteRequestDTO requestDTO) {
        // Validar artista usando RestTemplate (NO Feign)
        if (!artistaServiceClient.validarArtista(requestDTO.getAutor())) {
            throw new RuntimeException("El artista '" + requestDTO.getAutor() + "' no existe en el sistema.");
        }

        // Crear pintura desde DTO
        Pintura pintura = new Pintura();
        pintura.setTitulo(requestDTO.getTitulo());
        pintura.setAutor(requestDTO.getAutor());
        pintura.setPrecio(requestDTO.getPrecio());
        pintura.setEstado(requestDTO.getEstado() != null ? requestDTO.getEstado() : "Activo");
        pintura.setTecnica(requestDTO.getTecnica());
        pintura.setTextura(requestDTO.getTextura());
        pintura.setTipo("Pintura");

        Pintura savedPintura = pinturaRepository.save(pintura);

        // Convertir a ResponseDTO y enriquecer con artista
        return enriquecerConArtista(savedPintura);
    }

    @Override
    public ObraArteResponseDTO crearEsculturaConDTO(ObraArteRequestDTO requestDTO) {
        // Validar artista usando RestTemplate (NO Feign)
        if (!artistaServiceClient.validarArtista(requestDTO.getAutor())) {
            throw new RuntimeException("El artista '" + requestDTO.getAutor() + "' no existe en el sistema.");
        }

        // Crear escultura desde DTO
        Escultura escultura = new Escultura();
        escultura.setTitulo(requestDTO.getTitulo());
        escultura.setAutor(requestDTO.getAutor());
        escultura.setPrecio(requestDTO.getPrecio());
        escultura.setEstado(requestDTO.getEstado() != null ? requestDTO.getEstado() : "Activo");
        escultura.setAltura(requestDTO.getAltura());
        escultura.setVolumen(requestDTO.getVolumen());
        escultura.setMaterial(requestDTO.getMaterial());
        escultura.setTipoEscultura(requestDTO.getTipoEscultura());
        escultura.setTipo("Escultura");

        Escultura savedEscultura = esculturaRepository.save(escultura);

        // Convertir a ResponseDTO y enriquecer con artista
        return enriquecerConArtista(savedEscultura);
    }

    @Override
    public ObraArteResponseDTO obtenerObraConArtista(Integer id) {
        // Buscar en ambos repositorios
        Optional<Pintura> pintura = pinturaRepository.findById(id);
        if (pintura.isPresent()) {
            return enriquecerConArtista(pintura.get());
        }

        Optional<Escultura> escultura = esculturaRepository.findById(id);
        if (escultura.isPresent()) {
            return enriquecerConArtista(escultura.get());
        }

        throw new RuntimeException("Obra no encontrada con ID: " + id);
    }

    @Override
    public List<ObraArteResponseDTO> listarTodasLasObrasConArtista() {
        List<ObraArteResponseDTO> resultados = new ArrayList<>();

        // Obtener y enriquecer pinturas
        List<Pintura> pinturas = pinturaRepository.findAll();
        for (Pintura pintura : pinturas) {
            resultados.add(enriquecerConArtista(pintura));
        }

        // Obtener y enriquecer esculturas
        List<Escultura> esculturas = esculturaRepository.findAll();
        for (Escultura escultura : esculturas) {
            resultados.add(enriquecerConArtista(escultura));
        }

        return resultados;
    }

    @Override
    public List<ObraArteResponseDTO> buscarObrasPorAutorConArtista(String autor) {
        List<ObraArteResponseDTO> resultados = new ArrayList<>();

        // Buscar y enriquecer pinturas
        List<Pintura> pinturas = pinturaRepository.findByAutorContainingIgnoreCase(autor);
        for (Pintura pintura : pinturas) {
            resultados.add(enriquecerConArtista(pintura));
        }

        // Buscar y enriquecer esculturas
        List<Escultura> esculturas = esculturaRepository.findByAutorContainingIgnoreCase(autor);
        for (Escultura escultura : esculturas) {
            resultados.add(enriquecerConArtista(escultura));
        }

        return resultados;
    }

    // ========== MÉTODO PRIVADO PARA ENRIQUECER CON ARTISTA ==========

    private ObraArteResponseDTO enriquecerConArtista(ObraArte obraArte) {
        ObraArteResponseDTO responseDTO = new ObraArteResponseDTO();

        // Mapeo manual de los campos básicos
        responseDTO.setId(obraArte.getId());
        responseDTO.setTitulo(obraArte.getTitulo());
        responseDTO.setPrecio(obraArte.getPrecio());
        responseDTO.setEstado(obraArte.getEstado());
        responseDTO.setFechaIngreso(obraArte.getFechaIngreso());
        responseDTO.setTipo(obraArte.getTipo());

        // Mapeo de campos específicos según el tipo
        if (obraArte instanceof Pintura) {
            Pintura pintura = (Pintura) obraArte;
            responseDTO.setTecnica(pintura.getTecnica());
            responseDTO.setTextura(pintura.getTextura());
        } else if (obraArte instanceof Escultura) {
            Escultura escultura = (Escultura) obraArte;
            responseDTO.setAltura(escultura.getAltura());
            responseDTO.setVolumen(escultura.getVolumen());
            responseDTO.setMaterial(escultura.getMaterial());
            responseDTO.setTipoEscultura(escultura.getTipoEscultura());
        }

        // Enriquecer con información del artista usando RestTemplate (NO Feign)
        try {
            ArtistaDTO artista = artistaServiceClient.obtenerArtistaPorNombre(obraArte.getAutor());
            if (artista != null) {
                responseDTO.setArtista(artista);
            }
        } catch (Exception e) {
            // Si hay error al obtener artista, continuar sin esa información
            System.err.println("Error al obtener información del artista: " + e.getMessage());
        }

        return responseDTO;
    }

    // ========== MÉTODOS ORIGINALES (sin cambios) ==========

    @Override
    public Pintura crearPintura(Pintura pintura) {
        if (!artistaServiceClient.validarArtista(pintura.getAutor())) {
            throw new RuntimeException("El artista '" + pintura.getAutor() + "' no existe en el sistema. Debe registrarlo primero.");
        }
        pintura.setTipo("Pintura");
        return pinturaRepository.save(pintura);
    }

    @Override
    @Transactional(readOnly = true)
    public Optional<Pintura> obtenerPinturaPorId(Integer id) {
        return pinturaRepository.findById(id);
    }

    @Override
    @Transactional(readOnly = true)
    public List<Pintura> listarTodasPinturas() {
        return pinturaRepository.findAll();
    }

    @Override
    @Transactional(readOnly = true)
    public List<Pintura> buscarPinturasPorAutor(String autor) {
        return pinturaRepository.findByAutorContainingIgnoreCase(autor);
    }

    @Override
    @Transactional(readOnly = true)
    public List<Pintura> buscarPinturasPorTitulo(String titulo) {
        return pinturaRepository.findByTituloContainingIgnoreCase(titulo);
    }

    @Override
    public Pintura actualizarPintura(Integer id, Pintura pinturaActualizada) {
        Optional<Pintura> pinturaExistente = pinturaRepository.findById(id);
        if (pinturaExistente.isPresent()) {
            Pintura pintura = pinturaExistente.get();
            pintura.setTitulo(pinturaActualizada.getTitulo());
            pintura.setAutor(pinturaActualizada.getAutor());
            pintura.setPrecio(pinturaActualizada.getPrecio());
            pintura.setEstado(pinturaActualizada.getEstado());
            pintura.setTecnica(pinturaActualizada.getTecnica());
            pintura.setTextura(pinturaActualizada.getTextura());
            return pinturaRepository.save(pintura);
        }
        throw new RuntimeException("Pintura no encontrada con ID: " + id);
    }

    @Override
    public void eliminarPintura(Integer id) {
        pinturaRepository.deleteById(id);
    }

    // ========== ESCULTURAS ==========
    @Override
    public Escultura crearEscultura(Escultura escultura) {
        if (!artistaServiceClient.validarArtista(escultura.getAutor())) {
            throw new RuntimeException("El artista '" + escultura.getAutor() + "' no existe en el sistema. Debe registrarlo primero.");
        }
        escultura.setTipo("Escultura");
        return esculturaRepository.save(escultura);
    }

    @Override
    @Transactional(readOnly = true)
    public Optional<Escultura> obtenerEsculturaPorId(Integer id) {
        return esculturaRepository.findById(id);
    }

    @Override
    @Transactional(readOnly = true)
    public List<Escultura> listarTodasEsculturas() {
        return esculturaRepository.findAll();
    }

    @Override
    @Transactional(readOnly = true)
    public List<Escultura> buscarEsculturasPorAutor(String autor) {
        return esculturaRepository.findByAutorContainingIgnoreCase(autor);
    }

    @Override
    @Transactional(readOnly = true)
    public List<Escultura> buscarEsculturasPorTitulo(String titulo) {
        return esculturaRepository.findByTituloContainingIgnoreCase(titulo);
    }

    @Override
    public Escultura actualizarEscultura(Integer id, Escultura esculturaActualizada) {
        Optional<Escultura> esculturaExistente = esculturaRepository.findById(id);
        if (esculturaExistente.isPresent()) {
            Escultura escultura = esculturaExistente.get();
            escultura.setTitulo(esculturaActualizada.getTitulo());
            escultura.setAutor(esculturaActualizada.getAutor());
            escultura.setPrecio(esculturaActualizada.getPrecio());
            escultura.setEstado(esculturaActualizada.getEstado());
            escultura.setAltura(esculturaActualizada.getAltura());
            escultura.setVolumen(esculturaActualizada.getVolumen());
            escultura.setMaterial(esculturaActualizada.getMaterial());
            escultura.setTipoEscultura(esculturaActualizada.getTipoEscultura());
            return esculturaRepository.save(escultura);
        }
        throw new RuntimeException("Escultura no encontrada con ID: " + id);
    }

    @Override
    public void eliminarEscultura(Integer id) {
        esculturaRepository.deleteById(id);
    }

    // ========== BÚSQUEDAS COMBINADAS ==========
    @Override
    @Transactional(readOnly = true)
    public List<Object> buscarObrasPorAutor(String autor) {
        List<Object> resultados = new ArrayList<>();
        resultados.addAll(pinturaRepository.findByAutorContainingIgnoreCase(autor));
        resultados.addAll(esculturaRepository.findByAutorContainingIgnoreCase(autor));
        return resultados;
    }

    @Override
    @Transactional(readOnly = true)
    public List<Object> buscarObrasPorTitulo(String titulo) {
        List<Object> resultados = new ArrayList<>();
        resultados.addAll(pinturaRepository.findByTituloContainingIgnoreCase(titulo));
        resultados.addAll(esculturaRepository.findByTituloContainingIgnoreCase(titulo));
        return resultados;
    }

    @Override
    @Transactional(readOnly = true)
    public List<Object> listarTodasLasObras() {
        List<Object> todasLasObras = new ArrayList<>();
        todasLasObras.addAll(pinturaRepository.findAll());
        todasLasObras.addAll(esculturaRepository.findAll());
        return todasLasObras;
    }

    @Override
    public List<Object> buscarObrasActivas() {
        return List.of();
    }
}
