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
    class BulletPowerup : AnimationObject
    {
        public BulletPowerup(AnimationObjectProperties gop)
            : base(gop)
        {
            this.gop.tex = gop.world.content.Load<Texture2D>("powerups");
            this.gop.loop = true;
            this.gop.xFrames = 2;
            this.gop.yFrames = 8;
            this.gop.sizeFrame = 32;
            this.gop.numFrames = 16;
            this.gop.radius = 16;
            this.gop.scale = 1.0f;
            this.gop.causescollision = true;
            this.gop.startPointInFile = 0;
            this.Initialize();
        }
    }
}
