package dev.nghia3;

import org.apache.log4j.Logger;

import java.io.IOException;
import java.util.Scanner;

public class Main {

    private static final Logger logger = Logger.getLogger(Main.class);
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        boolean isExit = false;
        AddressBook addressBook = new AddressBook();

        while (!isExit) {
            System.out.println();
            System.out.println("=".repeat(10) + " Welcome to Address Book program " + "=".repeat(10));
            System.out.println("""
                    1. Add new contact
                    2. Find a contact by name
                    3. Display contacts
                    4. Save contacts to file
                    5. Exit""");
            System.out.print("Enter your selection: ");
            String selection = scanner.nextLine();
            switch (selection) {
                case "1" -> {
                    System.out.println();
                    System.out.println("-".repeat(10) + " Add new contact " + "-".repeat(10));
                    try {
                        addressBook.addContact();
                        logInfo("Add new contact successfully");
                    } catch (Exception e) {
                        logWarning("Add new contact failed");
                    }
                }
                case "2" -> {
                    System.out.println();
                    System.out.println("-".repeat(10) + " Find a contact by name " + "-".repeat(10));
                    addressBook.findContact();
                }
                 case "3" -> {
                     System.out.println();
                     System.out.println("-".repeat(10) + " Display contacts " + "-".repeat(10));
                     addressBook.displayContacts();
                 }
                 case "4" -> {
                     System.out.println();
                     System.out.println("-".repeat(10) + " Save contacts to file " + "-".repeat(10));
                     try {
                         addressBook.saveContacts();
                         logInfo("Save contacts successfully");
                     } catch (IOException e) {
                         logWarning("Save contacts failed");
                     }
                 }
                 case "5" -> {
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
