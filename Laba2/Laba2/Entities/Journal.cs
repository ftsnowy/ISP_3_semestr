using laba2.Collections;

namespace laba2.Entities; 

public class Journal {
    private MyCustomCollection<string> logs;

    public Journal() {
        logs = new MyCustomCollection<string>();
    }

    public void addEvent(string log) {
        logs.add(log);
    }

    public void getLogs() {
        foreach (var log in logs) {
            Console.WriteLine(log);
        }
    }
    
}