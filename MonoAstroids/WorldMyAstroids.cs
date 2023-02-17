using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

using MyAstroids.Engine;

namespace MyAstroids
{
    class WorldMyAstroids : World
    {


         KeyboardState oldState = Keyboard.GetState();

        

        public WorldMyAstroids(GraphicsDeviceManager graphics, SpriteBatch spriteBatch, ContentManager content,Game game)
            : base(graphics, spriteBatch, content,game)
        {
            //set the collision detector object
            cr = new CollisionResolverMyAstroids(this);
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState newState = Keyboard.GetState();


            if (newState.IsKeyDown(Keys.S) & !oldState.IsKeyDown(Keys.S))
            {
                Vector2 pos = new Vector2(World.RandomBetween(0, this.width), World.RandomBetween(0, this.height));
                Vector2 vel = new Vector2(20,20);


                AnimationObjectProperties aop = new AnimationObjectProperties() { world = this,
                        pos = pos,
                        velocity = vel};
              
    
                this.AddObject( new SpeedPowerup(aop));

            }

            if (newState.IsKeyDown(Keys.B) & !oldState.IsKeyDown(Keys.B))
            {
                Vector2 pos = new Vector2(World.RandomBetween(0,this.width), World.RandomBetween(0,this.height));
                Vector2 vel = new Vector2(20, 20);


                AnimationObjectProperties aop = new AnimationObjectProperties()
                {
                    world = this,
                    pos = pos,
                    velocity = vel
                };


                this.AddObject(new BulletPowerup(aop));

            }

            oldState = newState;

            base.Update(gameTime);

        }

        public override void Initialize()
        {
            base.Initialize();
            GameObjectProperties gop;

            gop = new GameObjectProperties(this, new Vector2(0, 0), 0, false);

            // add the stars
            Stars stars1 = new Stars(gop, 50, 20);
            this.AddObject(stars1);

            // add the stars
            Stars stars2 = new Stars(gop, 70, 10);
            this.AddObject(stars2);

            // add the stars
            Stars stars3 = new Stars(gop, 100, 5);
            this.AddObject(stars3);

            MovableObjectProperties spaceMop;
            spaceMop = new MovableObjectProperties() { pos = new Vector2(this.width / 2, this.height / 2), world = this };

            // add the spaceship
            Spaceship spaceship = new Spaceship(spaceMop);
            this.AddObject(spaceship);

            //MovableObjectProperties spaceMop2;
            //spaceMop2 = new MovableObjectProperties() { pos = new Vector2(this.width / 4, this.height / 4), world = this };

            //// add the spaceship
            //Spaceship spaceship2 = new Spaceship(spaceMop2);
            //this.AddObject(spaceship2);

         
            // add the rock
            Rocks rocks = new Rocks(gop);
            this.AddObject(rocks);

            
           
        }

    }
}
