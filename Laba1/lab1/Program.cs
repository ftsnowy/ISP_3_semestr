using lab1.Collections;
using lab1.Entities;

Cashbox cashbox = new Cashbox();
cashbox.addRoute("Homel", 40);
cashbox.addRoute("Vitebsk", 20);
cashbox.addRoute("Mohilev", 30);
cashbox.addRoute("Brest", 50);
cashbox.addRoute("Hrodno", 35);


cashbox.buyTicket("Danik", "Homel");
cashbox.buyTicket("Danik", "Vitebsk");
cashbox.buyTicket("Danik", "Brest");


cashbox.buyTicket("Katya", "Vitebsk");
cashbox.buyTicket("Katya", "Brest");
cashbox.buyTicket("Katya", "Mohilev");

cashbox.getPassengersByRoute("Vitebsk");

Console.WriteLine(cashbox.getPassengerTicketsPrice("Danik"));
Console.WriteLine(cashbox.getPassengerTicketsPrice("Katya"));