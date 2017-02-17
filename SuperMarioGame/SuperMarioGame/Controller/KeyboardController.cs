using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace SuperMarioGame.Controller
{
    public class KeyboardController
    {
      
            private Dictionary<Keys, ICommand> controllerMappings;
            public KeyboardController()
            {
                controllerMappings = new Dictionary<Keys, ICommand>();
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
                
                Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
                if(pressedKeys.Length == 0)
                {
                    controllerMappings[Keys.BrowserBack].Execute();
                }

                foreach (Keys key in pressedKeys)
                {
                    if (controllerMappings.ContainsKey(key))
                    {

                        controllerMappings[key].Execute();

                    }

                }
            }
        }
}
