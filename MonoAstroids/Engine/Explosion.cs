using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyAstroids.Engine
{
    class Explosion : GameObject
    {

        private Texture2D tex;
        public float FPS = 1000.0f / 30.0f;     // Frames per second of this animation
                                                // 1000 represents one milisecond
                                                // 30 represents how many frames we want to display in 1000 miliseconds
                                                // I could've used 1.0f / 30.0f if I wanted to change the Update()
                                                // code to count .TotalSeconds instead of Milliseconds.
                                                // The net result here is that it should play 30 frames per second.
        public Rectangle[] frames;              // Array of rectangles to represent each frame of the animation sequence
        public int currentFrame = 0;            // The frame that should currently be displayed
        private float frameTimer = 0.0f;        // A counter to keep track of how long since the frame's been changed

        private float size;

        // TODO:  Require the texture
        // Standard constructor...
        public Explosion(GameObjectProperties gop,float size) : base(gop)
        {
            tex = this.gop.world.content.Load<Texture2D>("explosion");

            this.size = size;

            // Build the frame rectangles that represent each frame of the animation sequence
            // going from left to right, top to bottom
            frames = new Rectangle[25];
            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    frames[x + y * 5] = new Rectangle(x * 64, y * 64, 64, 64);
                }
            }
        }

        // This method will change the current frame when necessary
        public override void Update(GameTime gameTime)
        {
            // How many milliseconds since the last time the game's Update() method was called
            float elapsedTime = (float)gameTime.ElapsedGameTime.TotalMilliseconds;

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
                    //currentFrame = 0;
                    this.gop.world.RemoveObject(this);
                }
            }

        }

        // Basic method to draw the current frame
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, this.gop.pos, frames[currentFrame], Color.White, 0.0f, new Vector2(50, 50), size, SpriteEffects.None, 0.0f);
        }
    }
}
