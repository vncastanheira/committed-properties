using Castanha.Editor;
using UnityEditor;
using UnityEngine;

namespace Castanha.CommittedProperties
{
    [CustomPropertyDrawer(typeof(Vector2ProfileProperty))]
    public class Vector2ProfilePropertyDrawer : ProfilePropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label);
            position.width -= BUTTON_SPACING * 2;
            var isChangedProperty = property.FindPropertyRelative("isChanged");
            var valueProperty = property.FindPropertyRelative("Value");
            var dirtyProperty = property.FindPropertyRelative("DirtyValue");

            Vector2 newValue;
            if (isChangedProperty.boolValue)
            {
                newValue = EditorGUI.Vector2Field(position, label, dirtyProperty.vector2Value);
                dirtyProperty.vector2Value = newValue;
            }
            else
            {
                newValue = EditorGUI.Vector2Field(position, label, valueProperty.vector2Value);
                if (newValue != valueProperty.vector2Value)
                {
                    dirtyProperty.vector2Value = newValue;
                    isChangedProperty.boolValue = true;
                }
                else
                {
                    valueProperty.vector2Value = newValue;
                }
            }
        }

        public override void Commit(SerializedProperty valueProperty, SerializedProperty dirtyProperty)
        {
            valueProperty.vector2Value = dirtyProperty.vector2Value;
        }
    }
}
