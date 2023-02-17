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
    class Circle : MovableObject
    {
        private List<Vector2> vectors;
        private Color c;

        private int sides = 32;

        public Circle(MovableObjectProperties gop)
            : this(gop, Color.White)
        {
           
        }

        public Circle(MovableObjectProperties gop,Color c)
            : base(gop)
        {
            this.gop.causescollision = false;
            this.gop.tex = this.gop.world.content.Load<Texture2D>("pixel");
            vectors = new List<Vector2>();
            this.c = c;
        }

        public override void Update(GameTime gametime)
        {

            vectors.Clear();

            float max = 2 * (float)Math.PI;
            float step = max / (float)sides;

            for (float theta = 0; theta < max; theta += step)
            {
                vectors.Add(new Vector2(this.gop.radius * (float)Math.Cos((double)theta),
                    this.gop.radius * (float)Math.Sin((double)theta)));
            }

            // then add the first vector again so it's a complete loop
            vectors.Add(new Vector2(this.gop.radius * (float)Math.Cos(0),
                    this.gop.radius * (float)Math.Sin(0)));


        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gametime)
        {
            

            for (int i = 1; i < vectors.Count; i++)
            {
                Vector2 vector1 = vectors[i - 1];
                Vector2 vector2 = vectors[i];

                // calculate the distance between the two vectors 
                float distance = Vector2.Distance(vector1, vector2);
                Vector2 length = vector2 - vector1;
                length.Normalize();

                // calculate the angle between the two vectors 
                //float angle = (float)Math.Atan2(vector2.Y - vector1.Y, vector2.X - vector1.X); 

                int count = (int)Math.Round(distance);

                for (int x = 0; x < count; ++x)
                {
                    vector1 += length;
                    // stretch the pixel between the two vectors 
                    spriteBatch.Draw(this.gop.tex, this.gop.pos + vector1, null, this.c, 0, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                }
            } 

        }
    }
}
