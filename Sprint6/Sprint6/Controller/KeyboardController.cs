using Microsoft.Xna.Framework.Input;
using Sprint6.Commands;
using Sprint6.Sound.MarioSound;
using System.Collections.Generic;

namespace Sprint6.Controller
{
    public class KeyboardController
    {
      
        public Dictionary<Keys, ICommand> controllerMappings { get; }
        KeyboardState OldState;
        private bool wDown;
        private static int resetOnce=1;
        public bool keysEnabled { get; set; }
        private Game1 myGame;
        public KeyboardController(Game1 game)
        {
            myGame = game;
            controllerMappings = new Dictionary<Keys, ICommand>();
            keysEnabled = true;
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
            wDown = false;
            if (resetOnce<6)
            {
                controllerMappings[Keys.R].Execute();
                resetOnce++;
            }
            if(keysEnabled)
            {
                KeyboardState NewState = Keyboard.GetState();

                Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

                foreach (Keys key in pressedKeys)
                {
                    if (key.Equals(Keys.Q)||key.Equals(Keys.R))
                    {
                        controllerMappings[key].Execute();
                    }
                    if (controllerMappings.ContainsKey(key)&&myGame.level.mainCharacter.canMove)
                    {
                        if (key.Equals(Keys.W))
                        {
                            wDown = true;
                         
                        }

                        if (key.Equals(Keys.X))
                        {
                            if (NewState.IsKeyDown(Keys.X) && OldState.IsKeyUp(Keys.X))
                            {
                                controllerMappings[key].Execute();
                            }
                        }
                        if (key.Equals(Keys.W))
                        {
                            if (NewState.IsKeyDown(Keys.W) && OldState.IsKeyUp(Keys.W))
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
                MarioJumpCommand c = controllerMappings[Keys.W] as MarioJumpCommand;
                c.wDown = wDown;
                controllerMappings[Keys.W] = c;
            }            
        }
    }
}
