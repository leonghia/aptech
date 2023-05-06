package dev.lpa.controller;

import dev.lpa.Type;
import dev.lpa.util.DBConnection;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.ResultSet;
import java.util.ArrayList;
import java.util.List;

public class TypeController {

    public static boolean addType(Type type) {

        Connection connection = null;
        CallableStatement callableStatement = null;
        boolean isSuccessful = false;

        try {
            connection = DBConnection.getConnection();
            callableStatement = connection.prepareCall("{call addType(?)}");

            callableStatement.setString(1, type.getName());

            if (callableStatement.executeUpdate() > 0) {
                isSuccessful = true;
            }
        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            try {
                callableStatement.close();
                connection.close();
            } catch (Exception e) {
                e.printStackTrace();
            }
        }
        return isSuccessful;
    }

    public static boolean deleteType(int id) {

        Connection conn = null;
        CallableStatement stmt = null;
        boolean isSuccessful = false;

        try {
            conn = DBConnection.getConnection();
            stmt = conn.prepareCall("{call deleteType(?)}");

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

    public static List<Type> getTypes() {

        Connection conn = null;
        CallableStatement stmt = null;
        List<Type> types = new ArrayList<>();

        try {
            conn = DBConnection.getConnection();
            stmt = conn.prepareCall("{call getTypes}");

            ResultSet resultSet = stmt.executeQuery();

            while (resultSet.next()) {
                int id = resultSet.getInt(1);
                String name = resultSet.getString(2);

                Type type = new Type(id, name);
                types.add(type);
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
        return types;
    }

    public static int getTypeId(String name) {

        Connection conn = null;
        CallableStatement stmt = null;
        int result = -1;

        try {

            conn = DBConnection.getConnection();
            stmt = conn.prepareCall("{call getTypeId(?)}");
            stmt.setString(1, name);

            ResultSet resultSet = stmt.executeQuery();
            if (resultSet.next()) {
                result = resultSet.getInt(1);
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
        return result;
    }
}
