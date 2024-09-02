using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoransAdventure
{
    class Program
    {

        public static void Main(string[] args)
        {
            Game.StartMenu();
        }

        class Game
        {
            public static void StartMenu()
            {
                Console.WriteLine("Welcome to the world of ... \n" +
                    "Make a choice to continue\n" +
                    "1. Start Game\n" +
                    "2. Load Game\n" +
                    "3. Credits\n" +
                    "4. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":

                        break;
                    case "2":

                        break;
                    case "3":

                        break;
                    case "4":
                        ContinueOrClose();
                        break;

                }
            }
            public static void ContinueOrClose()
            {
                Console.Clear();
                Console.WriteLine($"Are you sure you want to quit? press x to quit\n");

                string input = Console.ReadLine();

                if (input?.ToLower() == "x")
                {
                    Console.Clear();
                   System.Environment.Exit(1);
                }
                else
                {
                    Console.Clear();
                    StartMenu();
                }
            }

        }
        class Item
        {

        }
      
    }

   

}