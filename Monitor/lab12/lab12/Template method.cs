using System;

namespace FactoryMethod
{

    class Program
    {
        static void Main(string[] args)
        {
            Scientist scientist = new Scientist();
            Assistent assistent = new Assistent();

            scientist.Testing();
            assistent.Testing();

            Console.Read();
        }

        abstract class Test
        {
            public void Testing()
            {
                TakeSample();
                ProcessSample();
                Investigate();
                WriteNotes();
            }
            public virtual void TakeSample()
            {
                Console.WriteLine("Берем образец");
            }
            public virtual void ProcessSample()
            {
                Console.WriteLine("Обрабатываем образец");

            }
            public abstract void Investigate();
            public virtual void WriteNotes()
            {
                Console.WriteLine("Документируем");

            }


        }

        class Scientist : Test
        {
            public override void Investigate()
            {
                Console.WriteLine("Исследуем образец с помощью спец приборов доступны только на должности ученого");
            }
        }
        class Assistent : Test
        {
            public override void Investigate()
            {
                Console.WriteLine("Исследуем образец с помощью спец приборов доступны только на должности ассистента");
            }
        }
    }
}

