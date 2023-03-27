package com.staff;

import java.util.Scanner;

public class Staff {

    private String name;
    private String email;
    private int salary;

    public int getSalary() {
        return salary;
    }

    public void input() {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Input name: ");
        name = scanner.nextLine();
        System.out.print("Input email: ");
        email = scanner.nextLine();
        System.out.print("Input salary: ");
        salary = Integer.parseInt(scanner.nextLine());
    }

    public void display() {
        System.out.printf("Name = %s, email = %s, salary = $%d", name, email, salary);
    }
}

class Director extends Staff {

    private String roll;

    @Override
    public void input() {
        Scanner newScanner = new Scanner(System.in);
        super.input();
        System.out.print("Input roll: ");
        roll = newScanner.nextLine();
    }

    @Override
    public void display() {
        super.display();
        System.out.printf(", roll = %s", roll);
    }
}

class Manager extends Staff {

    private String department;

    @Override
    public void input() {
        super.input();
        Scanner newScanner = new Scanner(System.in);
        System.out.print("Input department: ");
        department = newScanner.nextLine();
    }

    @Override
    public void display() {
        super.display();
        System.out.printf(", department = %s", department);
    }
}

class Employee extends  Staff {

    private String skill;

    @Override
    public void input() {
        super.input();
        Scanner newScanner = new Scanner(System.in);
        System.out.print("Input skill: ");
        skill = newScanner.nextLine();
    }

    @Override
    public void display() {
        super.display();
        System.out.printf(", skill = %s", skill);
    }
}
