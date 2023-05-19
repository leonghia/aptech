package dev.nghia3;

public class Contact {

    private String name;
    private String company;
    private String email;
    private String phoneNumber;

    public Contact(String name, String company, String email, String phoneNumber) {
        this.name = name;
        this.company = company;
        this.email = email;
        this.phoneNumber = phoneNumber;
    }

    public String getName() {
        return name;
    }

    public String getCompany() {
        return company;
    }

    public String getEmail() {
        return email;
    }

    public String getPhoneNumber() {
        return phoneNumber;
    }
}
