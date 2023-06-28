package com.nghia3.controller;

import com.nghia3.Account;
import com.nghia3.util.DBUtil;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.ResultSet;
import java.util.LinkedHashMap;
import java.util.Map;

public class AccountController {

    public static Map<String, Account> getAccounts() {

        Connection conn = null;
        CallableStatement stmt = null;

        Map<String, Account> accounts = new LinkedHashMap<>();

        try {
            conn = DBUtil.getConnection();
            stmt = conn.prepareCall("{call getAccounts}");

            ResultSet rs = stmt.executeQuery();

            while (rs.next()) {
                String accountNumber = rs.getString(1);
                int customerId = rs.getInt(2);
                double balance = rs.getDouble(3);
                double minAccount = rs.getDouble(4);
                Account account = new Account(accountNumber, customerId, balance, minAccount);
                accounts.put(accountNumber, account);
            }
            rs.close();
        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            try {
                stmt.close();
                conn.close();
            } catch (Exception e) {
                e.printStackTrace();
            }
        }
        return accounts;
    }

    public static boolean addNewAccount(Account account) {

        Connection conn = null;
        CallableStatement stmt = null;
        boolean isSuccessful = false;

        try {

            conn = DBUtil.getConnection();
            stmt = conn.prepareCall("{call addNewAccount(?, ?, ?, ?)}");
            stmt.setString(1, account.getAccountNumber());
            stmt.setInt(2, account.getCustomerId());
            stmt.setDouble(3, account.getBalance());
            stmt.setDouble(4, account.getMinAccount());

            if (stmt.executeUpdate() > 0) {
                isSuccessful = true;
            }
        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            try {
                stmt.close();
                conn.close();
            } catch (Exception e) {
                e.printStackTrace();
            }
        }
        return isSuccessful;
    }

    public static boolean deleteAccount(int customerId) {

        Connection conn = null;
        CallableStatement stmt = null;
        boolean isSuccessful = false;

        try {
            conn = DBUtil.getConnection();
            stmt = conn.prepareCall("{call deleteAccount(?)}");

            stmt.setInt(1, customerId);

            if (stmt.executeUpdate() > 0) {
                isSuccessful = true;
            }
        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            try {
                stmt.close();
                conn.close();
            } catch (Exception e) {
                e.printStackTrace();
            }
        }
        return isSuccessful;
    }

    public static boolean updateAccount (Account account) {

        Connection conn = null;
        CallableStatement stmt = null;
        boolean isSuccessful = false;

        try {
            conn = DBUtil.getConnection();
            stmt = conn.prepareCall("{call updateAccount(?, ?)}");

            stmt.setInt(1, account.getCustomerId());
            stmt.setDouble(2, account.getMinAccount());

            if (stmt.executeUpdate() > 0) {
                isSuccessful = true;
            }
        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            try {
                stmt.close();
                conn.close();
            } catch (Exception e) {
                e.printStackTrace();
            }
        }
        return isSuccessful;
    }
}
