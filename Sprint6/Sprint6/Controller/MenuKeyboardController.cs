using Microsoft.Xna.Framework.Input;
using TheMilkyWay.Commands;
using TheMilkyWay.ElementClasses;
using TheMilkyWay.Sound.MarioSound;
using System.Collections.Generic;
using System.Linq;

namespace TheMilkyWay.Controller
{
    public class MenuKeyboardController
    {
      
        public Dictionary<Keys, ICommand> controllerMappings { get; }
        KeyboardState OldState;
        public bool up { get; set; }
        public bool keysEnabled { get; set; }
    public MenuKeyboardController()
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
            if(keysEnabled)
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
                            if (NewState.IsKeyDown(Keys.Enter) && OldState.IsKeyUp(Keys.Enter))
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
