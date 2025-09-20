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

        public override void MakeSound()
        {
            Console.WriteLine($"{Name} the Lion Roars!");
        }

        public override string ToString()
        {
            string alphaStatus = IsAlpha ? "Alpha" : "Non-alpha";
            return $"{base.ToString()} ({alphaStatus})";
        }
    }

    public class Program
    {
        static void Main()
        {
            Animal alphaLion = new Lion("Leo", 5, true);
            Animal lion = new Lion("Lioness", 4, false);

            Console.WriteLine(alphaLion);
            alphaLion.MakeSound();

            Console.WriteLine(lion);
            lion.MakeSound();
        }
    }
}