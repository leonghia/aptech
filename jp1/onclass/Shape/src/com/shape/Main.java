package com.shape;

import java.util.Scanner;

public class Main {

    public static void main(String[] args) {

        System.out.println("===== Chao mung ban den voi phan mem tinh dien tich va chu vi =====");
        System.out.println("1. Tinh dien tich/chu vi hinh tam giac");
        System.out.println("2. Tinh dien tich/chu vi hinh chu nhat");
        System.out.println("3. Tinh dien tich/chu vi hinh tron");
        System.out.println("4. Thoat");

        while (true) {
            Scanner scanner = new Scanner(System.in);
            System.out.println();
            System.out.print("Vui long chon menu (1 - 4): ");
            int selectedMenu = Integer.parseInt(scanner.nextLine());

            switch (selectedMenu) {
                case 1 -> {
                    Triangle triangle = new Triangle();
                    triangle.input();
                    triangle.getPerimeter();
                    triangle.getArea();
                }
                case 2 -> {
                    Rectangle rectangle = new Rectangle();
                    rectangle.input();
                    rectangle.getPerimeter();
                    rectangle.getArea();
                }
                case 3 -> {
                    Circle circle = new Circle();
                    circle.input();
                    circle.getPerimeter();
                    circle.getArea();
                }
                case 4 -> {
                    return;
                }
            }
        }
    }
}
