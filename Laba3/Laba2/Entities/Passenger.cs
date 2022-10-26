using laba2.Collections;

namespace laba2.Entities; 

public class Passenger {
    private string name;
    private List<Ticket> tickets;

    public Passenger(string name) {
        this.name = name;
        tickets = new List<Ticket>();
    }
    

    public string getName() {
        return name;
    }

    public List<Ticket> getTickets() {
        return tickets;
    }
    

}