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
    class Bullet : MovableObject
    {
        public Bullet(MovableObjectProperties mop)
            : base(mop)
        {
            this.gop.causescollision = true;
            this.gop.offscreen= true;
            this.gop.zindex = 0.99f;
            this.gop.radius = 7.5f;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gametime)
        {
            VectorA tmp = new VectorA(this.gop.velocity);

            Texture2D tex = this.gop.world.content.Load<Texture2D>("bullet");
            spriteBatch.Draw(tex, this.gop.pos, null, Color.White, tmp.Angle.Value, new Vector2(this.gop.radius, this.gop.radius), 1.0f, SpriteEffects.None, this.gop.zindex);

            base.Draw(spriteBatch,gametime);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override string ToString()
        {
            return String.Format("Bullet : {0}", base.ToString());
        }


    }
}
