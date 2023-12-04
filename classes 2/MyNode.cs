using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Node {
    public Node(int d) { data = d; }
    int index;
    int data;
    Node next;
    //Node previous;

    public void setNext(Node node) { next = node; }
    public Node getNext() { return next; }
    //public void setPrevious(Node node) { previous = node; }
    //public Node getPrevious() { return previous; }
    public void setData(int d) { data = d; }
    public int getData() { return data; }
    public void setIndex(int index) { this.index = index; }
    public int getIndex() { return index; }
}

class Node2 {
    public Node2(int d) { data = d; }
    int data;
    Node2 next;
    Node2 previous;

    public void setNext(Node2 node) { next = node; }
    public Node2 getNext() { return next; }
    public void setPrevious(Node2 node) { previous = node; }
    public Node2 getPrevious() { return previous; }
    public void setData(int d) { data = d; }
    public int getData() { return data; }
}