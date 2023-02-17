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
    class Stars : GameObject
    {


        private List<Star> stars;
        private float speed;
        private int amount;

        public Stars(GameObjectProperties gop, int amount,float speed)
            : base(gop)
        {
            this.amount = amount;
            this.speed = speed;

            stars = new List<Star>();
            for (int j = 0; j < amount; j++)
            {
                stars.Add(new Star { X = World.RandomBetween(0, gop.world.width), Y = World.RandomBetween(0, gop.world.height), rotation = (int)World.RandomBetween(0, 360), size = speed / 3 });

            }


        }

        public override void Update(GameTime gametime)
        {

            MoveX(gametime);


        }

        public override void Initialize()
        {
            
        }

        private void MoveX(GameTime gametime)
        {
            int count = stars.Count;
            for (int i = 0; i < count; i++)
            {
                stars[i].X += speed * (float)gametime.ElapsedGameTime.TotalSeconds;
                if (stars[i].X < 0)
                    stars[i].X = gop.world.width;
                if (stars[i].X > gop.world.width)
                    stars[i].X = 0;

            }

        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gametime)
        {
            int count = stars.Count;

            for (int i = 0; i < count; i++)
            {
                Vector2 fo = gop.world.fontCourier.MeasureString("*") / 2;

                spriteBatch.DrawString(gop.world.fontCourier, "*", new Vector2(stars[i].X, stars[i].Y), Color.White, MathHelper.ToRadians(stars[i].rotation), fo, stars[i].size / 3, SpriteEffects.None, 1.0f);

            }

        }
    }
}
