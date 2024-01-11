using Castanha.Utils;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace Castanha.Editor
{
    [CustomPropertyDrawer(typeof(LayerMaskProfileProperty))]
    public class LayerMaskProfilePropertyDrawer : ProfilePropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label);
            position.width -= BUTTON_SPACING * 2;
            var isChangedProperty = property.FindPropertyRelative("isChanged");
            var valueProperty = property.FindPropertyRelative("Value");
            var dirtyProperty = property.FindPropertyRelative("DirtyValue");

            int newValue;
            if (isChangedProperty.boolValue)
            {
                newValue = EditorGUI.MaskField(position, label, dirtyProperty.intValue, InternalEditorUtility.layers);
                dirtyProperty.intValue = newValue;
            }
            else
            {
                newValue = EditorGUI.MaskField(position, label, valueProperty.intValue, InternalEditorUtility.layers);
                if (newValue != valueProperty.intValue)
                {
                    dirtyProperty.intValue = newValue;
                    isChangedProperty.boolValue = true;
                }
                else
                {
                    valueProperty.intValue = newValue;
                }
            }
        }

        public override void Commit(SerializedProperty valueProperty, SerializedProperty dirtyProperty)
        {
            valueProperty.intValue = dirtyProperty.intValue;
        }
    }
}
