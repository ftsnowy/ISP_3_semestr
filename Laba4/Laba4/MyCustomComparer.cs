namespace Laba4; 

public class MyCustomComparer : IComparer<Computer> {
    public int Compare(Computer? x, Computer? y) {
        return String.CompareOrdinal(x.getBrand(), y.getBrand());
    }
}