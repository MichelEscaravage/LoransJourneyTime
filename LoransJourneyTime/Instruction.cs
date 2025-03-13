using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoransJourneyTime
{
    internal class Instruction
    {
        public Instruction GameInstructions(Game game)
        {
            Instruction instruction = new Instruction();
           

            Console.Clear();
            string instructions = "Welcome!" +
                "\nHere follow the instructions to help you play and have fun!" +
                "\nThis is a textbased adventure game which means you progress by making choices, your choices actually matter and may" +
                "\nresult in a different outcome." +
                "\nSome choices may have an impact on your Karma which can result in different outcomes on it's own." +
                "\nThere is a chance to find items on your journey, you can decide to take them with you." +
                "\nThey might hinder you or might help you along the way!" +
                "\nDecide what you feel is the right choice, like in life there is not alway an obvious answer." +
                "\n\nBefore every choice in the story you have a few commands at your exposal:" +
                "\n- help" +
                "\n- save" +
                "\n- karma" +
                "\nthe help command will give you instructions specific to the current scene you're in." +
                "\nthe save command will save your game with a check to make sure you want to overwrite the latest savefile." +
                "\nthe karma command will show your current karma." +
                "\nAfter making a savefile you can simply close the application, everything is secured!" +
                "\n" +
                "\n" +
                "ENJOY!";

            List<string> keywords = new List<string>();
            keywords.Add("Karma");
            keywords.Add("items");
           

            game.PrintKeyWordsInColour(instructions, keywords);
            Console.ReadKey();

            return instruction;
        }
/*        public Dictionary<float, Scene> InitializeStory()
        {

            return instructions;
        }*/
    }
}




