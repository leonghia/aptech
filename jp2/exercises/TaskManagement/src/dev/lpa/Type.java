package dev.lpa;

public class Type {

    private static int count = 0;
    private int id;
    private String name;

    public Type(String name) {
        id = ++count;
        this.name = name;
    }

    public Type(int id, String name) {
        this.id = id;
        this.name = name;
    }

    public int getId() {
        return id;
    }

    public String getName() {
        return name;
    }

    @Override
    public String toString() {
        return String.format("[id = %d, ten = %s]", id, name);
    }
}