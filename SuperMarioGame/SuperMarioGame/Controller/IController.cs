﻿using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.Controller
{
    public interface IController
    {
        void RegisterCommand(Keys key, ICommand command);

        void Update();
    }
}
