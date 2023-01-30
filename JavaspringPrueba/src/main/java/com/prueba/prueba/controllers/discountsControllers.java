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

import com.prueba.prueba.Model.discounts;
import com.prueba.prueba.services.discountsService;

import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseStatus;
import org.springframework.http.HttpStatus;

@RestController
@RequestMapping("/api")
@CrossOrigin(origins = "*", methods = { RequestMethod.GET, RequestMethod.POST, RequestMethod.PUT,
        RequestMethod.DELETE })
public class discountsControllers {

    @Autowired
    private discountsService discountsController;

    @GetMapping("/GetAllDiscounts")
    @ResponseStatus(HttpStatus.OK)
    public List<discounts> GetAllDiscounts() {
        return discountsController.GetAllDiscounts();
    }

    @GetMapping("/GetAllDiscounts/{id}")
    @ResponseStatus(HttpStatus.OK)
    public Optional<discounts> GetDiscountsDetails(@PathVariable("id") Integer id) {
        return discountsController.GetDiscountsDetails(id);
    }

    @PostMapping("/InsertDiscounts")
    @ResponseStatus(HttpStatus.OK)
    public discounts InsertDiscounts(@RequestBody discounts discount) {
        return discountsController.InsertDiscounts(discount);
    }

    @DeleteMapping("/DeleteDiscounts/{id}")
    @ResponseStatus(HttpStatus.OK)
    public String InsertDiscounts(@PathVariable("id") Integer id) {
        return discountsController.DeleteDiscounts(id);
    }

    @PutMapping("/UpdateDiscounts")
    @ResponseStatus(HttpStatus.OK)
    public String UpdateDiscounts(@RequestBody discounts discount) {
        return discountsController.UpdateDiscounts(discount);
    }

}
