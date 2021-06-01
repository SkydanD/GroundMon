using System;

namespace FactoryMethod
{
    class FactoryMethod
    {
        static void Main(string[] args)
        {
            Worker workerS = new ScientistWorker("Serhii");
            workerS.Test();
            Worker workerA = new AssistentWorker("Misha");
            workerA.Test();

        }


        public abstract class Worker
        {
            public string name { get; set; }

            public Worker(string n)
            {
                name = n;
            }
            // фабричный метод
            abstract public Test Test();
        }
        // Проводит научные тесты
        public class ScientistWorker : Worker
        {
            public ScientistWorker(string n) : base(n)
            { }

            public override Test Test()
            {
                return new ScientistTest();
            }
        }
        // Проводит тесты ассистента
        public class AssistentWorker : Worker
        {
            public AssistentWorker(string n) : base(n)
            { }

            public override Test Test()
            {
                return new AssistentTest();
            }
        }

        public abstract class Test
        { }

        public class ScientistTest : Test
        {
            public ScientistTest()
            {
                Console.WriteLine("Научный тест произведён");
            }
        }
        public class AssistentTest : Test
        {
            public AssistentTest()
            {
                Console.WriteLine("Тест лаборанта произвидён");
            }
        }


    }
}
