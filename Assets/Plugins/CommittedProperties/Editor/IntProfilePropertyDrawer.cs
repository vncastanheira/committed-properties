using Castanha.Utils;
using UnityEditor;
using UnityEngine;

namespace Castanha.Editor
{
    [CustomPropertyDrawer(typeof(IntProfileProperty))]
    public class IntProfilePropertyDrawer : ProfilePropertyDrawer
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
                newValue = EditorGUI.IntField(position, label, dirtyProperty.intValue);
                dirtyProperty.intValue = newValue;
            }
            else
            {
                newValue = EditorGUI.IntField(position, label, valueProperty.intValue);
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
