using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.ElementClasses.ElementInterfaces
{
    public interface IBlock
    {
        Vector2 position { get; set; }
        void Draw();
        void Update();
    }
}
