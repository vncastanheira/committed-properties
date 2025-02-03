using Castanha.CommittedProperties;
using UnityEditor;
using UnityEngine;

namespace Castanha.Editor
{
    [CustomPropertyDrawer(typeof(BoolProfileProperty))]
    public class BoolProfilePropertyDrawer : ProfilePropertyDrawer
    {   
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label);
            position.width -= BUTTON_SPACING * 2;
            var isChangedProperty = property.FindPropertyRelative("isChanged");
            var valueProperty = property.FindPropertyRelative("Value");
            var dirtyProperty = property.FindPropertyRelative("DirtyValue");

            bool newValue;
            if (isChangedProperty.boolValue)
            {
                newValue = EditorGUI.Toggle(position, label, dirtyProperty.boolValue);
                dirtyProperty.boolValue = newValue;
            }
            else
            {
                newValue = EditorGUI.Toggle(position, label, valueProperty.boolValue);
                if (newValue != valueProperty.boolValue)
                {
                    dirtyProperty.boolValue = newValue;
                    isChangedProperty.boolValue = true;
                }
                else
                {
                    valueProperty.boolValue = newValue;
                }
            }
        }

        public override void Commit(SerializedProperty valueProperty, SerializedProperty dirtyProperty)
        {
            valueProperty.boolValue = dirtyProperty.boolValue;
        }

    }
}
