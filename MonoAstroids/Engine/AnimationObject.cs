using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyAstroids.Engine
{
    class AnimationObject : MovableObject
    {
        public new AnimationObjectProperties gop;

        public float FPS = 1000.0f / 30.0f;

        public Rectangle[] frames;              // Array of rectangles to represent each frame of the animation sequence
        public int currentFrame = 0;            // The frame that should currently be displayed
        private float frameTimer = 0.0f;        // A counter to keep track of how long since the frame's been changed 

        public AnimationObject(AnimationObjectProperties gop)
            : base(gop)
        {
            this.gop = gop;
        }

        #region " Initialize "

        protected void Initialize()
        {
            frames = new Rectangle[gop.numFrames];
            for (int y = 0; y < gop.xFrames; y++)
            {
                for (int x = 0; x < gop.yFrames; x++)
                {
                    frames[x + y * gop.yFrames] = new Rectangle(x * gop.sizeFrame, y * gop.sizeFrame + gop.startPointInFile, gop.sizeFrame, gop.sizeFrame);
                }
            }
        }

        #endregion

        #region " Update "

        public override void Update(GameTime gametime)
        {
            // How many milliseconds since the last time the game's Update() method was called
            float elapsedTime = (float)gametime.ElapsedGameTime.TotalMilliseconds;

            // Accumulate time this frame has been active
            frameTimer += elapsedTime;

            // If the time active for this frame is more than the time allowed...
            if (frameTimer >= FPS)
            {
                // Reset the frame timer
                frameTimer = 0;

                // Increment the current frame, then test it against the number of frames available...
                if (++currentFrame >= frames.Length)
                {
                    // Reset the frame to the beginning when it's over
                    if (this.gop.loop)
                    {
                        currentFrame = 0;
                    }
                    else
                    {
                        this.gop.world.RemoveObject(this);
                    }


                }
            }
            base.Update(gametime);
        }

        #endregion

        #region " Draw "

        public override void Draw(SpriteBatch spriteBatch, GameTime gametime)
        {
            spriteBatch.Draw(gop.tex, this.gop.pos, frames[currentFrame], Color.White, 0.0f, new Vector2(this.gop.radius, this.gop.radius), this.gop.scale, SpriteEffects.None, 0.0f);
            base.Draw(spriteBatch,gametime);
        }

        #endregion

    }
}
