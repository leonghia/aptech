package dev.lpa;

import dev.lpa.controller.TaskController;
import dev.lpa.controller.TypeController;

import java.io.*;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Collections;
import java.util.List;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Management {

    private List<Type> types;
    private List<Task> tasks;

    public Management() {
        types = TypeController.getTypes();
        tasks = TaskController.getTasks();
    }

    public boolean addType(String name) throws Exception {
        String rawPattern = "^[a-zA-Z]*$";
        if (name.isEmpty()) {
            throw new Exception("Ten danh muc khong duoc de trong");
        }
        if (!isMatchingRegex(name, rawPattern)) {
            throw new Exception("Ten danh muc phai chua chu cai A – Z");
        }
        if (isTypeDuplicated(name)) {
            throw new Exception("Ten danh muc da ton tai");
        }
        Type type = new Type(name);
        if (TypeController.addType(type)) {
            System.out.println("Da them thanh cong: " + type);
            refreshTypes();
            return true;
        }
        return false;
    }

    public boolean deleteType(String id) throws Exception {
        int idNum;
        try {
            idNum = Integer.parseInt(id);
        } catch (NumberFormatException numberFormatException) {
            throw new Exception("Sai dinh dang ID");
        }
        Type type = findType(idNum);
        if (type == null) {
            throw new Exception("Khong tim thay danh muc");
        }
        if (TypeController.deleteType(idNum)) {
            System.out.println("Da xoa thanh cong: " + type);
            refreshTypes();
            return true;
        }
        return false;
    }

    public List<Type> getTypes() {
        return Collections.unmodifiableList(types);
    }

    public boolean addTask(String requirementName, String assignee, String reviewer, String typeID, String date, String planFrom, String planTo) throws Exception {
        String rawPattern = "^[a-zA-Z ]*$";
        if (!isMatchingRegex(requirementName, rawPattern) || !isMatchingRegex(assignee, rawPattern) || !isMatchingRegex(reviewer, rawPattern)) {
            throw new Exception("Ten cong viec hoac ten nguoi phai chua chu cai A – Z");
        }
        int taskTypeIDNum;
        try {
             taskTypeIDNum = Integer.parseInt(typeID);
        } catch (NumberFormatException numberFormatException) {
            throw new Exception("Sai dinh dang ID");
        }
        String taskTypeName;
        try {
            taskTypeName = findType(taskTypeIDNum).getName();
        } catch (NullPointerException nullPointerException) {
            throw new Exception("Khong tim thay danh muc");
        }
        SimpleDateFormat simpleDateFormat = new SimpleDateFormat("dd/MM/yyyy");
        simpleDateFormat.setLenient(false);
        try {
            simpleDateFormat.parse(date);
        } catch (ParseException parseException) {
            throw new Exception("Sai dinh dang ngay (dd/MM/yyyy)");
        }
        Double from, to, time;
        try {
            from = Double.parseDouble(planFrom);
            to = Double.parseDouble(planTo);
        } catch (NumberFormatException numberFormatException) {
            throw new Exception("Sai dinh dang thoi gian");
        }
        if (!isTimeValid(from) || !isTimeValid(to)) {
            throw new Exception("Thoi gian phai >= 0h hoac < 24h");
        }
        if (from < to) {
            time = to - from;
        } else if (from > to) {
            time = (24.0 - from) + (to - 0.0);
        } else {
            throw new Exception("Thoi gian bat dau va thoi gian ket thuc khong duoc trung nhau");
        }
        Task task = new Task(requirementName, taskTypeName, date, time, assignee, reviewer);
        if (TaskController.addTask(task)) {
            System.out.println("Da them thanh cong: " + task);
            refreshTasks();
            return true;
        }
        return false;
    }

    public boolean deleteTask(String id) throws Exception {
        int idNum;
        try {
            idNum = Integer.parseInt(id);
        } catch (NumberFormatException numberFormatException) {
            throw new Exception("Sai dinh dang ID");
        }
        Task task = findTask(idNum);
        if (task == null) {
            throw new Exception("Khong tim thay cong viec");
        }
        if (TaskController.deleteTask(idNum)) {
            System.out.println("Da xoa thanh cong: " + task);
            refreshTasks();
            return true;
        }
        return false;
    }

    public List<Task> getTasks() {
        return tasks;
    }

    private Type findType(int id) {
        for (Type type : types) {
            if (type.getId() == id) {
                return type;
            }
        }
        return null;
    }

    private Task findTask(int id) {
        for (Task task : tasks) {
            if (task.getId() == id) {
                return task;
            }
        }
        return null;
    }

    private boolean isTypeDuplicated(String name) {
        for (Type type : types) {
            if (type.getName().equalsIgnoreCase(name)) {
                return true;
            }
        }
        return false;
    }

    private boolean isTimeValid(double time) {
        return (time >= 0 && time < 24);
    }

    private static boolean isMatchingRegex(String input, String rawPattern) {
        Pattern pattern = Pattern.compile(rawPattern);
        Matcher matcher = pattern.matcher(input);
        return matcher.matches();
    }

    public static Type getTypeId(String name, List<Type> types) {
        for (Type type : types) {
            if (type.getName().equalsIgnoreCase(name)) {
                return type;
            }
        }
        return null;
    }

    public static String getTypeName(int id, List<Type> types) {
        for (Type type : types) {
            if (type.getId() == id) {
                return type.getName();
            }
        }
        return null;
    }

    public void refreshTasks() {
        tasks = TaskController.getTasks();
    }

    public void refreshTypes() {
        types = TypeController.getTypes();
    }

    public boolean saveTypes() {
        FileOutputStream fileOutputStream = null;
        ObjectOutputStream objectOutputStream = null;
        boolean isSuccessful = false;

        try {
            fileOutputStream = new FileOutputStream("types.dat", false);
            objectOutputStream = new ObjectOutputStream(fileOutputStream);

            objectOutputStream.writeObject(types);
            isSuccessful = true;
        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            try {
                objectOutputStream.close();
                fileOutputStream.close();
            } catch (Exception e) {
                e.printStackTrace();
            }
        }
        return isSuccessful;
    }

    public boolean saveTasks() {
        FileOutputStream fileOutputStream = null;
        ObjectOutputStream objectOutputStream = null;
        boolean isSuccessful = false;

        try {
            fileOutputStream = new FileOutputStream("tasks.dat", false);
            objectOutputStream = new ObjectOutputStream(fileOutputStream);

            objectOutputStream.writeObject(tasks);
            isSuccessful = true;
        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            try {
                objectOutputStream.close();
                fileOutputStream.close();
            } catch (Exception e) {
                e.printStackTrace();
            }
        }
        return isSuccessful;
    }

    public boolean saveData() {
        return saveTypes() && saveTasks();
    }

    public boolean loadTypes() {
        FileInputStream fileInputStream = null;
        ObjectInputStream objectInputStream = null;
        boolean isSuccessful = false;

        try {
            fileInputStream = new FileInputStream("types.dat");
            objectInputStream = new ObjectInputStream(fileInputStream);

            types = (List<Type>) objectInputStream.readObject();
            if (types != null) {
                isSuccessful = true;
            }
        } catch (FileNotFoundException fileNotFoundException) {
            System.out.println("Sorry, types.dat is not found");
        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            try {
                objectInputStream.close();
                fileInputStream.close();
            } catch (Exception e) {
                e.printStackTrace();
            }
        }
        return isSuccessful;
    }

    public boolean loadTasks() {
        FileInputStream fileInputStream = null;
        ObjectInputStream objectInputStream = null;
        boolean isSuccessful = false;

        try {
            fileInputStream = new FileInputStream("tasks.dat");
            objectInputStream = new ObjectInputStream(fileInputStream);

            tasks = (List<Task>) objectInputStream.readObject();
            if (tasks != null) {
                isSuccessful = true;
            }
        } catch (FileNotFoundException fileNotFoundException) {
            System.out.println("Sorry, tasks.dat is not found");
        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            try {
                objectInputStream.close();
                fileInputStream.close();
            } catch (Exception e) {
                e.printStackTrace();
            }
        }
        return isSuccessful;
    }

    public boolean loadData() {
        return loadTypes() & loadTasks();
    }
}


