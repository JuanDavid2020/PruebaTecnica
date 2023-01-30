package com.prueba.prueba.Model;

import java.io.Serializable;
import java.sql.Date;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name = "Sales")
public class sales implements Serializable {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    public Integer IdSales;

    public String DescriptionSale;

    public float SaleValue;

    public float QuantityProducts;

    public Date SaleDate;

    public String DiscountSale;

    public Integer getIdSales() {
        return IdSales;
    }

    public void setIdSales(Integer idSales) {
        IdSales = idSales;
    }

    public String getDescriptionSale() {
        return DescriptionSale;
    }

    public void setDescriptionSale(String descriptionSale) {
        DescriptionSale = descriptionSale;
    }

    public float getSaleValue() {
        return SaleValue;
    }

    public void setSaleValue(float saleValue) {
        SaleValue = saleValue;
    }

    public float getQuantityProducts() {
        return QuantityProducts;
    }

    public void setQuantityProducts(float quantityProducts) {
        QuantityProducts = quantityProducts;
    }

    public Date getSaleDate() {
        return SaleDate;
    }

    public void setSaleDate(Date saleDate) {
        SaleDate = saleDate;
    }

    public String getDiscountSale() {
        return DiscountSale;
    }

    public void setDiscountSale(String discountSale) {
        DiscountSale = discountSale;
    }

}
