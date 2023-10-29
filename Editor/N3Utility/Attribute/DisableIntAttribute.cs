/**
 *  FileName    :   DisableIntAttribute.cs
 *  Description :   条件付きシリアライズ化属性(int)
 *
 *  Copyright 2023 H.Nakata All rights reserved.
 */

using UnityEngine;

namespace N3Utility.Attribute
{

    /// <summary> 条件付きシリアライズ化属性(int) </summary>
    public class DisableIntAttribute : PropertyAttribute
    {
        //-----------------------------------------------------------------------
        // 変数
        //-----------------------------------------------------------------------

        /// <summary>
        /// 比較元IntField名
        /// </summary>
        public string targetIntFieldName { get; private set; }

        /// <summary>
        /// 比較用Int値
        /// </summary>
        public int value { get; private set; }

        /// <summary>
        /// 比較演算子
        /// </summary>
        public CompareType type { get; private set; }

        /// <summary>
        /// 条件付きシリアライズ化属性(int)
        /// <remarks>
        ///     <para>
        ///         UnityEngine.SerializeField属性を付与した変数に対し、
        ///         第一引数で渡されたintFieldが第二引数と第三引数を使って判定後、
        ///         trueの場合Inspectorから編集が出来ないようにする属性
        ///     </para>
        /// </remarks>
        /// </summary>
        /// <param name="targetIntFieldName">
        /// 比較元IntField名
        /// <remarks>
        ///     <para>
        ///         ・UnityEngine.SerializeField属性を付けたint型のField名を渡してください(必須)
        ///     </para>
        ///     <para>
        ///         ・nameofを使用してField名を渡してください(推奨)
        ///     </para>
        ///     <para>
        ///         ・Inspectorから隠したいFieldの場合、UnityEngine.HideInspectorを使用してください(任意)
        ///     </para>
        /// </remarks>
        /// </param>
        /// <param name="value">
        /// 比較用Int値
        ///     <para>
        ///         ・渡せる値は静的な値のみです。動的な変数を渡したい場合はDisableIntFieldAttributeを使用してください。
        ///     </para>
        /// </param>
        /// <param name="type">
        /// 比較演算子
        /// </param>
        public DisableIntAttribute(string targetIntFieldName, int value, CompareType type)
        {
            this.targetIntFieldName = targetIntFieldName;
            this.value = value;
            this.type = type;
        }
    }

}