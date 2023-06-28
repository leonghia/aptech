package dev.lpa;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class AtmManagement {

    private static List<Account> list = new ArrayList<Account>();

    public static void run() {
        Scanner scanner = new Scanner(System.in);
        mainMenuLoop: while (true) {
            System.out.println();
            System.out.println("===== Chao mung ban den voi ngan hang Vietcombank =====");
            System.out.println("1. Tao tai khoan moi");
            System.out.println("2. Nap tien vao tai khoan");
            System.out.println("3. Rut tien tu tai khoan");
            System.out.println("4. Tra cuu thong tin tai khoan");
            System.out.println("5. Hien thi danh sach tai khoan");
            System.out.println("6. Chinh sua tai khoan");
            System.out.println("7. Xoa tai khoan");
            System.out.println("8. Thoat");

            System.out.print("Vui long chon menu (1 - 8): ");
            int selectedMenu = Integer.parseInt(scanner.nextLine());

            switch (selectedMenu) {
                case 1 -> {
                    createNewAccount();
                }
                case 2 -> {
                    deposit();
                }
                case 3 -> {
                    withdraw();
                }
                case 4 -> {
                    viewAccount();
                }
                case 5 -> {
                    displayAllAccounts();
                }
                case 6 -> {
                    editAccount();
                }
                case 7 -> {
                    deleteAccount();
                }
                case 8 -> {
                    break mainMenuLoop;
                }
            }
        }
    }

    private static void createNewAccount() {
        Scanner scanner = new Scanner(System.in);
        System.out.println();
        System.out.println("Dang khoi tao tai khoan moi................");
        System.out.print("Nhap so CMT hoac CCCD: ");
        String id = scanner.nextLine();
        System.out.print("Nhap so tai khoan: ");
        String accountNumber = scanner.nextLine();
        System.out.print("Nhap ten chu tai khoan: ");
        String name = scanner.nextLine();
        System.out.print("Nhap so dien thoai: ");
        String phone = scanner.nextLine();
        Account account = new Account(id, accountNumber, name, phone);
        System.out.println("Tao tai khoan thanh cong. Thong tin tai khoan: " + account);
        list.add(account);
    }

    private static void deposit() {
        Scanner scanner = new Scanner(System.in);
        System.out.println();
        System.out.println("Nap tien vao tai khoan...................");
        System.out.print("Nhap so tai khoan ban muon nap: ");
        String accountNumber = scanner.nextLine();
        Account result = findAccountByAccountNumber(accountNumber);
        if (result != null) {
            System.out.print("Nhap so tien ban muon nap ($): ");
            double amount = Double.parseDouble(scanner.nextLine());
            result.addBalance(amount);
            System.out.printf("Ban da nap thanh cong $%.2f. So du hien tai cua ban la $%.2f%n", amount, result.getBalance());
        } else {
            System.out.println("So tai khoan nay khong ton tai");
        }
    }

    private static void withdraw() {
        Scanner scanner = new Scanner(System.in);
        System.out.println();
        System.out.println("Rut tien tu tai khoan...............");
        System.out.print("Nhap so tai khoan ban muon rut: ");
        String accountNumber = scanner.nextLine();
        Account result = findAccountByAccountNumber(accountNumber);
        if (result != null) {
            System.out.print("Nhap so tien ban muon rut ($): ");
            double amount = Double.parseDouble(scanner.nextLine());
            if (result.verifyWithdrawal(amount)) {
                result.subtractBalance(amount);
                System.out.printf("Ban da rut thanh cong $%.2f. So du hien tai cua ban la $%.2f%n", amount, result.getBalance());
            } else {
                System.out.println("Xin loi ! Tai khoan cua ban khong du tien.");
            }
        } else {
            System.out.println("So tai khoan nay khong ton tai");
        }
    }

    private static void viewAccount() {
        Scanner scanner = new Scanner(System.in);
        System.out.println();
        System.out.println("Tra cuu thong tin tai khoan...............");
        System.out.print("Nhap so CMT hoac CCCD: ");
        String id = scanner.nextLine();
        Account result = findAccountById(id);
        if (result != null) {
            System.out.println("Tim thay 1 ket qua: " + result);
        } else {
            System.out.println("So CMT/CCCD nay khong chinh xac");
        }
    }

    private static void displayAllAccounts() {
        System.out.println();
        System.out.println("Hien thi danh sach tai khoan..............");
        for (Account element : list) {
            System.out.println(element);
        }
        System.out.println("Tong so: " + list.size() + " tai khoan");
    }

    private static void deleteAccount()  {
        Scanner scanner = new Scanner(System.in);
        System.out.println();
        System.out.println("Xoa tai khoan...............");
        System.out.print("Nhap so tai khoan ban muon xoa: ");
        String accountNumber = scanner.nextLine();
        Account result = findAccountByAccountNumber(accountNumber);
        if (result != null) {
            System.out.println("Tim thay 1 ket qua: " + result);
            System.out.print("Ban co chac chan muon xoa tai khoan nay? (bam Y de dong y, bam N de huy): ");
            String answer = scanner.nextLine();
            if (answer.equalsIgnoreCase("Y")) {
                list.remove(result);
                System.out.println("Ban da xoa thanh cong tai khoan");
            }
        } else {
            System.out.println("So tai khoan nay khong ton tai");
        }
    }

    private static void editAccount() {
        Scanner scanner = new Scanner(System.in);
        System.out.println();
        System.out.println("Chinh sua tai khoan..................");
        System.out.print("Nhap vao so tai khoan ban muon chinh sua: ");
        String accountNumber = scanner.nextLine();
        Account result = findAccountByAccountNumber(accountNumber);
        if (result != null) {
            System.out.print("Nhap so CMT hoac CCCD moi: ");
            String id = scanner.nextLine();
            System.out.print("Nhap ten moi: ");
            String name = scanner.nextLine();
            System.out.print("Nhap so dien thoai moi: ");
            String phone = scanner.nextLine();
            result.update(id, name, phone);
            System.out.println("Ban da cap nhat thanh cong: " + result);
        } else {
            System.out.println("So tai khoan nay khong ton tai");
        }
    }

    private static Account findAccountByAccountNumber(String accountNumber) {
        for (Account element : list) {
            if (element.getAccountNumber().equals(accountNumber)) {
                return element;
            }
        }
        return null;
    }

    private static Account findAccountById(String id) {
        for (Account element : list) {
            if (element.getId().equals(id)) {
                return element;
            }
        }
        return null;
    }
}
