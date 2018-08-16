using System;

namespace _04.Shopping_Spree
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputPeople = Console.ReadLine()
                       .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            string[] inputProducts = Console.ReadLine()
                .Split(new[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);

            int index = 0;
            int countPeople = inputPeople.Length / 2;
            for (int i = 0; i < countPeople; i++)
            {
                string[] infoForPerson = inputPeople[i].Split("=");
                int a = 4;
            }
        }
    }
}

