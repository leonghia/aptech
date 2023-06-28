package dev.nghia3;

import java.io.File;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {

        Management management = new Management();
        Scanner scanner = new Scanner(System.in);
        boolean isExit = false;
        while (!isExit) {
            System.out.println("""
                ============= Word Program =============
                1. Count a word in a file
                2. Find files by a word
                3. Exit""");
            System.out.print("Enter your selection (1 - 3): ");
            String selection = scanner.nextLine();
            switch (selection) {
                case "1" -> {
                    System.out.println("----------- Count a word in a file -----------");
                    System.out.print("Enter file path: ");
                    File file = new File(scanner.nextLine());
                    System.out.print("Enter word to count: ");
                    String word = scanner.nextLine();
                    int count = management.countTheFrequencyOfWordInFile(file, word);
                    System.out.println("Counting.................");
                    System.out.printf("Counts of \"%s\": %d\n", word, count);
                }
                case "2" -> {
                    System.out.println("----------- Find files by word -----------");
                    System.out.print("Enter folder path: ");
                    File file = new File(scanner.nextLine());
                    System.out.print("Enter word to find: ");
                    String word = scanner.nextLine();
                    management.searchForWordInDirectory(file, word);
                }
                case "3" -> {
                    isExit = true;
                }
            }
        }

    }
}
