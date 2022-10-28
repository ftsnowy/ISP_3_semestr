namespace Laba4;

public interface IFileService<T>  {
    IEnumerable<T> readFile(string fileName);
    void saveData(IEnumerable<T> data, string fileName);
}