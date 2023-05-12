package dev.lpa;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class CompanyManagement {

    private static List<Person> list = new ArrayList<Person>();
    private static Person person;
    public static void runMainMenu() {

        Scanner scanner = new Scanner(System.in);

        mainMenuLoop: while (true) {
            System.out.println();
            System.out.println("===== Chao mung ban den voi phan men Quan ly cong ty =====");
            System.out.println("1. Tao nhan su moi");
            System.out.println("2. Hien thi tat ca nhan su");
            System.out.println("3. Tim kiem nhan su theo ID");
            System.out.println("4. Cap nhat thong tin nhan su");
            System.out.println("5. Xem luong cua nhan su");
            System.out.println("6. Cap nhat luong cho nhan su");
            System.out.println("7. Thoat");
            System.out.print("Nhap lua chon cua ban (1 - 7): ");
            int selectedMenu = Integer.parseInt(scanner.nextLine());
            switch (selectedMenu) {
                case 1 -> {
                    createNewPerson();
                }
                case 2 -> {
                    displayAllPeople();
                }
                case 3 -> {
                    findPerson();
                }
                case 4 -> {
                    updatePerson();
                }
                case 5 -> {
                    checkSalary();
                }
                case 6 -> {
                    updateSalary();
                }
                case 7 -> {
                    break mainMenuLoop;
                }
            }
        }
    }

    private static void createNewPerson() {
        Scanner scanner = new Scanner(System.in);
        int selectedMenu = 0;
        createNewPersonLoop: while (true) {
            System.out.println();
            System.out.println("===== Tao nhan su moi =====");
            System.out.println("""
                    1. Nhan su HR
                    2. Nhan su FPT""");
            System.out.print("Ban muon tao nhan su nao (1 - 2), hoac an ky tu bat ki de quay lai trang chu: ");
            try {
                selectedMenu = Integer.parseInt(scanner.nextLine());
            } catch (NumberFormatException numberFormatException) {
                break createNewPersonLoop;
            }
            AbstractFactory abstractFactory = null;
            if (selectedMenu == 1) {
                abstractFactory = FactoryProducer.getFactory(false);
            } else if (selectedMenu == 2) {
                abstractFactory = FactoryProducer.getFactory(true);
            }
            System.out.println("""
                    
                    1. Tao giam doc
                    2. Tao truong phong
                    3. Tao nhan vien""");
            System.out.print("Nhap vao lua chon cua ban (1 - 3), hoac an ky tu bat ki de quay lai trang chu: ");
            try {
                selectedMenu = Integer.parseInt(scanner.nextLine());
            } catch (NumberFormatException numberFormatException) {
                break createNewPersonLoop;
            }
            switch (selectedMenu) {
                case 1 -> {
                    person = abstractFactory.getPerson("DIRECTOR");
                }
                case 2 -> {
                    person = abstractFactory.getPerson("MANAGER");
                }
                case 3 -> {
                    person = abstractFactory.getPerson("EMPLOYEE");
                }
            }
            person.input();
            list.add(person);
        }

    }

    private static void displayAllPeople() {
        System.out.println("Dang hien thi " + list.size() + " nhan su..........");
        for (Person person : list) {
            person.display();
        }
    }

    private static void findPerson() {
        Scanner scanner = new Scanner(System.in);
        findPersonLoop: while (true) {
            System.out.println();
            int id;
            System.out.print("Nhap ID cua nhan su ban muon tim kiem (hoac nhan Q de quay lai): ");
            try {
                id = Integer.parseInt(scanner.nextLine());
            } catch (NumberFormatException numberFormatException) {
                break findPersonLoop;
            }
            Person result = findPersonById(id);
            if (result != null) {
                System.out.print("Tim thay 1 ket qua: ");
                result.display();
            } else {
                System.out.println("Khong tim thay ket qua nao");
            }
        }

    }

    private static Person findPersonById(int id) {
        for (Person person : list) {
            if (person.getId() == id) {
                return person;
            }
        }
        return null;
    }

    private static void updatePerson() {
        Scanner scanner = new Scanner(System.in);
        findPersonLoop: while (true) {
            System.out.println();
            int id;
            System.out.print("Nhap ID cua nhan su ban muon cap nhat (hoac nhan Q de quay lai): ");
            try {
                id = Integer.parseInt(scanner.nextLine());
            } catch (NumberFormatException numberFormatException) {
                break findPersonLoop;
            }
            Person result = findPersonById(id);
            if (result != null) {
                System.out.print("Tim thay 1 ket qua: ");
                result.display();
                result.updatePerson();
            } else {
                System.out.println("Khong tim thay ket qua nao");
            }
        }
    }

    private static void checkSalary() {
        Scanner scanner = new Scanner(System.in);
        findPersonLoop: while (true) {
            System.out.println();
            int id;
            System.out.print("Nhap ID cua nhan su ban muon xem luong (hoac nhan Q de quay lai): ");
            try {
                id = Integer.parseInt(scanner.nextLine());
            } catch (NumberFormatException numberFormatException) {
                break findPersonLoop;
            }
            Person result = findPersonById(id);
            if (result != null) {
                System.out.print("Tim thay 1 ket qua: ");
                result.display();
            } else {
                System.out.println("Khong tim thay ket qua nao");
            }
        }
    }

    private static void updateSalary() {
        Scanner scanner = new Scanner(System.in);
        findPersonLoop: while (true) {
            System.out.println();
            int id;
            System.out.print("Nhap ID cua nhan su ban muon cap nhat luong (hoac nhan Q de quay lai): ");
            try {
                id = Integer.parseInt(scanner.nextLine());
            } catch (NumberFormatException numberFormatException) {
                break findPersonLoop;
            }
            Person result = findPersonById(id);
            if (result != null) {
                System.out.print("Tim thay 1 ket qua: ");
                result.display();
            } else {
                System.out.println("Khong tim thay ket qua nao");
            }
        }
    }
}
