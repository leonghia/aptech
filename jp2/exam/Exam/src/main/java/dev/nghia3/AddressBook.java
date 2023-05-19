package dev.nghia3;

import dev.nghia3.controller.ContactController;

import java.io.BufferedWriter;
import java.io.FileWriter;
import java.io.IOException;
import java.util.List;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class AddressBook {

    private List<Contact> contactList;

    public AddressBook() {
        refreshContactList();
    }

    public void displayContacts() {
        System.out.println(" ".repeat(25) + " Address Book " + " ".repeat(35));
        System.out.printf("%-15s %-15s %-25s %-25s%n", "Contact Name", "Company", "Email", "Phone Number");
        for (Contact contact : contactList) {
            System.out.printf("%-15s %-15s %-25s %-25s%n", contact.getName(), contact.getCompany(), contact.getEmail(), contact.getPhoneNumber());
        }
    }

    public void addContact() throws Exception {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Enter name: ");
        String name = scanner.nextLine();
        if (name.isEmpty()) {
            throw new Exception("Name must not be empty");
        }

        System.out.print("Enter company: ");
        String company = scanner.nextLine();
        if (company.isEmpty()) {
            throw new Exception("Company must not be empty");
        }

        // Validate email
        System.out.print("Enter email: ");
        String email = scanner.nextLine();
        String emailRegex = "^(?=.{1,64}@)[A-Za-z0-9_-]+(\\.[A-Za-z0-9_-]+)*@"
                + "[^-][A-Za-z0-9-]+(\\.[A-Za-z0-9-]+)*(\\.[A-Za-z]{2,})$";
        if (!validate(email, emailRegex)) {
            throw new Exception("Invalid email exception");
        }

        // Validate phone
        System.out.print("Enter phone: ");
        String phone = scanner.nextLine();
        String phoneRegex = "0[0-9]+";
        if (!validate(phone, phoneRegex)) {
            throw new Exception("Invalid phone number");
        }

        Contact contact = new Contact(name, company, email, phone);
        ContactController.addContact(contact);
        refreshContactList();
    }

    public void findContact() {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter contact name: ");
        String name = scanner.nextLine();
        Contact result = null;
        for (Contact contact : contactList) {
            if (contact.getName().equalsIgnoreCase(name)) {
                result = contact;
                break;
            }
        }
        if (result != null) {
            System.out.printf("%-15s %-15s %-25s %-25s%n", "Contact Name", "Company", "Email", "Phone Number");
            System.out.printf("%-15s %-15s %-25s %-25s%n", result.getName(), result.getCompany(), result.getEmail(), result.getPhoneNumber());
        } else {
            System.out.println("Not found");
        }
    }

    public void saveContacts() throws IOException {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter file name to save (ending with .txt): ");
        String fileName = scanner.nextLine();
        BufferedWriter outputStream = null;

        try {
            outputStream = new BufferedWriter(new FileWriter(fileName));
            for (Contact contact : contactList) {
                outputStream.write(contact.getName() + ", " + contact.getCompany() + ", " + contact.getEmail() + ", " + contact.getPhoneNumber());
                outputStream.newLine();
            }
        } finally {
            if (outputStream != null) {
                outputStream.close();
            }
        }
    }

    public void refreshContactList() {
        contactList = ContactController.getContacts();
    }

    private static boolean validate(String input, String rawPattern) {
        Pattern pattern = Pattern.compile(rawPattern);
        Matcher matcher = pattern.matcher(input);
        return matcher.matches();
    }
}
