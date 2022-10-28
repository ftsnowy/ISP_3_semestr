namespace Laba4; 

public class Computer {
    private string brand;
    private int price;
    private bool isSold;
    
    public Computer(){}

    public Computer(string brand, int price, bool isSold) {
        this.brand = brand;
        this.price = price;
        this.isSold = isSold;
    }

    public string getBrand() {
        return brand;
    }
    
    public int getPrice() {
        return price;
    }
    
    
    public bool getIsSold() {
        return isSold;
    }

    public void printInfo() {
        Console.WriteLine(brand + " " + price + " " + isSold);
    }
    
}