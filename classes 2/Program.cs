using System;
using System.Runtime.InteropServices;

class Program {

    static string pathin = "D:\\YandexDisk\\Хлам\\лабы\\ВМП\\classes\\classes 2\\in.txt";
    static void Main() {
        //константы
        int nb = 5;
        int nc = 5;
        int nq = 20;
        int t = 5;
        //

        //ввод
        string tmp = File.ReadAllText(pathin);
        string[] tmps = tmp.Split(' ', '\n');
        baker[] bakers = new baker[nb];
        carrier[] carriers = new carrier[nc];
        Queue storage = new Queue(t);
        Queue queue = new Queue();
        int[] orders= new int[nq];
        for (int i = 0; i < nb; i++) {
            bakers[i] = new baker(Convert.ToInt32(tmps[i]), i);
        }
        for (int i = nb; i < nb+nc; i++) {
            carriers[i-nb] = new carrier(Convert.ToInt32(tmps[i]), i-nb);
        }
        for (int i = nb+nc; i < nb + nc + nq; i++) {
            orders[i - nb - nc] = Convert.ToInt32(tmps[i]);
        }
        //

        bakers = sort(bakers);
        carriers = sort(carriers);
        //

        int done = 0;
        int tick = 0;
        int next = 0;

        while (done < nq) {
            Console.WriteLine($"Tick: {tick}");

            for (int i = 0; i < nc; i++) {
                if (carriers[i].get_way() != 0) {
                    done += carriers[i].tick();
                }
            }

            bool cont = true;
            while (storage.getHead() != null && cont) {
                cont = false;
                if (max(carriers) >= storage.getSize()) {
                    for (int i = 0; i < nc; i++) {
                        if (carriers[i].get_way() == 0 && carriers[i].get_trunk() >= storage.getSize()) {
                            for (int j = 0; j < carriers[i].get_trunk(); j++) {
                                carriers[i].fromStorage(storage.front());
                                if (storage.front() != null) Console.WriteLine($"Order {storage.front().getIndex()} is being delivered, carrier: {carriers[i].get_ID()}");
                                storage.popfront();
                                cont = true;
                                if (storage.getHead() == null) break;
                            }
                        }
                    }
                }
                else {
                    for (int i = nc-1; i >= 0; i--) {
                        if (carriers[i].get_way() == 0) {
                            for (int j = 0; j < carriers[i].get_trunk(); j++) {
                                carriers[i].fromStorage(storage.front());
                                storage.popfront();
                                cont = true;
                                if (storage.getHead() == null) { break; }
                            }
                        }
                    }
                }
            }

            if (storage.getHead() != null) {
                Console.WriteLine("Storage:");
                storage.print();
            }

            for (int i = 0; i < nb; i++) { 
                if (bakers[i].get_busy() == true) {
                    bakers[i].tick();
                }
            }

            while (storage.getSize() <= t) {
                int min = 10000;
                int min_index = -1;
                for (int i = 0; i < nb; i++) {
                    if (bakers[i].get_waiting() == true) {
                        if (min > bakers[i].get_cooking().getIndex()) { min = bakers[i].get_cooking().getIndex(); min_index = i; }
                    }
                }
                if (min_index != -1) {
                    storage.push(bakers[min_index].toStorage());
                    Console.WriteLine($"Order {storage.front().getIndex()} in storage, baker: {bakers[min_index].get_ID()}");
                }
                else break;
            }

            if (tick < nq) queue.push(orders[tick], tick);
            cont = true;
            while (queue.getHead() != null && cont) {
                cont = false;
                for (int j = 0; j < nb; j++) {
                    if (bakers[j].get_busy() == false && bakers[j].get_waiting() == false) {
                        bakers[j].set_busy(true);
                        bakers[j].set_cooking(queue.front());
                        queue.popfront();
                        Console.WriteLine($"Order {next+1} is being cooked, baker: {bakers[j].get_ID()}");
                        next++;
                        cont = true;
                        break;
                    }
                }


            }

            if (storage.getHead() != null) {
                Console.WriteLine("Storage:");
                storage.print();
            }

            Thread.Sleep(1000);

            tick++;

        }

        print(bakers, 'e');
        print(bakers, 'b');
        print(bakers, 'w');
        print(carriers, 't');
        print(carriers, 'w');
        queue.print();
        bakers = sort(bakers);
        carriers = sort(carriers);
        print(bakers, 'e');
        print(bakers, 'b');
        print(bakers, 'w');
        print(carriers, 't');
        print(carriers, 'w');
        queue.print();



        Thread.Sleep(1000);

    }

    static public baker[] sort(baker[] array) {
        for (int i = 0; i < array.Length; i++) {
            for (int j = array.Length - 1; j > i; j--) {
                if (array[j].get_exp() > array[i].get_exp()) {
                    baker tmp = array[i];
                    array[i] = array[j];
                    array[j] = tmp;
                }
            }
        }
        return array;
    }

    static public carrier[] sort(carrier[] array) {
        for (int i = 0; i < array.Length; i++) {
            for (int j = array.Length - 1; j > i; j--) {
                if (array[j].get_trunk() < array[i].get_trunk()) {
                    carrier tmp = array[i];
                    array[i] = array[j];
                    array[j] = tmp;
                }
            }
        }
        return array;
    }

    static public int max(carrier[] carriers) {
        int max = 0;
        for (int i = 0; i < carriers.Length; i++) if (carriers[i].get_way() == 0 && carriers[i].get_trunk() > max) max = carriers[i].get_trunk();
        return max;
    }

    static public void print(baker[] array, char t) {
        switch (t) {
            case 'e':
                Console.WriteLine("Exp:");
                for(int i = 0; i < array.Length; i++) Console.Write($"Baker {i + 1}: {array[i].get_exp()}, ");
                Console.Write("\n");
                break;
            case 'b':
                Console.WriteLine("Busy:");
                for (int i = 0; i < array.Length; i++) Console.Write($"Baker {i + 1}: {array[i].get_busy()}, ");
                Console.Write("\n");
                break;
            case 'w':
                Console.WriteLine("Waiting:");
                for (int i = 0; i < array.Length; i++) Console.Write($"Baker {i + 1}: {array[i].get_waiting()}, ");
                Console.Write("\n");
                break;
        }
    }

    static public void print(carrier[] array, char t) {
        switch (t) {
            case 't':
                Console.WriteLine("Trunk:");
                for (int i = 0; i < array.Length; i++) Console.Write($"Carrier {i + 1}: {array[i].get_trunk()}, ");
                Console.Write("\n");
                break;
            case 'w':
                Console.WriteLine("Way:");
                for (int i = 0; i < array.Length; i++) Console.Write($"Carrier {i + 1}: {array[i].get_way()}, ");
                Console.Write("\n");
                break;
        }
    }

    static void print(int[] array) {
        Console.WriteLine("All queue:");
        for (int i = 0; i < array.Length; i++) Console.Write($"Pizza {i + 1}: {array[i]}, ");
        Console.Write("\n");
    }
    static void print(int[] array, int tick) {
        Console.WriteLine("Queue:");
        for (int i = 0; i < tick; i++) Console.Write($"Pizza {i + 1}: {array[i]}, ");
        Console.Write("\n");
    }
}