using Castanha.CommittedProperties;
using UnityEditor;
using UnityEngine;

namespace Castanha.Editor
{
    [CustomPropertyDrawer(typeof(FloatProfileProperty))]
    public class FloatProfilePropertyDrawer : ProfilePropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label);
            position.width -= BUTTON_SPACING * 2;
            var isChangedProperty = property.FindPropertyRelative("isChanged");
            var valueProperty = property.FindPropertyRelative("Value");
            var dirtyProperty = property.FindPropertyRelative("DirtyValue");

            float newValue;
            if (isChangedProperty.boolValue)
            {
                newValue = EditorGUI.FloatField(position, label, dirtyProperty.floatValue);
                dirtyProperty.floatValue = newValue;
            }
            else
            {
                newValue = EditorGUI.FloatField(position, label, valueProperty.floatValue);
                if (newValue != valueProperty.floatValue)
                {
                    dirtyProperty.floatValue = newValue;
                    isChangedProperty.boolValue = true;
                }
                else
                {
                    valueProperty.floatValue = newValue;
                }
            }
        }

        public override void Commit(SerializedProperty valueProperty, SerializedProperty dirtyProperty)
        {
            valueProperty.floatValue = dirtyProperty.floatValue;
        }
    }
}
