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
    class CollisionResolverMyAstroids : CollisionResolver
    {


        public CollisionResolverMyAstroids(World w)
            : base(w)
        { }

        public override void  ResolveCollision(GameTime gametime,GameObject a, GameObject other)
        {
            if (a is Rock && other is Rock)
            {
                this.Bounce(gametime, (MovableObject)a, (MovableObject)other);
            }

            if (a is Rock && other is Bullet)
            {
                a.gop.world.RemoveObject(other);
                ((Rock)a).SplitRock();

                MakeExplosion(a.gop.pos, 1.0f);
            }

            if (a is Rock && other is SpeedPowerup)
            {

                a.gop.world.RemoveObject(other);
                MakeExplosion(a.gop.pos, 0.4f);
            }

            if (a is Spaceship && other is Rock)
            {

                if (a.PerformHealth() == 0)
                {
                    a.gop.world.RemoveObject(other);
                    MakeExplosion(a.gop.pos, 2f);
                    a.gop.world.gameover = true;
                }
                else
                {
                    if (other is MovableObject)
                    {
                        this.Bounce(gametime, (MovableObject)a, (MovableObject)other);
                    }
                }
            }

            if (a is Spaceship && other is SpeedPowerup)
            {
                ((Spaceship)a).PowerUp();
                a.gop.world.RemoveObject(other);

            }

            if (a is Spaceship && other is BulletPowerup)
            {
                ((Spaceship)a).BulletUp();
              
                a.gop.world.RemoveObject(other);

            }
                
        }

        protected void MakeExplosion(Vector2 pos,float scale)
        {
            AnimationObjectProperties aop = new AnimationObjectProperties() { world = w,pos = pos, scale = scale };
            w.AddObject(new Explosion(aop));
        }


       
    }
}
