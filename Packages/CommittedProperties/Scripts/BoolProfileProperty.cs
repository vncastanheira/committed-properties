namespace Castanha.CommittedProperties
{
    [System.Serializable]
    public class BoolProfileProperty : ProfileProperty<bool>
    {
        public static implicit operator BoolProfileProperty(bool value)
        {
            var p = new BoolProfileProperty();
            p.SetDirty(value);
            p.Commit();
            return p;
        }
    }

}
