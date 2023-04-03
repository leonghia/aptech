package dev.lpa;

import java.util.Scanner;

public abstract class Person {

    private static int count = 0;
    protected int id;
    protected String name;
    protected double bonus;
    protected double salary;

    public Person() {
        this.id = ++count;
    }

    public int getId() {
        return id;
    }

    public String getName() {
        return name;
    }

    public double getBonus() {
        return bonus;
    }

    public double getSalary() {
        return bonus * salary + salary;
    }

    public abstract void input();
    public abstract void display();
    public abstract void updatePerson();
    public void updateSalary() {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Cap nhat luong moi: ");
        salary = Double.parseDouble(scanner.nextLine());
        System.out.print("Cap nhat muc thuong moi: ");
        bonus = Double.parseDouble(scanner.nextLine());
        System.out.printf("Da cap nhat: Luong co ban moi = %f, Muc thuong moi = %f", salary, bonus);
    }
}

class Director extends Person {
    private String role;

    public Director() {
        super();
    }

    public String getRole() {
        return role;
    }

    @Override
    public void input() {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Nhap ten: ");
        name = scanner.nextLine();
        System.out.print("Nhap luong co ban: ");
        salary = Double.parseDouble(scanner.nextLine());
        System.out.print("Nhap muc thuong: ");
        bonus = Double.parseDouble(scanner.nextLine());
        System.out.print("Nhap vi tri: ");
        role = scanner.nextLine();
        System.out.print("Da tao thanh cong: ");
        display();
    }

    @Override
    public void display() {
        System.out.printf("Giam doc [id = %d, ten = %s, luong co ban = %f, muc thuong = %f, vi tri = %s", getId(), getName(), getSalary(), getBonus(), getRole());
    }

    @Override
    public void updatePerson() {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Cap nhat ten: ");
        name = scanner.nextLine();
        System.out.print("Cap nhat vi tri: ");
        role = scanner.nextLine();
        System.out.print("Da cap nhat thanh cong: ");
        display();
    }
}

class Manager extends Person {
    private String department;

    public Manager() {
        super();
    }

    public String getDepartment() {
        return department;
    }

    @Override
    public void input() {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Nhap ten: ");
        name = scanner.nextLine();
        System.out.print("Nhap luong co ban: ");
        salary = Double.parseDouble(scanner.nextLine());
        System.out.print("Nhap muc thuong: ");
        bonus = Double.parseDouble(scanner.nextLine());
        System.out.print("Nhap phong ban: ");
        department = scanner.nextLine();
    }

    @Override
    public void display() {
        System.out.printf("Truong phong [id = %d, ten = %s, luong co ban = %f, muc thuong = %f, phong ban = %s", getId(), getName(), getSalary(), getBonus(), getDepartment());
    }

    @Override
    public void updatePerson() {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Cap nhat ten: ");
        name = scanner.nextLine();
        System.out.print("Cap nhat phong ban: ");
        department = scanner.nextLine();
    }
}

class Employee extends Person {
    private String skill;

    public Employee() {
        super();
    }

    public String getSkill() {
        return skill;
    }

    @Override
    public void input() {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Nhap ten: ");
        name = scanner.nextLine();
        System.out.print("Nhap luong co ban: ");
        salary = Double.parseDouble(scanner.nextLine());
        System.out.print("Nhap muc thuong: ");
        bonus = Double.parseDouble(scanner.nextLine());
        System.out.print("Nhap vi tri: ");
        skill = scanner.nextLine();
    }

    @Override
    public void display() {
        System.out.printf("Nhan vien [id = %d, ten = %s, luong co ban = %f, muc thuong = %f, vi tri = %s", getId(), getName(), getSalary(), getBonus(), getSkill());
    }

    @Override
    public void updatePerson() {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Cap nhat ten: ");
        name = scanner.nextLine();
        System.out.print("Cap nhat vi tri: ");
        skill = scanner.nextLine();
    }
}
