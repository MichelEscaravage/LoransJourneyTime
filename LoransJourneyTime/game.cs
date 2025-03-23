using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Threading;

namespace LoransJourneyTime
{
    class Game
    {
        private List<string> commands = new List<string>();
        private Dictionary<float, Scene> story = new Dictionary<float, Scene>();
        private Instruction instruction = new Instruction();
        private float currentScene = 1.0f;
        public string characterName = "";
        private int Karma = 0;
        private static string filePath = "";
        private Mp3FileReader? audioFile;
        WaveOutEvent outputDevice = new WaveOutEvent();
        private Scene.SceneType? lastSceneType = null;


        // Constructor: Initializes the game by setting up the story and available commands.
        public Game()
        {
            InitializeStory();
            commands.Add("help");
            commands.Add("save");
            commands.Add("karma");
        }

        // Initializes the game story by loading scenes and choices.
        private void InitializeStory()
        {
            StoryInitializer storyInitializer = new StoryInitializer();
            story = storyInitializer.InitializeStory(this);
        }

        // Displays the start menu with options to start a new game, load a game, view instructions, or exit.
        public void ShowStartMenu()
        {

            Console.WriteLine("Welcome pelgrim, are you ready to go on an adventure? \n" +
                              "Make a choice to continue\n" +
                              "1. Start new Game\n" +
                              "2. Load Game\n" +
                              "3. Instructions\n" +
                              "4. Exit");
        }

        // Handles the player's choice from the start menu and navigates to the appropriate action.
        public void StartMenuChoice()
        {
            ShowStartMenu();

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AskForName();
                    StartGame();
                    break;
                case "2":
                    LoadGame();
                    break;
                case "3":
                    DisplayInstructions();
                    Console.Clear();
                    StartMenuChoice();
                    break;
                case "4":
                    ContinueOrClose();
                    break;
            }
        }

        // Prompts the player to confirm if they want to quit the game, and exits if confirmed.
        public void ContinueOrClose()
        {
            Console.Clear();
            WarningDialog("Are you sure you want to quit? Press x to quit\n");

            string input = Console.ReadLine();

            if (input?.ToLower() == "x")
            {
                Console.Clear();
                Environment.Exit(1);
            }
            else
            {
                Console.Clear();
                StartMenuChoice();
            }
        }

        // Asks the player to enter their character's name and displays a confirmation message.
        public void AskForName()
        {
            Console.Clear();
            Console.WriteLine("Fill in your character name:");
            characterName = Console.ReadLine();
            Console.Clear();
            while (string.IsNullOrEmpty(characterName) || characterName.Length < 2)
            {
                Console.WriteLine("Name must have atleast 2 characters try again: ");
                characterName = Console.ReadLine();
                Console.Clear();
            }
            Console.WriteLine($"Great! Your name is now {characterName}");
            Console.ReadKey();
            Console.Clear();
        }

        // Displays the game's instructions to the player.
        private void DisplayInstructions()
        {
            instruction = instruction.GameInstructions(this);
        }

        // Main game loop: Continuously displays scenes, processes player choices, and updates the game state.
        public void StartGame()
        {
            while (true)
            {
                DisplayScene();
                string choice = GetPlayerChoice();

                if (CommandCheck(choice))
                {
                    continue;
                }

                float nextScene = ValidateAndReturnScene(choice);
                UpdateScene(nextScene);
            }
        }

        // Displays the current scene's text and available choices to the player.
        private async void DisplayScene()
        {
            List<string> friends = new List<string> { "Tanuki", "Baku" };
            List<string> foes = new List<string> { "Nue", "Nekomata" };

            string sceneText = story[currentScene].Text;

            Task.Run(() => PlaySceneMusic());

            string[] words = sceneText.Split(' ');
            foreach (string word in words)
            {
                bool isFriend = false;
                bool isFoe = false;

                foreach (string friend in friends)
                {
                    if (word.Contains(friend, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;

                        foreach (char character in word)
                        {
                            Console.Write(character);
                            Thread.Sleep(40);
                        }

                        Console.ResetColor();
                        isFriend = true;
                        break;
                    }
                }
                foreach (string foe in foes)
                {
                    if (word.Contains(foe, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;

                        foreach (char character in word)
                        {
                            Console.Write(character);
                            Thread.Sleep(40);
                        }

                        Console.ResetColor();
                        isFoe = true;
                        break;
                    }
                }
                if (!isFriend && !isFoe)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    if (Console.KeyAvailable)
                    {
                        var key = Console.ReadKey(intercept: true).Key;

                        if (key == ConsoleKey.Spacebar)
                        {
                            foreach (char character in word)
                            {
                                Console.Write(character);
                                Thread.Sleep(10);
                            }
                        }
                    }
                    else
                    {
                        foreach (char character in word)
                        {
                            Console.Write(character);
                            Thread.Sleep(40);
                        }
                    }


                }
                Console.Write(' ');
            }

            Console.WriteLine("\n ");

            int choiceIndex = 0;
            foreach (Choice choice in story[currentScene].Choices)
            {
                choiceIndex++;
                Console.WriteLine($"{choiceIndex}. {choice.Option}");
            }
        }

        public async void PlaySceneMusic()
        {
            var currentSceneType = story[currentScene].GetSceneType();

            if (currentSceneType == lastSceneType)
            {
                return;
            }

            lastSceneType = currentSceneType;
            outputDevice.Stop();
            audioFile?.Dispose();

            switch (currentSceneType)
            {
                case Scene.SceneType.Somber:

                    filePath = "Assets/AudioFiles/Somber.mp3";

                    break;
                case Scene.SceneType.Happy:
                    filePath = "Assets/AudioFiles/Happy.mp3";
                    break;
                default:
                    // code block
                    break;
            }

            audioFile = new Mp3FileReader(filePath);
            outputDevice.Init(audioFile);
            outputDevice.Play();


        }

        // Prompts the player to enter their choice and returns it as a lowercase string.
        private string GetPlayerChoice()
        {
            // Clear any buffered input
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }

            Console.WriteLine("\nEnter your choice:");

            string choice = "";

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                // Check if the key is a valid choice
                if (keyInfo.Key == ConsoleKey.D1 || keyInfo.Key == ConsoleKey.D2 || keyInfo.Key == ConsoleKey.D3 || keyInfo.Key == ConsoleKey.D4)
                {
                    Console.Write(keyInfo.KeyChar); // Show choice on screen
                    choice = keyInfo.KeyChar.ToString();
                }
                else if (keyInfo.Key == ConsoleKey.Enter && !string.IsNullOrEmpty(choice))
                {
                    Console.WriteLine(); // Move to new line after Enter
                    return choice;
                }
            }
        }


        // Validates the player's choice, checks if it's a command or a valid scene option, and returns the next scene.
        private float ValidateAndReturnScene(string choice)
        {
            int choiceIndex;
            List<float> deathScenes = new List<float>
            {
                3.3f,
                4.2f,
                5.5f,
                7.2f
            };

            CommandCheck(choice);

            if (int.TryParse(choice, out choiceIndex) && choiceIndex >= 1 && choiceIndex <= story[currentScene].Choices.Count)
            {
                Choice selectedChoice = story[currentScene].Choices[choiceIndex - 1];
                Karma += selectedChoice.KarmaEffect;

                float nextScene = selectedChoice.NextScene;

                if (nextScene == 1.13f)
                {
                    WinGame();
                    return currentScene;
                }

                foreach (float deathScene in deathScenes)
                {
                    if (nextScene == deathScene)
                    {
                        LoseGame();
                        return currentScene;
                    }
                }
                Console.Clear();
                return nextScene;
            }
            Console.Clear();
            WarningDialog("Invalid choice. Please choose a valid option.");
            Thread.Sleep(1000);
            Console.Clear();
            return currentScene;
        }

        // Updates the current scene based on the player's choice. If the choice is invalid, displays a warning.
        private void UpdateScene(float choice)
        {
            if (choice >= 1.0f && choice <= 12.0f)
            {
                currentScene = choice;
            }
            else
            {
                WarningDialog("Invalid choice. Please choose a valid option.");
            }
        }

        // Checks if the player's input matches any commands (e.g., "help", "save") and executes the corresponding action.
        public bool CommandCheck(string choice)
        {
            foreach (string command in commands)
            {
                if (choice == command)
                {
                    switch (choice)
                    {
                        //MAKE KARMACOMMAND
                        case "help":
                            HelpCommand();
                            return true;
                        case "save":
                            Console.Clear();
                            SaveCheck();
                            return true;
                        case "karma":
                            ShowKarma();

                            return true;
                            break;
                        default:
                            WarningDialog("Invalid input. Please enter a valid option.");
                            return true;
                    }
                }
            }
            return false;
        }

        // Provides instructions for every scene in the story
        public void HelpCommand()
        {
            Console.Clear();
            foreach (char character in story[currentScene].Instructions)
            {
                Console.Write(character);
                Thread.Sleep(60);
            }
            Console.WriteLine("\nPress any key to return to the game.");
            Console.ReadKey();
        }

        // Checks if a save file exists and prompts the player to overwrite it. Saves the game if confirmed.
        public void SaveCheck()
        {
            if (File.Exists("test.txt"))
            {
                WarningDialog("A save file exists. Overwrite it?\n" +
                              "1. Overwrite  2. Cancel");

                if (Console.ReadLine() == "1")
                {
                    SaveGame();
                }
            }
            SaveGame();
            LoadGame();
        }

        // Saves the current game state to a file and reloads the game.
        public void SaveGame()
        {
            Console.Clear();
            StreamWriter file = new StreamWriter("test.txt");
            file.WriteLine(currentScene);
            file.Close();
            Console.WriteLine("Game saved!");
            Thread.Sleep(1000);
            Console.Clear();
            LoadGame();
        }

        // Loads the game state from a save file and starts the game from the saved scene.
        public void LoadGame()
        {
            if (File.Exists("test.txt"))
            {
                float.TryParse(File.ReadAllText("test.txt"), out currentScene);
                StartGame();
            }

            Console.Clear();
            WarningDialog("Couldn't find file");
            Console.ReadKey();
            Console.Clear();
            StartMenuChoice();
        }

        public void ShowKarma()
        {
            Console.Clear();
            Console.WriteLine($"current karma: {Karma}\n");
            Console.WriteLine("\nPress any key to return to the game.");
            Console.ReadKey();
        }

        // Handles text printing and calling Keywords function to colour keywords
        public void PrintKeyWordsInColour(string text, List<string> keywords)
        {
            string[] words = text.Split(' ');

            foreach (string word in words)
            {
                bool isKeyword = false;

                foreach (string keyword in keywords)
                {
                    if (word.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                    {
                        KeyWord(word);
                        isKeyword = true;
                        break;
                    }
                }
                if (!isKeyword)
                {
                    Console.Write(word);
                }
                Console.Write(' ');
            }
        }

        // Displays keywords in blue text
        public void KeyWord(string keyWord)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(keyWord);
            Console.ResetColor();
        }

        // Gives a win message and loops back to the start menu or close option
        public void WinGame()
        {
            Console.Clear();
            Console.WriteLine("Congratulations! You have completed the game.");
            Console.WriteLine("Thank you for playing!");
            ContinueOrClose();
        }

        // Gives a lose message and loops back to the start menu or close option

        public void LoseGame()
        {
            Console.Clear();
            WarningDialog("You did not survive the journey, reload your safe file to try again or quit to give up...");
            Console.ReadKey();
            ContinueOrClose();
        }

        // Displays a warning message in red text.
        private void WarningDialog(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

    }
}