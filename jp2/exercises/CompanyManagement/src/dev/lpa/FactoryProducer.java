package dev.lpa;

public class FactoryProducer {

    public static AbstractFactory getFactory(boolean type) {
        if (type) {
            return new FPTFactory();
        }
        return new HRFactory();
    }
}
