package dev.nghia3;

import java.util.Collection;
import java.util.HashMap;

public class App {

    private HashMap<String, Doctor> doctors;

    public App() {
        doctors = new HashMap<>();
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
}
