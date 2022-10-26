using laba2.Collections;

namespace laba2.Entities; 

public class Cashbox {
    
    public delegate void routesHandler(string message);
    public event routesHandler notifyRoutes;
    
    public delegate void passengersHandler(string message);
    public event routesHandler notifyPassengers;
    
    public delegate void ticketHandler(string message);
    public event routesHandler notifyTicket;
    


    public Cashbox() {
        passengers = new List<Passenger>();
        routes = new Dictionary<string, Route>();
    }
    
    private List<Passenger> passengers;
    private Dictionary<string, Route> routes;

    public void addRoute(string city, int price) {
        routes.Add(city, new Route(city, price));
        notifyRoutes?.Invoke("Added route: " + city);
    }

    private Route getRouteByCity(string city) {
        return routes[city];
    }
    
    public void buyTicket(string name, string city) {
        Passenger currentPassenger;
        if (getPassengerByName(name) == null) {
            currentPassenger = new Passenger(name);
            passengers.Add(currentPassenger);
            notifyPassengers?.Invoke("New passenger added to DB: " + name);
        }

        currentPassenger = getPassengerByName(name);

        Route currentRoute = getRouteByCity(city);
        currentPassenger.getTickets().Add(new Ticket(currentRoute));
        notifyTicket?.Invoke(name + " bought ticket to " + city);
    }


    private Passenger getPassengerByName(string name) {
        try {
            int index = -1;
            for (int i = 0; i < passengers.Count; i++) {
                if (passengers[i].getName() == name) {
                    index = i;
                    break;
                }
            }
            return passengers[index];
        } catch (Exception ex) {
            return null;
        }

    }
    
    public int getPassengerTicketsPrice(string name) {
        int totalPrice = 0;
        Passenger currentPassenger = getPassengerByName(name);
        for (int i = 0; i < currentPassenger.getTickets().Count; i++) {
            totalPrice += currentPassenger.getTickets()[i].getRoute().getPrice();
        }
        return totalPrice;
    }

    public void getRoutes() {
        var sortedRoutes = from r in routes orderby r.Value.getPrice() select r;
        foreach (var r in sortedRoutes) {
            Console.WriteLine(r.Key + " " + r.Value.getPrice());
        }
    }


    public void getTotalTicketsCost() {
        int ans = 0;
        foreach (var p in passengers) {
            ans += p.getTickets().Sum(ticket => ticket.getRoute().getPrice());
        }
        Console.WriteLine("Total tickets cost: " + ans);
    }

    public void getMaxPassenger() {
        var answer = passengers.OrderBy(p => p.getTickets().Sum(t => t.getRoute().getPrice())).Last();
        Console.WriteLine("Max Cost Passenger: " + answer.getName());
    }

    public void getAmountOfPassengersGreaterThan(int sum) {
        int answer = passengers.Count(p => p.getTickets().Sum(t => t.getRoute().getPrice()) > sum);
        Console.WriteLine("The amount of passengers with total tickets cost greater than " + sum + ": " + answer);
    }

    public void getPassengersCosts(string name) {
        Passenger p = getPassengerByName(name);
        Console.WriteLine(name + "'s tickets cost:");
        var sortedTickets = p.getTickets().GroupBy(t => t.getRoute().getCity());
        foreach (var ticketsGroup in sortedTickets) {
            Console.Write(ticketsGroup.Key + ": ");
            int sum = 0;
            foreach (var ticket in ticketsGroup) {
                sum += ticket.getRoute().getPrice();
            }
            Console.WriteLine(sum);
        }
    }


}