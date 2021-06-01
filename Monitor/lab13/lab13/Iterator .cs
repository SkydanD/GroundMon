using System;

namespace FactoryMethod
{

    class Program
    {
        static void Main(string[] args)
        {
            Storage storage = new Storage();
            Worker worker = new Worker();
            worker.SeeReagent(storage);

            Console.Read();
        }


        class Worker
        {
            public void SeeReagent(Storage storage)
            {
                IReagentIterator iterator = storage.CreateNumerator();
                while (iterator.HasNext())
                {
                    Item book = iterator.Next();
                    Console.WriteLine(book.Name);
                }
            }
        }

        interface IReagentIterator
        {
            bool HasNext();
            Item Next();
        }
        interface IReagentNumerable
        {
            IReagentIterator CreateNumerator();
            int Count { get; }
            Item this[int index] { get; }
        }
        class Item
        {
            public string Name { get; set; }
        }

        class Storage : IReagentNumerable
        {
            private Item[] Reagent;
            public Storage()
            {
                Reagent = new Item[]
               {
                    new Item{Name="Wheland Intermediate"},
                    new Item {Name="Wieland-Miescher Ketone"},
                    new Item {Name="Vilsmeier Reagent"}
               };
            }
            public int Count
            {
                get { return Reagent.Length; }
            }

            public Item this[int index]
            {
                get { return Reagent[index]; }
            }
            public IReagentIterator CreateNumerator()
            {
                return new StorageNumerator(this);
            }
        }
        class StorageNumerator : IReagentIterator
        {
            IReagentNumerable aggregate;
            int index = 0;
            public StorageNumerator(IReagentNumerable a)
            {
                aggregate = a;
            }
            public bool HasNext()
            {
                return index < aggregate.Count;
            }

            public Item Next()
            {
                return aggregate[index++];
            }
        }
    }
}
