package dev.nghia3;

import java.io.File;
import java.io.FileInputStream;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Management {

    // Hàm tìm kiếm từ khóa trong thư mục
    public void searchForWordInDirectory(File file, String word) {
        int found = 0;
        // Liệt kê tất cả các thư mục và file rồi thêm chúng vào mảng
        File[] files = file.listFiles();

        // Chạy vòng lặp từng phần tử trong mảng
        for (File element : files) {
            // Nếu phần tử này là thư mục
            if (element.isDirectory()) {
                // Tìm kiếm từ khóa trong thư mục này bằng cách
                // gọi hàm đệ quy
                searchForWordInDirectory(element, word);
            } else {
                // Trường hợp đây là file, cụ thể là file .txt
                if (element.getName().endsWith("txt")) {
                    // Tìm kiếm từ khóa trong file này
                    try {
                        int count = countTheFrequencyOfWordInFile(element, word);
                        if (count > 0) {
                            System.out.println("Found in: " + element.getAbsolutePath() + "//" + element.getName());
                            found++;
                        } else {
                            System.out.println("Not found in: " + element.getAbsolutePath() + "//" + element.getName());
                        }
                    } catch (Exception e) {
                        System.out.println(e.getMessage());
                    }
                }
            }
        }
        System.out.printf("Total of files that containing \"%s\": %d\n", word, found);;
    }

    // Hàm đếm số lần xuất hiện của từ khóa trong file
    public int countTheFrequencyOfWordInFile(File file, String word) {
        // Khai bao bo dem
        int count = 0;
        try {
            // Doc noi dung file
            String content = readFile(file);
            // Khai bao bo tim kiem
            Pattern pattern = Pattern.compile(word);
            Matcher matcher = pattern.matcher(content);

            while (matcher.find()) {
                count++;
            }
        } catch (Exception e) {
            System.out.println(e.getMessage());
        }

        return count;
    }

    // Ham doc noi dung file
    private String readFile(File file) throws Exception {
        try {
            // Ket noi file voi Java, tuong tu nhu Scanner = new Scanner(System.in)
            FileInputStream fileInputStream = new FileInputStream(file);
            // So luong byte trong file
            int len = fileInputStream.available();
            // Tao mang byte de chua noi dung (dang byte) tu file
            byte[] bytes = new byte[len];

            // Tien hanh doc file (Chuyen doi byte thanh dang chu cai)
            fileInputStream.read(bytes);

            // Dong file sau khi doc xong de tranh tieu hao RAM
            fileInputStream.close();

            // Tra ve noi dung dang chu cai
            return (new String (bytes));
        } catch (Exception e) {
            throw new Exception(e.getMessage());
        }
    }
}
