package dev.nghia3;

import java.io.*;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);
        Dictionary dictionary = new Dictionary("Anh - Viet");
        boolean isExit = false;
        boolean isExternalDataLoaded = false;
        String filePath = null;
        System.out.println();
        System.out.println("=".repeat(20) + String.format(" Welcome to %s dictionary ", dictionary.getName()) + "=".repeat(20));
        System.out.print("Do you want to load an existing dictionary? (Y/n): ");
        String yesOrNo = scanner.nextLine();
        if (yesOrNo.toUpperCase().equals("Y")) {
            System.out.print("Enter file path (ends with .txt): ");
            filePath = scanner.nextLine();
            try {
                dictionary.setData(loadData(filePath));
                isExternalDataLoaded = true;
            } catch (Exception e) {
                isExternalDataLoaded = false;
            }
        }
        while (!isExit) {
            System.out.println();
            System.out.println("""
                    (A)dd new word
                    (D)elete a word
                    (F)ind a word
                    (V)iew all words
                    (L)oad external data
                    (E)xit""");
            System.out.print("Enter your selection: ");
            String selection = scanner.nextLine();
            switch (selection.toUpperCase()) {
                case "A" -> {
                    System.out.println();
                    System.out.println("-".repeat(20) + " Add new word " + "-".repeat(20));
                    System.out.print("Enter English word: ");
                    String eng = scanner.nextLine();
                    String meaning = dictionary.lookUp(eng);
                    if (meaning == null) {
                        System.out.print("Enter Vietnamese meaning: ");
                        String vi = scanner.nextLine();
                        dictionary.addWord(eng, vi);
                        System.out.println("Added successfully: " + dictionary.displayASingleWord(eng, vi));
                    } else {
                        boolean isDecided = false;
                        while (!isDecided) {
                            System.out.print("This word is already existing. Do you want to update it? (Y/n): ");
                            yesOrNo = scanner.nextLine();
                            if (yesOrNo.toUpperCase().equals("Y")) {
                                isDecided = true;
                                System.out.print("Enter new Vietnamese meaning: ");
                                String vi = scanner.nextLine();
                                dictionary.updateWord(eng, vi);
                                System.out.println("Updated successfully: " + dictionary.displayASingleWord(eng, vi));
                            }
                            if (yesOrNo.toUpperCase().equals("N")) {
                                isDecided = true;
                            }
                        }
                    }
                    if (isExternalDataLoaded) {
                        updateDatabase(filePath, dictionary.getData());
                    }
                }
                case "D" -> {
                    System.out.println();
                    System.out.println("-".repeat(20) + " Delete a word " + "-".repeat(20));
                    System.out.print("Enter English word: ");
                    String word = scanner.nextLine();
                    try {
                        dictionary.deleteWord(word);
                        System.out.println("Deleted successfully: " + word);
                    } catch (Exception e) {
                        System.out.println(e.getMessage());
                    }
                    if (isExternalDataLoaded) {
                        updateDatabase(filePath, dictionary.getData());
                    }
                }
                case "F" -> {
                    System.out.println();
                    System.out.println("-".repeat(20) + " Find a word " + "-".repeat(20));
                    System.out.print("Enter English word: ");
                    String word = scanner.nextLine();
                    String meaning = dictionary.lookUp(word);
                    if (meaning == null) {
                        System.out.println("Look up failed: Word does not exist");
                    } else {
                        System.out.println("Vietnamese meaning: " + meaning);
                    }
                }
                case "V" -> {
                    System.out.println("=".repeat(70));
                    System.out.printf("| %-10s | %-20s | %-25s\n", "NO.", "WORD", "MEANING");
                    System.out.println("=".repeat(70));
                    HashMap<String, String> wordsAndMeanings = dictionary.getData();
                    ArrayList<String> words = dictionary.getAllWords();
                    int firstNumber = 1;
                    for (String word: words) {
                        System.out.printf("| %-10s | %-20s | %-25s\n", firstNumber++, word, wordsAndMeanings.get(word));
                        System.out.println("-".repeat(70));
                    }
                }
                case "L" -> {
                    System.out.print("Enter file path (ends with .txt): ");
                    filePath = scanner.nextLine();
                    try {
                        dictionary.setData(loadData(filePath));
                        isExternalDataLoaded = true;
                    } catch (Exception e) {
                        isExternalDataLoaded = false;
                    }
                }
                case "E" -> {
                    isExit = true;
                }
            }
        }
    }

    private static boolean isDataAvailable() {
        return false;
    }

    private static HashMap<String, String> loadData(String filePath) {
        HashMap<String, String> map = new HashMap<>();
        BufferedReader br = null;

        try {

            // create file object
            File file = new File(filePath);

            // create BufferedReader object from the file
            br = new BufferedReader(new FileReader(file));

            String line = null;

            // read file line by line
            while ((line = br.readLine()) != null) {

                // split the line by colon
                String[] parts = line.split(":");

                // first part is eng, second is vi
                String eng = parts[0].trim();
                String vi = parts[1].trim();

                // put eng, vi in HashMap if they are not empty
                if (!eng.equals("") && !vi.equals("")) {
                    map.put(eng, vi);
                }
            }
            System.out.println("Data has been loaded successfully");
        } catch (Exception e) {
            e.printStackTrace();
        } finally {

            // Always close the BufferedReader
            if (br != null) {
                try {
                    br.close();
                } catch (Exception e) {

                }
            }
        }
        return map;
    }

    private static void updateDatabase(String outputFilePath, HashMap<String, String> map) {
        File file = new File(outputFilePath);
        BufferedWriter bf = null;

        try {
            // Create new BufferedWriter for the output file
            bf = new BufferedWriter(new FileWriter(file));

            // iterate map entries
            for (Map.Entry<String, String> entry : map.entrySet()) {

                // put key and value separated by a colon
                bf.write(entry.getKey() + ":" + entry.getValue());

                // new line
                bf.newLine();
            }

            bf.flush();
        } catch (IOException e) {
            e.printStackTrace();
        } finally {
            try {
                // always close the writer
                bf.close();
            } catch (Exception e) {

            }
        }
    }
}
