package com.nghia3;

import org.apache.log4j.Logger;

import java.io.IOException;
import java.util.Map;
import java.util.Scanner;

public class Main {

    private static final Scanner prompt = new Scanner(System.in);
    private static final Company company = new Company("Company");
    private final static Logger logger = Logger.getLogger(Main.class);

    public static void main(String[] args) {
        boolean isExit = false;
        while (!isExit) {
            System.out.println();
            System.out.println("=".repeat(10) + " Chao mung ban den voi phan mem Quan ly Cong ty " + "=".repeat(10));
            System.out.println("""
                    1. Tao nhan su moi
                    2. Hien thi tat ca nhan su
                    3. Tim kiem nhan su theo ID
                    4. Cap nhat thong tin nhan su
                    5. Cap nhat luong cho nhan su
                    6. Doc - Ghi du lieu tu file
                    7. Thoat""");
            System.out.print("Nhap vao lua chon cua ban: ");
            String selection = prompt.nextLine();
            switch (selection) {
                case "1" -> {
                    runMenu1();
                }
                case "2" -> {
                    runMenu2();
                }
                case "3" -> {
                    runMenu3();
                }
                case "4" -> {
                    runMenu4();
                }
                case "5" -> {
                    runMenu5();
                }
                case "6" -> {
                    runMenu6();
                }
                case "7" -> {
                    isExit = true;
                }
            }
        }
    }

    private static void runMenu1() {
        boolean isBack = false;
        while (!isBack) {
            System.out.println();
            System.out.println("-".repeat(10) + " Tao nhan su moi " + "-".repeat(10));
            System.out.println("""
                    1. Tao nhan su FPT
                    2. Tao nhan su HR
                    3. Quay lai""");
            System.out.print("Nhap vao lua chon cua ban: ");
            String selection = prompt.nextLine();
            AbstractFactory abstractFactory = null;
            Person person = null;
            switch (selection) {
                case "1" -> {
                    abstractFactory = FactoryProducer.getFactory(true);
                    System.out.println("-".repeat(10) + " Tao nhan su FPT " + "-".repeat(10));
                }
                case "2" -> {
                    abstractFactory = FactoryProducer.getFactory(false);
                    System.out.println("-".repeat(10) + " Tao nhan su HR " + "-".repeat(10));
                }
                case "3" -> {
                    isBack = true;
                    continue;
                }
                default -> {
                    System.out.println("Lua chon khong hop le");
                    continue;
                }
            }
            System.out.println("""
                    1. Tao giam doc
                    2. Tao truong phong
                    3. Tao nhan vien
                    4. Quay lai""");
            System.out.print("Nhap vao lua chon cua ban: ");
            selection = prompt.nextLine();
            switch (selection) {
                case "1" -> {
                    person = abstractFactory.getPerson("DIRECTOR");
                    System.out.println("-".repeat(10) + " Tao giam doc " + "-".repeat(10));
                }
                case "2" -> {
                    person = abstractFactory.getPerson("MANAGER");
                    System.out.println("-".repeat(10) + " Tao truong phong " + "-".repeat(10));
                }
                case "3" -> {
                    person = abstractFactory.getPerson("EMPLOYEE");
                    System.out.println("-".repeat(10) + " Tao nhan vien " + "-".repeat(10));
                }
                case "4" -> {
                    isBack = true;
                    continue;
                }
                default -> {
                    System.out.println("Lua chon khong hop le");
                    continue;
                }
            }
            person.input();
            company.addPerson(person);
            logInfo("Tao nhan su thanh cong");
        }
    }

    private static void runMenu2() {
        Map<Integer, Person> personMap = company.getPersonMap();
        System.out.println();
        System.out.println("-".repeat(10) + " Hien thi tat ca nhan su " + "-".repeat(10));
        System.out.println();
        System.out.println("=".repeat(90));
        System.out.printf("| %-10s | %-25s | %-15s | %-10s | %-15s%n", "ID", "TEN", "LUONG", "BONUS", "THU NHAP");
        System.out.println("=".repeat(90));
        for (Person person : personMap.values()) {
            System.out.printf("| %-10s | %-25s | $%-15s| %-10s | $%-15s%n", person.getId(), person.getName(), person.getSalary(), person.getBonus(), person.getIncome());
            System.out.println("-".repeat(90));
        }
    }

    private static void runMenu3() {
        System.out.println();
        System.out.println("-".repeat(10) + " Tim kiem nhan su theo ID " + "-".repeat(10));
        runMenu3_0();
    }

    private static Person runMenu3_0() {
        System.out.print("Nhap ID nhan su: ");
        int id;
        try {
            id = Integer.parseInt(prompt.nextLine());
        } catch (NumberFormatException e) {
            System.out.println("ID khong hop le");
            return null;
        }
        Person person = company.getPerson(id);
        if (person == null) {
            System.out.println("Khong tim thay nhan su nao");
            return null;
        } else {
            System.out.print("Da tim thay: ");
            person.display();
            return person;
        }
    }

    private static void runMenu4() {
        System.out.println("");
        System.out.println("-".repeat(10) + " Cap nhat thong tin nhan su " + "-".repeat(10));
        Person person = runMenu3_0();
        if (person != null) {
            person.updatePerson();
            logInfo("Cap nhat thong tin nhan su thanh cong");
        }
    }

    private static void runMenu5() {
        System.out.println();
        System.out.println("-".repeat(10) + " Cap nhat luong cho nhan su " + "-".repeat(10));
        Person person = runMenu3_0();
        if (person != null) {
            person.updateSalary();
            logInfo("Cap nhat luong nhan su thanh cong ");
        }
    }

    private static void runMenu6() {
        boolean isBack = false;
        while (!isBack) {
            System.out.println();
            System.out.println("-".repeat(10) + " Doc - Ghi du lieu tu file " + "-".repeat(10));
            System.out.println("""
                    1. Doc du lieu
                    2. Ghi du lieu
                    3. Quay lai""");
            System.out.print("Nhap vao lua chon cua ban: ");
            String selection = prompt.nextLine();
            switch (selection) {
                case "1" -> {
                    System.out.println("-".repeat(10) + " Doc du lieu tu file " + "-".repeat(10));
                    System.out.print("Nhap ten file: ");
                    String fileName = prompt.nextLine();
                    try {
                        company.readFile(fileName);
                        logInfo("Doc du lieu thanh cong");
                        Person.count = company.getSizeOfPersonMap();
                        isBack = true;
                    } catch (ClassNotFoundException | IOException e) {
                        System.out.println(e.getMessage());
                        isBack = true;
                        logWarning("Doc du lieu that bai");
                    }
                }
                case "2" -> {
                    System.out.println("-".repeat(10) + " Ghi du lieu vao file " + "-".repeat(10));
                    System.out.print("Nhap ten file: ");
                    String fileName = prompt.nextLine();
                    try {
                        company.writeFile(fileName);
                        logInfo("Ghi du lieu thanh cong");
                    } catch (IOException e) {
                        e.printStackTrace();
                        logWarning("Ghi du lieu that bai");
                        isBack = true;
                    }
                }
                case "3" -> {
                    isBack = true;
                }
                default -> System.out.println("Lua chon khong hop le");
            }
        }
    }

    private static void logInfo(String message) {
        logger.info("This is info : " + message);
    }

    private static void logWarning(String message) {
        logger.warn("This is warn : " + message);
    }
}