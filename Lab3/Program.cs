using System;
using System.Text;
using Lab3.Task1_Adapter;
using Lab3.Task2_Decorator;
using Lab3.Task3_Bridge;
using Lab3.Task4_Proxy;
using Lab3.Task5_Composite;
using Lab3.Task6_Flyweight;
using System.Collections.Generic;

namespace Lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.WriteLine("===== Task1_Adapter =====");

            Logger logger = new Logger();

            logger.Log("Звичайне повідомлення");
            logger.Error("Сталася помилка");
            logger.Warn("Попередження");

            FileWriter writer = new FileWriter("log.txt");
            Logger fileLogger = new FileLoggerAdapter(writer);

            fileLogger.Log("Запис у файл");
            fileLogger.Error("Помилка у файл");
            fileLogger.Warn("Попередження у файл");

            Console.WriteLine("Готово. Перевір файл log.txt");

            Console.WriteLine();
            Console.WriteLine("===== Task2_Decorator =====");

            Hero warrior = new Warrior();
            warrior = new Armor(warrior);
            warrior = new Weapon(warrior);

            Console.WriteLine("Герой 1:");
            Console.WriteLine(warrior.GetDescription());
            Console.WriteLine("Сила: " + warrior.GetPower());

            Console.WriteLine();

            Hero mage = new Mage();
            mage = new Artifact(mage);
            mage = new Weapon(mage);
            mage = new Armor(mage);

            Console.WriteLine("Герой 2:");
            Console.WriteLine(mage.GetDescription());
            Console.WriteLine("Сила: " + mage.GetPower());

            Console.WriteLine();

            Hero palladin = new Palladin();
            palladin = new Armor(palladin);
            palladin = new Artifact(palladin);

            Console.WriteLine("Герой 3:");
            Console.WriteLine(palladin.GetDescription());
            Console.WriteLine("Сила: " + palladin.GetPower());

            Console.WriteLine();
            Console.WriteLine("===== Task3_Bridge =====");

            IRenderer vectorRenderer = new VectorRenderer();
            IRenderer rasterRenderer = new RasterRenderer();

            Shape circleVector = new Circle(vectorRenderer);
            Shape circleRaster = new Circle(rasterRenderer);

            Shape squareVector = new Square(vectorRenderer);
            Shape squareRaster = new Square(rasterRenderer);

            Shape triangleVector = new Triangle(vectorRenderer);
            Shape triangleRaster = new Triangle(rasterRenderer);

            circleVector.Draw();
            circleRaster.Draw();

            squareVector.Draw();
            squareRaster.Draw();

            triangleVector.Draw();
            triangleRaster.Draw();

            Console.WriteLine();
            Console.WriteLine("===== Task4_Proxy =====");

            SmartTextReader smartReader = new SmartTextReader();

            ISmartTextReader checker = new SmartTextChecker(smartReader);
            char[][] text = checker.ReadText("text.txt");

            Console.WriteLine("Вміст файлу:");

            foreach (char[] line in text)
            {
                Console.WriteLine(new string(line));
            }

            Console.WriteLine();

            ISmartTextReader locker = new SmartTextReaderLocker(smartReader, @"secret|blocked|private");

            locker.ReadText("secret.txt");
            locker.ReadText("text.txt");

            Console.WriteLine();
            Console.WriteLine("===== Task5_Composite =====");

            LightElementNode ul = new LightElementNode(
                "ul",
                DisplayType.Block,
                ClosingType.WithClosingTag);

            ul.AddClass("menu");

            LightElementNode li1 = new LightElementNode(
                "li",
                DisplayType.Inline,
                ClosingType.WithClosingTag);

            li1.AddChild(new LightTextNode("Головна"));

            LightElementNode li2 = new LightElementNode(
                "li",
                DisplayType.Inline,
                ClosingType.WithClosingTag);

            li2.AddChild(new LightTextNode("Контакти"));

            LightElementNode li3 = new LightElementNode(
                "li",
                DisplayType.Inline,
                ClosingType.WithClosingTag);

            li3.AddChild(new LightTextNode("Про нас"));

            ul.AddChild(li1);
            ul.AddChild(li2);
            ul.AddChild(li3);

            Console.WriteLine(ul.OuterHTML());

            Console.WriteLine();
            Console.WriteLine("===== Task6_Flyweight =====");

            long memoryBefore = MemoryCounter.GetMemory();

            BookConverter converter = new BookConverter();

            List<LightNode> nodes = converter.ConvertBook("book.txt");

            long memoryAfter = MemoryCounter.GetMemory();

            Console.WriteLine("Кількість HTML елементів: " + nodes.Count);
            Console.WriteLine("Пам'ять до створення дерева: " + memoryBefore + " байт");
            Console.WriteLine("Пам'ять після створення дерева: " + memoryAfter + " байт");
            Console.WriteLine("Використано пам'яті: " + (memoryAfter - memoryBefore) + " байт");

            Console.WriteLine();
            Console.WriteLine("Перші 10 елементів HTML:");

            for (int i = 0; i < 10 && i < nodes.Count; i++)
            {
                Console.WriteLine(nodes[i].OuterHTML());
            }
        }
    }
}