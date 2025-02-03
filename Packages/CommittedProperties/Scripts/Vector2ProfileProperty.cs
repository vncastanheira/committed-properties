using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Castanha.CommittedProperties
{
    [System.Serializable]
    public class Vector2ProfileProperty : ProfileProperty<Vector2>
    {
        public float x => Get().x; 
        public float y => Get().y;

        #region Overload
        public static Vector2 operator *(Vector2ProfileProperty v, FloatProfileProperty f)
        {
            return f.Get() * v.Get();
        }

        public static Vector3 operator *(FloatProfileProperty f, Vector2ProfileProperty v)
        {
            return f.Get() * v.Get();
        }

        public static Vector3 operator +(Vector2ProfileProperty v1, Vector2ProfileProperty v2)
        {
            return v1.Get() + v2.Get();
        }

        public static Vector3 operator +(Vector2 v1, Vector2ProfileProperty v2)
        {
            return v1 + v2.Get();
        }

        public static Vector3 operator /(Vector2ProfileProperty vec, float val)
        {
            return vec.Get() / val;
        }

        public static implicit operator Vector2(Vector2ProfileProperty p) => p.Get();

        public static implicit operator Vector2ProfileProperty(Vector2 value)
        {
            var p = new Vector2ProfileProperty();
            p.SetDirty(value);
            p.Commit();
            return p;
        }

        public float this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                var value = Get();
                return index switch
                {
                    0 => value.x,
                    1 => value.y,
                    _ => throw new IndexOutOfRangeException("Invalid Vector3 index!"),
                };
            }
        }
        #endregion
    }
}
