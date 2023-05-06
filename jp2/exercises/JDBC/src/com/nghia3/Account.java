package com.nghia3;

public final class Account {

    private final String accountNumber;
    private final int customerId;
    private double balance;
    private double minAccount;

    public Account(int customerId, double minAccount) {
        accountNumber = null;
        this.customerId = customerId;
        this.minAccount = minAccount;
    }

    public Account(String accountNumber, int customerId) {
        this.accountNumber = accountNumber;
        this.customerId = customerId;
        balance = 0.0;
        minAccount = 100;
    }

    public Account(String accountNumber, int customerId, double balance, double minAccount) {
        this.accountNumber = accountNumber;
        this.customerId = customerId;
        this.balance = balance;
        this.minAccount = minAccount;
    }

    public String getAccountNumber() {
        return accountNumber;
    }

    public int getCustomerId() {
        return customerId;
    }

    public double getBalance() {
        return balance;
    }

    public double getMinAccount() {
        return minAccount;
    }
}
