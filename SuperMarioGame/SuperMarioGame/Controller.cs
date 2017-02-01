using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame
{
    public class Controller : IController
    {
      
            private Dictionary<Keys, ICommand> controllerMappings;

            public Controller()
            {
                controllerMappings = new Dictionary<Keys, ICommand>();
            }

            public void RegisterCommand(Keys key, ICommand command)
            {
                controllerMappings.Add(key, command);
            }

            public void Update()
            {
                Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

                foreach (Keys key in pressedKeys)
                {
                    if (key.Equals(Keys.Q) || key.Equals(Keys.W) || key.Equals(Keys.E) || key.Equals(Keys.R) || key.Equals(Keys.T))
                    {
                        controllerMappings[key].Execute();
                    }
                }
            }

        }
    
}
