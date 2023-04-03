package com.shapemanagement;

import java.util.Scanner;

public abstract class Shape {

    private static int count = 0;
    private int id;

    public Shape() {
        id = ++count;
    }

    public int getId() {
        return id;
    }

    public abstract void input();

    public abstract void edit();

    public abstract String getType();

    @Override
    public String toString() {
        return String.format("id = %d", getId());
    }
}

class Rectangle extends Shape {

    private int length;
    private int width;

    public Rectangle() {
        super();
        length = 0;
        width = 0;
    }

    @Override
    public String getType() {
        return "hinh chu nhat";
    }

    @Override
    public void input() {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Nhap chieu dai: ");
        length = Integer.parseInt(scanner.nextLine());
        System.out.print("Nhap chieu rong: ");
        width = Integer.parseInt(scanner.nextLine());
    }

    @Override
    public String toString() {
        return String.format("Hinh chu nhat [%s, chieu dai = %d,  chieu rong = %d]", super.toString(), length, width);
    }

    @Override
    public void edit() {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Sua chieu dai: ");
        length = Integer.parseInt(scanner.nextLine());
        System.out.print("Sua chieu rong: ");
        width = Integer.parseInt(scanner.nextLine());
    }
}

class Triangle extends Shape {

    private int a;
    private int b;
    private int c;

    public Triangle() {
        super();
        a = 0;
        b = 0;
        c = 0;
    }

    @Override
    public String getType() {
        return "hinh tam giac";
    }

    @Override
    public void input() {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Nhap canh a: ");
        a = Integer.parseInt(scanner.nextLine());
        System.out.print("Nhap canh b: ");
        b = Integer.parseInt(scanner.nextLine());
        System.out.print("Nhap canh c: ");
        c = Integer.parseInt(scanner.nextLine());
    }

    @Override
    public String toString() {
        return String.format("Tam giac [%s, canh a = %d, canh b = %d, canh c = %d]", super.toString(), a, b, c);
    }

    public void edit() {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Sua canh a: ");
        a = Integer.parseInt(scanner.nextLine());
        System.out.print("Sua canh b: ");
        b = Integer.parseInt(scanner.nextLine());
        System.out.print("Sua canh c: ");
        c = Integer.parseInt(scanner.nextLine());
    }
}

class Circle extends Shape {

    private int radius;

    public Circle() {
        super();
        radius = 0;
    }

    public String getType() {
        return "hinh tron";
    }

    @Override
    public void input() {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Nhap ban kinh: ");
        radius = Integer.parseInt(scanner.nextLine());
    }

    @Override
    public String toString() {
        return String.format("Hinh tron [%s, ban kinh = %d]", super.toString(), radius);
    }

    @Override
    public void edit() {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Sua ban kinh: ");
        radius = Integer.parseInt(scanner.nextLine());
    }
}


