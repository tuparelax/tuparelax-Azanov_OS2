using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace OS_Practice2
{
    class Program
    {
        private const string HashesFile = "../../../keys.txt";
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать! Пожалуйста, выберите способ ввода:");
            Console.WriteLine("1. Читать хэши из файла");
            Console.WriteLine("2. Чтение хэшей из консоли");

            var choice = Convert.ToInt32(Console.ReadLine());

            List<string> hashes = new List<string>();
            switch (choice)
            {
                case 1:
                    hashes = ReadHashesFile();
                    break;
                case 2:
                    hashes = ReadHashesConsole();
                    
                    break;
                default:
                    Console.WriteLine("Неизвестный вариант");
                    break;
            }

            Console.Write("Выберите одиночный (1) или многопоточный (2) режим: ");

            var mode  = Convert.ToInt32(Console.ReadLine());
            foreach (var hash in hashes)
            {
               
                switch (mode)
                {
                    case 1:
                        SingleTread.Brut(hash);
                        
                        break;
                    case 2:
                        MultiThreading.gethash(hash);
                        break;
                    default:
                        Console.WriteLine("Неизвестный вариант");
                        break;
                }
                
            }
        }
        private static List<string> ReadHashesFile()
        {
            var reader = new StreamReader(HashesFile);
            var hashes = new List<string>();
            while (!reader.EndOfStream)
                hashes.Add(reader.ReadLine());
            reader.Close();
            return hashes;
        }

        private static List<string> ReadHashesConsole()
        {
            Console.WriteLine("Введите свои хэши построчно; Введите 0, чтобы остановить");
            var hashes = new List<string>();
            while (true)
            {
                var hash = Console.ReadLine();
                if (hash != "0")
                    hashes.Add(hash);
                else
                    break;
            }
            return hashes;
        }
    }
}