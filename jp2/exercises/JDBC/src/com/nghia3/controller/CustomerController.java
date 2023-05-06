package com.nghia3.controller;

import com.nghia3.Customer;
import com.nghia3.util.DBUtil;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.Types;
import java.util.LinkedHashMap;
import java.util.Map;

public class CustomerController {

    public static Map<Integer, Customer> getCustomers() {

        Connection conn = null;
        CallableStatement stmt = null;

        Map<Integer, Customer> customers = new LinkedHashMap<>();

        try {
            conn = DBUtil.getConnection();
            stmt = conn.prepareCall("{call getCustomers}");

            ResultSet rs = stmt.executeQuery();

            while (rs.next()) {
                int id = rs.getInt(1);
                String name = rs.getString(2);
                String city = rs.getString(3);
                String country = rs.getString(4);
                String phone = rs.getString(5);
                String email = rs.getString(6);
                Customer customer = new Customer(id, name, city, country, phone, email);
                customers.put(id, customer);
            }
            rs.close();
        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            try {
                stmt.close();
                conn.close();
            } catch (Exception e) {
                e.printStackTrace();
            }
        }
        return customers;
    }

    public static boolean addNewCustomer(Customer customer) {

        Connection conn = null;
        CallableStatement stmt = null;
        boolean isSuccessful = false;

        try {
            conn = DBUtil.getConnection();
            stmt = conn.prepareCall("{call addNewCustomer(?, ?, ? , ?, ?)}");
            stmt.setString(1, customer.getName());
            stmt.setString(2, customer.getCity());
            stmt.setString(3, customer.getCountry());
            stmt.setString(4, customer.getPhone());
            stmt.setString(5, customer.getEmail());

            if (stmt.executeUpdate() > 0) {
                isSuccessful = true;
            }
        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            try {
                stmt.close();
                conn.close();
            } catch (Exception e) {
                e.printStackTrace();
            }
        }
        return isSuccessful;
    }

    public static boolean deleteCustomer(int id) {

        Connection conn = null;
        CallableStatement stmt = null;
        boolean isSuccessful = false;

        try {
            conn = DBUtil.getConnection();
            stmt = conn.prepareCall("{call deleteCustomer(?)}");
            stmt.setInt(1, id);

            if (stmt.executeUpdate() > 0) {
                isSuccessful = true;
            }
        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            try {
                stmt.close();
                conn.close();
            } catch (Exception e) {
                e.printStackTrace();
            }
        }
        return isSuccessful;
    }

    public static boolean updateCustomer(Customer customer) {

        Connection conn = null;
        CallableStatement stmt = null;
        boolean isSuccessful = false;

        int id = customer.getId();
        String name = customer.getName();
        String city = customer.getCity();
        String country = customer.getCountry();
        String phone = customer.getPhone();
        String email = customer.getEmail();

        try {
            conn = DBUtil.getConnection();
            stmt = conn.prepareCall("{call updateCustomer(?, ?, ?, ?, ?, ?)}");
            stmt.setInt(1, id);

            if (name.isEmpty()) {
                stmt.setNull(2, Types.NVARCHAR);
            } else {
                stmt.setString(2, name);
            }

            if (city.isEmpty()) {
                stmt.setNull(3, Types.NVARCHAR);
            } else {
                stmt.setString(3, city);
            }

            if (country.isEmpty()) {
                stmt.setNull(4, Types.NVARCHAR);
            } else {
                stmt.setString(4, country);
            }

            if (phone.isEmpty()) {
                stmt.setNull(5, Types.NVARCHAR);
            } else {
                stmt.setString(5, phone);
            }

            if (email.isEmpty()) {
                stmt.setNull(6, Types.NVARCHAR);
            } else {
                stmt.setString(6, email);
            }

            if (stmt.executeUpdate() > 0) {
                isSuccessful = true;
            }
        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            try {
                stmt.close();
                conn.close();
            } catch (Exception e) {
                e.printStackTrace();
            }
        }
        return isSuccessful;
    }



}
