using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoransJourneyTime
{
    class Game
    {
        public Game() 
        {
            InitializeStory();
        }

        Dictionary<float,Scene> story = new Dictionary<float,Scene>();
        float currentScene = 1.0f;
        public  string characterName = "";

        public void StartMenu()
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
                    AskForName();
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
        public void StartGame()
        {
            while (true)
            {
                DisplayScene();
                float choice = GetPlayerChoice();
                UpdateScene(choice);
            }
        }
  
        public void AskForName()
        {
            Console.Clear();
            Console.WriteLine($"Fill in your character name");
            characterName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"Great! Your name is now {characterName}");
            Console.ReadKey();
            Console.Clear();
        }

        private void InitializeStory()
        {
            StoryInitializer storyInitializer = new StoryInitializer();
            story = storyInitializer.InitializeStory();
        }

        void DisplayScene()
        {
            Console.Clear();
            foreach (char character in story[currentScene].Text)
            {
                Console.Write(character);
                Thread.Sleep(60);
            }
            Console.WriteLine("\n ");
            int choiceIndex = 0;

            foreach(Choice choice in story[currentScene].Choices)
            {
                choiceIndex++;
                Console.WriteLine($"{choiceIndex}. {choice.Option}");
            }
        }

        float GetPlayerChoice()
        {
            bool makingChoice = true;
            int choiceIndex = 0;

            while (makingChoice)
            {
                Console.WriteLine("\n Enter your choice");
                string choice = Console.ReadLine();

                if (choice == "Help")
                {
                    Console.WriteLine("TESTHELP");
                    Console.ReadKey();
                }
                else if(int.TryParse(choice, out choiceIndex) || choiceIndex >= 1 && choiceIndex < story[currentScene].Choices.Count)
                {
                    makingChoice = false;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid option.");
                    Console.Write("Enter your choice: ");
                }
            }
            return story[currentScene].Choices[choiceIndex - 1].NextScene;

        }

        void UpdateScene(float choice)
        {
            if (choice >= 1.0f && choice <= 5.0f) 
            {
                currentScene = choice;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please choose a valid option");
            }
        }

        public void Instructions()
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
        public void ContinueOrClose()
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
         void Dialog(string message)
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


