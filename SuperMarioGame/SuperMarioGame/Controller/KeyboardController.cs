using Microsoft.Xna.Framework.Input;
using SuperMarioGame.Commands;
using System.Collections.Generic;

namespace SuperMarioGame.Controller
{
    public class KeyboardController
    {
      
        private Dictionary<Keys, ICommand> controllerMappings;
        KeyboardState OldState;
        private bool wDown;
        private static int resetOnce=1;
        public bool keysEnabled { get; set; }
        public KeyboardController()
        {
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
            
            {
                KeyboardState NewState = Keyboard.GetState();
                Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
                if (pressedKeys.Length == 0)
                {
                    controllerMappings[Keys.BrowserBack].Execute();
                }

                foreach (Keys key in pressedKeys)
                {
                    if (controllerMappings.ContainsKey(key))
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
