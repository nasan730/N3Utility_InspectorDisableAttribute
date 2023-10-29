/**
 *  FileName    :   DisableIntFieldAttributeDrawer.cs
 *  Description :   条件付きシリアライズ化属性(intField)GUI
 *
 *  Copyright 2023 H.Nakata All rights reserved.
 */

using UnityEngine;
using UnityEditor;

namespace N3Utility.Attribute.Editor
{

    /// <summary> 条件付きシリアライズ化属性(intField)GUI </summary>
    [CustomPropertyDrawer(typeof(DisableIntFieldAttribute))]
    public class DisableIntFieldAttributeDrawer : PropertyDrawer
    {
        //-----------------------------------------------------------------------
        // PropertyDrawer継承
        //-----------------------------------------------------------------------

        /// <inheritdoc/>
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // 値更新
            property.serializedObject.Update();

            var derivedAttribute = attribute as DisableIntFieldAttribute;
            if (derivedAttribute == null)
            {
                Debug.LogError($"[{nameof(DisableIntFieldAttributeDrawer)}.{nameof(OnGUI)}()]" +
                               $"Inspectorへの描画失敗。\n{nameof(DisableIntFieldAttribute)}へのキャストに失敗しました。");
                EditorGUI.PropertyField(position, property, label);
                property.serializedObject.ApplyModifiedProperties();
                return;
            }

            int target;
            if (!TryGetIntFieldValue(property, derivedAttribute.targetIntFieldName, out target))
            {
                EditorGUI.PropertyField(position, property, label);
                property.serializedObject.ApplyModifiedProperties();
                return;
            }
            int value;
            if (!TryGetIntFieldValue(property, derivedAttribute.valueIntFieldName, out value))
            {
                EditorGUI.PropertyField(position, property, label);
                property.serializedObject.ApplyModifiedProperties();
                return;
            }

            // 判定
            if (Judge(target, value, derivedAttribute.type))
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
        /// 動的なIntField値を取得
        /// </summary>
        /// <param name="property">プロパティ</param>
        /// <param name="fieldName">フィールド名</param>
        /// <param name="value">out:IntField値</param>
        /// <returns>
        /// <para>true  取得成功</para>
        /// <para>false 取得失敗</para>
        /// </returns>
        private bool TryGetIntFieldValue(SerializedProperty property, string fieldName, out int value)
        {
            SerializedProperty field = property.serializedObject.FindProperty(fieldName);
            if (field == null)
            {
                Debug.LogError($"[{nameof(DisableIntFieldAttributeDrawer)}.{nameof(TryGetIntFieldValue)}()]" +
                               $"Inspectorへの描画失敗。\n{property.serializedObject.targetObject.ToString()}から渡された属性パラメータ{fieldName}が存在しません。");
                value = int.MinValue;
                return false;
            }

            value = field.intValue;
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
        private bool Judge(int target, int value, CompareType type)
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