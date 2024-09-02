using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoransJourneyTime
{
    internal class StoryInitializer
    {
        public Dictionary<float, Scene>InitializeStory()
        {
            Dictionary<float, Scene> story = new Dictionary<float, Scene>();

            story.Add(1.0f, new Scene("test", 
                new List<Choice>()
                {
                    new Choice("keuze1", 1.1f),
                    new Choice("keuze2", 1.2f)
                }));

            return story; 
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
        public string Option { get; }
        public float NextScene { get; }

        public Choice(string option, float nextScene)
        {
            Option = option;
            NextScene = nextScene;
        }
    }
}
