using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

class Queue {
    int maxSize = -1;
    int size;
    Node head;

    public Queue(int max) {
        int maxSize = max;
        int size = 0;
        Node head = null;
    }

    public Queue() {
        int maxSize = -1;
        int size = 0;
        Node head = null;
    }

    public int getSize() { return size; }
    public Node getHead() { return head; }
    public void push(int d) {
        if (size + 1 < maxSize || maxSize == -1) {
            Node tmp = new Node(d);
            tmp.setNext(head);
            head = tmp;
            if (head != null) tmp.setIndex(head.getIndex() + 1);
            else { tmp.setIndex(0); }
            size++;
        }
        else Console.WriteLine("Не влезло");

    }

    public void push(int d, int ID) {
        if (size + 1 < maxSize || maxSize == -1) {
            Node tmp = new Node(d);
            tmp.setNext(head);
            head = tmp;
            if (head != null) tmp.setIndex(ID + 1);
            else { tmp.setIndex(ID + 1); }
            size++;
        }
        else Console.WriteLine("Не влезло");

    }
    public void push(Node d) {
        if (size + 1 < maxSize || maxSize == -1) {
            Node tmp = d;
            tmp.setNext(head);
            head = tmp;
            //if (head != null) tmp.setIndex(head.getIndex() + 1);
            //else tmp.setIndex(0);
            size++;
        }
        else Console.WriteLine("Не влезло");

    }
    /*public void popBack() {
        tail = tail.getNext();
        tail.setNext(null);
        size--;
    }*/

    public void find(int d, char a) {
        int id = -1;
        Node node = head;
        for (int i = 0; i < size; i++) {
            if (node.getData() == d) { id = i; break; }
            node = node.getNext();
        }
        if (id == -1) { Console.WriteLine("Не найдено"); }
        else { Console.WriteLine($"Найден на {id} позиции"); }
        //return node;
    }

    public Node find(int d) {
        int id = -1;
        Node node = head;
        for (int i = 0; i < size; i++) {
            if (node.getData() == d) { id = i; break; }
            node = node.getNext();
        }
        if (id == -1) { Console.WriteLine("Не найдено"); }
        else { Console.WriteLine($"Найден на {id} позиции"); }
        return node;
    }
    public void popfront() {
        if (size > 1) {
            Node tmp = head;
            for (int i = 0; i < size - 2; i++) {
                tmp = tmp.getNext();
            }
            tmp.setNext(null);
        }
        else head = null;
        size--;

    }
    public Node front() {
        Node tmp = head;
        if (size == 1) return tmp;
        else {
            for (int i = 0; i < size - 1; i++) {
                tmp = tmp.getNext();
            }
            return tmp;
        }
    }
    public void print() {
        Node node = head;
        int d = node.getIndex();
        for (int i = 0; i < size; i++) { Console.WriteLine($"{i} : {node.getIndex()}"); node = node.getNext(); }
        Console.WriteLine();
    }

}

