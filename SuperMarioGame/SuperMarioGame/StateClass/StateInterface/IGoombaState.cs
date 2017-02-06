﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.StateClass.StateInterface
{
    public interface IGoombaState
    {
        /**
         *  Comments
         * 
         */
        void ChangeDirection();
        
        /**
         * Comments
         */
        void BeStomped();

        /**
         * Comments
         */
        void BeFilpped();

        /**
         * 
         * 
         */
        void Update();

        void Draw();
    }
}