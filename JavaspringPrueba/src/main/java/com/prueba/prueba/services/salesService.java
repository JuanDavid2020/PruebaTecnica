package com.prueba.prueba.services;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.stereotype.Component;

import com.prueba.prueba.Repository.salesRepository;

@Component
@Service
public class salesService {

    @Autowired
    private salesRepository saleservices;

}
