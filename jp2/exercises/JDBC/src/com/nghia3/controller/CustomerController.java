package com.nghia3.controller;

import com.nghia3.Customer;
import com.nghia3.util.DBUtil;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.Statement;

public class CustomerController {

    public void addNewCustomer(Customer customer) throws Exception {

        try {
            Connection conn = DBUtil.getConnection();
            PreparedStatement preparedStatement = conn.prepareStatement(
                    "INSERT INTO Customer(CustomerId, Name, City, Country, Phone, Email) VALUES (?, ?, ?, ?, ?, ?)"
            );
            preparedStatement.setInt(1, customer.getId());
            preparedStatement.setString(2, customer.getName());
            preparedStatement.setString(3, customer.getCity());
            preparedStatement.setString(4, customer.getCountry());
            preparedStatement.setString(5, customer.getPhone());
            preparedStatement.setString(6, customer.getEmail());

            int updated = preparedStatement.executeUpdate();

            if (updated > 0) {
                System.out.println("Inserted successfully");
            }

            preparedStatement.close();
            conn.close();
        } catch (Exception e) {
            throw new Exception(e.getMessage());
        }
    }

    public void getAllCustomers() {

        try {

            // 1. Register JDBC & Create connection
            Connection conn = DBUtil.getConnection();

            // 2. Create statement
            Statement statement = conn.createStatement();

            // 3. Execute statement
            ResultSet resultSet = statement.executeQuery("SELECT * FROM Customer");

            while (resultSet.next()) {
                System.out.println("=".repeat(20) + " Customer " + "=".repeat(20));
                Customer customer = new Customer(
                        resultSet.getInt(1),
                        resultSet.getString(2),
                        resultSet.getString(3),
                        resultSet.getString(4),
                        resultSet.getString(5),
                        resultSet.getString(6)
                );

                System.out.println(customer);
            }

            resultSet.close();
            statement.close();
            conn.close();

        } catch (Exception e) {
            System.out.println(e.getMessage());
        }
    }

    public void updateCustomerCity(int id, String city) throws Exception {

        try {

            Connection conn = DBUtil.getConnection();
            PreparedStatement preparedStatement = conn.prepareStatement("""
                    UPDATE Customer
                    SET City = ?
                    WHERE CustomerId = ?""");
            preparedStatement.setString(1, city);
            preparedStatement.setInt(2, id);

            int updated = preparedStatement.executeUpdate();
            if (updated > 0) {
                System.out.println("Updated customer successfully");
            }

            preparedStatement.close();
            conn.close();

        } catch (Exception e) {
            throw new Exception(e.getMessage());
        }
    }

    public void deleteCustomer(int id) throws Exception {

        try {

            Connection conn = DBUtil.getConnection();
            PreparedStatement preparedStatement = conn.prepareStatement("""
                    DELETE FROM Customer
                    WHERE CustomerId = ?""");
            preparedStatement.setInt(1, id);

            int updated = preparedStatement.executeUpdate();
            if (updated > 0) {
                System.out.println("Deleted customer successfully");
            }

            preparedStatement.close();
            conn.close();

        } catch (Exception e) {
            throw new Exception(e.getMessage());
        }
    }

    public void getCustomerById(int id) {

        try {

            Connection conn = DBUtil.getConnection();
            PreparedStatement preparedStatement = conn.prepareStatement("""
                    SELECT * FROM Customer
                    WHERE CustomerId = ?""");
            preparedStatement.setInt(1, id);

            ResultSet resultSet = preparedStatement.executeQuery();

            System.out.println("=".repeat(20) + " Result " + "=".repeat(20));
            while (resultSet.next()) {
                Customer customer = new Customer(
                        resultSet.getInt(1),
                        resultSet.getString(2),
                        resultSet.getString(3),
                        resultSet.getString(4),
                        resultSet.getString(5),
                        resultSet.getString(6)
                );
                System.out.println(customer);
            }

            resultSet.close();
            preparedStatement.close();
            conn.close();

        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
