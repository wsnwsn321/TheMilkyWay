using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MyGame
{
    public class Circle
    {
        public Vector2 Center { get; set; }
        public float Radius { get; set; }

        public Circle(Vector2 center, float radius)
        {
            Center = center;
            Radius = radius;
        }

        public bool Contains(Vector2 point)
        {
            return ((point - Center).Length() <= Radius);
        }

        public bool Intersects(Circle other)
        {
            return ((other.Center - Center).Length() < (other.Radius - Radius));
        }
        //public bool Intersects(Rectangle rectangle)
        //{
        //    // the first thing we want to know is if any of the corners intersect
        //    var corners = new[]
        //    {
        //        new Point(rectangle.Top, rectangle.Left),
        //        new Point(rectangle.Top, rectangle.Right),
        //        new Point(rectangle.Bottom, rectangle.Right),
        //        new Point(rectangle.Bottom, rectangle.Left)
        //    };

        //    foreach (var corner in corners)
        //    {
        //        if (ContainsPoint(corner))
        //            return true;
        //    }

        //    // next we want to know if the left, top, right or bottom edges overlap
        //    if (Center.X - Radius > rectangle.Right || Center.X + Radius < rectangle.Left)
        //        return false;

        //    if (Center.Y - Radius > rectangle.Bottom || Center.Y + Radius < rectangle.Top)
        //        return false;

        //    return true;
        //}
        //public bool ContainsPoint(Point point)
        //{
        //    var vector2 = new Vector2(point.X - Center.X, point.Y - Center.Y);
        //    return vector2.Length() <= Radius;
        //}
        public bool Intersects(Rectangle rect)
        {
            float distanceX = (Center.X - rect.X-rect.Width/2.0f);
            if (distanceX < 0)
            {
                distanceX = -distanceX;
            }
            float distanceY = (Center.Y - rect.Y-rect.Height/2.0f);
            if (distanceY < 0)
            {
                distanceY = -distanceY;
            }
            if (distanceX > (rect.Width / 2.0f + Radius)) { return false; }
            if (distanceY > (rect.Height / 2.0f + Radius)) { return false; }

            if (distanceX <= (rect.Width / 2.0f)) { return true; }
            if (distanceY <= (rect.Height / 2.0f)) { return true; }

            float cornerDist = (distanceX - rect.Width / 2.0f) * (distanceX - rect.Width / 2.0f) +
                                      (distanceY - rect.Height / 2.0f) * (distanceY - rect.Height / 2.0f);

            return (cornerDist <= (Radius*Radius));
        }
    }
}