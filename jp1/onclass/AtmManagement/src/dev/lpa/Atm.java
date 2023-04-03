package dev.lpa;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Atm {

    private List<Account> list = new ArrayList<Account>();
    private Account account;

    public static void runMainMenu() {
        Scanner scanner = new Scanner(System.in);
        mainMenuLoop: while (true) {
            System.out.println();
            System.out.println("===== Chao mung ban den voi ngan hang Vietcombank =====");
            System.out.println("1. Tao tai khoan moi");
            System.out.println("2. Nop tien vao tai khoan");
            System.out.println("3. Rut tien tu tai khoan");
            System.out.println("4. Tra cuu thong tin tai khoan");
            System.out.println("5. Hien thi danh sach tai khoan");
            System.out.println("6. Xoa tai khoan");
            System.out.println("7. Sua tai khoan");
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
                    widthdraw();
                }
                case 4 -> {
                    viewAccount();
                }
                case 5 -> {
                    displayAllAccounts();
                }
                case 6 -> {
                    deleteAccount();
                }
                case 7 -> {
                    editAccount();
                }
                case 8 -> {
                    break mainMenuLoop;
                }
            }
        }
    }

    public void createNewAccount() {
        Scanner scanner = new Scanner(System.in);
        while (true) {
            System.out.println();
            System.out.println("Dang khoi tao tai khoan moi. Ban co the an Q de quay lai trang chu.");
            System.out.print("Nhap ten: ");
            String name = scanner.nextLine();
            System.out.print("Nhap so dien thoai: ");
            String phone = scanner.nextLine();
            System.out.print("Nhap email: ");
            String email = scanner.nextLine();
            account = new Account(name, phone, email);
            System.out.println("Tao tai khoan thanh cong. Thong tin tai khoan cua ban la: " + account.toString());
        }
    }
}
