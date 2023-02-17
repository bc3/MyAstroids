using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace MyAstroids.Engine
{

    public struct VectorA
    {
        public VectorA(float angle, float length) : this(new Angle(angle), length)
        {

        }

        public VectorA(Angle angle, float length)
        {
            Length = length;
            Angle = angle;
        }

        public VectorA(Vector2 vector)
        {
            Length = vector.Length();
            Angle = new Angle((float)System.Math.Atan2(vector.Y, vector.X));
        }

        public Vector2 GetVector2()
        {
            return new Vector2(Length * (float)System.Math.Cos(Angle.Value), Length * (float)System.Math.Sin(Angle.Value));
        }

        public float Length;
        public Angle Angle;

        public override string ToString()
        {
            return String.Format("{{alfa={0}; l={1}}}", Angle.Value.ToString("#0.00"), Length.ToString("#0.00")); 
        }
    }
}
