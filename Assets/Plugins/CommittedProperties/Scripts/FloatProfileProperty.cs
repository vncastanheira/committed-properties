namespace Castanha.Utils
{
    [System.Serializable]
    public class FloatProfileProperty : ProfileProperty<float>
    {
        public FloatProfileProperty() : base() { }

        #region Overload
        public static float operator *(FloatProfileProperty property, float value)
        {
            return property.Get() * value;
        }

        public static float operator *(FloatProfileProperty p1, FloatProfileProperty p2)
        {
            return p1.Get() * p2.Get();
        }

        public static float operator +(FloatProfileProperty p1, float p2)
        {
            return p1.Get() + p2;
        }

        public static implicit operator FloatProfileProperty(float value)
        {
            var p = new FloatProfileProperty();
            p.SetDirty(value);
            p.Commit();
            return p;
        }
        #endregion


    }
}