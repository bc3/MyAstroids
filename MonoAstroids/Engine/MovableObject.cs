using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyAstroids.Engine
{
    public class MovableObject : GameObject
    {
        public new MovableObjectProperties gop;

        public MovableObject debugCircle;

        public MovableObject(MovableObjectProperties gop)
            : base(gop)
        {
            this.gop = gop;



        }

        public override void Update(GameTime gametime)
        {
            //---------------------------------------
            //add a debug circle
            //---------------------------------------
            if ((this.gop.world.diagnostics) & (debugCircle == null))
            {
                debugCircle = new Circle((MovableObjectProperties)gop.Clone());
                this.gop.world.AddObject(debugCircle);
            }
            else
            {
                if (debugCircle != null)
                {
                    this.gop.world.RemoveObject(debugCircle);
                }
            }
            //---------------------------------------


            this.gop.pos += this.gop.velocity * (float)gametime.ElapsedGameTime.TotalSeconds;

            if (!this.gop.offscreen)
            {

                if (this.gop.pos.X + gop.radius < 0)
                    this.gop.pos.X = gop.world.width;

                if (this.gop.pos.X - gop.radius > gop.world.width)
                    this.gop.pos.X = 0;

                if (this.gop.pos.Y + gop.radius < 0)
                    this.gop.pos.Y = gop.world.height;
                if (this.gop.pos.Y - gop.radius > gop.world.height)
                    this.gop.pos.Y = 0;
            }

            if (this.gop.world.diagnostics)
            {
                debugCircle.gop.pos = this.gop.pos;
                debugCircle.Update(gametime);
            }

        }



        public override void Draw(SpriteBatch spriteBatch, GameTime gametime)
        {
            if (this.gop.world.diagnostics)
            {
                spriteBatch.DrawString(this.gop.world.fontCourier, "X", this.gop.pos, Color.Yellow, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);
                if (debugCircle != null)
                    debugCircle.Draw(spriteBatch,gametime);
            }

            base.Draw(spriteBatch,gametime);
        }

        public override string ToString()
        {
            return this.gop.ToString();
        }

   
        public override void Initialize()
        {
           
        }


    }
}
