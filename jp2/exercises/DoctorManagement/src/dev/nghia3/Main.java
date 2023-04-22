package dev.nghia3;

import java.util.Collection;
import java.util.HashMap;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {

        App app = new App();
        Scanner scanner = new Scanner(System.in);
        boolean isExit = false;

        while (!isExit) {
            System.out.println();
            System.out.println("""
                    =========== Doctor Management ===========
                    1. Add doctor
                    2. Update doctor
                    3. Delete doctor
                    4. Search doctor
                    5. Exit""");
            System.out.print("Please select a menu (1 – 5): ");
            String selection = scanner.nextLine();
            switch (selection) {
                case "1" -> {
                    System.out.println("–".repeat(10) + " Add doctor " + "–".repeat(10));
                    String code = null, name = null, specialization = null;
                    int availability = 0;
                    boolean isCodeValid = false;
                    while (!isCodeValid) {
                        System.out.print("Enter code: ");
                        code = scanner.nextLine().trim();
                        if (!code.startsWith("DOC")) {
                            System.out.println("Code must start with \"DOC\"");
                        } else {
                            isCodeValid = true;
                        }
                    }
                    boolean isNameValid = false;
                    while (!isNameValid) {
                        System.out.print("Enter name: ");
                        name = scanner.nextLine().trim();
                        if (name.isEmpty()) {
                            System.out.println("Name must not be empty");
                        } else {
                            isNameValid = true;
                        }
                    }
                    boolean isSpecializationValid = false;
                    while (!isSpecializationValid) {
                        System.out.print("Enter specialization: ");
                        specialization = scanner.nextLine().trim();
                        if (specialization.isEmpty()) {
                            System.out.println("Specialization must not be empty");
                        } else {
                            isSpecializationValid = true;
                        }
                    }
                    boolean isAvailabilityValid = false;
                    while (!isAvailabilityValid) {
                        System.out.print("Enter availability: ");
                        try {
                            availability = Integer.parseInt(scanner.nextLine());
                            isAvailabilityValid = true;
                        } catch (NumberFormatException numberFormatException) {
                            System.out.println("Availability must be a number");
                        }
                    }
                    Doctor doctor = new Doctor(code, name, specialization, availability);
                    try {
                        app.addDoctor(doctor);
                        System.out.printf("Added successfully: Doctor[code = %s, name = %s, specialization = %s, availability = %d]\n", code, name, specialization, availability);
                    } catch (Exception e) {
                        System.out.println(e.getMessage());
                    }
                }
                case "2" -> {
                    System.out.println("–".repeat(10) + " Update doctor " + "–".repeat(10));
                    String code = null, name = null, specialization = null;
                    int availability = 0;
                    boolean isCodeValid = false;
                    while (!isCodeValid) {
                        System.out.print("Enter code: ");
                        code = scanner.nextLine().trim();
                        if (!code.startsWith("DOC")) {
                            System.out.println("Code must start with \"DOC\"");
                        } else {
                            isCodeValid = true;
                        }
                    }
                    boolean isNameValid = false;
                    while (!isNameValid) {
                        System.out.print("Enter name: ");
                        name = scanner.nextLine().trim();
                        if (name.isEmpty()) {
                            System.out.println("Name must not be empty");
                        } else {
                            isNameValid = true;
                        }
                    }
                    boolean isSpecializationValid = false;
                    while (!isSpecializationValid) {
                        System.out.print("Enter specialization: ");
                        specialization = scanner.nextLine().trim();
                        if (specialization.isEmpty()) {
                            System.out.println("Specialization must not be empty");
                        } else {
                            isSpecializationValid = true;
                        }
                    }
                    boolean isAvailabilityValid = false;
                    while (!isAvailabilityValid) {
                        System.out.print("Enter availability: ");
                        try {
                            availability = Integer.parseInt(scanner.nextLine());
                            isAvailabilityValid = true;
                        } catch (NumberFormatException numberFormatException) {
                            System.out.println("Availability must be a number");
                        }
                    }
                    Doctor doctor = new Doctor(code, name, specialization, availability);
                    try {
                        app.updateDoctor(doctor);
                        System.out.printf("Updated successfully: Doctor[code = %s, name = %s, specialization = %s, availability = %d]\n", code, name, specialization, availability);
                    } catch (Exception e) {
                        System.out.println(e.getMessage());
                    }
                }
                case "3" -> {
                    System.out.println("–".repeat(10) + " Delete doctor " + "–".repeat(10));
                    System.out.print("Enter code: ");
                    String code = scanner.nextLine();
                    Doctor doctor = app.searchDoctorByCode(code);
                    try {
                        app.deleteDoctor(doctor);
                        System.out.printf("Deleted successfully: Doctor[code = %s, name = %s, specialization = %s, availability = %d]\n", code, doctor.getName(), doctor.getSpecialization(), doctor.getAvailability());
                    } catch (Exception e) {
                        System.out.println(e.getMessage());
                    }
                }
                case "4" -> {
                    System.out.println("–".repeat(10) + " Search doctor " + "–".repeat(10));
                    System.out.print("Enter text: ");
                    String input = scanner.nextLine();
                    try {
                        HashMap<String, Doctor> results = app.searchDoctor(input);
                        Collection<Doctor> doctors = results.values();
                        System.out.println();
                        System.out.println("=".repeat(90));
                        System.out.printf("| %-10s | %-25s | %-25s | %-20s \n", "CODE", "NAME", "SPECIALIZATION", "AVAILABILITY");
                        System.out.println("=".repeat(90));
                        for (Doctor doctor : doctors) {
                            System.out.printf("| %-10s | %-25s | %-25s | %-20s \n", doctor.getCode(), doctor.getName(), doctor.getSpecialization(), doctor.getAvailability());
                            System.out.println("–".repeat(90));
                        }
                    } catch (Exception e) {
                        System.out.println(e.getMessage());
                    }
                }
                case "5" -> {
                    isExit = true;
                }
            }
        }
    }
}
