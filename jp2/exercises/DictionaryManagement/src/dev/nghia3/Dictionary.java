package dev.nghia3;

import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;

public class Dictionary {

    private String name;
    private HashMap<String, String> data;

    public Dictionary(String name) {
        this.name = name;
        data = new HashMap<>();
    }

    public String getName() {
        return name;
    }

    public HashMap<String, String> getData() {
        return data;
    }

    public void setData(HashMap<String, String> data) {
        this.data = data;
    }

    public boolean addWord(String eng, String vi) {
        String result = lookUp(eng);
        if (result == null) {
            data.put(eng, vi);
            return true;
        }
        return false;
    }

    public boolean deleteWord(String eng) {
        String result = lookUp(eng);
        if (result == null) {
            throw new IllegalArgumentException("Delete failed: Word is not existed");
        }
        data.remove(eng);
        return true;
    }

    public void updateWord(String eng, String vi) {
        data.put(eng, vi);
    }

    public String lookUp(String eng) {
        return data.get(eng);
    }

    public String displayASingleWord(String eng, String vi) {
        return String.format("Word[eng = %s, vi = %s]", eng, vi);
    }

    public ArrayList<String> getAllWords() {
        int size = data.size();
        ArrayList<String> arr = new ArrayList<>(size);
        arr.addAll(data.keySet());
        Collections.sort(arr);
        return arr;
    }
}
