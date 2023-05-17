package com.nghia3;

import java.io.*;
import java.util.Collections;
import java.util.LinkedHashMap;
import java.util.Map;

public class Company {

    private String name;
    private Map<Integer, Person> personMap;

    public Company(String name) {
        this.name = name;
        personMap = new LinkedHashMap<>();
    }

    public Map<Integer, Person> getPersonMap() {
        return Collections.unmodifiableMap(personMap);
    }

    public int getSizeOfPersonMap() {
        return personMap.size();
    }

    public Person getPerson(int id) {
        return personMap.get(id);
    }

    public void addPerson(Person person) {
        personMap.put(person.getId(), person);
    }

    public void readFile(String fileName) throws IOException, ClassNotFoundException {
        Map<Integer, Person> temp = new LinkedHashMap<>();
        ObjectInputStream in = null;
        try {
            in = new ObjectInputStream(new BufferedInputStream(new FileInputStream(fileName)));

            boolean isEOF = false;
            while (!isEOF) {
                try {
                    Person person = (Person) in.readObject();
                    temp.put(person.getId(), person);
                } catch (EOFException e) {
                    isEOF = true;
                }
            }

            if (temp.size() > 0) {
                personMap = new LinkedHashMap<>(temp);
            }

        } finally {
            if (in != null) {
                in.close();
            }
        }
    }

    public void writeFile(String fileName) throws IOException {
        class MyObjectOutputStream extends ObjectOutputStream {
            public MyObjectOutputStream(OutputStream out) throws IOException {
                super(out);
            }

            @Override
            protected void writeStreamHeader() throws IOException {
            }
        }

        File file = new File(fileName);
        ObjectOutputStream out = null;

        try {
            if (file.length() == 0) {
                out = new ObjectOutputStream(new BufferedOutputStream(new FileOutputStream(fileName)));
            } else {
                out = new MyObjectOutputStream(new BufferedOutputStream(new FileOutputStream(fileName)));
            }
            for (Person person : personMap.values()) {
                out.writeObject(person);
            }
        } finally {
            if (out != null) {
                out.close();
            }
        }
    }
}
