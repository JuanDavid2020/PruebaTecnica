package com.prueba.prueba.Repository;

import java.util.List;
import java.util.Optional;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import com.prueba.prueba.Interface.discountsInterface;
import com.prueba.prueba.Model.discounts;

@Repository
public class discountsRepository {

    @Autowired
    private discountsInterface discountsCRUD;

    public List<discounts> GetAllDiscounts() {
        return (List<discounts>) discountsCRUD.findAll();
    }

    public Optional<discounts> GetDiscountsDetails(Integer id) {
        return discountsCRUD.findById(id);
    }

    public discounts InsertDiscounts(discounts discount) {
        return discountsCRUD.save(discount);
    }

    public discounts UpdateDiscounts(discounts discount) {
        return discountsCRUD.save(discount);
    }

    public void DeleteDiscounts(Integer id) {
        discountsCRUD.deleteById(id);
    }
}
