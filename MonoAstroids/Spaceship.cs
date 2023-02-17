using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using MyAstroids.Engine;

namespace MyAstroids
{
    class Spaceship : MovableObject
    {
        private Texture2D tex;

        private TimeSpan lastShot;

        private float MAXSPEED = 250;
        private float MINSPEED = -250;
        const float SPEEDSTEP = 30;
        const float ROATATIONSTEP = 0.1f;
        private int BULLETTIME = 300;
        private bool hasSpeedPowerUp = false;
        private bool hasBullerPowerUp = false;
        private TimeSpan lastTime;
        public MovableObject circleSpeed ;

        private SmokePlumeParticleSystem smokePlume;

        // keep a timer that will tell us when it's time to add more particles to the
        // smoke plume.
        const float TimeBetweenSmokePlumePuffs = .0f;
        float timeTillPuff = 0.0f;

        public Spaceship(MovableObjectProperties mop)
            : base(mop)
        {
            this.gop.offscreen = false;
            this.gop.mass = 10;
            this.gop.causescollision = true;
            this.gop.velocity = new Vector2(0, 0);
            this.gop.radius = 25;
            this.gop.zindex = 0.1f;
            this.tex = mop.world.content.Load<Texture2D>("spaceship");
            //health parameters
            this.gop.maxhealth = 100;
            this.gop.currenthealth = 100;
            this.gop.stephealth = 20;

            // we'll see lots of these effects at once; this is ok
            // because they have a fairly small number of particles per effect.
            smokePlume = new SmokePlumeParticleSystem(this.gop,2);
            this.gop.world.AddObject(smokePlume);
        }

        // this function is called when we want to demo the smoke plume effect. it
        // updates the timeTillPuff timer, and adds more particles to the plume when
        // necessary.
        private void UpdateSmokePlume(float dt)
        {
            //timeTillPuff -= dt;
            //if (timeTillPuff < 0)
            //{
                Vector2 where = Vector2.Zero;
                // add more particles at the bottom of the screen, halfway across.
                where.X = this.gop.pos.X;
                where.Y = this.gop.pos.Y;
                smokePlume.AddParticles(where);

                // and then reset the timer.
                timeTillPuff = TimeBetweenSmokePlumePuffs;
           // }
        }

        public override void Update(GameTime gametime)
        {


            float dt = (float)gametime.ElapsedGameTime.TotalSeconds;

            KeyboardState keys = Keyboard.GetState();

            VectorA tmp = new VectorA(this.gop.velocity);

            if (keys.IsKeyDown(Keys.Up))
            {
                if (tmp.Length < MAXSPEED)
                    tmp.Length += SPEEDSTEP;
            }

            if (keys.IsKeyDown(Keys.Down))
            {
                if (tmp.Length > MINSPEED)
                    tmp.Length -= SPEEDSTEP;
            }

            if (keys.IsKeyDown(Keys.Left))
            {
                tmp.Angle.Value -= ROATATIONSTEP;
            }

            if (keys.IsKeyDown(Keys.Right))
            {
                tmp.Angle.Value += ROATATIONSTEP;
            }


            if (keys.IsKeyDown(Keys.Space))
            {
                if ((gametime.TotalGameTime - lastShot) > new TimeSpan(0, 0, 0, 0, BULLETTIME))
                {
                    this.gop.world.soundEffects[0].Play();
                    Vector2 bulletPos = this.gop.pos;
                    VectorA bulletSpeed = new VectorA(this.gop.velocity);
                    bulletSpeed.Length = bulletSpeed.Length + 400;

                    MovableObjectProperties bulletMop = new MovableObjectProperties();
                    bulletMop.world = this.gop.world;
                    bulletMop.pos = bulletPos;
                    bulletMop.velocity = bulletSpeed.GetVector2();

                    this.gop.world.AddObject(new Bullet(bulletMop));
                    lastShot = gametime.TotalGameTime;
                }
            }

            this.gop.velocity = tmp.GetVector2();

          

            if (this.hasSpeedPowerUp)
            {
                if (circleSpeed == null)
                {
                    circleSpeed = new Circle((MovableObjectProperties)gop.Clone(), Color.Yellow);
                    this.gop.world.AddObject(circleSpeed);
                }
                else
                {
                    circleSpeed.gop.pos = this.gop.pos;
                    circleSpeed.Update(gametime);
                }
            }
            UpdateSmokePlume(dt);
            smokePlume.Update(gametime);

            base.Update(gametime);

        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gametime)
        {

            VectorA tmp = new VectorA(this.gop.velocity);

            spriteBatch.Draw(tex, this.gop.pos, new Rectangle(0, 0, 50, 50), Color.White, tmp.Angle.Value, new Vector2(this.gop.radius, this.gop.radius), new Vector2(1, 1), SpriteEffects.None, this.gop.zindex);

            if (this.gop.world.diagnostics)
            {
                spriteBatch.DrawString(this.gop.world.fontCourier, String.Format("[X: {0} / Y: {1}] [Velocity: {2}]", this.gop.pos.X.ToString("#.00"), this.gop.pos.Y.ToString("#.00"), tmp.ToString(), this), new Vector2(0, 0), Color.Yellow);
               
            }

            if (this.hasSpeedPowerUp & circleSpeed != null)
            {
                circleSpeed.Draw(spriteBatch,gametime);
            }

            smokePlume.Draw(spriteBatch,gametime);

            base.Draw(spriteBatch,gametime);
        }

        public void PowerUp()
        {
                hasSpeedPowerUp = true;
                MAXSPEED = MAXSPEED * 2;
                MINSPEED = MINSPEED * 2;
        }

        public void BulletUp()
        {
            hasSpeedPowerUp = true;
            BULLETTIME = BULLETTIME / 2;
        }

        public override string ToString()
        {
            return String.Format("Spaceship : {0}", base.ToString());
        }
    }
}
