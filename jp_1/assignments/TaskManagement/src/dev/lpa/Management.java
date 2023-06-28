package dev.lpa;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.List;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Management {

    private List<Type> types = new ArrayList<>();
    private List<Task> tasks = new ArrayList<>();

    public int addType(String name) throws Exception {
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
        types.add(type);
        System.out.println("Da them thanh cong: " + type);
        return type.getId();
    }

    public void deleteType(String id) throws Exception {
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
        System.out.println("Da xoa thanh cong: " + type);
        types.remove(type);
    }

    public List<Type> getTypes() {
        return types;
    }

    public int addTask(String requirementName, String assignee, String reviewer, String typeID, String date, String planFrom, String planTo) throws Exception {
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
        tasks.add(task);
        System.out.println("Da them thanh cong: " + task);
        return task.getId();
    }

    public void deleteTask(String id) throws Exception {
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
        System.out.println("Da xoa thanh cong: " + task);
        tasks.remove(task);
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
}


