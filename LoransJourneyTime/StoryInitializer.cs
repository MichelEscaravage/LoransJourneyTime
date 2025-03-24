using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LoransJourneyTime
{
    internal class StoryInitializer
    {
        public int karma = 0;

        public Dictionary<float, Scene> InitializeStory(Game game)
        {
            Dictionary<float, Scene> story = new Dictionary<float, Scene>();

            // MAIN BRANCH -------------------------------------- MAIN BRANCH ------------------------------------- BRANCH 1
            story.Add(1.0f, new Scene(Scene.SceneType.Somber, "Raindrops slowly drip on your head as the ceiling boards creek and move in the wind, you wake up.." +
                "\nYou look around you hoping yesterday was all a dream. Unfortunately it wasn't." +
                "\nYou get up to see the now cold and expressionless body of your daughter laying on a bed of flowers." +
                "\nIt is time to bury her.." +
                "\nYou close the cloth that's wrapped around her and secure the body on your back." +
                "\nIt is time to...",
                new List<Choice>()
                {
                    new Choice("Gather my supplies and leave for my journey", 1.1f),
                    new Choice("Take her one last time to the place you found her", 2.1f, karmaEffect: +1) // BRANCH 2------
                },
                "You could either go straight towards the first step of the endgoal or take a small detour."));

            story.Add(1.1f, new Scene(Scene.SceneType.Somber, "You gathered your supplies and start your journey, one more time you look behind you." +
                "\nAll the memories made in this cabin, how happy you all were." +
                "\nEverything changed since that faithful day." +
                "\nAlthough you tried to stay strong for your daughter, you can't shake the feeling that you failed her." +
                "\nIt was hard for you to stay yourself after the loss of your partner to the curse."
                ,
              new List<Choice>
              {
                new Choice("Push on for now", 1.2f),
              },
              "There is only one option at this point."));

            story.Add(1.2f, new Scene(Scene.SceneType.Somber, "It is still cold down in the jungle village, the humidity is making it harder to breathe." +
                "\nEven colder is the energy that surrounds this once bustling village, most houses are abandoned and closed shut.\n" +
                "\nYou can hear a soft whining noice coming from one of the houses.." +
                "\nYou decide to..",
              new List<Choice>
              {
                new Choice("Continue on the path up the mountain", 1.3f),
                new Choice("Check the supposed empty house ", 3.1f, karmaEffect: -1) // BRANCH 3 -----

              },
              "Will you investigate the house in your village or will you focus on your goal?"));

            story.Add(1.3f, new Scene(Scene.SceneType.Normal, "\nHours ago you left the jungle and the village behind you," +
                "\nIt's been almost a full day of walking, slowly the winding paths are taking you up the mountain." +
                "\nthe air is getting colder and the lush jungle trees have been traded for pine trees." +
                "\nIt is getting darker slowly, it might be wise to set up camp." +
                "\nYou look around you for shelter and see a cave nearby, this might be perfect to shelter from the elements!" +
                "\nYou decide to..",
              new List<Choice>
              {
                new Choice("Stay outside and set up camp for the night", 1.4f),
                new Choice("Go inside the cave to shelter from the elements", 4.1f), //BRANCH 4 ----
              },
              "The cave will give you cover from the elements but you can't be sure what is waiting for you inside." +
              "\nOn the other hand you might freeze outside."));

            story.Add(1.4f, new Scene(Scene.SceneType.Tense, "Deciding it will probably be safer outside you set up camp." +
                "\nYou lay your daughter down in the tent. You try to eat some food but the sorrow you feel makes it hard." +
                "\nAfter a few attempts of eating you give up and crawl into your tent for some sleep." +
                "\nYou wake up in the middle of the night to a growling noise nearby." +
                "\nYou forgot to clean up the food you left outside!" +
               "\nYou decide to..",
             new List<Choice>
             {
                new Choice("Charge outside with your makeshift weapon to confront whatever makes the noise", 1.5f),
                new Choice("Try to lay as still as possible and dont make any noise.", 5.1f), //BRANCH 5 -----
             },
             "You might be able to fend off or even kill the possible threat, although laying still might be enough." +
             "\nDon't forget your food is still outside! There might not be enough for the whole journey..."));

            story.Add(1.5f, new Scene(Scene.SceneType.Combat, "You charge outside with your makeshift spear, your eyes with a small hairy creature " +
                "\nhappily feasting on your supplies." +
                "\nThe creature jumps back after seeing your spear and hides behind a rock." +
                "\nYou decide to..",
              new List<Choice>
              {
                            new Choice("Make loud noises and charge towards the creature to scare it", 6.1f, karmaEffect:-2), //BRANCH 6 ----
                            new Choice("Put down your spear and offer the creature a bit of food",1.6f, karmaEffect:+2)
              },
              "You already have a shortage of food, it's up to you what to prioritize"));

            story.Add(1.6f, new Scene(Scene.SceneType.Happy, "As you slowly put your spear on the ground the curious creature peaks from behind the rock." +
                "\nIt looks again at you with it's big eyes while you offer it some dry bread." +
                "\nHesitantly the creature walks up to you and takes the bread out of your hand." +
                "\nIt smiles at you, it's eyes light up with golden colours. For a second you are being blinded." +
                "\nThe eyes of the creature turn back into its original colour, you take a moment to adjust to the darkness again." +
                "\nWhen you look around you see the creature has multiplied your supplies tenfold. You now have more than enough food!" +
                "\nThe creature you now recognize as a Tanuki disappears into nothing." +
                "\nYou decide to..",
              new List<Choice>
              {
                            new Choice("Safely store the food in your backpack and go inside the tent to get some sleep.", 1.7f),
              },
              "Yet again, there is only one choice here"));

            story.Add(1.7f, new Scene(Scene.SceneType.Happy, "After the eventful night you feel refreshed and light, it feels as though a mystical force is" +
               "\npushing you towards your goal.",
             new List<Choice>
             {
                            new Choice("Press on", 1.8f),
             },
             "Yet again, there is only one choice here"));

            story.Add(1.8f, new Scene(Scene.SceneType.TemplePast, "After the eventful night you feel refreshed and light, it feels as though a mystical force is" +
                "\npushing you towards your goal. You get up to pack up camp and secure your daughter to your back." +
                "\nYou can't help but smile when you start walking." +
                "\nAfter another day of walking you finally see a temple in the distance." +
                "\nYou recognize it immediately, this is the temple your father brought you to when you were just a boy." +
                "\n\nTogether with your father you lit the incense and and recieved blessings from the monks." +
                "\nYou remember the beauty of the temple, the golden roof glistening in the sun, the white and red walls with" +
                "\nseemingly endless carvings of all kinds of beautiful imagery and the gigantic Buddha statue in the middle of the" +
                "\ncourtyard. It is here where you played with the temple tiger cubs and took naps in the sun.",
              new List<Choice>
              {
                            new Choice("Press on", 1.9f),
              },
              "Yet again, there is only one choice here"));

            story.Add(1.9f, new Scene(Scene.SceneType.Tense, "The last bit of grass has now turned into snow and there are barely any trees left." +
                "\nYou are now on the slope of the mountain at the first stop." +
                "\nAs you draw closer to the temple you feel a wave of discomfort, there is something different " +
                "\nabout this once blissful place." +
                "\nYou stop at the temple gate, noticing it is closed.. strange.. normally this was open to anyone." +
                "\nyou know the gate.. Knock Knock.. No answer." +
                "\nYou try again but with a bit more force this time.. KNOCK KNOCK! No answer again." +
                "\nYou decide to..",
              new List<Choice>
              {
                            new Choice("Barge your way in by running into the gate", 7.1f, karmaEffect: -3), //BRANCH 7 ----
                            new Choice("Look around you for help", 1.10f),
              },
              "It is getting dark, you need to get inside soon! How will you respond?"));

            story.Add(1.11f, new Scene(Scene.SceneType.Monk, "As you look around you, you notice a man in the distance with a red with yellow robe walking" +
                "\nthrough the snow. On his shoulder a familiar figure." +
                "\nIt is the friendly Tanuki from before and it is pointing directly at you." +
                "\nSlowly the monk approaches you, he waves friendly at you." +
                "\nOnce the monk is close enough to be able to talk he presses his hands together in front of his chest and bows to you." +
                "\nYou decide to...",
              new List<Choice>
              {
                            new Choice("Try to catch the Tanuki that clumsily falls of the shoulder of the monk", 1.11f, karmaEffect: +1),
                            new Choice("Bow back to the old monk", 1.11f, karmaEffect: +2),
              },
              "Would you rather show the same respect back to the monk or save your friend from a cold dip in the snow"));

            story.Add(1.12f, new Scene(Scene.SceneType.TemplePresent, "As the old man bows to greet you, the Tanuki tumbles of his shoulder. " +
                "\nJust as fast as it fell the Tanuki disappeared again into nothing, saving itself from a cold dip in the snow." +
                "\n\nIt's been a long time, I remember you from when you were a child. Your father used to bring you here!" + "  Expressed the old monk" +
                "\n\n" +
                "\nYou suddenly recognize the old monk as one of the masters at the time you came to visit, this was Master Baku!" +
                "\n\nAlthough you could not have come at a worse time, of course you are welcome to the temple as always!" +
                "\nExcuse me for the mess please, I try hard to keep it all neat and clean." +
                "\n\nMaster Baku mutters out a mantra in an unknown language and bows, the massive gate creaks and slowly opens." +
                "\nAs you walk onto the courtyard you see the temple is deserted.. no tigercubs running around, monks meditating or" +
                "\nchildren's laughter." +
                "\nThere is only silence and a lot of snow." +
                "\nSome parts of the temple roof collapsed under the weight of the snow and the massive Buddha statue is barely visible anymore." +
                "" +
                "\nYou decide to...",
              new List<Choice>
              {
                            new Choice("Complain to Master Baku about the state of affairs", 1.12f, karmaEffect: -2),
                            new Choice("Silently look around and smile at Master Baku as he turns to you", 1.12f, karmaEffect: +2),

              },
              "Be nice or honest?"));

            story.Add(1.13f, new Scene(Scene.SceneType.TemplePresent, 
                "Master Baku invites you in the main hall where it seems the last fire is still keeping a part" +
                "\nof the temple warm." +
                "\nMaster Baku's face turns grim as you carefully lay your daughter's body down and take a seat on a cushions." +
                "\n\nSo this is why you came, my sincere condolences.." +
                "\nWe will bless her tonight so you can continue the journey to her final resting place tomorrow." +
                "\nFollow me please."+
                "\n\nAs you follow Master Baku down the dark halls, you notice every room is abandoned and dark.." +
                "\nCould he be here alone?" +
                "\n\nyou walk up a flight of stairs where you end up in a room with a bath. The water seems to give a golden light" +
                "\nilluminating the room in a golden glow.",
              new List<Choice>
              {
                            new Choice("Stare at the golden glowing water", 1.13f, karmaEffect: +1),

              },//
              ""));

            story.Add(1.14f, new Scene(Scene.SceneType.Ritual,
                "\nMaster Baku holds out his arms, indicating you to hand over your daughter to him. One last time you look at your" +
                "\ndaughter wrapped in white cloth, you give her a kiss on her head and gently lay her in Master Baku's arms." +
                "\n\n\nMaster Baku slowly walks into the water as he unwraps your daughter's body from the white cloth." +
                "\nOnce her body touches the water, the water begins to swirl and the golden light turns stronger." +
                "\nFor a second the darkness seems to be taking over, you hurry into the water to support your daughter in the passing." +
                "\nImmediately the waters calm down and the light turns even more bright." +
                "\nBoth you and Master Baku retreat from the water as Ruby slowly gets pulled in." +
                "\nA golden flash appears and on the surface of the water, a red gem appears.",
              new List<Choice>
              {
                            new Choice("You take the stone from the water and hold it close..", 1.13f, karmaEffect: +1),

              },
              ""));

            story.Add(1.15f, new Scene(Scene.SceneType.Win, "Congrationlations! You finished the demo of the game!",
              new List<Choice>
              {
                            new Choice("Exit", 1.13f),

              },
              ""));

            // BRANCH 2 -------------------------------------- BRANCH 2 ------------------------------------- BRANCH 2
            story.Add(2.1f, new Scene(Scene.SceneType.Memories, "You exit your cabin and walk up to a small hill just outside of the village." +
                "\nThe sun is slowly rising.." +
                "\nFrom here you can oversee the small village." +
                "\nAs you gently put down your daughter's body on the ground you sit down next to her." +
                "\n\nThis is where you first found her all those years ago. You were gathering wood in the forest when you saw a shadow" +
                "\nslip away into the darkness between the trees." +
                "\nNot long after the shadow left you head a cry, chilling to the bone, of a baby behind you." +
                "\nYou dropped everything you were doing and ran towards the noise." +
                "\n\nThere she was, a beautiful baby girl with her crimson hair and freckles." +
                "\nyou took her in and raised her together with your partner as if she was your own." +
                "\n\nAs you reminiscence further on those amazing years you feel a tear falling of your cheek." +
                "\nYou wipe the tear away and get up." +
               "\nIt is time to...",
               new List<Choice>()
               {
                    new Choice("Gather my supplies and leave for my journey", 1.1f),
               },
               "Let's keep going!"));

            // BRANCH 3 -------------------------------------- BRANCH 3 ------------------------------------- BRANCH 3
            story.Add(3.1f, new Scene(Scene.SceneType.Tense, "As you slowly approach the house you notice shadows moving around inside." +
                "\n\nThis is the house where the Lin family used to live. A happy family with 3 kids who would always play and dance" +
                "\nmaking the town more lively." +
                "\nOne day they simply dissapeared without a trace, only the father was left but he was not able to speak anymore." +
                "\nEndless nights he would walk around the village staring blankly in front of him until one day he walked into the forest" +
                "\nnever to be seen again." +
                "\n\n" +
                "\nYou enter the house, you walk into the living room. It's dark and grim, the paper walls between the rooms are ripped apart." +
                "\nOn a table you see a book what's clearly supposed to be a journal, it is covered in blood." +
                "\nYou decide to..",
              new List<Choice>
              {
                new Choice("Leave the house untouched and continue your journey", 1.3f),
                new Choice("Grab the journal", 3.2f, karmaEffect: -5)

              },
              "The journal could uncover the truth about the family that disapeared!"));

            story.Add(3.2f, new Scene(Scene.SceneType.Combat,"\nSuddenly the front door slams shut behind you, your turn around but see nothing." +
                "\nAs you run back to the door something is touching the back of your neck..." +
                "\nYou turn around to see a massive cat with evil eyes and two tails staring right at you, a Nekomata! " +
                "\nKnown to devour households and take the homes of their victims. These creatures are very territorial and will almost" +
                "\nalways kill trespassers." +
                "\nAll you can think of is running out the door but you are too late.. The Nekomata has its claws wrapped around your throat." +
                "\nWith a foul swing it slices your throat.." +
                "\nEverything goes dark... ",
              new List<Choice>
              {
                new Choice("Exit", 3.3f),

              },
              ""));
            story.Add(3.3f, new Scene(Scene.SceneType.Death,"",
              new List<Choice>
              {
                new Choice("....", 3.3f),

              },
              ""));

            // BRANCH 4 -------------------------------------- BRANCH 4 ------------------------------------- BRANCH 4
            story.Add(4.1f, new Scene(Scene.SceneType.Combat, "You enter the cave, lighting your torch with a firestone." +
                "\nThe light of the torch flickers on the walls, a strong wind gushes through the cave extinguishing the torch." +
                "\nYou relight the torch and look up to a pair of big eyes not even half a meter away from you." +
                "\n\nAs your eyes readjust to the light you see the creature with massive fangs sticking out." +
                "\nIt's seems to be part tiger, part monkey, part dog and part snake. It's a massive wild Nue! " +
                "\n\nIt let's out a horrifying and bonechilling cry as it lunges towards you." +
                "\nBefore you can move the creature picks you up, piercing you with it's tiger claws, it's snake tail wraps around your" +
                "\nthroat. Finally it sinks it's monkey fangs in your stomache." +
                "\n\nEverything turns dark.",
              new List<Choice>
              {
                new Choice("Exit", 4.2f),
              },
              ""));

            story.Add(4.2f, new Scene(Scene.SceneType.Death, "",
              new List<Choice>
              {
                new Choice("", 4.2f),
              },
              ""));

            // BRANCH 5 -------------------------------------- BRANCH 5 ------------------------------------- BRANCH 5
            story.Add(5.1f, new Scene(Scene.SceneType.Somber, "You try to lay as still as possible, trying not to alert the possible threat outside." +
                "\nAfter a while the sound stopped, you wait for a bit longer to be sure before you step outside to check your food." +
                "\nEverything has been eaten, there is nothing left." +
               "\nYou decide to..",
             new List<Choice>
             {
                new Choice("Go back to bed, there is nothing you can do now.",5.2f),
             },
             "There is nothing for you to do now but sleep. It is still too dark to continue."));

            story.Add(5.2f, new Scene(Scene.SceneType.TemplePast, "After the eventful night you feel doubtful and hungry." +
                "\nWith no food to eat you get up to pack up camp and secure your daughter to your back." +
                "\nAfter another day of walking you finally see a temple in the distance." +
                "\nYou recognize it immediately, this is the temple your father brought you to when you were just a boy." +
                "\n\nTogether with your father you lit the incense and and recieved blessings from the monks." +
                "\nYou remember the beauty of the temple, the golden roof glistening in the sun, the white and red walls with" +
                "\nseemingly endless carvings of all kinds of beautiful imagery and the gigantic Buddha statue in the middle of the" +
                "\ncourtyard. It is here where you played with the temple tiger cubs and took naps in the sun.",
              new List<Choice>
              {
                            new Choice("Press on", 5.3f),
              },
              "There is only one choice here"));

            story.Add(5.3f, new Scene(Scene.SceneType.TemplePresent, "As you continue you feel dizzy and cold, it feels as though you used up your final strenght." +
                "\nThe last bit of grass has now turned into snow and there are barely any trees left." +
                "\nYou are now on the slope of the mountain at the first stop." +
                "\nAs you draw closer to the temple you feel a wave of discomfort, there is something different " +
                "\nabout this once blissful place." +
                "\n\nYou stop at the temple gate, noticing it is closed.. strange.. normally this was open to anyone." +
                "\nyou know the gate.. Knock Knock.. No answer." +
                "\nYou try again but with a bit more force this time.. KNOCK KNOCK! No answer again." +
                "\nYou decide to..",
              new List<Choice>
              {
                            new Choice("Barge your way in by running into the gate", 7.1f, karmaEffect: -3), //BRANCH 7 ----
                            new Choice("Look around you for help", 5.4f),
              },
              "It is getting dark, you need to get inside soon! How will you respond?"));

            story.Add(5.4f, new Scene(Scene.SceneType.Death,"As you look around you, you see only endless hills of snow and the giant holy mountain in the distance." +
                "\nYou are on your own." +
                "\n\nYou keep knocking the gate, screaming to let you in. But alas, no one answers. " +
                "\nAs the sun disappears behind the mountains and the air feels colder and colder, you start to lose your vision." +
                "\nYour arms and legs feel stiff and it is getting really hard to breathe." +
                "\n\nYou try to warm yourself on your firestone but to no effect. It's completely frozen over, as the last bit of light in" +
                "\nthe core of the stone starts flickering, you finally lose the last bit of warmth you had left." +
                "\nEverything turns black." +
                "\n\nThe last thing you see is your daughter's beautiful face reaching towards you, she is crying.." +
                "\nOyaji.. why.. Oyaji... " +
                "\nYou decide to...",
              new List<Choice>
              {
                            new Choice("Exit", 5.5f),
              },
              "...."));

            story.Add(5.5f, new Scene(Scene.SceneType.Death, "",
              new List<Choice>
              {
                            new Choice("", 5.5f),
              },
              "...."));

            // BRANCH 6 -------------------------------------- BRANCH 6 ------------------------------------- BRANCH 6
            story.Add(6.1f, new Scene(Scene.SceneType.Combat, "As you try to scare the creature by charging at it, the Tanuki jumps from behind the rock." +
                "\nYou now recognize this creature. It's a forest spirit in the form of a raccoon dog" +
                "\nthat can bring good luck to humans who are nice to it." +
                "\nIt probably followed the smell of food coming from your back." +
                "\nAs you realise what you have done you immediately stop and throw your spear back but you are too late. " +
                "\nThe Tanuki starts mocking you by sticking out it's tongue and it disapears into nothing." +
                "\n\nAs you look around to check the damage you see that most of the food is eaten." +
                "\nThere is just a little bit of stale bread left that was already turning questionable colours." +
                "\nYou decide to..",
              new List<Choice>
              {
                   new Choice("Go back to bed, there is nothing you can do now.",5.2f)
             },
             "There is nothing for you to do now but sleep. It is still too dark to continue."));

            // BRANCH 7 -------------------------------------- BRANCH 7 ------------------------------------- BRANCH 7
            story.Add(7.1f, new Scene(Scene.SceneType.Death, "You take a few steps back and leap headfirst into the iron reinforced gate" +
                "\nYou crash into one of the metal studs on the gate and fall down. You are now unconscious." +
                "\nLaying in the snow in front of the gate, you quickly freeze." +
                "\nEverything turns black. ",
              new List<Choice>
              {
                            new Choice("Exit", 7.2f)
              },
              "Really? That was your best idea? "));

            story.Add(7.2f, new Scene(Scene.SceneType.Death,"",
              new List<Choice>
              {
                            new Choice("Exit", 7.2f)
              },
              " "));


            return story;
        }
    }
    class Scene
    {
        public enum SceneType
        {
            Somber = 1,
            Tense = 2,
            Happy = 3,
            Memories = 4,
            Normal = 5,
            Combat = 6,
            TemplePresent = 7,
            TemplePast = 8,
            Monk = 9,
            Ritual = 10,
            Death = 11,
            Win = 12,
        }

        public SceneType _SceneType { get; set; }
        public string Text { get; }
        public List<Choice> Choices { get; }
        public string Instructions { get; }
        public int Karma { get; set; }
        public string Dialog { get; set; }

        public Scene(SceneType sceneType, string text, List<Choice> choices, string instructions, int karma = 0)
        {
            _SceneType = sceneType;
            Text = text;
            Choices = choices;
            Instructions = instructions;
            Karma = karma;
        }

        public  SceneType GetSceneType()
        {
          return _SceneType;
        }
    }


    class Choice
    {
        public string Option { get; }
        public float NextScene { get; }
        public int KarmaEffect { get; }

        public Choice(string option, float nextScene, int karmaEffect = 0)
        {
            Option = option;
            NextScene = nextScene;
            KarmaEffect = karmaEffect;
        }
    }

}
