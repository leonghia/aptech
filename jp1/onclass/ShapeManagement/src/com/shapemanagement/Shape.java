package com.shapemanagement;

import java.util.Scanner;

public abstract class Shape {

    private int id;

    public int getId() {
        return id;
    }

    public void input() {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Nhap id hinh: ");
        id = Integer.parseInt(scanner.nextLine());
    }

    public abstract void edit();
    public abstract String toString();
}

class Rectangle extends Shape {

    private int length;
    private int width;

    public void setLength(int length) {
        this.length = length;
    }

    public void setWidth(int width) {
        this.width = width;
    }

    @Override
    public void input() {
        super.input();
        Scanner scanner = new Scanner(System.in);
        System.out.print("Nhap chieu dai: ");
        length = Integer.parseInt(scanner.nextLine());
        System.out.print("Nhap chieu rong: ");
        width = Integer.parseInt(scanner.nextLine());
    }

    @Override
    public String toString() {
        return String.format("Hinh chu nhat [chieu dai = %d,  chieu rong = %d]%n", length, width);
    }

    @Override
    public void edit() {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Nhap chieu dai: ");
        length = Integer.parseInt(scanner.nextLine());
        System.out.print("Nhap chieu rong: ");
        width = Integer.parseInt(scanner.nextLine());
    }
}

class Triangle extends Shape {

    private int a;
    private int b;
    private int c;

    public Triangle() {
        super();
    }

    public void setA(int a) {
        this.a = a;
    }

    public void setB(int b) {
        this.b = b;
    }

    public void setC(int c) {
        this.c = c;
    }

    @Override
    public void input() {
        super.input();
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
        return String.format("Tam giac [canh a = %d, canh b = %d, canh c = %d]", a, b, c);
    }

    public void edit() {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Nhap canh a: ");
        a = Integer.parseInt(scanner.nextLine());
        System.out.print("Nhap canh b: ");
        b = Integer.parseInt(scanner.nextLine());
        System.out.print("Nhap canh c: ");
        c = Integer.parseInt(scanner.nextLine());
    }
}

class Circle extends Shape {

    private int radius;

    @Override
    public void input() {
        super.input();
        Scanner scanner = new Scanner(System.in);
        System.out.print("Nhap ban kinh: ");
        radius = Integer.parseInt(scanner.nextLine());
    }

    @Override
    public String toString() {
        return String.format("Hinh tron [ban kinh = %d]", radius);
    }

    @Override
    public void edit() {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Nhap ban kinh: ");
        radius = Integer.parseInt(scanner.nextLine());
    }
}


