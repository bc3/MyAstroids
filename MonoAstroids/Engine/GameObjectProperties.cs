using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyAstroids.Engine
{
    public class GameObjectProperties : ICloneable
    {
        public Vector2 pos;
        public float radius;
        public float zindex;
        public float scale;
        public World world;
        public bool causescollision;
        public Texture2D tex;
        public int maxhealth;
        public int stephealth;
        public int currenthealth;
        public float mass;
        public TimeSpan lastCollision;
   


        public GameObjectProperties()
        {
            this.mass = 0;
            this.pos = Vector2.Zero;
            this.radius = 0;
            this.causescollision = false;
            this.zindex = 1; // 1 for background ... 0 for foreground
            this.scale = 1;
            this.maxhealth = -1;
            this.stephealth = -1;
            this.currenthealth = -1;
        }

        public GameObjectProperties(World world, Vector2 pos, float radius, bool causescollision)
        {
            this.pos = pos;
            this.world = world;
            this.radius = radius;
            this.causescollision = causescollision;
        }

        public object Clone()
        {
            return ((object)this).CloneObject();
        }



    }
}
