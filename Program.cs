using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Practice:
Develop a small (5-6 entities) model for animal world using classes and interfaces. 
Develop a generic class Group for storing animals in groups.
*/

namespace FourthTask
{
    interface IWalk
    {
        void FoodSearch(bool _search);
    }

    interface IFly
    {
        void FoodSearch(bool _search);
    }

    interface ISwim
    {
        void FoodSearch(bool _search);
    }

    abstract class Animal
    {
        private string species;
        private int energy;

        public string Species
        {
            get
            {
                return species;
            }

            set
            {
                species = value;
            }
        }

        public int Energy
        {
            get
            {
                return energy;
            }

            set
            {
                energy = value;
            }
        }

        public void Eat()
        {
            Random rand = new Random();
            int upEnergy = rand.Next(1, 51);
            Energy += upEnergy;
            Console.WriteLine("Received energy: " + upEnergy);
        }

        public void FoundFood()
        {
            bool[] findFood = new bool[2];
            findFood[0] = true;
            findFood[1] = false;
            Random rand = new Random();
            bool foodFounded = findFood[rand.Next(0, 2)];
            if (foodFounded)
            {
                Eat();
                Console.WriteLine("Current energy: " + Energy);
            }
            else
                Console.WriteLine("Food not found.");
        }
    }

    class Dog : Animal, IWalk
    {
        public void FoodSearch(bool _search)
        {
            if (_search)
            {
                Console.WriteLine("Search on the land.");
                FoundFood();
            }
        }
    }

    class Crocodile : Animal, IWalk, ISwim
    {
        public void FoodSearch(bool _search)
        {
            if (_search)
            {
                Console.WriteLine("Search on the land.");
                FoundFood();
            }
        }

        void ISwim.FoodSearch(bool _search)
        {
            if (_search)
            {
                Console.WriteLine("Search in the water.");
                FoundFood();
            }
        }
    }

    class Bat : Animal, IWalk, IFly
    {
        void IWalk.FoodSearch(bool _search)
        {
            if (_search)
            {
                Console.WriteLine("Search on the land.");
                FoundFood();
            }
        }

        void IFly.FoodSearch(bool _search)
        {
            if (_search)
            {
                Console.WriteLine("Search on the air.");
                FoundFood();
            }
        }
    }

    class Crucian : Animal, ISwim
    {
        public void FoodSearch(bool _search)
        {
            if (_search)
            {
                Console.WriteLine("Search in the water.");
                FoundFood();
            }
        }
    }

    class Goose : Animal, IWalk, ISwim, IFly
    {
        void IWalk.FoodSearch(bool _search)
        {
            if (_search)
            {
                Console.WriteLine("Search on the land.");
                FoundFood();
            }
        }

        void IFly.FoodSearch(bool _search)
        {
            if (_search)
            {
                Console.WriteLine("Search on the air.");
                FoundFood();
            }
        }

        void ISwim.FoodSearch(bool _search)
        {
            if (_search)
            {
                Console.WriteLine("Search in the water.");
                FoundFood();
            }
        }
    }

    class Group<TName>
    {
        TName[] name = new TName[10];
        TName[] value = new TName[10];
        int position1;
        int position2;

        public void Push(TName _name, TName _value)
        {
            name[position1++] = _name;
            value[position2++] = _value;
        }

        public void Print()
        {
            for(int i = 0; i < name.Length; i++)
            {
                Console.WriteLine("Name: " + name[i]);
            }
            for (int i = 0; i < value.Length; i++)
            {
                Console.WriteLine("Value: " + value[i]);
            }
            
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dog d1 = new Dog { Species = "Labrador Retriever" };
            d1.FoodSearch(true);

            Crocodile c1 = new Crocodile { Species = "Nile crocodile" };
            c1.FoodSearch(true);
            ((ISwim)c1).FoodSearch(true);

            Bat b1 = new Bat { Species = "Desert long-eared bat" };
            ((IWalk)b1).FoodSearch(true);
            ((IFly)b1).FoodSearch(true);

            Crucian k1 = new Crucian { Species = "Gold crucian" };
            k1.FoodSearch(true);

            Goose g1 = new Goose { Species = "Grey goose" };
            ((ISwim)g1).FoodSearch(true);
            ((IFly)g1).FoodSearch(true);
            ((IWalk)g1).FoodSearch(true);

            Group<string> group = new Group<string>();

            group.Push("psovie", d1.Species);
            group.Push("crocodiloobraznie", c1.Species);
            group.Push("mishinie", b1.Species);
            group.Push("karpovie", k1.Species);
            group.Push("guseobraznie", g1.Species);
            group.Print();

            Console.ReadKey();
        }
    }
}
