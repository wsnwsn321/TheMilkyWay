using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace TheMilkyWay.VolecotyTest
{
    public static class Volecity
    {
        public const float gravity = 0.2f;
        //vDirection true Top
        //hDirection true left
        public static Vector2 getNewPosition(TwoVolecity volecity, bool vDirection, bool hDirection, bool hasGravity, Vector2 position)
        {
            float x = position.X;
            float y = position.Y;
            if (hasGravity)
            {
                if(volecity.vv == 0 && volecity.vh == 0) {
                    return position;
                }else if(volecity.vv == 0)
                {
                    if (hDirection)
                    {
                        //straight left
                        x -= volecity.vh;
                    }else
                    {
                        //straight right
                        x += volecity.vh;
                    }
                }else if(volecity.vh == 0)
                {
                    if (vDirection)
                    {
                        //straight up
                        y -= volecity.vh;
                        volecity.vh = volecity.vh - gravity;
                    }
                    else
                    {
                        //straight down
                        y += volecity.vh;
                        volecity.vh = volecity.vh - gravity;
                    }
                }
                else
                {
                    
                    if(vDirection && hDirection)
                    {
                        //left up
                        x -= volecity.vh;
                        y -= volecity.vv;
                        volecity.vv -= gravity;
                    }
                    else if(!vDirection && hDirection)
                    {
                        //left down
                        x -= volecity.vh;
                        y += volecity.vv;
                        volecity.vv += gravity;

                    }else if(vDirection && !hDirection)
                    {
                        //right up
                        x += volecity.vh;
                        y -= volecity.vv;
                        volecity.vv -= gravity;
                    }
                    else
                    {
                        //right down
                        x += volecity.vh;
                        y += volecity.vv;
                        volecity.vv += gravity;
                    }

                }
            }else
            {
                if (hDirection)
                {
                    if (vDirection)
                    {
                        x -= volecity.vh;
                        y += volecity.vv;
                    }
                    else
                    {
                        x -= volecity.vh;
                        y -= volecity.vv;
                    }
                }else
                {
                    if (vDirection)
                    {
                        x += volecity.vh;
                        y += volecity.vv;
                    }else
                    {
                        x += volecity.vh;
                        y += volecity.vv;
                    }
                }
            }
            return new Vector2(x, y);
        }
    }
}
