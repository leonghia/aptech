package com.leonghia;

import java.util.Scanner;

public class Rectangle {

    private int width;
    private int height;

    // Constructors
    public Rectangle() {
        this(5, 3);
    }

    public Rectangle(int width, int height) {
        this.width = width;
        this.height = height;
    }

    // Getters and Setters
    public int getWidth() {
        return width;
    }

    public void setWidth(int width) {
        this.width = width;
    }

    public int getHeight() {
        return height;
    }

    public void setHeight(int height) {
        this.height = height;
    }

    // Calculate the perimeter and the area of a rectangle
    public double getPerimeter() {
        return (width + height) * 2;
    }

    public double getArea() {
        return width * height;
    }

    // Edit the width and height of a rectangle
    public void scanInfo() {
        System.out.println("Enter information of the rectangle");
        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter width: ");
        width = Integer.parseInt(scanner.nextLine());
        System.out.print("Enter height: ");
        height = Integer.parseInt(scanner.nextLine());
    }

    // Draw a rectangle
    public void showRectangle() {
        System.out.printf("Drawing rectangle width = %d, height = %d%n", width, height);
       for (int i = 0; i < height; i++) {
           for (int j = 0; j < width; j++) {
               System.out.print("* ");
           }
           System.out.println();
       }
    }
}
