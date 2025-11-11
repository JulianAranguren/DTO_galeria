package com.mycompany.GaleriaArteBD;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.ComponentScan;

@SpringBootApplication
@ComponentScan(basePackages = "com.mycompany.GaleriaArteBD")
public class GaleriaArteBdApplication {

    public static void main(String[] args) {
        SpringApplication.run(GaleriaArteBdApplication.class, args);
    }
}
