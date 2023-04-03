package dev.lpa;

public class Account {

    private static int count;
    private static int id;
    private String name;
    private double balance;
    private String phone;
    private String email;

    public Account(String name, String phone, String email) {
        id = ++count;
        this.name = name;
        this.phone = phone;
        this.email = email;
    }

    public static int getId() {
        return id;
    }

    public static void setId(int id) {
        Account.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getPhone() {
        return phone;
    }

    public void setPhone(String phone) {
        this.phone = phone;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    @Override
    public String toString() {
        return String.format("so tai khoan = %d, chu tai khoan = %s, so du tai khoan = %f%n", id, name, balance);
    }

    public void addBalance(double amount) {
        balance += amount;
        System.out.printf("Ban da nop thanh cong %f, so du hien tai cua ban = %f", amount, balance);
        System.out.println();
    }

    public void subtractBalance(double amount) {
        if (balance - amount >= 0) {
            balance -= amount;
            System.out.printf("Ban da rut thanh cong %f, so du hien tai cua ban = %f", amount, balance);
            System.out.println();
        } else {
            System.out.println("Xin loi ! So du cua ban khong du, vui long nap them tien");
        }
    }

    public void update(String name, String phone, String email) {
        this.name = name;
        this.phone = phone;
        this.email = email;
    }
}
