using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyAstroids.Engine
{
    /// <summary>
    /// Represents a normalized angle in radians (between 0 and 2PI).  High/Low values will automatically be normalized.
    /// </summary>
    public struct Angle
    {
        public Angle(float value)
        {
            _value = Angle.Normalize(value);
        }

        static private float Normalize(float angle)
        {
            float normValue;
            if (angle >= (float)Math.PI * 2)
            {
                var fullCircleCount = (int)Math.Floor(angle / (Math.PI * 2));
                normValue = angle - (float)(fullCircleCount * Math.PI * 2);
            }
            else if (angle < 0)
            {
                var fullCircleCount = (int)Math.Ceiling(-angle / (Math.PI * 2));
                normValue = (float)(fullCircleCount * Math.PI * 2) + angle;
            }
            else
            {
                normValue = angle;
            }
            return normValue;
        }

        public static float FullCircleF = (float)(Math.PI * 2);
        public static float HalfCircleF = (float)(Math.PI);
        public static float QuarterCircleF = (float)(Math.PI / 2);

        public static Angle FullCircle = new Angle((float)(Math.PI) * 2 - 0.00001f);
        public static Angle Zero = new Angle(0);
        public static Angle HalfCircle = new Angle((float)Math.PI);
        public static Angle QuarterCircle = new Angle((float)Math.PI / 2);

        /// <summary>
        /// Returns a random angle between 0 and max.
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        static public Angle Random(Angle min, Angle max)
        {
            Angle result;
            if (min == max)
            {
                result = min;
            }
            else
            {
                if (min > max)
                {
                    var tmp = min;
                    min = max;
                    max = tmp;
                }
                float randomValue = (float)(new Random((int)DateTime.Now.Ticks).NextDouble());
                result = new Angle(min._value + (randomValue * (max._value - min._value)));
            }
            return result;
        }

        private float _value;
        public float Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = Normalize(value);
            }
        }

        #region Methods

        public Angle Mirror(Angle a)
        {
            return new Angle(a._value + a._value - this._value);
        }

        public Angle MirrorX()
        {
            return Mirror(Angle.Zero);
        }

        public Angle MirrorY()
        {
            return Mirror(Angle.QuarterCircle);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        #endregion

        #region Operators

        static public Angle operator +(Angle a, Angle b)
        {
            return new Angle(a._value + b.Value);
        }

        static public Angle operator +(Angle a, float b)
        {
            return new Angle(a._value + b);
        }

        static public float operator -(Angle a, Angle b)
        {
            float ab = a._value - b.Value;
            if (ab > Math.PI)
                return ab - FullCircleF;
            else if (ab < -Math.PI)
                return ab + FullCircleF;
            else
                return ab;
        }

        static public Angle operator -(Angle a)
        {
            return new Angle(a._value + (float)Math.PI);
        }

        static public bool operator >(Angle a, Angle b)
        {
            return a._value > b.Value;
        }

        static public bool operator >=(Angle a, Angle b)
        {
            return a._value >= b.Value;
        }

        static public bool operator <(Angle a, Angle b)
        {
            return a._value < b.Value;
        }

        static public bool operator <=(Angle a, Angle b)
        {
            return a._value <= b.Value;
        }

        static public bool operator ==(Angle a, Angle b)
        {
            return a._value == b._value;
        }

        static public bool operator !=(Angle a, Angle b)
        {
            return a._value != b._value;
        }

        #endregion

        public override string ToString()
        {
            return _value.ToString();
        }

    }
}
