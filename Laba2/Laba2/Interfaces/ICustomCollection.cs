namespace laba2.Interfaces;

public interface ICustomCollection<T>
{
    T this[int index]
    {
        get;
        set;
    }

    void reset();
    void next();
     T current();
    int getCount();
    void add(T item);
    void remove(T item);
    void removeCurrent();
    
}