package com.leonghia;

import java.util.Scanner;

public class Wallet {

    private double amount;

    public Wallet() {

    }

    public void setAmount() {
        System.out.print("Input amount in your wallet: ");
        Scanner scanner = new Scanner(System.in);
        double walletAmount = Double.parseDouble(scanner.nextLine());
        amount = walletAmount;
    }

    public boolean payMoney(double total) {
        if (total > amount) {
            System.out.println("You cannot buy it");
            return false;
        }
        amount -= total;
        System.out.println("You can buy it");
        return true;
    }
}
