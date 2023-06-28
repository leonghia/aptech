package com.leonghia;

public class Person {

    private String id;
    private String name;
    private Wallet wallet;

    public Person(String id, String name) {
        this.id = id;
        this.name = name;
        wallet = new Wallet();
    }

    public void setWalletAmount() {
        wallet.setAmount();
    }

    public boolean verifyPayment(double total) {
        return wallet.payMoney(total);
    }
}
