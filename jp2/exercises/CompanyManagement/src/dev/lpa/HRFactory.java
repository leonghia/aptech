package dev.lpa;

public class HRFactory extends AbstractFactory {
    @Override
    public Person getPerson(String type) {
        if (type.equalsIgnoreCase("DIRECTOR")) {
            return new Director();
        }
        if (type.equalsIgnoreCase("MANAGER")) {
            return new Manager();
        }
        if (type.equalsIgnoreCase("EMPLOYEE")) {
            return new Employee();
        }
        return null;
    }
}
