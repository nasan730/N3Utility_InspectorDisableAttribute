/**
 *  FileName    :   DisableFloatFieldAttribute.cs
 *  Description :   条件付きシリアライズ化属性(floatField)
 *
 *  Copyright 2023 H.Nakata All rights reserved.
 */

using UnityEngine;

namespace N3Utility.Attribute
{

    /// <summary> 条件付きシリアライズ化属性(floatField) </summary>
    public class DisableFloatFieldAttribute : PropertyAttribute
    {
        //-----------------------------------------------------------------------
        // 変数
        //-----------------------------------------------------------------------

        /// <summary>
        /// 比較元FloatField名
        /// </summary>
        public string targetFloatFieldName { get; private set; }

        /// <summary>
        /// 比較用FloatField名
        /// </summary>
        public string valueFloatFieldName { get; private set; }

        /// <summary>
        /// 比較演算子
        /// </summary>
        public CompareType type { get; private set; }

        /// <summary>
        /// 条件付きシリアライズ化属性(floatField)
        /// <remarks>
        ///     <para>
        ///         UnityEngine.SerializeField属性を付与した変数に対し、
        ///         第一引数で渡されたFloatFieldが第二引数と第三引数を使って判定後、
        ///         trueの場合Inspectorから編集が出来ないようにする属性
        ///     </para>
        /// </remarks>
        /// </summary>
        /// <param name="targetFloatFieldName">
        /// 比較元FloatField名
        /// <remarks>
        ///     <para>
        ///         ・UnityEngine.SerializeField属性を付けたfloat型のField名を渡してください(必須)
        ///     </para>
        ///     <para>
        ///         ・nameofを使用してField名を渡してください(推奨)
        ///     </para>
        ///     <para>
        ///         ・Inspectorから隠したいFieldの場合、UnityEngine.HideInspectorを使用してください(任意)
        ///     </para>
        /// </remarks>
        /// </param>
        /// <param name="valueFloatFieldName">
        /// 比較元FloatField名
        /// <remarks>
        ///     <para>
        ///         ・UnityEngine.SerializeField属性を付けたfloat型のField名を渡してください(必須)
        ///     </para>
        ///     <para>
        ///         ・nameofを使用してField名を渡してください(推奨)
        ///     </para>
        ///     <para>
        ///         ・Inspectorから隠したいFieldの場合、UnityEngine.HideInspectorを使用してください(任意)
        ///     </para>
        /// </remarks>
        /// </param>
        /// <param name="type">
        /// 比較演算子
        /// </param>
        public DisableFloatFieldAttribute(string targetFloatFieldName, string valueFloatFieldName, CompareType type)
        {
            this.targetFloatFieldName = targetFloatFieldName;
            this.valueFloatFieldName = valueFloatFieldName;
            this.type = type;
        }
    }

}