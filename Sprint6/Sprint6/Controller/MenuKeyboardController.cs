using Microsoft.Xna.Framework.Input;
using TheMilkyWay.Commands;
using TheMilkyWay.ElementClasses;
using TheMilkyWay.Sound.UFOSound;
using System.Collections.Generic;
using System.Linq;

namespace TheMilkyWay.Controller
{
    public class MenuKeyboardController
    {
      
        public Dictionary<Keys, ICommand> controllerMappings { get; }
        KeyboardState OldState;
        public Game1 myGame;
        public bool up { get; set; }
        public bool keysEnabled { get; set; }
    public MenuKeyboardController(Game1 game)
        {
            controllerMappings = new Dictionary<Keys, ICommand>();
            keysEnabled = true;
            myGame = game;
        }

        public void RegisterCommand(Keys key, ICommand command)
        {
            if (!controllerMappings.ContainsKey(key))
            {
                controllerMappings.Add(key, command);
            }
        }

        public void Update()
        {
            if(keysEnabled&& !myGame.level.scoreSystem.displayCollectibles)
            {
                KeyboardState NewState = Keyboard.GetState();

                Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

                foreach (Keys key in pressedKeys)
                {
                    if (controllerMappings.ContainsKey(key))
                    {
                        if (key.Equals(Keys.Up))
                        {
                            up = true;
                            if (NewState.IsKeyDown(Keys.Up) && OldState.IsKeyUp(Keys.Up))
                            {
                                controllerMappings[key].Execute();
                            }
                        }
                        else if (key.Equals(Keys.Down))
                        {
                            up = false;
                            if (NewState.IsKeyDown(Keys.Down) && OldState.IsKeyUp(Keys.Down))
                            {
                                controllerMappings[key].Execute();
                            }
                        }
                        else if (key.Equals(Keys.Enter))
                        {
                            if (NewState.IsKeyDown(Keys.Enter) && OldState.IsKeyUp(Keys.Enter) && !myGame.level.scoreSystem.displayCredits)
                            {
                                controllerMappings[key].Execute();
                            }
                        }
                        else
                        {
                            controllerMappings[key].Execute();
                        }
                    }
                }
                OldState = NewState;
            }
        }
    }
}
