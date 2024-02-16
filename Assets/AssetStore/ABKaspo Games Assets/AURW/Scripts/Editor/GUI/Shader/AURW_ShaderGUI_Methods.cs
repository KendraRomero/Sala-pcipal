using UnityEditor;
using UnityEngine;

namespace ABKaspo.Assets.AURW.AURW_Editor.Shaders
{
    public class AURW_ShaderGUI_Methods : ShaderGUI
    {
        public static void ShowFloatField(string label, MaterialProperty property, GUIStyle style, MaterialEditor materialEditor)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(label, style, GUILayout.Width(200));
            materialEditor.ShaderProperty(property, GUIContent.none);

            EditorGUILayout.EndHorizontal();
        }
        public static void ShowFloatSlider(string label, MaterialProperty property, GUIStyle style, float max, float min)
        {
            EditorGUILayout.BeginHorizontal();
            if (property.type == MaterialProperty.PropType.Float)
            {
                EditorGUIUtility.labelWidth = 0;
                EditorGUILayout.LabelField(label, style, GUILayout.Width(120));
                EditorGUI.indentLevel--;
                EditorGUI.showMixedValue = property.hasMixedValue;
                property.floatValue = EditorGUILayout.Slider(property.floatValue, min, max);
                EditorGUI.indentLevel++;
                EditorGUI.showMixedValue = false;

                EditorGUILayout.EndHorizontal();
            }
        }

        public static void ShowKeywordEnumField(string label, MaterialProperty property, GUIStyle style, MaterialEditor materialEditor)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(label, style, GUILayout.Width(200));
            materialEditor.ShaderProperty(property, GUIContent.none);

            EditorGUILayout.EndHorizontal();
        }

        public static void ShowKeywordBoolFIeld(string label, MaterialProperty property, GUIStyle style, MaterialEditor materialEditor)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(label, style);
            materialEditor.ShaderProperty(property, GUIContent.none);

            EditorGUILayout.EndHorizontal();
        }

        public static void ShowTextureProperty(string label, MaterialProperty property, MaterialEditor materialEditor)
        {
            if (property.type == MaterialProperty.PropType.Texture)
            {
                EditorGUIUtility.labelWidth = 0;
                // EditorGUILayout.LabelField(label, GUILayout.Width(120));
                EditorGUI.indentLevel--;
                EditorGUI.showMixedValue = property.hasMixedValue;
                materialEditor.TextureProperty(property, label);
                EditorGUI.indentLevel++;
                EditorGUI.showMixedValue = false;
            }
        }
        public static void DrawColorProperty(string label, MaterialProperty property)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUIUtility.labelWidth = 0;
            EditorGUILayout.LabelField(label, GUILayout.Width(120));
            EditorGUI.indentLevel--;
            EditorGUI.showMixedValue = property.hasMixedValue;
            property.colorValue = EditorGUILayout.ColorField(GUIContent.none, property.colorValue, true, true, true);
            EditorGUI.indentLevel++;
            EditorGUI.showMixedValue = false;
            EditorGUILayout.EndHorizontal();
        }
        public static void ShowVector2Property(string label, MaterialProperty property)
        {
            EditorGUILayout.BeginHorizontal();
            if (property.type == MaterialProperty.PropType.Vector)
            {
                EditorGUIUtility.labelWidth = 0;
                EditorGUILayout.LabelField(label, GUILayout.Width(120));
                EditorGUI.indentLevel--;
                EditorGUI.showMixedValue = property.hasMixedValue;
                Vector2 vectorValue = property.vectorValue;
                EditorGUI.BeginChangeCheck();
                vectorValue = EditorGUILayout.Vector2Field("", vectorValue);
                if (EditorGUI.EndChangeCheck())
                {
                    property.vectorValue = vectorValue;
                }
                EditorGUI.indentLevel++;
                EditorGUI.showMixedValue = false;
            }

            EditorGUILayout.EndHorizontal();
        }
    }
}