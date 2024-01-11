using Castanha.CommittedProperties;
using UnityEngine;

namespace Castanha.Samples
{
    [CreateAssetMenu(fileName = "Sample Scriptable Object", menuName = "Committed Properties/Sample Scriptable Object")]
    public class SampleScriptableObject : ScriptableObject
    {
        public IntProfileProperty Integer;
        public FloatProfileProperty Float;
        public BoolProfileProperty Bool;
        public Vector2ProfileProperty Vector2;
        public Vector3ProfileProperty Vector3;
        public LayerMaskProfileProperty LayerMask;
        public TagProfileProperty Tag;
    }
}
