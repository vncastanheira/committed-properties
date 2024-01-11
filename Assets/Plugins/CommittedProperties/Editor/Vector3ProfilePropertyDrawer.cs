using Castanha.CommittedProperties;
using UnityEditor;
using UnityEngine;

namespace Castanha.Editor
{
    [CustomPropertyDrawer(typeof(Vector3ProfileProperty))]
    public class Vector3ProfilePropertyDrawer : ProfilePropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label);
            position.width -= BUTTON_SPACING * 2;
            var isChangedProperty = property.FindPropertyRelative("isChanged");
            var valueProperty = property.FindPropertyRelative("Value");
            var dirtyProperty = property.FindPropertyRelative("DirtyValue");

            Vector3 newValue;
            if (isChangedProperty.boolValue)
            {
                newValue = EditorGUI.Vector3Field(position, label, dirtyProperty.vector3Value);
                dirtyProperty.vector3Value = newValue;
            }
            else
            {
                newValue = EditorGUI.Vector3Field(position, label, valueProperty.vector3Value);
                if (newValue != valueProperty.vector3Value)
                {
                    dirtyProperty.vector3Value = newValue;
                    isChangedProperty.boolValue = true;
                }
                else
                {
                    valueProperty.vector3Value = newValue;
                }
            }
        }

        public override void Commit(SerializedProperty valueProperty, SerializedProperty dirtyProperty)
        {
            valueProperty.vector3Value = dirtyProperty.vector3Value;
        }
    }
}
