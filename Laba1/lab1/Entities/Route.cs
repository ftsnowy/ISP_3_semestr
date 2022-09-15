namespace lab1.Entities; 

public class Route {
    private string city;
    private int price;
    
    public Route(string city, int price) {
        this.city = city;
        this.price = price;
    }

    public string getCity() {
        return city;
    }

    public int getPrice() {
        return price;
    }
    
}