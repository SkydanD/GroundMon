using System;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Reagent reag = new Wheland();
            reag = new WhelandIntermediate(reag); // Wheland Intermidiate
            Console.WriteLine("Название: {0}", reag.Name);
            Console.WriteLine("Количество: {0}", reag.GetQty());
            Console.ReadLine();
        }


        abstract class Reagent
        {
            public Reagent(string n)
            {
                this.Name = n;
            }
            public string Name { get; protected set; }
            public abstract int GetQty();
        }

        class Wheland : Reagent
        {
            public Wheland() : base("Wheland")
            { }
            public override int GetQty()
            {
                return 4;
            }
        }

        abstract class ReagentDecorator : Reagent
        {
            protected Reagent reagent;
            public ReagentDecorator(string n, Reagent reagent) : base(n)
            {
                this.reagent = reagent;
            }
        }

        class WhelandIntermediate : ReagentDecorator
        {
            public WhelandIntermediate(Reagent r)
            : base(r.Name + " Intermidiate", r)
            { }

            public override int GetQty()
            {
                return reagent.GetQty() + 13;
            }
        }


    }
}

