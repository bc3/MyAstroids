using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace MyAstroids.Engine
{
    public static class Vector2Extension
    {
        public static Vector2 Move2SouthWestBottom(this Vector2 v, float w, float h)
        {
            Vector2 res;

            res = new Vector2();
            res.X = v.X + w;
            res.Y = v.Y + h;

            return res;
        }

    }
}
