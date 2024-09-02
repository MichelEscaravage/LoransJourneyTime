using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoransJourneyTime
{
    internal class StoryInitializer
    {
        public static void Choice()
        {

        }
    }

    class Scene
    {
        public string Text { get; }
        public List<Choice> Choices { get; }

        public Scene(string text, List<Choice> choices)
        {
            Text = text;
            Choices = choices;
        }
    }

    class Choice
    {
        public string Text { get; }
        public float NextScene { get; }

        public Choice(string option, float nextScene)
        {
            Text = option;
            NextScene = nextScene;
        }
    }
}
