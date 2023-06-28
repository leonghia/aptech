package com.nghia3;

import org.apache.log4j.Logger;

import java.io.IOException;
import java.util.Map;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Main {

    private static final Logger logger = Logger.getLogger(Main.class);
    private static final Scanner scanner = new Scanner(System.in);
    private static final Bank bank = new Bank("Vietcombank");

    public static void main(String[] args) {

        boolean isExit = false;

        while (!isExit) {
            System.out.println();
            System.out.println("=".repeat(10) + String.format(" Welcome to %s ", bank.getName()) + "=".repeat(10));
            System.out.println("""
                    1. Customers menu
                    2. Accounts menu
                    3. Transactions menu
                    4. Read - Write data with file
                    5. Exit""");
            System.out.print("Enter your selection: ");
            String selection = scanner.nextLine();
            switch (selection) {
                case "1" -> {
                    runCustomersMenu();
                }
                case "2" -> {
                    runAccountsMenu();
                }
                case "3" -> {
                    runTransactionsMenu();
                }
                case "4" -> {
                    runReadWriteMenu();
                }
                case "5" -> {
                    isExit = true;
                }
            }
        }
    }

    private static void runCustomersMenu() {
        boolean isBack = false;
        while (!isBack) {
            System.out.println();
            System.out.println("=".repeat(10) + " Customers Menu " + "=".repeat(10));
            System.out.println("""
                1. Add a new customer
                2. Delete a customer
                3. Update a customer
                4. View all customers
                5. Back""");
            System.out.print("Enter your selection: ");
            String selection = scanner.nextLine();
            switch (selection.toUpperCase()) {
                case "1" -> {
                    System.out.println("-".repeat(10) + " Add a new customer " + "-".repeat(10));
                    String name, city, country, phone, email;
                    name = city = country = phone = email = null;

                    boolean isNameValid = false;
                    while (!isNameValid) {
                        System.out.print("Enter name: ");
                        name = scanner.nextLine();
                        if (name.isEmpty()) {
                            System.out.println("Name must not be empty");
                            continue;
                        }
                        isNameValid = true;
                    }

                    boolean isCityValid = false;
                    while (!isCityValid) {
                        System.out.print("Enter city: ");
                        city = scanner.nextLine();
                        if (city.isEmpty()) {
                            System.out.println("City must not be empty");
                            continue;
                        }
                        isCityValid = true;
                    }

                    boolean isCountryValid = false;
                    while (!isCountryValid) {
                        System.out.print("Enter country: ");
                        country = scanner.nextLine();
                        if (country.isEmpty()) {
                            System.out.println("Country must not be empty: ");
                            continue;
                        }
                        isCountryValid = true;
                    }

                    boolean isPhoneValid = false;
                    while (!isPhoneValid) {
                        System.out.print("Enter phone: ");
                        phone = scanner.nextLine();
                        if (phone.isEmpty()) {
                            System.out.println("Phone must not be empty");
                            continue;
                        }
                        isPhoneValid = true;
                    }

                    boolean isEmailValid = false;
                    while (!isEmailValid) {
                        System.out.print("Enter email: ");
                        email = scanner.nextLine();
                        if (email.isEmpty()) {
                            System.out.println("Email must not be empty");
                            continue;
                        }
                        isEmailValid = true;
                    }

                    name = name.trim();
                    city = city.trim();
                    country = country.trim();
                    phone = phone.trim();
                    email = email.trim();

                    Customer customer = new Customer(name, city, country, phone, email);
                    if (bank.addNewCustomer(customer)) {
                        logger.info("Added new customer");
                    }
                }
                case "2" -> {
                    System.out.println("-".repeat(10) + " Delete a customer " + "-".repeat(10));
                    boolean isCustomerIdValid = false;
                    int id = 0;
                    while (!isCustomerIdValid) {
                        System.out.print("Enter customer ID: ");
                        try {
                            id = Integer.parseInt(scanner.nextLine());
                            isCustomerIdValid = true;
                        } catch (NumberFormatException e) {
                            System.out.println("Customer Id must be an integer");
                        }
                    }
                    if (bank.deleteCustomer(id)) {
                        logger.info("Deleted customer");
                    }
                }
                case "3" -> {
                    System.out.println("-".repeat(10) + " Update a customer " + "-".repeat(10));
                    boolean isCustomerIdValid = false;
                    int id = 0;
                    while (!isCustomerIdValid) {
                        System.out.print("Enter customer ID: ");
                        try {
                            id = Integer.parseInt(scanner.nextLine());
                            isCustomerIdValid = true;
                        } catch (Exception e) {
                            System.out.println("Customer ID must be an integer");
                        }
                    }

                    System.out.print("Update name (Skip if not needed): ");
                    String name = scanner.nextLine();
                    System.out.print("Update city (Skip if not needed): ");
                    String city = scanner.nextLine();
                    System.out.print("Update country (Skip if not needed): ");
                    String country = scanner.nextLine();
                    System.out.print("Update phone (Skip if not needed): ");
                    String phone = scanner.nextLine();
                    System.out.print("Update email (Skip if not needed): ");
                    String email = scanner.nextLine();

                    name = name.trim();
                    city = city.trim();
                    country = country.trim();
                    phone = phone.trim();
                    email = email.trim();
                    Customer customer = new Customer(id, name, city, country, phone, email);

                    if (bank.updateCustomer(customer)) {
                        logger.info("Updated customer");
                    }
                }
                case "4" -> {
                    System.out.println("Loading customers" + ".".repeat(20));
                    System.out.println();
                    Map<Integer, Customer> customers = bank.getCustomers();
                    System.out.println("=".repeat(120));
                    System.out.printf("| %-10S | %-25S | %-15S | %-15S | %-15S | %-25S\n", "id", "name", "city", "country", "phone", "email");
                    System.out.println("=".repeat(120));
                    for (Integer key : customers.keySet()) {
                        Customer customer = customers.get(key);
                        System.out.printf("| %-10s | %-25s | %-15s | %-15s | %-15s | %-25s\n",
                                key,
                                customer.getName(),
                                customer.getCity(),
                                customer.getCountry(),
                                customer.getPhone(),
                                customer.getEmail());
                        System.out.println("-".repeat(120));
                    }
                }
                case "5" -> {
                    isBack = true;
                }
            }
        }

    }

    private static void runAccountsMenu() {
        boolean isBack = false;
        while (!isBack) {
            System.out.println();
            System.out.println("-".repeat(10) + " Accounts Menu " + "-".repeat(10));
            System.out.println("""
                (A)dd a new account
                (D)elete an account
                (U)pdate an account
                (V)iew all accounts
                (B)ack""");
            System.out.print("Enter your selection: ");
            String selection = scanner.nextLine();
            switch (selection.toUpperCase()) {
                case "A" -> {
                    boolean isDone = false;
                    addNewAccountLoop: while (!isDone) {
                        System.out.println("-".repeat(10) + " Add a new account " + "-".repeat(10));
                        boolean isCustomerIdValid = false;
                        int customerId = 0;
                        while (!isCustomerIdValid) {
                            System.out.print("Enter customer ID (or enter any letter to cancel): ");
                            try {
                                customerId = Integer.parseInt(scanner.nextLine());
                                if (bank.getCustomer(customerId) == null) {
                                    System.out.println("Customer ID does not exist, please try again");
                                } else if (bank.checkIfCustomerAlreadyHasAnAccount(customerId)) {
                                    System.out.println("This customer already has an account");
                                } else {
                                    isCustomerIdValid = true;
                                }
                            } catch (NumberFormatException e) {
                                break addNewAccountLoop;
                            }
                        }
                        boolean isAccountNumberValid = false;
                        String accountNumber = null;
                        while (!isAccountNumberValid) {
                            System.out.print("Enter account number: ");
                            accountNumber = scanner.nextLine();
                            accountNumber = accountNumber.trim();
                            if (accountNumber.isEmpty()) {
                                System.out.println("Account number must not be empty");
                                continue;
                            }
                            Pattern pattern = Pattern.compile("[0-9]+");
                            Matcher matcher = pattern.matcher(accountNumber);
                            if (!matcher.matches()) {
                                System.out.println("Account number must be a number");
                                continue;
                            }
                            if (!accountNumber.startsWith("0991")) {
                                System.out.println("Account number must start with 0991");
                                continue;
                            }
                            isAccountNumberValid = true;
                        }
                        Account account = new Account(accountNumber, customerId);
                        if (bank.addNewAccount(account)) {
                            logger.info("Added new account");
                        }
                        isDone = true;
                    }

                }
                case "D" -> {
                    System.out.println("-".repeat(10) + " Delete an account " + "-".repeat(10));
                    boolean isCustomerIdValid = false;
                    int customerId = 0;
                    while (!isCustomerIdValid) {
                        System.out.print("Enter customer ID of the account: ");
                        try {
                            customerId = Integer.parseInt(scanner.nextLine());
                            isCustomerIdValid = true;
                        } catch (NumberFormatException e) {
                            System.out.println("Customer ID must be an integer");
                        }
                    }
                    if (bank.deleteAccount(customerId)) {
                        System.out.println("Deleted successfully");
                        logger.info("Deleted account");
                    }
                }
                case "U" -> {
                    System.out.println("-".repeat(10) + " Update an account " + "-".repeat(10));
                    boolean isCustomerIdValid = false;
                    int customerId = 0;
                    while (!isCustomerIdValid) {
                        System.out.print("Enter customer ID of the account: ");
                        try {
                            customerId = Integer.parseInt(scanner.nextLine());
                            isCustomerIdValid = true;
                        } catch (NumberFormatException e) {
                            System.out.println("Customer ID must be an integer");
                        }
                    }
                    boolean isMinAccountValid = false;
                    String minAccountInput;
                    double minAccount = 0.0;
                    while (!isMinAccountValid) {
                        System.out.print("Update Minimum account (Skip if not needed): ");
                        try {
                            minAccount = Double.parseDouble(scanner.nextLine());
                            if (minAccount < 100) {
                                System.out.println("Minimum account must be greater than 100($)");
                            } else {
                                isMinAccountValid = true;
                            }
                        } catch (NumberFormatException e) {
                            System.out.println("Minimum account must be a decimal number");
                        }
                    }
                    Account account = new Account(customerId, minAccount);
                    if (bank.updateAccount(account)) {
                        logger.info("Updated account");
                    }
                }
                case "V" -> {
                    System.out.println("Loading accounts" + ".".repeat(20));
                    System.out.println();
                    System.out.println("=".repeat(80));
                    System.out.printf("| %-20S | %-10S | %-20S | %-20S\n", "number", "cus. id", "balance", "min. account");
                    System.out.println("=".repeat(80));
                    Map<String, Account> accounts = bank.getAccounts();
                    for (String key : accounts.keySet()) {
                        Account account = accounts.get(key);
                        System.out.printf("| %-20s | %-10s | %-20s | %-20s\n", account.getAccountNumber(), account.getCustomerId(), account.getBalance(), account.getMinAccount());
                        System.out.println("-".repeat(80));
                    }
                }
                case "B" -> {
                    isBack = true;
                }
            }
        }

    }

    private static void runTransactionsMenu() {
        boolean isBack = false;
        while (!isBack) {
            System.out.println();
            System.out.println("=".repeat(10) + " Transactions Menu" + "=".repeat(10));
            System.out.println("""
                    (D)eposit
                    (W)ithdraw
                    (V)iew all transactions
                    (B)ack""");
            System.out.print("Enter your selection: ");
            String selection = scanner.nextLine();
            switch (selection.toUpperCase()) {
                case "D" -> {
                    System.out.println("-".repeat(10) + " Deposit " + "-".repeat(10));
                    System.out.print("Enter account number: ");
                    String accountNumber = scanner.nextLine();
                    if (bank.getAccount(accountNumber) != null) {
                        double amount = 0.0;
                        boolean isAmountValid = false;
                        while (!isAmountValid) {
                            System.out.print("Enter amount to deposit ($): ");
                            try {
                                amount = Double.parseDouble(scanner.nextLine());
                                if (amount > 0) {
                                    Transaction transaction = new Transaction(accountNumber, amount, (byte) 1);
                                    if (bank.addTransaction(transaction)) {
                                        logger.info("Transaction successfully: Deposited $" + amount);
                                        isAmountValid = true;
                                    }
                                } else {
                                    System.out.println("Amount must be greater than 0");
                                }
                            } catch (NumberFormatException nfe) {
                                System.out.println("Please enter a valid amount");
                            }
                        }

                    } else {
                        logger.warn("Deposit failed: Account number does not exist");
                    }
                }
                case "W" -> {
                    System.out.println("-".repeat(10) + " Withdraw " + "-".repeat(10));
                    System.out.print("Enter account number: ");
                    String accountNumber = scanner.nextLine();
                    if (bank.getAccount(accountNumber) != null) {
                        double amount = 0.0;
                        boolean isAmountValid = false;
                        while (!isAmountValid) {
                            System.out.print("Enter amount to withdraw ($): ");
                            try {
                                amount = Double.parseDouble(scanner.nextLine());
                                if (amount > 0) {
                                    Transaction transaction = new Transaction(accountNumber, amount, (byte) 1);
                                    if (bank.validateWithdraw(amount, accountNumber)) {
                                        if (bank.addTransaction(transaction)) {
                                            logger.info("Transaction successfully: Withdrew $" + amount);
                                            isAmountValid = true;
                                        }
                                    } else {
                                        logger.warn("Transaction failed: Balance is not sufficient");
                                    }
                                } else {
                                    System.out.println("Amount must be greater than 0");
                                }
                            } catch (NumberFormatException nfe) {
                                System.out.println("Please enter a valid amount");
                            }
                        }

                    } else {
                        logger.warn("Withdraw failed: Account number does not exist");
                    }
                }
                case "V" -> {
                    System.out.println("Loading transactions" +".".repeat(20));
                    System.out.println();
                    Map<Integer, Transaction> transactions = bank.getTransactions();
                    System.out.println("=".repeat(95));
                    System.out.printf("| %-10s | %-15s | %-25s | %-20s | %-15s\n", "TRANS. ID", "ACC. NUMBER", "TRANS. DATE", "AMOUNT", "STATUS");
                    System.out.println("=".repeat(95));
                    for (Integer key : transactions.keySet()) {
                        Transaction transaction = transactions.get(key);
                        System.out.printf("| %-10s | %-15s | %-25s | $%-19s | %-15s\n", transaction.getTransactionId(), transaction.getAccountNumber(), transaction.getTransactionDate(), transaction.getAmount(), transaction.getDepositOrWithdraw() == 0 ? "Withdraw" : "Deposit");
                        System.out.println("-".repeat(95));
                    }
                }
                case "B" -> {
                    isBack = true;
                }
            }
        }
    }

    private static void runReadWriteMenu() {
        System.out.println();
        System.out.println("-".repeat(10) + " Read - Write data with file " + "-".repeat(10));
        System.out.println("""
                (R)ead data
                (W)rite data
                (B)ack""");
        System.out.print("Enter your selection: ");
        String selection = scanner.nextLine();
        switch (selection.toUpperCase()) {
            case "R" -> {
                System.out.println("-".repeat(10) + " Read data from file " + "-".repeat(10));
                System.out.print("Enter file name for customers: ");
                String customersFileName = scanner.nextLine();
                System.out.print("Enter file name for accounts: ");
                String accountsFileName = scanner.nextLine();
                System.out.print("Enter file name transactions: ");
                String transactionsFileName = scanner.nextLine();
                try {
                    bank.readData(customersFileName, accountsFileName, transactionsFileName);
                    logger.info("Data has been read successfully");
                } catch (IOException e) {
                    e.printStackTrace();
                    logger.warn("Read data failed: " + e.getMessage());
                }
            }
            case "W" -> {
                System.out.println("-".repeat(10) + " Write data to file " + "-".repeat(10));
                System.out.print("Enter file name for customers: ");
                String customersFileName = scanner.nextLine();
                System.out.print("Enter file name for accounts: ");
                String accountsFileName = scanner.nextLine();
                System.out.print("Enter file name transactions: ");
                String transactionsFileName = scanner.nextLine();
                try {
                    bank.writeData(customersFileName, accountsFileName, transactionsFileName);
                    logger.info("Data has been written successfully");
                } catch (IOException e) {
                    e.printStackTrace();
                    logger.warn("Write data failed: " + e.getMessage());
                }
            }
            case "B" -> {
                return;
            }
            default -> {
                System.out.println("Invalid selection");
            }
        }
    }
}
