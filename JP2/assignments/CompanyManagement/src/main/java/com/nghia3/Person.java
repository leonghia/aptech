package com.nghia3;

import java.io.Serializable;
import java.util.Scanner;

public abstract class Person implements Serializable {

    private static final long serialVersionUID = 1234567L;
    protected static int count = 0;
    protected int id;
    protected String name;
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

    public double getSalary() {
        return salary;
    }

    public double getIncome() {
        return salary * (1 + getBonus());
    }

    public void updateSalary() {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Nhap luong co ban ($): ");
        try {
            salary = Double.parseDouble(scanner.nextLine());
            System.out.print("Da cap nhat thanh cong: ");
            display();
        } catch (NumberFormatException e) {
            System.out.println(e.getMessage());
        }
    }

    public abstract double getBonus();

    public abstract void input();
    public abstract void updatePerson();

    public abstract void display();
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
    public double getBonus() {
        return 0.5;
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
        System.out.printf("Giam doc [id = %d, ten = %s, chuc vu = %s, luong co ban = $%.2f, muc thuong = %.2f, tong luong = $%.2f]%n", getId(), getName(), role, getSalary(), getBonus(), getIncome());
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
    }

    @Override
    public double getBonus() {
        return 0.3;
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
        System.out.printf("Truong phong [id = %d, ten = %s, phong ban = %s, luong co ban = $%.2f, muc thuong = %.2f, tong luong = $%.2f]%n", getId(), getName(), department, getSalary(), getBonus(), getIncome());
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
    }

    public String getSkill() {
        return skill;
    }

    @Override
    public double getBonus() {
        return 0.1;
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
        System.out.printf("Nhan vien [id = %d, ten = %s, vi tri = %s, luong co ban = $%.2f, muc thuong = %.2f, tong luong = $%.2f]%n", getId(), getName(), skill, getSalary(), getBonus(), getIncome());
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

class FPTDirector extends Person {

    private String role;

    public String getRole() {
        return role;
    }

    @Override
    public double getBonus() {
        return 0.5;
    }

    @Override
    public void input() {
        System.out.println("Dang khoi tao giam doc cua FPT................");
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
    public void updatePerson() {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Cap nhat ten: ");
        name = scanner.nextLine();
        System.out.print("Cap nhat chuc vu: ");
        role = scanner.nextLine();
        System.out.print("Da cap nhat thanh cong: ");
        display();
    }

    @Override
    public void display() {
        System.out.printf("Giam doc FPT [id = %d, ten = %s, chuc vu = %s, luong co ban = $%.2f, muc thuong = %.2f, tong luong = $%.2f]%n", getId(), getName(), role, getSalary(), getBonus(), getIncome());
    }
}

class FPTManager extends Person {
    private String department;

    public FPTManager() {
        super();
    }

    @Override
    public double getBonus() {
        return 0.3;
    }

    public String getDepartment() {
        return department;
    }

    @Override
    public void input() {
        System.out.println("Dang khoi tao truong phong FPT................");
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
        System.out.printf("Truong phong FPT [id = %d, ten = %s, phong ban = %s, luong co ban = $%.2f, muc thuong = %.2f, tong luong = $%.2f]%n", getId(), getName(), department, getSalary(), getBonus(), getIncome());
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

class FPTEmployee extends Person {

    private String skill;

    public FPTEmployee() {
        super();
    }

    public String getSkill() {
        return skill;
    }

    @Override
    public double getBonus() {
        return 0.1;
    }

    @Override
    public void input() {
        System.out.println("Dang khoi tao nhan vien FPT................");
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
        System.out.printf("Nhan vien FPT [id = %d, ten = %s, vi tri = %s, luong co ban = $%.2f, muc thuong = %.2f, tong luong = $%.2f]%n", getId(), getName(), skill, getSalary(), getBonus(), getIncome());
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
