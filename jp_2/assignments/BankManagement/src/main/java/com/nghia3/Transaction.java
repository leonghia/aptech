package com.nghia3;

import java.io.Serializable;
import java.sql.Timestamp;

public class Transaction implements Serializable {

    private int transactionId;
    private String accountNumber;
    private Timestamp transactionDate;
    private double amount;
    private byte depositOrWithdraw;

    public Transaction(String accountNumber, double amount, byte depositOrWithdraw) {
        this.accountNumber = accountNumber;
        this.amount = amount;
        this.depositOrWithdraw = depositOrWithdraw;
    }

    public Transaction(int transactionId, String accountNumber, Timestamp transactionDate, double amount, byte depositOrWithdraw) {
        this.transactionId = transactionId;
        this.accountNumber = accountNumber;
        this.transactionDate = transactionDate;
        this.amount = amount;
        this.depositOrWithdraw = depositOrWithdraw;
    }

    public int getTransactionId() {
        return transactionId;
    }

    public String getAccountNumber() {
        return accountNumber;
    }

    public Timestamp getTransactionDate() {
        return transactionDate;
    }

    public double getAmount() {
        return amount;
    }

    public byte getDepositOrWithdraw() {
        return depositOrWithdraw;
    }
}
