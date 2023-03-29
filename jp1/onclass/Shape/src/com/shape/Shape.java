package com.shape;

import java.util.Scanner;

public abstract class Shape {

    public abstract void input();
    public abstract void getArea();
}

class Triangle extends Shape {

    private int a;
    private int b;
    private int c;

    public void input() {
        System.out.println("Instantiating a new triangle.....");
        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter a: ");
        a = Integer.parseInt(scanner.nextLine());
        System.out.println("Enter b: ");
        b = Integer.parseInt(scanner.nextLine());
        System.out.println("Enter c: ");
        c = Integer.parseInt(scanner.nextLine());
    }

    public void getArea() {
        double p = (a + b + c) / 2;
        double area = Math.sqrt(p * (p - a) * (p - b) * (p - c));
        System.out.printf("Area of triangle = %.1f%n", area);
    }
}

class Rectangle extends Shape {

    private int a;
    private int b;

    public void input() {
        System.out.println("Instantiating a new rectangle.....");
        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter a: ");
        a = Integer.parseInt(scanner.nextLine());
        System.out.print("Enter b: ");
        b = Integer.parseInt(scanner.nextLine());
    }

    public void getArea() {
        double area = a * b;
        System.out.printf("Area of rectangle = %.1f%n", area);
    }
}

class Circle extends Shape {

    private int radius;

    public void input() {
        System.out.println("Instantiating a new circle.....");
        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter r: ");
        radius = Integer.parseInt(scanner.nextLine());
    }

    public void getArea() {
        double area = Math.PI * radius * radius;
        System.out.printf("Area of circle = %.1f%n", area);
    }
}
