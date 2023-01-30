package com.prueba.prueba.Interface;

import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.CrudRepository;

import com.prueba.prueba.Model.sales;

public interface salesInterface extends CrudRepository<sales, Integer> {

    @Query(value = "SELECT sum(sale_value) as Valor_Total_Sales_Con_Descuento FROM sales WHERE discount_sale=:type", nativeQuery = true)
    float SumSales(String type);

    // @Query(value = "SELECT SaleValue as ValorCobrarCliente FROM sales order by
    // SaleDate desc LIMIT 1", nativeQuery = true)
    // float ReturnLastSale();

}
