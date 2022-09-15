using lab1.Collections;

namespace lab1.Entities; 

public class Passenger {
    private string name;
    private MyCustomCollection<Ticket> tickets;

    public Passenger(string name) {
        this.name = name;
        tickets = new MyCustomCollection<Ticket>();
    }
    

    public string getName() {
        return name;
    }

    public MyCustomCollection<Ticket> getTickets() {
        return tickets;
    }
    

}