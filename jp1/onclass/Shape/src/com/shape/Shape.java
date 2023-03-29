package com.shape;

import java.util.Scanner;

public abstract class Shape {

    public abstract void input();

    public abstract void getPerimeter();
    public abstract void getArea();
}

class Triangle extends Shape {

    private int a;
    private int b;
    private int c;

    @Override
    public void input() {
        System.out.println("Dang khoi tao hinh tam giac.....");
        Scanner scanner = new Scanner(System.in);
        System.out.print("Nhap do dai canh a: ");
        a = Integer.parseInt(scanner.nextLine());
        System.out.print("Nhap do dai canh b: ");
        b = Integer.parseInt(scanner.nextLine());
        System.out.print("Nhap do dai canh c: ");
        c = Integer.parseInt(scanner.nextLine());
    }

    @Override
    public void getPerimeter() {
        int perimeter = a + b + c;
        System.out.printf("Chu vi hinh tam giac = %d%n", perimeter);
    }

    @Override
    public void getArea() {
        double p = (a + b + c) / 2;
        double area = Math.sqrt(p * (p - a) * (p - b) * (p - c));
        System.out.printf("Dien tich hinh tam giac = %.1f%n", area);
    }
}

class Rectangle extends Shape {

    private int a;
    private int b;

    @Override
    public void input() {
        System.out.println("Dang khoi tao hinh chu nhat.....");
        Scanner scanner = new Scanner(System.in);
        System.out.print("Nhap chieu dai: ");
        a = Integer.parseInt(scanner.nextLine());
        System.out.print("Nhap chieu rong: ");
        b = Integer.parseInt(scanner.nextLine());
    }

    @Override
    public void getPerimeter() {
        int perimeter = (a + b) * 2;
        System.out.printf("Chu vi hinh chu nhat = %d%n", perimeter);
    }

    @Override
    public void getArea() {
        double area = a * b;
        System.out.printf("Dien tich hinh chu nhat = %.1f%n", area);
    }
}

class Circle extends Shape {

    private int radius;

    @Override
    public void input() {
        System.out.println("Dang khoi tao hinh tron.....");
        Scanner scanner = new Scanner(System.in);
        System.out.print("Nhap ban kinh: ");
        radius = Integer.parseInt(scanner.nextLine());
    }

    @Override
    public void getPerimeter() {
        double perimeter = Math.PI * radius * 2;
        System.out.printf("Chu vi hinh tron = %f%n", perimeter);
    }

    @Override
    public void getArea() {
        double area = Math.PI * radius * radius;
        System.out.printf("Dien tich hinh tron = %.1f%n", area);
    }
}
