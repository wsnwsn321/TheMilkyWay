using Microsoft.Xna.Framework.Input;
using TheMilkyWay.Commands;
using TheMilkyWay.ElementClasses;
using TheMilkyWay.Sound.UFOSound;
using System.Collections.Generic;
using System.Linq;

namespace TheMilkyWay.Controller
{
    public class KeyboardController
    {
      
        public Dictionary<Keys, ICommand> controllerMappings { get; }
        KeyboardState OldState;
        public bool wDown { get; set; }
        private static int resetOnce=1;
        public bool keysEnabled { get; set; }
        private Game1 myGame;
        public KeyboardController(Game1 game)
        {
            myGame = game;
            controllerMappings = new Dictionary<Keys, ICommand>();
            keysEnabled = true;
            wDown = false;
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
            if(keysEnabled&&!myGame.level.scoreSystem.displayMenu)
            {
                KeyboardState NewState = Keyboard.GetState();

                Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
                if (myGame.level.mainCharacter.state is AliveState)
                {
                    AliveState f = myGame.level.mainCharacter.state as AliveState;
                    f.beam = false;
                    myGame.level.mainCharacter.state = f;
                }

                foreach (Keys key in pressedKeys)
                {
                    if (key.Equals(Keys.Q)||(key.Equals(Keys.R)&&!myGame.level.scoreSystem.displayCollectibles&&!myGame.level.scoreSystem.displayCredits&&!myGame.level.scoreSystem.displayMenu))
                    {
                        controllerMappings[key].Execute();
                    }

                    if (controllerMappings.ContainsKey(key)&&myGame.level.mainCharacter.canMove)
                    {
                        if (key.Equals(Keys.Space))
                        {
                            wDown = true;
                         
                        }

                        if (key.Equals(Keys.N))
                        {
                            if (NewState.IsKeyDown(Keys.N) && OldState.IsKeyUp(Keys.N))
                            {
                                controllerMappings[key].Execute();
                            }
                        }
                        else if (key.Equals(Keys.Space))
                        {
                            if (NewState.IsKeyDown(Keys.Space) && OldState.IsKeyUp(Keys.Space))
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
                MainCharJumpCommand c = controllerMappings[Keys.Space] as MainCharJumpCommand;
                controllerMappings[Keys.Space] = c;
            }            
        }
    }
}
