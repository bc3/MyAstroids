using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyAstroids.Engine
{
    public class MovableObjectProperties : GameObjectProperties
    {
        public Vector2 velocity;
        public bool offscreen;

        public MovableObjectProperties() : base()
        {
            this.velocity = Vector2.Zero;
            this.offscreen = true;
        }

        public MovableObjectProperties(World world, Vector2 pos, float radius, bool causescollision, Vector2 velocity, bool offscreen) :
            base(world, pos, radius, causescollision)
        {
            this.velocity = velocity;
            this.offscreen = offscreen;
        }

        public override string ToString()
        {
            return String.Format("POS: {{{0};{1}}} / SPEED: {2}", pos.X.ToString("#0.00"), pos.Y.ToString("#0.00"), new VectorA(velocity).ToString());
        }

       
    }
}
