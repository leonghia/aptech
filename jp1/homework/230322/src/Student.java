import java.util.Scanner;

public class Student {

    private int id;
    private String name;
    private String email;

    public Student() {

    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public void inputData() {
        Scanner scanner = new Scanner(System.in);

        // Input id
        System.out.println("Enter id: ");
        this.id = Integer.parseInt(scanner.nextLine());

        // Input name
        System.out.println("Enter name: ");
        this.name = scanner.nextLine();

        // Input email
        System.out.println("Enter email: ");
        this.email = scanner.nextLine();

    }

    // Display data
    public void displayData() {
        System.out.println("id = " + this.id);
        System.out.println("name = " + this.name);
        System.out.println("email = " + this.email);
    }

}
