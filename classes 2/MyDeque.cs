using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Deque {
    int size;
    Node2 head;
    Node2 tail;

    public Deque() {
        int size = 0;
        Node2 head = null;
        Node2 tail = null;
    }

    public void pushFront(int d) {
        Node2 node = new Node2(d);
        node.setNext(head);
        node.setPrevious(null);
        if (head != null) {
            head.setPrevious(node);
        }
        head = node;
        if (tail == null) { tail = node; }
        size++;
    }
    public void popFront() {
        head = head.getNext();
        head.setPrevious(null);
        size--;
    }
    public void pushBack(int d) {
        Node2 node = new Node2(d);
        node.setNext(null);
        node.setPrevious(tail);
        if (tail != null) { tail.setNext(node); }
        tail = node;
        if (head == null) { head = node; }
        size++;
    }
    public void popBack() {
        tail = tail.getNext();
        tail.setNext(null);
        size--;
    }
    public void find(int d, char a) {
        int id = -1;
        Node2 node = head;
        for (int i = 0; i < size; i++) {
            if (node.getData() == d) { id = i; break; }
            node = node.getNext();
        }
        if (id == -1) { Console.WriteLine("Не найдено"); }
        else { Console.WriteLine($"Найден на {id} позиции"); }
        //return node;
    }

    public Node2 find(int d) {
        int id = -1;
        Node2 node = head;
        for (int i = 0; i < size; i++) {
            if (node.getData() == d) { id = i; break; }
            node = node.getNext();
        }
        if (id == -1) { Console.WriteLine("Не найдено"); }
        else { Console.WriteLine($"Найден на {id} позиции"); }
        return node;
    }
    public void pop(int d) {
        Node2 tmp = find(d);
        Node2 node = new Node2(0);
        if (tmp.getPrevious() == null) {
            node = tmp.getNext();
            node.setPrevious(tmp.getPrevious());
            size--;
        }
        else if (tmp.getNext() == null) {
            node = tmp.getPrevious();
            node.setNext(tmp.getNext());
            size--;
        }

        else {
            node = tmp.getPrevious();
            node.setNext(tmp.getNext());
            node = tmp.getNext();
            node.setPrevious(tmp.getPrevious());
            size--;
        }
    }
    public void print() {
        Node2 node = head;
        int d = node.getData();
        for (int i = 0; i < size; i++) { Console.WriteLine($"{i} : {node.getData()}"); node = node.getNext(); }
    }

}
