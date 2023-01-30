package com.prueba.prueba.services;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import com.prueba.prueba.Model.discounts;
import com.prueba.prueba.Repository.discountsRepository;

@Service
public class discountsService {

    @Autowired
    private discountsRepository discountservices;

    public List<discounts> GetAllDiscounts() {
        return discountservices.GetAllDiscounts();
    }

    public Optional<discounts> GetDiscountsDetails(Integer id) {
        return discountservices.GetDiscountsDetails(id);
    }

    public discounts InsertDiscounts(discounts discount) {

        if (!discount.getConsole().isEmpty()) {
            return discountservices.InsertDiscounts(discount);
        }
        return discount;
    }

    public String DeleteDiscounts(Integer id) {

        Optional<discounts> discount = discountservices.GetDiscountsDetails(id);
        if (!discount.isEmpty()) {
            discountservices.DeleteDiscounts(id);
            return "Registro Eliminado";
        }

        return "Registro No encontrado";
    }

    public String UpdateDiscounts(discounts discount) {

        Optional<discounts> discount1 = discountservices.GetDiscountsDetails(discount.getId());

        if (!discount1.isEmpty()) {
            discountservices.UpdateDiscounts(discount);
            return "Registro Actualizado";
        }

        return "Registro No encontrado";
    }
}
