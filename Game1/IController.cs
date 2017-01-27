using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    interface IController
    {
        void Update();
    }

    public class KeyboardController : IController
    {
        private Dictionary<Keys, ICommand> controllerMappings;

        public KeyboardController()
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
                if (key.Equals(Keys.Q) || key.Equals(Keys.W) || key.Equals(Keys.E) || key.Equals(Keys.R) || key.Equals(Keys.T)) { 
                    controllerMappings[key].Execute();
               }
            }
        }

    }

    public class GamePadController : IController
    {
        private Dictionary<Buttons, ICommand> controllerMappings;

        public GamePadController()
        {
            controllerMappings = new Dictionary<Buttons, ICommand>();
        }

        public void RegisterCommand(Buttons button, ICommand command)
        {
            controllerMappings.Add(button, command);
        }

        public void Update()
        {
            GamePadState gps = GamePad.GetState(0);

            if(gps.IsButtonDown(Buttons.A)) 
            {
                controllerMappings[Buttons.A].Execute();
            }
            if (gps.IsButtonDown(Buttons.B))
            {
                controllerMappings[Buttons.B].Execute();
            }
            if (gps.IsButtonDown(Buttons.X))
            {
                controllerMappings[Buttons.X].Execute();
            }
            if (gps.IsButtonDown(Buttons.Y))
            {
                controllerMappings[Buttons.Y].Execute();
            }
            if (gps.IsButtonDown(Buttons.Start))
            {
                controllerMappings[Buttons.Start].Execute();
            }

        }
    }
}
