package com.nghia3;

import java.io.Serializable;

public class Task implements Serializable {

    private static int count = 0;
    private int id;
    private String name;
    private String type;
    private String date;
    private double time;
    private String assignee;
    private String reviewer;

    public Task(int id, String name, String type, String date, double time, String assignee, String reviewer) {
        this.id = id;
        this.name = name;
        this.type = type;
        this.date = date;
        this.time = time;
        this.assignee = assignee;
        this.reviewer = reviewer;
    }

    public Task(String name, String taskType, String date, double time, String assignee, String reviewer) {
        id = ++count;
        this.name = name;
        this.type = taskType;
        this.date = date;
        this.time = time;
        this.assignee = assignee;
        this.reviewer = reviewer;
    }

    public int getId() {
        return id;
    }

    public String getName() {
        return name;
    }

    public String getType() {
        return type;
    }

    public String getDate() {
        return date;
    }

    public double getTime() {
        return time;
    }

    public String getAssignee() {
        return assignee;
    }

    public String getReviewer() {
        return reviewer;
    }

    public String toString() {
        return String.format("[ten = %s, danh muc = %s, ngay = %s, thoi gian = %.1f, nguoi thuc hien = %s, nguoi kiem tra = %s]", id, name, type, date, time, assignee, reviewer);
    }
}


