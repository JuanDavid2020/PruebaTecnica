package com.prueba.prueba.Interface;

import org.springframework.data.repository.CrudRepository;

import com.prueba.prueba.Model.discounts;

public interface discountsInterface extends CrudRepository<discounts, Integer> {

    // @Query(value="SELECT id,Console,MinimalPrice,MaximumPrice,Discount FROM
    // discounts",nativeQuery = true)
    // List<discounts> GetDiscounts();

}
