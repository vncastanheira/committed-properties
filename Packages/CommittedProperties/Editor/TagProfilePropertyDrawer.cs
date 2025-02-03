using Castanha.CommittedProperties;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Castanha.Editor
{
    [CustomPropertyDrawer(typeof(TagProfileProperty))]
    public class TagProfilePropertyDrawer : ProfilePropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label);

            var tagList = UnityEditorInternal.InternalEditorUtility.tags.ToList();

            position.width -= BUTTON_SPACING * 2;
            var isChangedProperty = property.FindPropertyRelative("isChanged");
            var valueProperty = property.FindPropertyRelative("Value");
            var dirtyProperty = property.FindPropertyRelative("DirtyValue");

            string newValue;
            if (isChangedProperty.boolValue)
            {
                newValue = EditorGUI.TagField(position, label, dirtyProperty.stringValue);
                dirtyProperty.stringValue = newValue;
            }
            else
            {
                newValue = EditorGUI.TagField(position, label, valueProperty.stringValue);

                if (newValue != valueProperty.stringValue)
                {
                    dirtyProperty.stringValue = newValue;
                    isChangedProperty.boolValue = true;
                }
                else
                {
                    valueProperty.stringValue = newValue;
                }
            }
        }

        public override void Commit(SerializedProperty valueProperty, SerializedProperty dirtyProperty)
        {
            valueProperty.stringValue = dirtyProperty.stringValue;
        }
    }
}
