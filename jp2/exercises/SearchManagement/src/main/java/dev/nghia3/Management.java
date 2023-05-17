package dev.nghia3;

import org.apache.log4j.Logger;

import java.io.File;
import java.io.FileInputStream;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Management {

    private final Logger logger = Logger.getLogger(Management.class);

    public void searchForWordInDirectory(File file, String word) {
        int found = 0;
        File[] files = file.listFiles();

        for (File element : files) {
            if (element.isDirectory()) {
                searchForWordInDirectory(element, word);
            } else {
                if (element.getName().endsWith("txt")) {
                    try {
                        int count = countTheFrequencyOfWordInFile(element, word);
                        if (count > 0) {
                            logInfo(new String("Found in: " + element.getAbsolutePath() + "//" + element.getName()));
                            found++;
                        } else {
                            logWarning(new String("Not found in: " + element.getAbsolutePath() + "//" + element.getName()));
                        }
                    } catch (Exception e) {
                        System.out.println(e.getMessage());
                    }
                }
            }
        }
        System.out.printf("Total of files that containing \"%s\": %d\n", word, found);;
    }

    public int countTheFrequencyOfWordInFile(File file, String word) {
        int count = 0;
        try {
            String content = readFile(file);
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

    private String readFile(File file) throws Exception {
        try {

            FileInputStream fileInputStream = new FileInputStream(file);

            int len = fileInputStream.available();

            byte[] bytes = new byte[len];

            fileInputStream.read(bytes);

            fileInputStream.close();

            return (new String (bytes));
        } catch (Exception e) {
            throw new Exception(e.getMessage());
        }
    }

    private void logInfo(String message) {
        logger.info("This is info : " + message);
    }

    private void logWarning(String message) {
        logger.warn("This is warning : " + message);
    }
}
