using System;
using UnityEngine;

namespace Castanha.Utils
{
    [Serializable]
    public abstract class ProfileProperty<T> 
    {
        [SerializeField] private T Value = default;         // the "official" value of the property
        [SerializeField] private T DirtyValue = default;    // the "dirty" value, subject to change
        [SerializeField] private bool isChanged = false;    // signals if the value is being modified

        public void SetDirty(T value)
        {
            DirtyValue = value;
            isChanged = true;
        }

        public void Commit()
        {
            Value = DirtyValue;
            isChanged = false;
        }

        public void Reset()
        {
            DirtyValue = Value;
            isChanged = false;
        }

        public T Get() => isChanged ? DirtyValue : Value;

        /// <summary>
        /// Automatically converts the property type to T
        /// </summary>
        /// <param name="p">Property type</param>
        public static implicit operator T(ProfileProperty<T> p) => p.Get();
    }
}
