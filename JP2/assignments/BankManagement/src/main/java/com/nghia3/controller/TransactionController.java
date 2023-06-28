package com.nghia3.controller;

import com.nghia3.Transaction;
import com.nghia3.util.DBUtil;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.Timestamp;
import java.util.LinkedHashMap;
import java.util.Map;

public class TransactionController {

    public static boolean addTransaction(Transaction transaction) {

        Connection conn = null;
        CallableStatement stmt = null;
        boolean isSuccessful = false;

        try {
            conn = DBUtil.getConnection();
            stmt = conn.prepareCall("{call addTransaction(?, ?, ?)}");

            stmt.setString(1, transaction.getAccountNumber());
            stmt.setDouble(2, transaction.getAmount());
            stmt.setByte(3, transaction.getDepositOrWithdraw());

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

    public static Map<Integer, Transaction> getTransactions() {

        Map<Integer, Transaction> transactions = new LinkedHashMap<>();
        Connection conn = null;
        CallableStatement stmt = null;

        try {
            conn = DBUtil.getConnection();
            stmt = conn.prepareCall("{call getTransactions}");

            ResultSet resultSet = stmt.executeQuery();

            while (resultSet.next()) {
                int transactionId = resultSet.getInt(1);
                String accountNumber = resultSet.getString(2);
                Timestamp transactionDate = resultSet.getTimestamp(3);
                double amount = resultSet.getDouble(4);
                byte depositOrWithdraw = resultSet.getByte(5);

                Transaction transaction = new Transaction(transactionId, accountNumber, transactionDate, amount, depositOrWithdraw);
                transactions.put(transactionId, transaction);
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
        return transactions;
    }
}
