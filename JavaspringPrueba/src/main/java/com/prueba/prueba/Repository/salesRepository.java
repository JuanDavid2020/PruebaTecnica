package com.prueba.prueba.Repository;

import java.util.List;
import java.util.Optional;
import org.springframework.beans.factory.annotation.Autowired;
import com.prueba.prueba.Interface.salesInterface;
import com.prueba.prueba.Model.sales;

public class salesRepository {

    @Autowired
    private salesInterface salesCRUD;

    public List<sales> GetAllsales() {
        return (List<sales>) salesCRUD.findAll();
    }

    public Optional<sales> GetsalesDetails(Integer id) {
        return salesCRUD.findById(id);
    }

    public sales Insertsales(sales discount) {
        return salesCRUD.save(discount);
    }

    public sales Updatesales(sales discount) {
        return salesCRUD.save(discount);
    }

    public void Deletesales(Integer id) {
        salesCRUD.deleteById(id);
    }

    // public float SumSales(String type) {
    // return salesCRUD.SumSales(type);
    // }

    /*
     * public float ReturnLastSale() {
     * return salesCRUD.ReturnLastSale();
     * }
     */

}
