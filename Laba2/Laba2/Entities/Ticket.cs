namespace laba2.Entities; 

public class Ticket {
    private Route route;
    public Ticket(Route route) {
        this.route = route;
    }
    public Route getRoute() {
        return route;
    }
}