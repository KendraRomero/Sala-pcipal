using UnityEditor;
using UnityEngine;
using ABKaspo.Assets.AURW.AURW_Editor.Shaders;

namespace ABKaspo.Assets.AURW.AURW_Editor.Shaders
{
    enum refractionQuality
    {
        Advanced = 0,
        Normal = 1
    }
    public class AURW_Free_Shader_GUI : ShaderGUI
    {
        public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] properties)
        {
            GUIStyle titleStyle = new GUIStyle(EditorStyles.boldLabel);
            titleStyle.alignment = TextAnchor.MiddleCenter;
            titleStyle.fontSize = 16;
            GUILayout.Label("A.U.R.W.", titleStyle);
            EditorGUILayout.Separator();
            GUILayout.Label("Rendering", EditorStyles.boldLabel);
            // base.OnGUI(materialEditor, properties);
            Material material = materialEditor.target as Material;

            MaterialProperty qualityWaterEnum = FindProperty("_WATER_QUALITY", properties);
            MaterialProperty qualityRefractionEnum = FindProperty("_REFRACTION_QUALITY", properties);
            MaterialProperty alphaBool = FindProperty("_ALPHA_CHANNEL", properties);
            MaterialProperty refractionFloat = FindProperty("_Refraction", properties);
            MaterialProperty refractionBool = FindProperty("_REFRACTION", properties);
            MaterialProperty reflectionFloat = FindProperty("_Reflection", properties);
            MaterialProperty reflectionBool = FindProperty("_REFLECTION", properties);
            MaterialProperty displacementBool = FindProperty("_DISPLACEMENT", properties);
            MaterialProperty waveFrequencyFloat = FindProperty("_HeighFrequency", properties);
            MaterialProperty waveAmplitudeFloat = FindProperty("_WaveAmplitude", properties);
            MaterialProperty waveSpeedFloat = FindProperty("_WaveSpeed", properties);
            MaterialProperty smoothnessFloat = FindProperty("_Smoothness", properties);
            MaterialProperty TillingFloat = FindProperty("_Tilling", properties);
            MaterialProperty speedFloat = FindProperty("_Speed", properties);
            MaterialProperty directionVector_2 = FindProperty("_Direction", properties);
            MaterialProperty depthFloat = FindProperty("_Depth", properties);
            MaterialProperty foamTexture = FindProperty("_Foam", properties);
            MaterialProperty n_MainTexture = FindProperty("_MainNormal", properties);
            MaterialProperty n_SecondTexture = FindProperty("_SecondNormal", properties);
            MaterialProperty n_BiggerTexture = FindProperty("_BiggerNormal", properties);
            MaterialProperty n_foamTexture = FindProperty("_FoamNormal", properties);
            MaterialProperty normalStrengthFloat = FindProperty("_Normal_Strength", properties);
            MaterialProperty colorA = FindProperty("_Color_A", properties);
            MaterialProperty colorB = FindProperty("_Color_B", properties);
            MaterialProperty colorC= FindProperty("_Color_C", properties);
            MaterialProperty colorFog = FindProperty("_Fog", properties);

            GUIStyle keywordStyle = new GUIStyle(EditorStyles.label);
            Color dividerColor = new Color(0.5f, 0.5f, 0.5f, 1f);
            //keywordStyle.fontSize = 12;

            EditorGUI.BeginChangeCheck();
            AURW_ShaderGUI_Methods.ShowKeywordEnumField("Water Quality", qualityWaterEnum, keywordStyle, materialEditor);
            AURW_ShaderGUI_Methods.ShowKeywordEnumField("Refraction Type", qualityRefractionEnum, keywordStyle, materialEditor);
            EditorGUILayout.Space();
            EditorGUI.DrawRect(EditorGUILayout.GetControlRect(false, 2), dividerColor);
            EditorGUILayout.Space();
            GUILayout.Label("Colours", EditorStyles.boldLabel);
            AURW_ShaderGUI_Methods.DrawColorProperty("Color A", colorA);
            AURW_ShaderGUI_Methods.DrawColorProperty("Color B", colorB);
            AURW_ShaderGUI_Methods.DrawColorProperty("Color Fog", colorFog);
            AURW_ShaderGUI_Methods.ShowKeywordBoolFIeld("      Alpha Channel", alphaBool, keywordStyle, materialEditor);
            if (alphaBool.floatValue == 1)
            {
                EditorGUILayout.HelpBox("If refraction is on, to a better render, turn off this.", MessageType.Info);
            }
            EditorGUILayout.Space();
            GUILayout.Label("Surface", EditorStyles.boldLabel);
            AURW_ShaderGUI_Methods.ShowFloatField("    Refraction", refractionFloat, keywordStyle, materialEditor);
            if (refractionBool.floatValue == 1 && qualityRefractionEnum.floatValue == 0)
            {
                EditorGUILayout.HelpBox("Refraction is based on normal strength, this values doesn't change its strength, but the distorion.", MessageType.Info);
            }
            AURW_ShaderGUI_Methods.ShowKeywordBoolFIeld("        Enable", refractionBool, keywordStyle, materialEditor);
            AURW_ShaderGUI_Methods.ShowFloatField("    Reflection", reflectionFloat, keywordStyle, materialEditor);
            if (reflectionBool.floatValue == 1)
            {
                EditorGUILayout.HelpBox("Add 'reflections' script to start reflecting (Beta).", MessageType.Info);
            }
            AURW_ShaderGUI_Methods.ShowKeywordBoolFIeld("        Enable", reflectionBool, keywordStyle, materialEditor);
            AURW_ShaderGUI_Methods.ShowFloatSlider("    Smoothness", smoothnessFloat, keywordStyle, 1, 0);
            EditorGUILayout.Space();
            GUILayout.Label("Tilling & Offset", EditorStyles.boldLabel);
            AURW_ShaderGUI_Methods.ShowFloatField("    Tilling", TillingFloat, keywordStyle, materialEditor);
            AURW_ShaderGUI_Methods.ShowFloatField("    Speed", speedFloat, keywordStyle, materialEditor);
            AURW_ShaderGUI_Methods.ShowVector2Property("    Direction", directionVector_2);
            EditorGUILayout.Space();
            EditorGUI.DrawRect(EditorGUILayout.GetControlRect(false, 2), dividerColor);
            EditorGUILayout.Space();
            GUILayout.Label("Foam", EditorStyles.boldLabel);
            AURW_ShaderGUI_Methods.ShowTextureProperty("       Foam Texture", foamTexture, materialEditor);
            AURW_ShaderGUI_Methods.ShowFloatField("    Depth", depthFloat, keywordStyle, materialEditor);
            AURW_ShaderGUI_Methods.DrawColorProperty("Color C", colorC);
            EditorGUILayout.Space();
            EditorGUI.DrawRect(EditorGUILayout.GetControlRect(false, 2), dividerColor);
            EditorGUILayout.Space();
            GUILayout.Label("Normal Mapping", EditorStyles.boldLabel);
            AURW_ShaderGUI_Methods.ShowTextureProperty("       Main Normal", n_MainTexture, materialEditor);
            AURW_ShaderGUI_Methods.ShowTextureProperty("       Second Normal", n_SecondTexture, materialEditor);
            AURW_ShaderGUI_Methods.ShowTextureProperty("       Bigger Normal", n_BiggerTexture, materialEditor);
            AURW_ShaderGUI_Methods.ShowTextureProperty("       Foam Normal", n_foamTexture, materialEditor);
            AURW_ShaderGUI_Methods.ShowFloatField("       NormalStrength", normalStrengthFloat, keywordStyle, materialEditor);
            EditorGUILayout.Space();
            EditorGUI.DrawRect(EditorGUILayout.GetControlRect(false, 2), dividerColor);
            EditorGUILayout.Space();
            GUILayout.Label("Displacement", EditorStyles.boldLabel);
            AURW_ShaderGUI_Methods.ShowKeywordBoolFIeld("    Enable", displacementBool, keywordStyle, materialEditor);
            if(displacementBool.floatValue == 1)
            {
                AURW_ShaderGUI_Methods.ShowFloatField("    Wave Speed", waveSpeedFloat, keywordStyle, materialEditor);
                AURW_ShaderGUI_Methods.ShowFloatField("    Wave Amplitude", waveAmplitudeFloat, keywordStyle, materialEditor);
                AURW_ShaderGUI_Methods.ShowFloatField("    Wave Frequency", waveFrequencyFloat, keywordStyle, materialEditor);
            }
            EditorGUILayout.Space();
            EditorGUI.DrawRect(EditorGUILayout.GetControlRect(false, 2), dividerColor);
            EditorGUILayout.Space();

            EditorGUILayout.HelpBox("ABKaspo's Ultra Realistic Water (A.U.R.W.), for more informations go to documentation window in ABKaspo -> About -> Documentation. If you wanna contact us send an e-mail to ABKaspo -> About -> Contact Us -> Send an E-Mail.", MessageType.None);
        }
        
    }
}