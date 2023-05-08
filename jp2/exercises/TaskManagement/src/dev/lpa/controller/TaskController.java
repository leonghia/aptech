package dev.lpa.controller;

import dev.lpa.Task;
import dev.lpa.Type;
import dev.lpa.util.DBConnection;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.ResultSet;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

public class TaskController {

    public static boolean addTask(Task task) {

        Connection conn = null;
        CallableStatement stmt = null;
        boolean isSuccessful = false;

        try {
            conn = DBConnection.getConnection();
            stmt = conn.prepareCall("{call addTask(?, ?, ?, ?, ?, ?)}");

            stmt.setString(1, task.getName());
            List<Type> types = TypeController.getTypes();
            int typeId = TypeController.getTypeId(task.getType());
            stmt.setInt(2, typeId);
            SimpleDateFormat simpleDateFormat = new SimpleDateFormat("dd/MM/yyyy");
            Date parsed = simpleDateFormat.parse(task.getDate());
            java.sql.Date sqlDate = new java.sql.Date(parsed.getTime());
            stmt.setDate(3, sqlDate);
            stmt.setString(4, task.getAssignee());
            stmt.setString(5, task.getReviewer());
            stmt.setDouble(6, task.getTime());

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

    public static boolean deleteTask(int id) {

        Connection conn = null;
        CallableStatement stmt = null;
        boolean isSuccessful = false;

        try {
            conn = DBConnection.getConnection();
            stmt = conn.prepareCall("{call deleteTask(?)}");

            stmt.setInt(1, id);

            stmt.executeUpdate();
            isSuccessful = true;

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

    public static List<Task> getTasks() {

        List<Task> tasks = new ArrayList<>();
        Connection conn = null;
        CallableStatement stmt = null;

        try {
            conn = DBConnection.getConnection();
            stmt = conn.prepareCall("{call getTasks}");

            ResultSet resultSet = stmt.executeQuery();

            while (resultSet.next()) {
                int id = resultSet.getInt(1);
                String name = resultSet.getString(2);
                String typeName = resultSet.getString(3);
                Date date = resultSet.getDate(4);
                double time = resultSet.getDouble(5);
                String assignee = resultSet.getString(6);
                String reviewer = resultSet.getString(7);


                String dateString = date.toString();

                Task task = new Task(id, name, typeName, dateString, time, assignee, reviewer);
                tasks.add(task);
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
        return tasks;
    }


}
