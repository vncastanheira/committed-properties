using System.Runtime.CompilerServices;
using System;
using UnityEngine;

namespace Castanha.CommittedProperties
{
    [System.Serializable]
    public class Vector3ProfileProperty : ProfileProperty<Vector3>
    {
        public float x => Get().x;
        public float y => Get().y;
        public float z => Get().z;

        #region Overload
        public static Vector3 operator *(Vector3ProfileProperty v, FloatProfileProperty f)
        {
            return f.Get() * v.Get();
        }

        public static Vector3 operator *(FloatProfileProperty f, Vector3ProfileProperty v)
        {
            return f.Get() * v.Get();
        }

        public static Vector3 operator +(Vector3ProfileProperty v1, Vector3ProfileProperty v2)
        {
            return v1.Get() + v2.Get();
        }

        public static Vector3 operator+(Vector3 v1, Vector3ProfileProperty v2)
        {
            return v1 + v2.Get();
        }

        public static Vector3 operator /(Vector3ProfileProperty vec, float val)
        {
            return vec.Get() / val;
        }

        public static implicit operator Vector3(Vector3ProfileProperty p) => p.Get();

        public static implicit operator Vector3ProfileProperty(Vector3 value)
        {
            var p = new Vector3ProfileProperty();
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
                    2 => value.z,
                    _ => throw new IndexOutOfRangeException("Invalid Vector3 index!"),
                };
            }
        }
        #endregion
    }
}
