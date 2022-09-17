using System.Collections;
using laba2.Interfaces;

namespace laba2.Collections;

public class MyCustomCollection<T> : ICustomCollection<T>, IEnumerable<T> {
    private class Node {
        
        public Node(Node next, T item) {
            this.next = next;
            this.item = item;
        }

        public Node() { }
        public Node next;
        public T item;
    }


    public MyCustomCollection() {
        size = 0;
        cursor = 0;
    }

    private Node head = new Node();
    private Node tail = new Node();
    private int size;
    private int cursor;


    private bool compare(T t1, T t2) {
        return EqualityComparer<T>.Default.Equals(t1, t2);
    }

    public T this[int index]
    {
        get {
            if (index >= size || index < 0) {
                throw new IndexOutOfRangeException("Index out of range");
            }

            Node el = head;
            for (int i = 0; i < index; i++) {
                el = el.next;
            }

            return el.item;
        }
        set {
            try {
                if (index >= size) {
                    throw new IndexOutOfRangeException("Index out of range");
                }

                Node el = head;
                for (int i = 0; i < index; i++) {
                    el = el.next;
                }
                el.item = value;
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public void reset() {
        size = 0;
        cursor = 0;
        head = new Node();
        tail = new Node();
    }

    public void next() {
        cursor++;
    }

    public T current() {
        return this[cursor];
    }

    public int getCount() {
        return size;
    }

    public void add(T item) {
        if (size == 0) {
            head.item = item;
            tail = head;
        }
        else {
            Node newEl = new Node();
            newEl.item = item;
            tail.next = newEl;
            tail = newEl;
        }

        size++;
    }


    public void remove(T item) {
        try {
            if (size == 0) {
                return;
            }

            int index = -1;
            Node el = head;
            for (int i = 0; i < size; i++) {
                if (compare(el.item, item)) {
                    index = i;
                    break;
                }

                el = el.next;
            }

            if (index == -1) {
                throw new Exception("This element isn't present in the collection");
            }

            if (cursor == 0) {
                head = head.next;
            }
            else {
                Node e = head;
                for (int i = 0; i < cursor - 1; i++) {
                    e = e.next;
                }

                e.next = e.next.next;
            }

            size--;
        }
        catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public void removeCurrent() {
        if (size == 0) {
            return;
        }

        if (cursor == 0) {
            head = head.next;
        }
        else {
            Node el = head;
            for (int i = 0; i < cursor - 1; i++) {
                el = el.next;
            }

            el.next = el.next.next;
        }

        size--;
    }

    public IEnumerator<T> GetEnumerator() {
        List<T> items = new List<T>();
        Node el = head;
        for (int i = 0; i < size; i++) {
            items.Add(el.item);
            el = el.next;
        }

        return items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }
}