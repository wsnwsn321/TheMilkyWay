using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.Controller
{
    public class GamepadController
    {

        private Dictionary<Buttons, ICommand> controllerMappings;
        public GamepadController()
        {
            controllerMappings = new Dictionary<Buttons, ICommand>();
        }

        public void RegisterCommand(Buttons button, ICommand command)
        {
            if (!controllerMappings.ContainsKey(button))
            {
                controllerMappings.Add(button, command);
            }
        }

        public void Update()
        {

            GamePadState gps = GamePad.GetState(0);

            if (gps.IsButtonDown(Buttons.LeftThumbstickDown))
            {
                controllerMappings[Buttons.LeftThumbstickDown].Execute();
            }
            if (gps.IsButtonDown(Buttons.LeftThumbstickUp))
            {
                controllerMappings[Buttons.LeftThumbstickUp].Execute();
            }
            if (gps.IsButtonDown(Buttons.LeftThumbstickRight))
            {
                controllerMappings[Buttons.LeftThumbstickRight].Execute();
            }
            if (gps.IsButtonDown(Buttons.LeftThumbstickLeft))
            {
                controllerMappings[Buttons.LeftThumbstickLeft].Execute();
            }
            if (gps.IsButtonDown(Buttons.Start))
            {
                controllerMappings[Buttons.Start].Execute();
            }
        }
    }
}
