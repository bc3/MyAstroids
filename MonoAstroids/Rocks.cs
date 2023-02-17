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
    class Rocks : GameObject
    {

        private List<Rock> rocks;
        private const String LEVEL1 = "";
        private String currentLevel;

        public Rocks(GameObjectProperties gop)
            : this(gop,LEVEL1)
        {
           
        }

        public Rocks(GameObjectProperties gop, String levelDefinition) 
             : base(gop)
        {
            currentLevel = levelDefinition;
        }

        public override void Update(GameTime gameTime)
        {
            int count = rocks.Count;
            for (int i = 0; i < count; i++)
            {
                rocks[i].Update(gameTime);
            }
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gametime)
        {
            int count = rocks.Count;
            for (int i = 0; i < count; i++)
            {
                rocks[i].Draw(spriteBatch,gametime);
            }

        }

        public override void Initialize()
        {
            rocks = new List<Rock>();
            //for (int i = 0; i <= w.random.Next(5); i++)
            for (int i = 0; i <= 3; i++)
            {
                AddRock(4);
            }
        }

        public void Remove(Rock r)
        {
          
            if (r.size == 4)
            {
                

                var r1 = AddRock(r.gop.pos,2);
                var r2 = AddRock(r.gop.pos, 2);

            }
            else if (r.size == 2)
            {
                var r1 = AddRock(r.gop.pos, 1);
                var r2 = AddRock(r.gop.pos, 1);
                
            }

            rocks.Remove(r);
            gop.world.RemoveObject(r);
        }

        private Rock AddRock(Vector2 pos, int size)
        {
            MovableObjectProperties mop = new MovableObjectProperties();
            mop.world = gop.world;
            mop.pos = pos;
            
            
            mop.offscreen = false;
            mop.zindex = 0.5f;


            var rock = new Rock(mop, this, size);
            rocks.Add(rock);
            mop.world.AddObject(rock);

            return rock;
        }

        private void AddRock(int size)
        {
            AddRock(new Vector2(World.RandomBetween(0, gop.world.width), World.RandomBetween(0, gop.world.height)), size);
        }


       


    }
}
