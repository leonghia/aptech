package com.nghia3;

import com.nghia3.controller.AccountController;
import com.nghia3.controller.CustomerController;
import com.nghia3.controller.TransactionController;

import java.io.*;
import java.util.Collections;
import java.util.Map;

public class Bank {

    private final String name;
    private Map<Integer, Customer> customers;
    private Map<String, Account> accounts;
    private Map<Integer, Transaction> transactions;

    public Bank(String name) {
        this.name = name;
        customers = CustomerController.getCustomers();
        accounts = AccountController.getAccounts();
        transactions = TransactionController.getTransactions();
    }

    public String getName() {
        return name;
    }

    public Map<Integer, Customer> getCustomers() {
        refreshCustomers();
        return Collections.unmodifiableMap(customers);
    }

    public Map<String, Account> getAccounts() {
        refreshAccounts();
        return Collections.unmodifiableMap(accounts);
    }

    public Map<Integer, Transaction> getTransactions() {
        refreshTransactions();
        return Collections.unmodifiableMap(transactions);
    }

    public Account getAccount(String accountNumber) {
        return accounts.get(accountNumber);
    }

    public Customer getCustomer(int id) {
        return customers.get(id);
    }

    public boolean addTransaction(Transaction transaction) {
        if (TransactionController.addTransaction(transaction)) {
            refreshTransactions();
            return true;
        }
        return false;
    }

    public boolean validateWithdraw(double amount, String accountNumber) {
        Account account = getAccount(accountNumber);
        return account.getBalance() > amount;
    }


    public boolean addNewCustomer(Customer customer) {
        if (CustomerController.addNewCustomer(customer)) {
            refreshCustomers();
            return true;
        }
        return false;
    }

    public boolean addNewAccount(Account account) {
        if (AccountController.addNewAccount(account)) {
            refreshAccounts();
            return true;
        }
        return false;
    }

    public boolean deleteCustomer(int id) {
        if (CustomerController.deleteCustomer(id)) {
            refreshCustomers();
            return true;
        }
        return false;
    }

    public boolean deleteAccount(int id) {
        if (AccountController.deleteAccount(id)) {
            refreshAccounts();
            return true;
        }
        return false;
    }

    public boolean updateCustomer(Customer customer) {
        if (CustomerController.updateCustomer(customer)) {
            refreshCustomers();
            return true;
        }
        return false;
    }

    public boolean updateAccount(Account account) {
        if (AccountController.updateAccount(account)) {
            refreshAccounts();
            return true;
        }
        return false;
    }

    public boolean checkIfCustomerAlreadyHasAnAccount(int id) {
        for (String key : accounts.keySet()) {
            if (accounts.get(key).getCustomerId() == id) {
                return true;
            }
        }
        return false;
    }

    public void refreshCustomers() {
        customers = CustomerController.getCustomers();
    }

    public void refreshAccounts() {
        accounts = AccountController.getAccounts();
    }

    public void refreshTransactions() {
        transactions = TransactionController.getTransactions();
    }

    public boolean writeData(String customersFileName, String accountsFileName, String transactionsFileName) throws IOException {

        ObjectOutputStream outForCustomers = null;
        ObjectOutputStream outForAccounts = null;
        ObjectOutputStream outForTransactions = null;

        try {
            outForCustomers = new ObjectOutputStream(new BufferedOutputStream(new FileOutputStream(customersFileName)));
            outForAccounts = new ObjectOutputStream(new BufferedOutputStream(new FileOutputStream(accountsFileName)));
            outForTransactions = new ObjectOutputStream(new BufferedOutputStream(new FileOutputStream(transactionsFileName)));

            for (Customer customer : customers.values()) {
                outForCustomers.writeObject(customer);
            }

            for (Account account : accounts.values()) {
                outForAccounts.writeObject(account);
            }

            for (Transaction transaction : transactions.values()) {
                outForTransactions.writeObject(transaction);
            }
        } finally {
            if (outForCustomers != null) {
                outForCustomers.close();
            }
            if (outForAccounts != null) {
                outForAccounts.close();
            }
            if (outForTransactions != null) {
                outForTransactions.close();
            }
        }
        return true;
    }

    public boolean readData(String customersFileName, String accountsFileName, String transactionsFileName) throws IOException {
        ObjectInputStream inForCustomers = null;
        ObjectInputStream inForAccounts = null;
        ObjectInputStream inForTransactions = null;

        boolean isEOFCustomers = false;
        boolean isEOFAccounts = false;
        boolean isEOFTransactions = false;

        try {
            inForCustomers = new ObjectInputStream(new BufferedInputStream(new FileInputStream(customersFileName)));
            inForAccounts = new ObjectInputStream(new BufferedInputStream(new FileInputStream(accountsFileName)));
            inForTransactions = new ObjectInputStream(new BufferedInputStream(new FileInputStream(accountsFileName)));

        } finally {
            if (inForCustomers != null) {
                inForCustomers.close();
            }
            if (inForAccounts != null) {
                inForAccounts.close();
            }
            if (inForTransactions != null) {
                inForTransactions.close();
            }
        }
        return true;
    }
}
