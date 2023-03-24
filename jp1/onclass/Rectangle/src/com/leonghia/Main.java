package com.leonghia;

import java.util.Scanner;

public class Main {

    private static Rectangle rectangle;

    public static void main(String[] args) {

        printMenu();

        Scanner scanner = new Scanner(System.in);
        while (true) {
            System.out.print("Please select a menu (1 - 4): ");
            int selectedMenu = Integer.parseInt(scanner.nextLine());
            switch (selectedMenu) {
                case 1 -> {
                    rectangle = createRectangle();
                }
                case 2 -> {
                    if (rectangle == null) {
                        System.out.println("You need to create a rectangle first");
                    } else {
                        enterInfoOfRectangle(rectangle);
                    }
                }
                case 3 -> {
                    if (rectangle == null) {
                        System.out.println("You need to create a rectangle first");
                    } else {
                        drawRectangle(rectangle);
                    }
                }
                default -> {
                    return;
                }
            }
        }

    }

    public static Rectangle createRectangle() {
        Rectangle defaultRectangle = new Rectangle();
        System.out.printf("Created default rectangle width = %d, height = %d%n", defaultRectangle.getWidth(), defaultRectangle.getHeight());
        return defaultRectangle;
    }

    public static void enterInfoOfRectangle(Rectangle rectangle) {
        rectangle.scanInfo();
    }

    public static void drawRectangle(Rectangle rectangle) {
        rectangle.showRectangle();
    }

    public static void printMenu() {
        System.out.println("====== Welcome to Rectangle program ======");
        System.out.println("1. Create a rectangle");
        System.out.println("2. Enter information of the rectangle");
        System.out.println("3. Draw a rectangle");
        System.out.println("4. Exit");
    }
}
