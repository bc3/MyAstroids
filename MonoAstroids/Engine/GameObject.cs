using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;



namespace MyAstroids.Engine
{
    public abstract class GameObject : DrawableGameComponent, ICloneable
    {
        public GameObjectProperties gop;

        private Texture2D healthbarTex;

        public GameObject(GameObjectProperties gop):base(gop.world.game)
        {
            this.gop = gop;
            healthbarTex = this.gop.world.content.Load<Texture2D>("HealthBar");
        }


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override  void Initialize()
        {
            base.Initialize();
        }

        public virtual void Draw(SpriteBatch spriteBatch,GameTime gametime)
        {
            if (gop.world.diagnostics) spriteBatch.DrawString(gop.world.fontCourier, this.ToString(), this.gop.pos, Color.Red);

            if (this.gop.maxhealth > -1)
            {
                spriteBatch.Draw(healthbarTex, this.gop.pos.Move2SouthWestBottom(this.gop.radius, this.gop.radius),null,Color.Red,0f,new Vector2(0,0),0.5f,SpriteEffects.None,0.1f);
                spriteBatch.Draw(healthbarTex,this.gop.pos.Move2SouthWestBottom(this.gop.radius,this.gop.radius),
                    new Rectangle(0, 0, (int)(healthbarTex.Width * this.gop.currenthealth / this.gop.maxhealth), healthbarTex.Height), Color.Green, 0f, new Vector2(0, 0), 0.5f, SpriteEffects.None, 0f);
            }


        }

        public Rectangle getBoundingRect()
        {
            int ballHeight = (int)(gop.radius * 2 * 0.80f);
            int ballWidth = (int)(gop.radius * 2 * 0.80f);
            int x = (int)gop.pos.X - ballWidth / 2;
            int y = (int)gop.pos.Y - ballHeight / 2;

            return new Rectangle(x, y, ballHeight, ballWidth);
        }

        public override string ToString()
        {
            return this.getBoundingRect().ToString();
        }

        public  int PerformHealth()
        {
            this.gop.currenthealth -= this.gop.stephealth;
            this.gop.currenthealth = (int)MathHelper.Clamp(this.gop.currenthealth, 0, this.gop.maxhealth);
            return this.gop.currenthealth;
        }

        public object Clone()
        {
            return ((object)this).CloneObject();
        }

    }
}
