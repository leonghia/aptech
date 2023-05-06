package com.nghia3;

import com.nghia3.controller.AccountController;
import com.nghia3.controller.CustomerController;
import com.nghia3.controller.TransactionController;

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
}
