package dev.nghia3;

import dev.nghia3.controller.DoctorController;

import java.io.*;
import java.util.*;

public class Hospital {

    private String name;
    private Map<String, Doctor> doctors;

    public Hospital(String name) {
        this.name = name;
        doctors = DoctorController.getDoctors();
    }

    public Map<String, Doctor> getDoctors() {
        return Collections.unmodifiableMap(doctors);
    }

    public boolean addDoctor(Doctor doctor) throws Exception {
        if (doctors == null) {
            throw new IllegalStateException("Database doesn't exist");
        }
        if (doctor == null) {
            throw new IllegalArgumentException("Data doesn't exist");
        }
        String key = doctor.getCode();
        if (doctors.containsKey(key)) {
            throw new IllegalArgumentException("Doctor code " + key + " is duplicated");
        }
        int availability = doctor.getAvailability();
        if (!checkAvailability(availability)) {
            throw new IllegalArgumentException("Availability " + availability + " must be > 0");
        }
        DoctorController.addDoctor(doctor);
        doctors.put(key, doctor);
        return true;
    }

    public boolean updateDoctor(Doctor doctor) throws Exception {
        if (doctors == null) {
            throw new IllegalStateException("Database doesn't exist");
        }
        if (doctor == null) {
            throw new IllegalArgumentException("Data doesn't exist");
        }
        String key = doctor.getCode();
        if (!doctors.containsKey(key)) {
            throw new IllegalArgumentException("Doctor code " + key + " doesn't exist");
        }
        int availability = doctor.getAvailability();
        if (!checkAvailability(availability)) {
            throw new IllegalArgumentException("Availability " + availability + " must be > 0");
        }
        DoctorController.updateDoctor(doctor);
        doctors.put(key, doctor);
        return true;
    }

    public boolean deleteDoctor(Doctor doctor) throws Exception {
        if (doctors == null) {
            throw new IllegalStateException("Database doesn't exist");
        }
        if (doctor == null) {
            throw new IllegalArgumentException("Data doesn't exist");
        }
        String key = doctor.getCode();
        if (!doctors.containsKey(key)) {
            throw new IllegalArgumentException("Doctor code " + key + " doesn't exist");
        }
        DoctorController.deleteDoctor(doctor.getCode());
        doctors.remove(key);
        return true;
    }

    public HashMap<String, Doctor> searchDoctor(String input) throws Exception {
        if (doctors == null) {
            throw new IllegalStateException("Database doesn't exist");
        }
        HashMap<String, Doctor> results = new HashMap<>();
        Collection<Doctor> collection = doctors.values();
        for (Doctor doctor : collection) {
            if (doctor.getCode().contains(input) || doctor.getName().contains(input) || doctor.getSpecialization().contains(input)) {
                results.put(doctor.getCode(), doctor);
            }
        }
        return results;
    }

    public Doctor searchDoctorByCode(String code) {
        return doctors.get(code);
    }

    public boolean checkAvailability(int availability) {
        return availability >= 0;
    }

    public void readFile(String fileName) throws IOException, ClassNotFoundException {
        Map<String, Doctor> temp = new LinkedHashMap<>();
        try (ObjectInputStream in = new ObjectInputStream(new BufferedInputStream(new FileInputStream(fileName)))) {

            boolean isEOF = false;
            while (!isEOF) {
                try {
                    Doctor doctor = (Doctor) in.readObject();
                    temp.put(doctor.getCode(), doctor);
                } catch (EOFException e) {
                    isEOF = true;
                }
            }

            if (temp.size() > 0) {
                doctors = new LinkedHashMap<>(temp);
            }
        }
    }

    public void writeFile(String fileName) throws IOException {

        try (ObjectOutputStream out = new ObjectOutputStream(new BufferedOutputStream(new FileOutputStream(fileName)))) {
            for (Doctor doctor : doctors.values()) {
                out.writeObject(doctor);
            }
        }
    }
}
