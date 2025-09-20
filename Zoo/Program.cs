using System;

namespace Zoo
{
    public abstract class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }

        protected Animal(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public abstract void MakeSound();

        public override string ToString()
        {
            return $"{GetType().Name}: {Name}, {Age} years old";
        }
    }

    public class Lion : Animal
    {
        public bool IsAlpha { get; set; }

        public Lion(string name, int age, bool isAlpha) : base(name, age)
        {
            this.IsAlpha = isAlpha;
        }

        public Lion(string name, int age) : this(name, age, false) { }

        public override void MakeSound()
        {
            Console.WriteLine($"{Name} the Lion roars: Roar!");
        }

        public override string ToString()
        {
            string alphaStatus = IsAlpha ? "Alpha" : "Non-alpha";
            return $"{base.ToString()} ({alphaStatus})";
        }
    }

    public class Parrot : Animal
    {
        private static readonly Random rnd = new Random();

        // Vocabulary: list of words the parrot knows
        public List<string> Vocabulary { get; private set; }

        // Allow vocabulary to be optional
        public Parrot(string name, int age, List<string> vocabulary = null)
            : base(name, age)
        {
            Vocabulary = vocabulary ?? new List<string>();
        }

        public override void MakeSound()
        {
            Console.WriteLine($"{Name} the Parrot squawks: Squawk!");
        }

        public void Speak()
        {
            if (Vocabulary.Count > 0)
            {
                string word = Vocabulary[rnd.Next(Vocabulary.Count)];
                Console.WriteLine($"{Name} says: {word}!");
            }
            else
            {
                Console.WriteLine($"{Name} doesn't know any words yet.");
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()} (Vocabulary size: {Vocabulary.Count})";
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Animal leo = new Lion("Leo", 5, true);
            Animal nala = new Lion("Nala", 4);

            Console.WriteLine(leo);
            leo.MakeSound();

            Console.WriteLine(nala);
            nala.MakeSound();

            var words = new List<string> { "Hello", "Pretty bird", "Polly wants a cracker" };
            Parrot parrot = new Parrot("Polly", 3, words);

            Console.WriteLine(parrot);
            parrot.MakeSound();
            parrot.Speak();
            parrot.Speak();

            Console.ReadKey();
        }
    }
}