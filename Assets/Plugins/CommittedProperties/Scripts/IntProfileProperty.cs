using Castanha.Utils;

namespace Castanha.Utils
{
    [System.Serializable]
    public class IntProfileProperty : ProfileProperty<int>
    {
        #region Overload
        public static int operator *(IntProfileProperty property, int value)
        {
            return property.Get() * value;
        }

        public static int operator *(IntProfileProperty p1, IntProfileProperty p2)
        {
            return p1.Get() * p2.Get();
        }

        public static IntProfileProperty operator +(IntProfileProperty p, int intValue)
        {
            p.SetDirty(p.Get() + intValue);
            p.Commit();
            return p;
        }

        public static IntProfileProperty operator -(IntProfileProperty p, int intValue)
        {
            p.SetDirty(p.Get() - intValue);
            p.Commit();
            return p;
        }

        public static implicit operator IntProfileProperty(int value)
        {
            var p = new IntProfileProperty();
            p.SetDirty(value);
            p.Commit();
            return p;
        }
        #endregion
    }
}
