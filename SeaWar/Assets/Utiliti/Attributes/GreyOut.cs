using UnityEditor;
using UnityEngine;

namespace Utiliti.Attributes
{
    public class GreyOut : PropertyAttribute
    {
    }
    #if UNITY_EDITOR
    [CustomPropertyDrawer((typeof(GreyOut)))]
    public class GrayOutDrawer: PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property,GUIContent lable)
        {
            return EditorGUI.GetPropertyHeight(property, lable, true);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent lable)
        {
            GUI.enabled = false;
            EditorGUI.PropertyField(position, property, lable, true);
            GUI.enabled = true; 
        }
    }
    #endif
}
