package com.nghia3;

import com.nghia3.controller.CustomerController;

public class Main {

    public static void main(String[] args) {
        System.out.println("JDBC Demo");

        try {

            CustomerController customerController = new CustomerController();
//            Customer customer = new Customer(4,"Nguyen Thi Huong", "Hanoi", "Vietnam", "0984336748", "huong2k4@gmail.com");
//            customerController.addNewCustomer(customer);
//            customerController.updateCustomerCity(3, "Dong Anh");

//            customerController.deleteCustomer(4);

            customerController.getCustomerById(3);

        } catch (Exception e) {

        }
    }

}
