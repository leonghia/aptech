package com.shapemanagement;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Main {

    private static List<Shape> list = new ArrayList<Shape>();

    public static void main(String[] args) {

        runMenu0();
    }

    public static void runMenu0() {
        System.out.println("==== Chao mung ban den voi phan mem Shape Management ====");
        System.out.println("1. Tao/Sua hinh chu nhat");
        System.out.println("2. Tao/Sua hinh tam giac");
        System.out.println("3. Tao/Sua hinh tron");
        System.out.println("4. Tra cuu hinh");
        System.out.println("5. Thoat");

        Scanner scanner = new Scanner(System.in);

        while (true) {
            System.out.println();
            System.out.print("Vui long chon menu (1 - 5): ");
            int selectedMenu = Integer.parseInt(scanner.nextLine());

            switch (selectedMenu) {
                case 1 -> {
                    runMenu1();
                }
                case 2 -> {
                    runMenu2();
                }
                case 3 -> {
                    runMenu3();
                }
                case 4 -> {
                    runMenu4();
                }
                case 5 -> {
                    System.exit(0);
                }
            }

        }
    }

    public static void runMenu1() {
        System.out.println();
        System.out.println("1. Tao hinh chu nhat");
        System.out.println("2. Sua hinh chu nhat");
        System.out.println("3. Quay lai");
        System.out.print("Vui long chon menu (1 - 3): ");
        Scanner scanner = new Scanner(System.in);
        int selectedMenu = Integer.parseInt(scanner.nextLine());
        switch (selectedMenu) {
            case 1 -> {
                Rectangle rectangle = new Rectangle();
                rectangle.input();
                System.out.println("Ban da tao hinh chu nhat thanh cong");
                list.add(rectangle);
            }
            case 2 -> {
                System.out.print("Nhap id hinh chu nhat ban muon sua: ");
                int idInput = Integer.parseInt(scanner.nextLine());
                Shape foundShape = findShape(idInput);
                foundShape.edit();
                System.out.println("Ban da sua hinh thanh cong");
            }
            case 3 -> {
                runMenu0();
            }
        }
    }

    public static void runMenu2() {
        System.out.println();
        System.out.println("1. Tao hinh tam giac");
        System.out.println("2. Sua hinh tam giac");
        System.out.println("3. Quay lai");
        System.out.print("Vui long chon menu (1 - 3): ");
        Scanner scanner = new Scanner(System.in);
        int selectedMenu = Integer.parseInt(scanner.nextLine());
        switch (selectedMenu) {
            case 1 -> {
                Triangle triangle = new Triangle();
                triangle.input();
                System.out.println("Ban da tao hinh tam giac thanh cong");
                list.add(triangle);
            }
            case 2 -> {
                System.out.print("Nhap id tam giac ban muon sua: ");
                int idInput = Integer.parseInt(scanner.nextLine());
                Shape foundShape = findShape(idInput);
                foundShape.edit();
                System.out.println("Ban da sua hinh thanh cong");
            }
            case 3 -> {
                runMenu0();
            }
        }

    }

    public static void runMenu3() {
        System.out.println();
        System.out.println("1. Tao hinh tron");
        System.out.println("2. Sua hinh tron");
        System.out.println("3. Quay lai");
        System.out.print("Vui long chon menu (1 - 3): ");
        Scanner scanner = new Scanner(System.in);
        int selectedMenu = Integer.parseInt(scanner.nextLine());
        switch (selectedMenu) {
            case 1 -> {
                Circle circle = new Circle();
                circle.input();
                System.out.println("Ban da tao hinh tron thanh cong");
                list.add(circle);
            }
            case 2 -> {
                System.out.print("Nhap id hinh tron ban muon sua: ");
                int idInput = Integer.parseInt(scanner.nextLine());
                Shape foundShape = findShape(idInput);
                foundShape.edit();
                System.out.println("Ban da sua hinh thanh cong");
            }
            case 3 -> {
                runMenu0();
            }
        }
    }

    public static void runMenu4() {
        System.out.println();
        System.out.print("Nhap id hinh ban muon tim kiem: ");
        Scanner scanner = new Scanner(System.in);
        int idSearch = Integer.parseInt(scanner.nextLine());
        Shape resultShape = findShape(idSearch);
        System.out.println("Result: " + resultShape.toString());
    }

    public static Shape findShape(int id) {
        for (Shape item : list) {
            if (item.getId() == id) {
                return item;
            }
        }
        return null;
    }
}
