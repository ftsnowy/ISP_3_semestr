﻿// See https://aka.ms/new-console-template for more information

using laba2.Collections;
using laba2.Entities;

Cashbox cashbox = new Cashbox();
Journal journal = new Journal();




// cashbox.notifyRoutes += journal.addEvent;
// cashbox.notifyPassengers += journal.addEvent;
//
//
// cashbox.notifyTicket += str => displayMessage(str);

cashbox.addRoute("Homel", 300);
cashbox.addRoute("Vitebsk", 250);
cashbox.addRoute("Mohilev", 200);
cashbox.addRoute("Brest", 350);



cashbox.buyTicket("Daniil", "Homel");
cashbox.buyTicket("Daniil", "Vitebsk");
cashbox.buyTicket("Daniil", "Brest");
cashbox.buyTicket("Daniil", "Vitebsk");
cashbox.buyTicket("Katya", "Brest");
cashbox.buyTicket("Katya", "Mohilev");
cashbox.buyTicket("Katya", "Homel");

cashbox.getRoutes();
cashbox.getTotalTicketsCost();
cashbox.getMaxPassenger();
cashbox.getAmountOfPassengersGreaterThan(600);
cashbox.getPassengersCosts("Daniil");

// journal.getLogs();

void displayMessage(string message) {
    Console.WriteLine(message);
}

