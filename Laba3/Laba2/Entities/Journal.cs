using laba2.Collections;

namespace laba2.Entities; 

public class Journal {
    private List<string> logs;

    public Journal() {
        logs = new List<string>();
    }

    public void addEvent(string log) {
        logs.Add(log);
    }

    public void getLogs() {
        foreach (var log in logs) {
            Console.WriteLine(log);
        }
    }
    
}