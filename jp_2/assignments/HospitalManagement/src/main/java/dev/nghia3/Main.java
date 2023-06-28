package dev.nghia3;

import org.apache.log4j.Logger;

import java.io.IOException;
import java.util.Map;
import java.util.Scanner;

public class Main {


    private final static Logger logger = Logger.getLogger(Main.class);
    public static void main(String[] args) {
        Hospital hospital = new Hospital("Bach Mai");
        Scanner scanner = new Scanner(System.in);
        boolean isExit = false;

        while (!isExit) {
            System.out.println();
            System.out.println("""
                    =========== Welcome to Bach Mai hospital ===========
                    1. Add doctor
                    2. Update doctor
                    3. Delete doctor
                    4. Show all doctors
                    5. Read - Write data with file
                    6. Exit""");
            System.out.print("Please select a menu (1 – 6): ");
            String selection = scanner.nextLine();
            switch (selection) {
                case "1" -> {
                    System.out.println();
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
                        hospital.addDoctor(doctor);
                        logInfo(String.format("Added successfully: Doctor[code = %s, name = %s, specialization = %s, availability = %d]\n", code, name, specialization, availability));
                    } catch (Exception e) {
                        logWarning(e.getMessage());
                    }
                }
                case "2" -> {
                    System.out.println();
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
                        hospital.updateDoctor(doctor);
                        logInfo(String.format("Updated successfully: Doctor[code = %s, name = %s, specialization = %s, availability = %d]\n", code, name, specialization, availability));
                    } catch (Exception e) {
                        logWarning(e.getMessage());
                    }
                }
                case "3" -> {
                    System.out.println();
                    System.out.println("–".repeat(10) + " Delete doctor " + "–".repeat(10));
                    System.out.print("Enter code: ");
                    String code = scanner.nextLine();
                    Doctor doctor = hospital.searchDoctorByCode(code);
                    try {
                        hospital.deleteDoctor(doctor);
                        logInfo(String.format("Deleted successfully: Doctor[code = %s, name = %s, specialization = %s, availability = %d]\n", code, doctor.getName(), doctor.getSpecialization(), doctor.getAvailability()));
                    } catch (Exception e) {
                        logWarning(e.getMessage());
                    }
                }
                case "4" -> {
                    System.out.println();
                    System.out.println("–".repeat(10) + " Show all doctors " + "–".repeat(10));
                    try {
                        Map<String, Doctor> results = hospital.getDoctors();
                        System.out.println();
                        System.out.println("=".repeat(90));
                        System.out.printf("| %-10s | %-25s | %-25s | %-20s \n", "CODE", "NAME", "SPECIALIZATION", "AVAILABILITY");
                        System.out.println("=".repeat(90));
                        for (Doctor doctor : results.values()) {
                            System.out.printf("| %-10s | %-25s | %-25s | %-20s \n", doctor.getCode(), doctor.getName(), doctor.getSpecialization(), doctor.getAvailability());
                            System.out.println("–".repeat(90));
                        }
                    } catch (Exception e) {
                        logWarning(e.getMessage());
                    }
                }
                case "5" -> {
                    boolean isBack = false;

                    while (!isBack) {
                        System.out.println();
                        System.out.println("-".repeat(10) + " Read - Write data with file " + "-".repeat(10));
                        System.out.println("""
                            1. Read data
                            2. Write data
                            3. Back""");
                        System.out.print("Enter your selection: ");
                        selection = scanner.nextLine();
                        switch (selection) {
                            case "1" -> {
                                System.out.println("-".repeat(10) + " Read data " + "-".repeat(10));
                                System.out.print("Enter file name to read: ");
                                String fileName = scanner.nextLine();
                                try {
                                    hospital.readFile(fileName);
                                } catch (IOException | ClassNotFoundException  e) {
                                    logWarning(e.getMessage());
                                }
                            }
                            case "2" -> {
                                System.out.println("-".repeat(10) + " Write data " + "-".repeat(10));
                                System.out.print("Enter file name to write: ");
                                String fileName = scanner.nextLine();
                                try {
                                    hospital.writeFile(fileName);
                                } catch (IOException e) {
                                    e.printStackTrace();
                                }
                            }
                            case "3" -> {
                                isBack = true;
                            }
                        }
                    }


                }
                case "6" -> {
                    isExit = true;
                }
            }
        }
    }

    private static void logInfo(String message) {
        logger.info("This is info : " + message);
    }

    private static void logWarning(String message) {
        logger.warn("This is warning : " + message);
    }
}
