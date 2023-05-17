package com.nghia3;

import java.io.Serializable;

public class Customer implements Serializable {

    private final int id;
    private final String name;
    private String city;
    private String country;
    private String phone;
    private String email;

    public Customer(String name, String city, String country, String phone, String email) {
        id = 0;
        this.name = name;
        this.city = city;
        this.country = country;
        this.phone = phone;
        this.email = email;
    }

    public Customer(int id, String name, String city, String country, String phone, String email) {
        this.id = id;
        this.name = name;
        this.city = city;
        this.country = country;
        this.phone = phone;
        this.email = email;
    }

    public int getId() {
        return id;
    }

    public String getName() {
        return name;
    }

    public String getCity() {
        return city;
    }

    public String getCountry() {
        return country;
    }

    public String getPhone() {
        return phone;
    }

    public String getEmail() {
        return email;
    }

    @Override
    public String toString() {
        return "Customer{" +
                "name='" + name + '\'' +
                ", city='" + city + '\'' +
                ", country='" + country + '\'' +
                ", phone='" + phone + '\'' +
                ", email='" + email + '\'' +
                '}';
    }
}
