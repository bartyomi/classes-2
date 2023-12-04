using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Stack {
    int size;
    Node head;

    public Stack() {
        int size = 0;
        Node head = null;
    }

    public int getSize() { return size; }
    public Node getHead() { return head; }
    public void push(int d) {
        Node tmp = new Node(d);
        tmp.setNext(head);
        head = tmp;
        size++;
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

    public void popback() {
        head = head.getNext();
        size--;
    }
    public void print() {
        Node node = head;
        int d = node.getData();
        for (int i = 0; i < size; i++) { Console.WriteLine($"{i} : {node.getData()}"); node = node.getNext(); }
        Console.WriteLine();
    }

}

