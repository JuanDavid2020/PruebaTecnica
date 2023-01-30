package com.prueba.prueba.controllers;

import java.util.List;
import java.util.Optional;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import com.prueba.prueba.Model.sales;
import com.prueba.prueba.services.salesService;

import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseStatus;
import org.springframework.http.HttpStatus;

@RestController
@RequestMapping("/api")
@CrossOrigin(origins = "*", methods = { RequestMethod.GET, RequestMethod.POST, RequestMethod.PUT,
                RequestMethod.DELETE })
public class salesControllers {

        @Autowired
        private salesService salesController;

        @GetMapping("/GetAllsales")

        @ResponseStatus(HttpStatus.OK)
        public List<sales> GetAllsales() {
                return salesController.GetAllsales();
        }

        @GetMapping("/GetAllsales/{id}")

        @ResponseStatus(HttpStatus.OK)
        public Optional<sales> GetsalesDetails(@PathVariable("id") Integer id) {
                return salesController.GetsalesDetails(id);
        }

        @PostMapping("/Insertsales")

        @ResponseStatus(HttpStatus.OK)
        public sales Insertsales(@RequestBody sales sale) {
                return salesController.Insertsales(sale);
        }

        @DeleteMapping("/Deletesales/{id}")

        @ResponseStatus(HttpStatus.OK)
        public String Insertsales(@PathVariable("id") Integer id) {
                return salesController.Deletesales(id);
        }

        @PutMapping("/Updatesales")

        @ResponseStatus(HttpStatus.OK)
        public String Updatesales(@RequestBody sales sale) {
                return salesController.Updatesales(sale);
        }

}
