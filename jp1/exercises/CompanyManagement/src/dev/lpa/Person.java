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
        return salary;
    }

    public double getTotalSalary() {
        return bonus * salary + salary;
    }

    public abstract void input();
    public abstract void display();
    public abstract void updatePerson();
    public void updateSalary() {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Cap nhat luong moi ($): ");
        salary = Double.parseDouble(scanner.nextLine());
        System.out.printf("Da cap nhat: Luong co ban moi = $%.2f%n", salary);
    }
}

class Director extends Person {
    private String role;

    public Director() {
        super();
        bonus = 0.5;
    }

    public String getRole() {
        return role;
    }

    @Override
    public void input() {
        System.out.println("Dang khoi tao giam doc................");
        Scanner scanner = new Scanner(System.in);
        System.out.print("Nhap ten: ");
        name = scanner.nextLine();
        System.out.print("Nhap luong co ban ($): ");
        salary = Double.parseDouble(scanner.nextLine());
        System.out.print("Nhap chuc vu: ");
        role = scanner.nextLine();
        System.out.print("Da tao thanh cong: ");
        display();
    }

    @Override
    public void display() {
        System.out.printf("Giam doc [id = %d, ten = %s, chuc vu = %s, luong co ban = $%.2f, muc thuong = %.2f, tong luong = $%.2f]%n", getId(), getName(), role, getSalary(), getBonus(), getTotalSalary());
    }

    @Override
    public void updatePerson() {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Cap nhat ten: ");
        name = scanner.nextLine();
        System.out.print("Cap nhat chuc vu: ");
        role = scanner.nextLine();
        System.out.print("Da cap nhat thanh cong: ");
        display();
    }
}

class Manager extends Person {
    private String department;

    public Manager() {
        super();
        bonus = 0.3;
    }

    public String getDepartment() {
        return department;
    }

    @Override
    public void input() {
        System.out.println("Dang khoi tao truong phong................");
        Scanner scanner = new Scanner(System.in);
        System.out.print("Nhap ten: ");
        name = scanner.nextLine();
        System.out.print("Nhap luong co ban ($): ");
        salary = Double.parseDouble(scanner.nextLine());
        System.out.print("Nhap phong ban: ");
        department = scanner.nextLine();
        System.out.print("Da tao thanh cong: ");
        display();
    }

    @Override
    public void display() {
        System.out.printf("Truong phong [id = %d, ten = %s, phong ban = %s, luong co ban = $%.2f, muc thuong = %.2f, tong luong = $%.2f]%n", getId(), getName(), department, getSalary(), getBonus(), getTotalSalary());
    }

    @Override
    public void updatePerson() {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Cap nhat ten: ");
        name = scanner.nextLine();
        System.out.print("Cap nhat phong ban: ");
        department = scanner.nextLine();
        System.out.print("Da cap nhat thanh cong: ");
        display();
    }
}

class Employee extends Person {
    private String skill;

    public Employee() {
        super();
        bonus = 0.1;
    }

    public String getSkill() {
        return skill;
    }



    @Override
    public void input() {
        System.out.println("Dang khoi tao nhan vien................");
        Scanner scanner = new Scanner(System.in);
        System.out.print("Nhap ten: ");
        name = scanner.nextLine();
        System.out.print("Nhap luong co ban ($): ");
        salary = Double.parseDouble(scanner.nextLine());
        System.out.print("Nhap vi tri: ");
        skill = scanner.nextLine();
        System.out.print("Da tao thanh cong: ");
        display();
    }

    @Override
    public void display() {
        System.out.printf("Nhan vien [id = %d, ten = %s, vi tri = %s, luong co ban = $%.2f, muc thuong = %.2f, tong luong = $%.2f]%n", getId(), getName(), skill, getSalary(), getBonus(), getTotalSalary());
    }

    @Override
    public void updatePerson() {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Cap nhat ten: ");
        name = scanner.nextLine();
        System.out.print("Cap nhat vi tri: ");
        skill = scanner.nextLine();
        System.out.print("Da cap nhat thanh cong: ");
        display();
    }
}
