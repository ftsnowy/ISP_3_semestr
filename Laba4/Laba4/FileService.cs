namespace Laba4; 

using System.IO;

public class FileService  : IFileService<Computer> {
    
    public IEnumerable<Computer> readFile(string fileName) {
        if (!File.Exists(fileName)) {
            yield break;
        }
        
        using (BinaryReader reader = new BinaryReader(new FileStream(fileName, FileMode.Open))) {
            while (reader.PeekChar() > -1) {
                    string brand = reader.ReadString();
                    int price = reader.ReadInt32();
                    bool isSold = reader.ReadBoolean();
                    yield return new Computer(brand, price, isSold);
            }
        }
    }

    public void saveData(IEnumerable<Computer> data, string fileName) {
        if (File.Exists(fileName)) {
            File.Delete(fileName);
        }
        try {
            using (BinaryWriter writer = new BinaryWriter(new FileStream(fileName, FileMode.OpenOrCreate))) {
                foreach (var d in data) {
                    writer.Write(d.getBrand());
                    writer.Write(d.getPrice());
                    writer.Write(d.getIsSold());
                }
            }
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}