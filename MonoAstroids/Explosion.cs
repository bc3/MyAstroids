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
    class Explosion : AnimationObject
    {
        public Explosion(AnimationObjectProperties gop)
            : base(gop)
        {
            this.gop.tex = gop.world.content.Load<Texture2D>("explosion");
            this.gop.loop = false;
            this.gop.xFrames = 5;
            this.gop.yFrames = 5;
            this.gop.sizeFrame = 64;
            this.gop.numFrames = 25;
            this.Initialize();
        }
    }
}
