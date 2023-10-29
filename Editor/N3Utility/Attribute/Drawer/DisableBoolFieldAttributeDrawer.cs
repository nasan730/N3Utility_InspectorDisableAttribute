/**
 *  FileName    :   DisableBoolFieldAttributeDrawer.cs
 *  Description :   条件付きシリアライズ化属性(boolField)GUI
 *
 *  Copyright 2023 H.Nakata All rights reserved.
 */

using UnityEngine;
using UnityEditor;

namespace N3Utility.Attribute.Editor
{

    /// <summary> 条件付きシリアライズ化属性(boolField)GUI </summary>
    [CustomPropertyDrawer(typeof(DisableBoolFieldAttribute))]
    public class DisableBoolFieldAttributeDrawer : PropertyDrawer
    {
        //-----------------------------------------------------------------------
        // PropertyDrawer継承
        //-----------------------------------------------------------------------

        /// <inheritdoc/>
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // 値更新
            property.serializedObject.Update();

            // 値取得
            var derivedAttribute = attribute as DisableBoolFieldAttribute;
            if (derivedAttribute == null)
            {
                
                Debug.LogError($"[{nameof(DisableBoolFieldAttributeDrawer)}.{nameof(OnGUI)}()]" +
                               $"Inspectorへの描画失敗。\n{nameof(DisableBoolFieldAttribute)}へのキャストに失敗しました。");
                EditorGUI.PropertyField(position, property, label);
                property.serializedObject.ApplyModifiedProperties();
                return;
            }
            SerializedProperty field = property.serializedObject.FindProperty(derivedAttribute.boolFieldName);
            if (field == null)
            {
                Debug.LogError($"[{nameof(DisableBoolFieldAttributeDrawer)}.{nameof(OnGUI)}()]" +
                               $"Inspectorへの描画失敗。\n{property.serializedObject.targetObject.ToString()}から渡された属性パラメータ{field}が存在しません。");
                EditorGUI.PropertyField(position, property, label);
                property.serializedObject.ApplyModifiedProperties();
                return;
            }

            // 判定
            if (field.boolValue == derivedAttribute.condition)
            {
                EditorGUI.BeginDisabledGroup(true);
                EditorGUI.PropertyField(position, property, label);
                EditorGUI.EndDisabledGroup();
            }
            else
            {
                EditorGUI.PropertyField(position, property, label);
            }

            property.serializedObject.ApplyModifiedProperties();
        }
    }

}