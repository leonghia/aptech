package com.shapemanagement;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Main {

    private static List<Shape> list = new ArrayList<Shape>();
    private static int currentMenu = 0;
    private static Shape newShape;

    public static void main(String[] args) {
        runMainMenu();
    }

    public static void runMainMenu() {
        Scanner scanner = new Scanner(System.in);
        mainMenuLoop: while (true) {
            System.out.println();
            System.out.println("===== Chao mung ban den voi phan mem Shape Management =====");
            System.out.println("1. Tao/Sua/Xoa hinh chu nhat");
            System.out.println("2. Tao/Sua/Xoa hinh tam giac");
            System.out.println("3. Tao/Sua/Xoa hinh tron");
            System.out.println("4. Tra cuu hinh");
            System.out.println("5. Thoat");
            System.out.print("Vui long chon menu (1 - 5): ");
            int selectedMenu = Integer.parseInt(scanner.nextLine());
            switch (selectedMenu) {
                case 1 -> {
                    runMenu1To3(1);
                }
                case 2 -> {
                    runMenu1To3(2);
                }
                case 3 -> {
                    runMenu1To3(3);
                }
                case 4 -> {
                    runMenu4();
                }
                case 5 -> {
                    break mainMenuLoop;
                }
            }
        }
    }

    public static void runMenu1To3(int menuNumber) {
        Scanner scanner = new Scanner(System.in);
        switch (menuNumber) {
            case 1 -> {
                newShape = new Rectangle();
            }
            case 2 -> {
                newShape = new Triangle();
            }
            case 3 -> {
                newShape = new Circle();
            }
        }
        menu1To3Loop: while (true) {
            System.out.println();
            System.out.printf("===== Tao/Sua/Xoa %s =====%n", newShape.getType());
            System.out.println("1. Tao " + newShape.getType());
            System.out.println("2. Sua " + newShape.getType());
            System.out.println("3. Xoa " + newShape.getType());
            System.out.println("4. Quay lai");
            System.out.print("Vui long chon menu (1 - 4): ");
            int selectedMenu = Integer.parseInt(scanner.nextLine());
            switch (selectedMenu) {
                case 1 -> {
                    newShape.input();
                    list.add(newShape);
                    System.out.println("Ban da tao thanh cong: " + newShape);
                }
                case 2 -> {
                    System.out.printf("Nhap id %s ban muon sua: ", newShape.getType());
                    int id = Integer.parseInt(scanner.nextLine());
                    Shape result = findShape(id);
                    if (result != null) {
                        result.edit();
                        System.out.println("Ban da sua thanh cong " + result);
                    }
                }
                case 3 -> {
                    System.out.printf("Nhap id %s ban muon xoa: ", newShape.getType());
                    int id = Integer.parseInt(scanner.nextLine());
                    Shape result = findShape(id);
                    if (result != null) {
                        list.remove(result);
                        System.out.println("Ban da xoa hinh thanh cong");
                    }
                }
                case 4 -> {
                    break menu1To3Loop;
                }
            }
        }
    }

    public static void runMenu4() {
        Scanner scanner = new Scanner(System.in);
        menu4Loop: while (true) {
            System.out.println();
            System.out.println("===== Tra cuu hinh =====");
            System.out.println("1. Hien thi tat ca");
            System.out.println("2. Tim kiem theo ID");
            System.out.println("3. Quay lai");
            System.out.print("Vui long chon menu (1 - 3): ");
            int selectedMenu = Integer.parseInt(scanner.nextLine());
            switch (selectedMenu) {
                case 1 -> {
                    System.out.printf("Dang hien thi tat ca %d ket qua.........%n", list.size());
                    for (Shape shape : list) {
                        System.out.println(shape);
                    }
                }
                case 2 -> {
                    System.out.print("Nhap id hinh ban muon tim kiem: ");
                    int id = Integer.parseInt(scanner.nextLine());
                    findShape(id);
                }
                case 3 -> {
                    break menu4Loop;
                }
            }
        }

    }

    public static Shape findShape(int id) {
        for (Shape shape : list) {
            if (shape.getId() == id) {
                System.out.println("Tim thay 1 ket qua: " + shape);
                return shape;
            }
        }
        System.out.println("Khong tim thay ket qua nao");
        return null;
    }
}
