/**
 *  FileName    :   DisableIntAttributeDrawer.cs
 *  Description :   条件付きシリアライズ化属性(float)GUI
 *
 *  Copyright 2023 H.Nakata All rights reserved.
 */

using UnityEngine;
using UnityEditor;

namespace N3Utility.Attribute.Editor
{

    /// <summary> 条件付きシリアライズ化属性(float)GUI </summary>
    [CustomPropertyDrawer(typeof(DisableFloatAttribute))]
    public class DisableFloatAttributeDrawer : PropertyDrawer
    {
        //-----------------------------------------------------------------------
        // PropertyDrawer継承
        //-----------------------------------------------------------------------

        /// <inheritdoc/>
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // 値更新
            property.serializedObject.Update();

            var derivedAttribute = attribute as DisableFloatAttribute;
            if (derivedAttribute == null)
            {
                
                Debug.LogError($"[{nameof(DisableFloatAttributeDrawer)}.{nameof(OnGUI)}()]" +
                               $"Inspectorへの描画失敗。\n{nameof(DisableFloatAttributeDrawer)}へのキャストに失敗しました。");
                EditorGUI.PropertyField(position, property, label);
                property.serializedObject.ApplyModifiedProperties();
                return;
            }

            float target;
            if (!TryGetFloatFieldValue(property, derivedAttribute.targetFloatFieldName, out target))
            {
                EditorGUI.PropertyField(position, property, label);
                property.serializedObject.ApplyModifiedProperties();
                return;
            }

            // 判定
            if (Judge(target, derivedAttribute.value, derivedAttribute.type))
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

        /// <summary>
        /// 動的なFloatField値を取得
        /// </summary>
        /// <param name="property">プロパティ</param>
        /// <param name="fieldName">フィールド名</param>
        /// <param name="value">out:FloatField値</param>
        /// <returns>
        /// <para>true  取得成功</para>
        /// <para>false 取得失敗</para>
        /// </returns>
        private bool TryGetFloatFieldValue(SerializedProperty property, string fieldName, out float value)
        {
            SerializedProperty field = property.serializedObject.FindProperty(fieldName);
            if (field == null)
            {
                Debug.LogError($"[{nameof(DisableFloatAttributeDrawer)}.{nameof(TryGetFloatFieldValue)}()]" +
                               $"Inspectorへの描画失敗。\n{property.serializedObject.targetObject.ToString()}から渡された属性パラメータ{fieldName}が存在しません。");
                value = float.NaN;
                return false;
            }

            value = field.floatValue;
            return true;
        }

        /// <summary>
        /// 判定
        /// </summary>
        /// <param name="target">ターゲット</param>
        /// <param name="value">比較値</param>
        /// <param name="type">比較種別</param>
        /// <returns>
        /// <para>true  成功</para>
        /// <para>false 失敗</para>
        /// </returns>
        private bool Judge(float target, float value, CompareType type)
        {
            return type switch
            {
                CompareType.Equal => target == value,
                CompareType.LessThan => target < value,
                CompareType.GreaterThan => target > value,
                CompareType.LessThanOrEqual => target <= value,
                CompareType.GreaterThanOrEqual => target >= value,
                _ => false
            };
        }
    }

}