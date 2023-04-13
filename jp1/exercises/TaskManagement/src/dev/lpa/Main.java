package dev.lpa;

import java.util.List;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {

        Management management = new Management();

        boolean isQuit = false;
        Scanner scanner = new Scanner(System.in);

        while (!isQuit) {
            System.out.println("""
                ========== Chao mung ban den voi phan mem Quan ly cong viec ==========
                1. Them danh muc moi
                2. Xoa danh muc
                3. Hien thi tat ca danh muc
                4. Them cong viec moi
                5. Xoa cong viec
                6. Hien thi tat ca cong viec
                7. Thoat""");
            System.out.print("Vui long chon menu (1 - 7): ");
            String select = scanner.nextLine().trim();
            switch (select) {
                case "1" -> {
                    System.out.println();
                    System.out.println("---------- Them danh muc moi ----------");
                    System.out.print("Nhap ten: ");
                    String name = scanner.nextLine();
                    try {
                        management.addType(name);
                    } catch (Exception e) {
                        System.out.println("Them that bai: " + e.getMessage());
                    }
                    System.out.println();
                }
                case "2" -> {
                    System.out.println();
                    System.out.println("---------- Xoa danh muc ----------");
                    System.out.print("Nhap ID danh muc ban muon xoa: ");
                    String id = scanner.nextLine();
                    try {
                        management.deleteType(id);
                    } catch (Exception e) {
                        System.out.println("Xoa that bai: " + e.getMessage());
                    }
                    System.out.println();
                }
                case "3" -> {
                    System.out.println();
                    System.out.println("---------- Hien thi tat ca danh muc ----------");
                    List<Type> types = management.getTypes();
                    System.out.printf("%-10s %-10s", "ID", "Ten");
                    System.out.println();
                    for (Type type : types) {
                        System.out.printf("%-10s %-10s", type.getId(), type.getName());
                        System.out.println();
                    }
                    System.out.println();
                }
                case "4" -> {
                    System.out.println();
                    System.out.println("---------- Them cong viec moi ----------");
                    System.out.print("Nhap ten cong viec: ");
                    String requirementName = scanner.nextLine();
                    System.out.print("Nhap ID danh muc: ");
                    String taskTypeID = scanner.nextLine();
                    System.out.print("Nhap ngay: ");
                    String date = scanner.nextLine();
                    System.out.print("Nhap thoi gian bat dau: ");
                    String planFrom = scanner.nextLine();
                    System.out.print("Nhap thoi gian ket thuc: ");
                    String planTo = scanner.nextLine();
                    System.out.print("Nhap ten nguoi thuc hien: ");
                    String assignee = scanner.nextLine();
                    System.out.print("Nhap ten nguoi kiem tra: ");
                    String reviewer = scanner.nextLine();
                    try {
                        management.addTask(requirementName, assignee, reviewer, taskTypeID, date, planFrom, planTo);
                    } catch (Exception e) {
                        System.out.println("Them that bai: " + e.getMessage());
                    }
                    System.out.println();
                }
                case "5" -> {
                    System.out.println();
                    System.out.println("---------- Xoa cong viec ----------");
                    System.out.print("Nhap ID cong viec ban muon xoa: ");
                    String id = scanner.nextLine();
                    try {
                        management.deleteTask(id);
                    } catch (Exception e) {
                        System.out.println("Xoa that bai: " + e.getMessage());
                    }
                    System.out.println();
                }
                case "6" -> {
                    System.out.println();
                    System.out.println("–".repeat(50) + " Hien thi tat ca cong viec " + "–".repeat(50));
                    System.out.printf("%-10s %-30s %-20s %-20s %-20s %-20s %-20s", "ID", "Ten", "Danh muc", "Ngay", "Thoi gian", "Nguoi thuc hien", "Nguoi kiem tra");
                    System.out.println();
                    List<Task> tasks = management.getTasks();
                    for (Task task : tasks) {
                        System.out.printf("%-10s %-30s %-20s %-20s %-20s %-20s %-20s", task.getId(), task.getName(), task.getType(), task.getDate(), task.getTime(), task.getAssignee(), task.getReviewer());
                        System.out.println();
                    }
                    System.out.println();
                }
                case "7" -> {
                    isQuit = true;
                }
            }
        }
    }
}
