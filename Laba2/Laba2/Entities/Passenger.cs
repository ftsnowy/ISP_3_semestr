using laba2.Collections;

namespace laba2.Entities; 

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