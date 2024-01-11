using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Castanha.Samples
{
    public class SampleManager : MonoBehaviour
    {
        [SerializeField] private SampleScriptableObject sampleScriptableObject;

        public TextMeshProUGUI integerValue;
        public TextMeshProUGUI floatValue;
        public Toggle boolValue;
        public TextMeshProUGUI vector2Value;
        public TextMeshProUGUI vector3Value;
        public TextMeshProUGUI layerMaskValue;
        public TextMeshProUGUI tagValue;

        private void Update()
        {
            integerValue.text = sampleScriptableObject.Integer.Get().ToString();
            floatValue.text = sampleScriptableObject.Float.Get().ToString();
            boolValue.isOn = sampleScriptableObject.Bool.Get();
            vector2Value.text = sampleScriptableObject.Vector2.Get().ToString();
            vector3Value.text = sampleScriptableObject.Vector3.Get().ToString();

            LayerMask mask = sampleScriptableObject.LayerMask.Get();
            var layers = Enumerable.Range(0, 31).Where(layer => (mask == (mask | 1 << layer)))
                .Select(i => LayerMask.LayerToName(i))
                .Where(name => !string.IsNullOrEmpty(name));

            layerMaskValue.text = string.Join(" ", layers);

            tagValue.text = sampleScriptableObject.Tag.Get().ToString();
        }
    }
}
