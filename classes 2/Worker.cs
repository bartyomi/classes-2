using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

class baker {

    int ID;
    int exp;
    bool busy;
    bool waiting;
    Node cooking;
    int cooking_time;

    public baker(int experience, int ID) {
        this.ID = ID;
        busy = false;
        waiting = false;
        exp = experience;
        cooking_time = 10 - experience;
    }

    public int get_exp() { return exp; }
    public bool get_busy() { return busy; }
    public bool get_waiting() { return waiting;}
    public int get_ID() { return ID; }
    public void set_exp(int exp) { this.exp = exp; }
    public void set_busy(bool busy) { this.busy = busy; }
    public void set_waiting(bool waiting) { this.waiting = waiting; }
    public Node get_cooking() { return cooking; }
    public void set_cooking(Node order) { cooking = order; }
    public void tick() { cooking_time--; if (cooking_time == 0) { busy = false; waiting = true; Console.WriteLine($"Order {cooking.getIndex()} is cooked, baker: {ID}"); } }
    public Node toStorage() { waiting = false; cooking_time = 10 - exp; return cooking; }




}

class carrier {

    int ID;
    int trunk;
    int way;
    int[,] carrying;
    int n_carrying;
    public carrier(int trunk, int ID) { 
        this.ID = ID;
        this.trunk = trunk;
        way = 0;
        carrying = new int[trunk, 2];
        n_carrying = 0;
    }
    public int get_way() { return way;}
    public void set_way(int way) { this.way = way; }
    public int get_trunk() { return trunk;}
    public int[,] get_carrying() { return carrying;}
    public int get_ID() { return ID; }
    public void set_carrying(Node order) { carrying[n_carrying, 0] = order.getData(); carrying[n_carrying, 1] = order.getIndex(); n_carrying++; }
    public void clear() {
        way = 0;
        carrying = new int[trunk, 2];
        n_carrying = 0;
    }
    public int tick() { way--; if (way == 0) { for (int i = 0; i < n_carrying; i++) Console.WriteLine($"Order {carrying[i, 1]} is delivered, carrier: {ID}"); clear(); return 1; } else return 0; }
    public void fromStorage(Node order) { if (order != null) { set_carrying(order); set_way(get_way() + order.getData()); } }

    }
