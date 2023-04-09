package dev.lpa;

import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

class InvalidPhoneException extends Exception {

    public InvalidPhoneException(String phone) {
        super(phone);
    }
}

class InvalidEmailException extends Exception {

    public InvalidEmailException(String email) {
        super(email);
    }
}

public class Main {

    public static void main(String[] args) {
        boolean isPhoneValid = false;
        boolean isEmailValid = false;
        boolean isDateValid = false;
        Scanner scanner = new Scanner(System.in);
        System.out.println();
        System.out.println("====== Xac thuc sdt, email va ngay ======");
        System.out.println("Ban co the an Q bat cu luc nao de thoat.........");
        while (!isPhoneValid) {
            System.out.print("Nhap sdt: ");
            String phone = scanner.nextLine();
            if (phone.trim().toLowerCase().equals("q"))
                System.exit(0);
            try {
                validatePhone(phone);
                isPhoneValid = true;
                System.out.println("Sdt da duoc xac thuc thanh cong");
            } catch (InvalidPhoneException invalidPhoneException) {
                System.out.println(invalidPhoneException.getMessage());
            }
        }
        while (!isEmailValid) {
            System.out.print("Nhap email: ");
            String email = scanner.nextLine();
            if (email.trim().toLowerCase().equals("q"))
                System.exit(0);
            try {
               validateEmail(email);
               isEmailValid = true;
                System.out.println("Email da duoc xac thuc thanh cong");
            } catch (InvalidEmailException invalidEmailException) {
                System.out.println(invalidEmailException.getMessage());
            }
        }
        while (!isDateValid) {
            System.out.print("Nhap ngay: ");
            String dateRaw = scanner.nextLine().trim();
            if (dateRaw.toLowerCase().equals("q"))
                System.exit(0);
            SimpleDateFormat simpleDateFormat = new SimpleDateFormat("dd/MM/yyyy");
            simpleDateFormat.setLenient(false);
            try {
                Date dateFormatted = simpleDateFormat.parse(dateRaw);
                isDateValid = true;
                System.out.println("Ngay da duoc xac thuc thanh cong");
            } catch (Exception exception) {
                System.out.println("Ngay phai dung dinh dang (ngay/thang/nam), vui long nhap lai");
            }
        }
        System.out.println();
        System.out.println("Xin chuc mung, ban da xac thuc thanh cong tat ca thong tin");
    }

    private static void validatePhone(String phone) throws InvalidPhoneException {
        String phoneTrimmed = phone.trim();
        String rawPattern = "[0-9]+";

        if (!isValid(phoneTrimmed, rawPattern)) {
            throw new InvalidPhoneException("So dien thoai chi duoc chua chu so, vui long nhap lai");
        } else if (phoneTrimmed.length() != 10) {
            throw new InvalidPhoneException("So dien thoai phai chua 10 chu so, vui long nhap lai");
        }
    }

    private static void validateEmail(String email) throws InvalidEmailException {
        String emailTrimmed = email.trim();
        String rawPattern = "^(?=.{1,64}@)[A-Za-z0-9_-]+(\\.[A-Za-z0-9_-]+)*@"
                + "[^-][A-Za-z0-9-]+(\\.[A-Za-z0-9-]+)*(\\.[A-Za-z]{2,})$";
        if (!isValid(emailTrimmed, rawPattern)) {
            throw new InvalidEmailException("Email phai dung dinh dang (VD: nghia@aptech.com), vui long nhap lai");
        }
    }

    private static boolean isValid(String input, String rawPattern) {
        Pattern pattern = Pattern.compile(rawPattern);
        Matcher matcher = pattern.matcher(input);
        return matcher.matches();
    }

}
