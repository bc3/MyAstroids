using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MyAstroids.Engine;

namespace MyAstroids
{
    class Rock : MovableObject
    {

        public int size;
        private VectorA objectRotation;
        private float objectDelta;
        private Rocks r;
        private Vector2 imagesize = new Vector2(0, 0);
        private Texture2D tex = null;

 

        public Rock(MovableObjectProperties mop,Rocks r, int size)
            : base(mop)
        {
            gop.causescollision = true;
            this.size = size;
            this.r = r;
            this.gop.zindex = 0.2f;
            mop.velocity = new VectorA(Angle.Random(Angle.Zero, Angle.FullCircle), World.RandomBetween(0, 150)).GetVector2();

            switch (size)
            {
                case 1:
                    this.objectRotation = new VectorA(Angle.Random(Angle.Zero, Angle.FullCircle), 0);
                    this.gop.radius = 12.5f;
                    this.gop.mass = 125;
                    //objectDelta = (float)this.gop.world.random.NextDouble() ;
                    imagesize = new Vector2(25, 25);
                    tex = this.gop.world.content.Load<Texture2D>("rock25x25");
                   
                    break;
                case 2:
                    this.objectRotation = new VectorA(Angle.Random(Angle.Zero, Angle.FullCircle), 0);
                    this.gop.radius = 25f;
                    this.gop.mass = 250;
                    //objectDelta = (float)this.gop.world.random.NextDouble() ;
                    imagesize = new Vector2(50, 50);
                    tex = this.gop.world.content.Load<Texture2D>("rock50x50");
                   
                    break;
                case 4:
                    this.objectRotation = new VectorA(Angle.Random(Angle.Zero, Angle.FullCircle), 0);
                    this.gop.radius = 50f;
                    this.gop.mass = 500;
                    //objectDelta = (float)this.gop.world.random.NextDouble() ;
                    imagesize = new Vector2(100, 100);
                    tex = this.gop.world.content.Load<Texture2D>("rock100x100");
                    break;


                   
            }

            this.gop.mass = this.gop.radius * 16;
            imagesize = new Vector2(this.gop.radius / 2, this.gop.radius / 2);


           

        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gametime)
        {



            spriteBatch.Draw(tex, this.gop.pos, new Rectangle(0, 0, (int)this.gop.radius * 2, (int)this.gop.radius * 2), Color.White, objectRotation.Angle.Value, new Vector2(this.gop.radius, this.gop.radius), new Vector2(1, 1), SpriteEffects.None, this.gop.zindex);
            base.Draw(spriteBatch,gametime);
        }

        public override void Update(GameTime gameTime)
        {

            this.objectRotation.Angle.Value += objectDelta * (float)gameTime.ElapsedGameTime.TotalSeconds;
            base.Update(gameTime);
        }

    

        public override string ToString()
        {
            return String.Format("Rock : {0}",base.ToString());
        }

        public void SplitRock()
        {
            r.Remove(this);
        }


    }
}
