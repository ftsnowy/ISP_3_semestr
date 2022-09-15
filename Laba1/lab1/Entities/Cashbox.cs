using lab1.Collections;

namespace lab1.Entities; 

public class Cashbox {
    
    public Cashbox() {
        passengers = new MyCustomCollection<Passenger>();
        routes = new MyCustomCollection<Route>();
    }
    
    private MyCustomCollection<Passenger> passengers;
    private MyCustomCollection<Route> routes;

    public void addRoute(string city, int price) {
        routes.add(new Route(city, price));
    }


    private Route getRouteByCity(string city) {
        for (int i = 0; i < routes.getCount(); i++) {
            if (routes[i].getCity() == city) {
                return routes[i];
            }
        }
        return null;
    }
    
    public void buyTicket(string name, string city) {
        Passenger currentPassenger;
        if (getPassengerByName(name) == null) {
            currentPassenger = new Passenger(name);
            passengers.add(currentPassenger);
        }

        currentPassenger = getPassengerByName(name);

        Route currentRoute = getRouteByCity(city);
        currentPassenger.getTickets().add(new Ticket(currentRoute));
    }
    
    public void getPassengersByRoute(string city) {
        for (int i = 0; i < passengers.getCount(); i++) {
            for (int j = 0; j < passengers[i].getTickets().getCount(); j++) {
                if (passengers[i].getTickets()[j].getRoute().getCity() == city) {
                    Console.WriteLine(passengers[i].getName());
                    break;
                }
            }
        }
    }
    
    
    private Passenger getPassengerByName(string name) {
        int index = -1;
        for (int i = 0; i < passengers.getCount(); i++) {
            if (passengers[i].getName() == name) {
                return passengers[i];
            }
        }
        return null;
    }
    
    public int getPassengerTicketsPrice(string name) {
        int totalPrice = 0;
        Passenger currentPassenger = getPassengerByName(name);
        for (int i = 0; i < currentPassenger.getTickets().getCount(); i++) {
            totalPrice += currentPassenger.getTickets()[i].getRoute().getPrice();
        }
        return totalPrice;
    }
}