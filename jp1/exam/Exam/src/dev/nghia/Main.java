package dev.nghia;

import java.util.Scanner;

public class Main {

    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        Account account = new Account();
        try {
            account.input();
        } catch (Exception exception) {
            System.out.println(exception.getMessage());
        }

        System.out.print("Deposit (0) or Withdraw (1): ");
        int type = Integer.parseInt(scanner.nextLine());
        System.out.print("Enter amount of money ($): ");
        long amount = Integer.parseInt(scanner.nextLine());
        try {
            account.depositAndWithdraw(amount, type);
        } catch (Exception exception) {
            System.out.println(exception.getMessage());
        }

        System.out.println(account);
    }
}
