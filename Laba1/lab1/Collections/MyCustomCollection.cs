using lab1.Interfaces;

namespace lab1.Collections; 

public class MyCustomCollection <T> : ICustomCollection<T> {


    
    private class Node {
        public Node(Node next, T item) {
            this.next = next;
            this.item = item;
        }

        public Node(){}
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
            Node el = head;
            for (int i = 0; i < index; i++) {
                el = el.next;
            }
            return el.item;
        }
        set {
            Node el = head;
            for (int i = 0; i < index; i++) {
                el = el.next;
            }
            el.item = value;
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
        } else {
            Node newEl = new Node();
            newEl.item = item;
            tail.next = newEl;
            tail = newEl;
        }
        size++;
    }

    
    
    public void remove(T item) {
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
            return;
        }

        if (cursor == 0) {
            head = head.next;
        } else {
            Node e = head;
            for (int i = 0; i < cursor - 1; i++) {
                e = e.next;
            }
            e.next = e.next.next;
        }
        
        size--;
        
        
    }

    public void removeCurrent() {
        if (size == 0) {
            return;
        }
        if (cursor == 0) {
            head = head.next;
        } else {
            Node el = head;
            for (int i = 0; i < cursor - 1; i++) {
                el = el.next;
            }
            el.next = el.next.next;
        }
        
        size--;
    }
}