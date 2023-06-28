package dev.nghia3.controller;

import dev.nghia3.Doctor;
import dev.nghia3.util.DBConnection;
import org.apache.log4j.Logger;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.ResultSet;
import java.util.LinkedHashMap;
import java.util.Map;

public class DoctorController {

    private final static Logger logger = Logger.getLogger(DoctorController.class);

    public static boolean addDoctor(Doctor doctor) {
        Connection conn = null;
        CallableStatement stmt = null;
        boolean isSuccessful = false;

        try {
            conn = DBConnection.getConnection();
            stmt = conn.prepareCall("{call addDoctor(?, ?, ?, ?)}");

            stmt.setString(1, doctor.getCode());
            stmt.setString(2, doctor.getName());
            stmt.setString(3, doctor.getSpecialization());
            stmt.setInt(4, doctor.getAvailability());

            if (stmt.executeUpdate() > 0) {
                isSuccessful = true;
            }
        } catch (Exception e) {
            logWarning(e.getMessage());
        } finally {
            try {
                stmt.close();
                conn.close();
            } catch (Exception e) {
                logWarning(e.getMessage());
            }
        }
        return isSuccessful;
    }

    public static boolean updateDoctor(Doctor doctor) {
        Connection conn = null;
        CallableStatement stmt = null;
        boolean isSuccessful = false;

        try {
            conn = DBConnection.getConnection();
            stmt = conn.prepareCall("{call updateDoctor(?, ?, ?)}");

            stmt.setString(1, doctor.getCode());
            stmt.setString(2, doctor.getSpecialization());
            stmt.setInt(3, doctor.getAvailability());

            if (stmt.executeUpdate() > 0) {
                isSuccessful = true;
            }
        } catch (Exception e) {
            logWarning(e.getMessage());
        } finally {
            try {
                stmt.close();
                conn.close();
            } catch (Exception e) {
                logWarning(e.getMessage());
            }
        }
        return isSuccessful;
    }

    public static boolean deleteDoctor(String code) {
        Connection conn = null;
        CallableStatement stmt = null;
        boolean isSuccessful = false;

        try {
            conn = DBConnection.getConnection();
            stmt = conn.prepareCall("{call deleteDoctor(?)}");

            stmt.setString(1, code);

            if (stmt.executeUpdate() > 0) {
                isSuccessful = true;
            }
        } catch (Exception e) {
            logWarning(e.getMessage());
        } finally {
            try {
                stmt.close();
                conn.close();
            } catch (Exception e) {
                logWarning(e.getMessage());
            }
        }
        return isSuccessful;
    }

    public static Map<String, Doctor> getDoctors() {
        Map<String, Doctor> doctorMap = new LinkedHashMap<>();
        Connection conn = null;
        CallableStatement stmt = null;

        try {
            conn = DBConnection.getConnection();
            stmt = conn.prepareCall("{call getDoctors}");

            ResultSet rs = stmt.executeQuery();

            while (rs.next()) {
                String code = rs.getString(1);
                String name = rs.getString(2);
                String specialization = rs.getString(3);
                int availability = rs.getInt(4);

                Doctor doctor = new Doctor(code, name, specialization, availability);
                doctorMap.put(code, doctor);
            }
        } catch (Exception e) {
            logWarning(e.getMessage());
        } finally {
            try {
                stmt.close();
                conn.close();
            } catch (Exception e) {
                logWarning(e.getMessage());
            }
        }
        return doctorMap;
    }

    private static void logInfo(String message) {
        logger.info("This is info : " + message);
    }

    private static void logWarning(String message) {
        logger.warn("This is warning : " + message);
    }
}
