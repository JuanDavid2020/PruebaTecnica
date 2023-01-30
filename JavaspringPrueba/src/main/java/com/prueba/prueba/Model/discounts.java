package com.prueba.prueba.Model;

import java.io.Serializable;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name = "discounts")
public class discounts implements Serializable {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer Id;

    private String Console;

    private float MinimalPrice;

    private float MaximumPrice;

    private float Discount;

    public Integer getId() {
        return Id;
    }

    public void setId(int id) {
        Id = id;
    }

    public String getConsole() {
        return Console;
    }

    public void setConsole(String console) {
        Console = console;
    }

    public float getMinimalPrice() {
        return MinimalPrice;
    }

    public void setMinimalPrice(float minimalPrice) {
        MinimalPrice = minimalPrice;
    }

    public float getMaximumPrice() {
        return MaximumPrice;
    }

    public void setMaximumPrice(float maximumPrice) {
        MaximumPrice = maximumPrice;
    }

    public float getDiscount() {
        return Discount;
    }

    public void setDiscount(float discount) {
        Discount = discount;
    }

}
