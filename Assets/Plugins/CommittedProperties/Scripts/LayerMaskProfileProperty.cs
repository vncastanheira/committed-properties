using UnityEngine;

namespace Castanha.CommittedProperties
{
    [System.Serializable]
    public class LayerMaskProfileProperty : ProfileProperty<LayerMask>
    {
        /// <summary>
        /// Automatically converts the property type to T
        /// </summary>
        /// <param name="p">Property type</param>
        public static implicit operator int(LayerMaskProfileProperty p) => p.Get();
    }
}
