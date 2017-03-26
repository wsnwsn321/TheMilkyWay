using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace SuperMarioGame.Controller
{
    public class KeyboardController
    {
      
        private Dictionary<Keys, ICommand> controllerMappings;
        KeyboardState OldState;
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
            if (resetOnce<6)
            {
                controllerMappings[Keys.R].Execute();
                resetOnce++;
            }
            if (keysEnabled)
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
                        if (key.Equals(Keys.X))
                        {
                            if (NewState.IsKeyDown(Keys.X) && OldState.IsKeyUp(Keys.X))
                            {
                                controllerMappings[key].Execute();
                            }
                        }
                        else if (key.Equals(Keys.W))
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
            }            
        }
    }
}
