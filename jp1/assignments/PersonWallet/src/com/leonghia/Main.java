package com.leonghia;

import java.util.Scanner;

public class Main {

    public static void main(String[] args) {

        // Instantiate nghia
        Person nghia = new Person("013568465", "La Trong Nghia");

        // Instantiate Quoc
        Person quoc = new Person("038204020104", "Trinh Dinh Quoc");

        // Prompt user to input bills
        double[] customerBills = inputBills();

        // Prompt user to enter wallet amount
        quoc.setWalletAmount();

        // Calculate the sum of bills
        double sumOfBills = calcTotal(customerBills);

        // Verify the payment
        quoc.verifyPayment(sumOfBills);
    }

    public static double calcTotal(double[] bills) {
        double total = 0;
        for (int i = 0; i < bills.length; i++) {
            total += bills[i];
        }
        System.out.println("Bills total = " + total);
        return total;
    }

    public static double[] inputBills() {
        System.out.println("======= Shopping programs ======");
        System.out.print("input number of bill: ");
        Scanner scanner = new Scanner(System.in);
        int number = Integer.parseInt(scanner.nextLine());
        double[] bills = new double[number + 1];
        int index = 1;
        for (int i = 0; i < number; i++) {
            System.out.printf("input value of bill %d: ", index);
            index++;
            double billAmount = Double.parseDouble(scanner.nextLine());
            bills[i] = billAmount;
        }
        return bills;
    }
}
