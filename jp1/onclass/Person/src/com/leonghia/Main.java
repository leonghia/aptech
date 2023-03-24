package com.leonghia;

public class Main {

    public static void main(String[] args) {

        Person nghia = new Person();
        Person quoc = new Person();
        Person hung = new Person();

        System.out.println("======= Information of Nghia =======");
        nghia.scanInfo();
        System.out.println(nghia.printInfo());

        System.out.println("======= Information of Quoc =======");
        quoc.scanInfo();
        System.out.println(quoc.printInfo());

        System.out.println("======= Information of Hung =======");
        hung.scanInfo();
        System.out.println(hung.printInfo());
    }
}
