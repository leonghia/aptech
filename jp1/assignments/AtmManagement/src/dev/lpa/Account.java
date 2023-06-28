package dev.lpa;

public class Account {

    private String id;
    private String accountNumber;
    private String name;
    private String phone;
    private double balance;

    public Account(String id, String accountNumber, String name, String phone) {
        this.id = id;
        this.accountNumber = accountNumber;
        this.name = name;
        this.phone = phone;
        balance = 0.0;
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getAccountNumber() {
        return accountNumber;
    }

    public void setAccountNumber(String accountNumber) {
        this.accountNumber = accountNumber;
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

    public double getBalance() {
        return balance;
    }

    @Override
    public String toString() {
        return String.format("[so tai khoan = %s, so CMT/CCCD = %s, chu tai khoan = %s, so du tai khoan = $%.2f]", accountNumber, id, name, balance);
    }

    public void addBalance(double amount) {
        balance += amount;
    }

    public void subtractBalance(double amount) {
        if (verifyWithdrawal(amount)) {
            balance -= amount;
        }
    }

    public boolean verifyWithdrawal(double amount) {
        if (amount <= balance) {
            return true;
        }
        return false;
    }

    public void update(String id, String name, String phone) {
        this.id = id;
        this.name = name;
        this.phone = phone;
    }
}
