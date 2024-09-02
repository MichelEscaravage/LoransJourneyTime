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
            static string characterName = ""; 
            public static void StartMenu()
            {
                Console.WriteLine("Welcome to the world of ... \n" +
                    "Make a choice to continue\n" +
                    "1. Start new Game\n" +
                    "2. Load Game\n" +
                    "3. Instructions\n" +
                    "4. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        StartGame();
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
            public static void StartGame()
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Adventure Game!");
                Console.WriteLine("Welcome to the adventurous world of .... ");
                Console.ReadKey();

                AskForName();

                Dialog("Welcome to .... " + characterName);
                Choice();
            }
            static void Choice()
            {
                string input = "";
                Console.WriteLine("Which will you choose? A or B?");
                Console.ReadLine();

                if (input.ToLower() == "A")
                {
                    Console.Clear();
                    Console.WriteLine(characterName + " You've chosen path A!");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine(characterName + " You've chosen path B!");
                }
            }
            public static void AskForName()
            {
                Console.Clear();
                Console.WriteLine($"Fill in your character name");
                characterName = Console.ReadLine();
                Console.Clear();
                Console.WriteLine($"Great! Your name is now {characterName}");
                Console.ReadKey();
                Console.Clear();
            }

            public static void Instructions()
            {
                Console.WriteLine("INSTRUCTIONS");
                string continueStory = Console.ReadLine();

                switch (continueStory)
                {
                    case "1":
                        StartMenu();
                        break;
                    case "2":
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
            static void Dialog(string message)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(message);
                Console.ResetColor();
            }
        }
        class Item
        {

        }
      
    }

   

}