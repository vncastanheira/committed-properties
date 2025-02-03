using UnityEditor;
using UnityEngine;

namespace Castanha.Editor
{
    public abstract class ProfilePropertyDrawer : PropertyDrawer
    {
        protected const float BUTTON_SPACING = 60f;
        const float PADDING = 120f;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var isChangedProperty = property.FindPropertyRelative("isChanged");

            position.x = position.width - PADDING;
            position.width = BUTTON_SPACING;
            GUI.enabled = isChangedProperty?.boolValue == true;
            if(GUI.Button(position, "Commit"))
            {
                // makes the value offical, can't rollback after this
                isChangedProperty.boolValue = false;
                var valueProperty = property.FindPropertyRelative("Value");
                var dirtyProperty = property.FindPropertyRelative("DirtyValue");
                Commit(valueProperty, dirtyProperty);
                EditorGUI.FocusTextInControl("");
            }
            position.x += BUTTON_SPACING;
            if (GUI.Button(position, "Reset"))
            {
                // return to previous value
                isChangedProperty.boolValue = false;
                EditorGUI.FocusTextInControl(""); // remove focus from the value input
            }

            GUI.enabled = true;
        }

        public abstract void Commit(SerializedProperty valueProperty, SerializedProperty dirtyProperty);
    }
}
