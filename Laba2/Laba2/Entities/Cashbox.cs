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
        passengers = new MyCustomCollection<Passenger>();
        routes = new MyCustomCollection<Route>();
    }
    
    private MyCustomCollection<Passenger> passengers;
    private MyCustomCollection<Route> routes;

    public void addRoute(string city, int price) {
        routes.add(new Route(city, price));
        notifyRoutes.Invoke("Added route: " + city);
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
            notifyPassengers.Invoke("New passenger added to DB: " + name);
        }

        currentPassenger = getPassengerByName(name);

        Route currentRoute = getRouteByCity(city);
        currentPassenger.getTickets().add(new Ticket(currentRoute));
        notifyTicket.Invoke(name + " bought ticket to " + city);
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
        try {
            int index = -1;
            for (int i = 0; i < passengers.getCount(); i++) {
                if (passengers[i].getName() == name) {
                    index = i;
                    break;
                }
            }
            return passengers[index];
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
            return null;
        }

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