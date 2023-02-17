using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyAstroids.Engine
{
    public abstract class CollisionResolver
    {

        protected World w;

        public CollisionResolver(World w)
        {
            this.w = w;
        }

        public  bool DetectCollision(GameTime gametime, GameObject a, GameObject b)
        {
            bool res = false;


            //if (other is MovableObject)
            //{

            //    float sumRadius = this.gop.radius + ((MovableObject)other).gop.radius;
            //    float distSqr = (this.gop.pos - other.gop.pos).Length();

            //    if (distSqr <= sumRadius)
            //    {
            //        this.gop.lastCollision = gametime.TotalGameTime;
            //        other.gop.lastCollision = gametime.TotalGameTime;
            //        res = true;
            //    }
            //}

            //CIRCULAR COLLISION DETECTION

            if (b is MovableObject)
            {
                float xd = a.gop.pos.X - ((MovableObject)b).gop.pos.X;
                float yd = a.gop.pos.Y - ((MovableObject)b).gop.pos.Y;

                float sumRadius = a.gop.radius + ((MovableObject)b).gop.radius;
                float sqrRadius = sumRadius * sumRadius;

                float distSqr = (xd * xd) + (yd * yd);

                if (distSqr <= sqrRadius)
                {
                    res = true;
                }
            }

            //RECTANGLE COLLISION DETECTION

            //Rectangle r1 = this.getBoundingRect();
            //Rectangle r2 = other.getBoundingRect();
            //res = r1.Intersects(r2);


            return res;



        }
    
        public abstract void ResolveCollision(GameTime gametime, GameObject a, GameObject b);

        protected void Bounce(GameTime gametime, MovableObject a, MovableObject b)
        {

            //http://forums.xna.com/forums/t/24186.aspx




            Vector2 FirstToSecondVect = a.gop.pos - b.gop.pos;
            FirstToSecondVect.Normalize();

            Vector2 collisionXAxis = a.gop.pos - b.gop.pos;
            collisionXAxis.Normalize();

            Vector2 collisionYAxis = new Vector2(-collisionXAxis.Y, collisionXAxis.X);

            Vector2 aLocalVelocity = new Vector2(Vector2.Dot(a.gop.velocity, collisionXAxis), Vector2.Dot(a.gop.velocity, collisionYAxis));
            Vector2 bLocalVelocity = new Vector2(Vector2.Dot(b.gop.velocity, collisionXAxis), Vector2.Dot(b.gop.velocity, collisionYAxis));

            // http://en.wikipedia.org/wiki/Elastic_collision
            // Beter

            Vector2 aLocalNewVelocity = new Vector2((aLocalVelocity.X * (a.gop.mass - b.gop.mass) + (2 * b.gop.mass * bLocalVelocity.X)) / (a.gop.mass + b.gop.mass), aLocalVelocity.Y);
            Vector2 bLocalNewVelocity = new Vector2((bLocalVelocity.X * (b.gop.mass - a.gop.mass) + (2 * a.gop.mass * aLocalVelocity.X)) / (b.gop.mass + a.gop.mass), bLocalVelocity.Y);

            Vector2 globalX = new Vector2(collisionXAxis.X, collisionYAxis.X);
            Vector2 globalY = new Vector2(collisionXAxis.Y, collisionYAxis.Y);

            // Now we have the globalX and Y axis defined in our local system, we can project the result velocities on them to obtain
            // their equivalent in the global axis system:
            a.gop.velocity = new Vector2(Vector2.Dot(aLocalNewVelocity, globalX), Vector2.Dot(aLocalNewVelocity, globalY));
            b.gop.velocity = new Vector2(Vector2.Dot(bLocalNewVelocity, globalX), Vector2.Dot(bLocalNewVelocity, globalY));

            maintainMinimumDistance(a, b);

        }

        internal void maintainMinimumDistance(MovableObject first, MovableObject second)
        {
            Vector2 diffVect = first.gop.pos - second.gop.pos;
            float distSqr = diffVect.LengthSquared();

            float radiiSum = first.gop.radius + second.gop.radius;

            if (distSqr < (radiiSum * radiiSum))
            {
                Vector2 newPos = diffVect * ((float)Math.Sqrt(distSqr) - radiiSum);
                first.gop.pos = first.gop.pos - (newPos * 0.01f);
            }
        }

    }
}
