﻿using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.Controller
{
    public class Controller : IController
    {
      
            private Dictionary<Keys, ICommand> controllerMappings;
        private int counter;

            public Controller()
            {
                controllerMappings = new Dictionary<Keys, ICommand>();
                counter = 0;
            }

            public void RegisterCommand(Keys key, ICommand command)
            {
                controllerMappings.Add(key, command);
            }

            public void Update()
            {
                
                Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            if (counter >= 7)
            {
                foreach (Keys key in pressedKeys)
                {
                    if (controllerMappings.ContainsKey(key))
                    {
                        
                            controllerMappings[key].Execute();
               

                    }

                }
                counter = 0;
            }
            counter++;
            }

        }
    
}
