using Laba4;

string path = "Computers.det";
string newPath = "NewComputers.det";


List<Computer> computers1 = new List<Computer>();

FileService f = new FileService();


computers1.Add(new Computer("Asus", 2100, false));
computers1.Add(new Computer("Lenovo", 2600, true));
computers1.Add(new Computer("Asus", 3200, true));
computers1.Add(new Computer("HP", 2400, false));
computers1.Add(new Computer("Acer", 2700, true));

f.saveData(computers1, path);

File.Move(path, newPath);



List<Computer> computers2 = new List<Computer>();
foreach (var i in f.readFile(newPath)) {
    computers2.Add(i);
}

foreach (var i in computers2) {
    i.printInfo();
}

Console.WriteLine("////////////////////////////");

var sortedByName = computers2.OrderBy(c => c, new MyCustomComparer());
foreach (var i in sortedByName) {
    i.printInfo();
}

Console.WriteLine("////////////////////////////");

var sortedByPrice = computers2.OrderBy(c => c.getPrice());
foreach (var i in sortedByPrice) {
    i.printInfo();
}