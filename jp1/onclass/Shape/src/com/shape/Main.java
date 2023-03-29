package com.shape;

import java.util.Scanner;

public class Main {

    public static void main(String[] args) {

        System.out.println("===== Welcome to area program =====");
        System.out.println("1. Area of triangle");
        System.out.println("2. Area of rectangle");
        System.out.println("3. Area of circle");
        System.out.println("4. Exit");

        while (true) {
            Scanner scanner = new Scanner(System.in);
            System.out.print("Enter a menu (1 - 4): ");
            int selectedMenu = Integer.parseInt(scanner.nextLine());

            switch (selectedMenu) {
                case 1 -> {
                    Triangle triangle = new Triangle();
                    triangle.input();
                    triangle.getArea();
                }
                case 2 -> {
                    Rectangle rectangle = new Rectangle();
                    rectangle.input();
                    rectangle.getArea();
                }
                case 3 -> {
                    Circle circle = new Circle();
                    circle.input();
                    circle.getArea();
                }
                case 4 -> {
                    return;
                }
            }
        }
    }
}
