package dev.lpa;

public class FPTFactory extends AbstractFactory {

    @Override
    public Person getPerson(String type) {
        if (type.equalsIgnoreCase("DIRECTOR")) {
            return new FPTDirector();
        }
        if (type.equalsIgnoreCase("MANAGER")) {
            return new FPTManager();
        }
        if (type.equalsIgnoreCase("EMPLOYEE")) {
            return new FPTEmployee();
        }
        return null;
    }
}
