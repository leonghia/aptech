package com.staff;

import java.util.Scanner;

public class Main {

    private static Staff[] staff = new Staff[4];
    private static int index = 0;

    public static void main(String[] args) {

        System.out.println("===== Welcome to our company =====");
        System.out.println("1. Create a new director");
        System.out.println("2. Create a new manager");
        System.out.println("3. Create a new employee");
        System.out.println("4. Exit");

        while (true) {
            System.out.print("Please select a menu (1 - 4): ");

            Scanner mainScanner = new Scanner(System.in);
            int selectedMenu = Integer.parseInt(mainScanner.nextLine());

            switch (selectedMenu) {
                case 1 -> {
                    if (index > 2) {
                        System.out.println("Staff is full");
                        return;
                    }
                    System.out.println("Instantiating a new director....");
                    Director director = new Director();
                    director.input();
                    staff[index] = director;
                    index++;
                    director.display();
                    System.out.println();
                }
                case 2 -> {
                    if (index > 2) {
                        System.out.println("Staff is full");
                        return;
                    }
                    System.out.println("Instantiating a new manager....");
                    Manager manager = new Manager();
                    manager.input();
                    staff[index] = manager;
                    index++;
                    manager.display();
                    System.out.println();
                }
                case 3 -> {
                    if (index > 3) {
                        System.out.println("Staff is full");
                        return;
                    }
                    System.out.println("Instantiating a new employee....");
                    Employee employee = new Employee();
                    employee.input();
                    staff[index] = employee;
                    index++;
                    employee.display();
                    System.out.println();
                }
                case 4 -> {
                    return;
                }
            }
        }
    }
}
