/**
 *  FileName    :   DisableIntFieldAttribute.cs
 *  Description :   条件付きシリアライズ化属性(intField)
 *
 *  Copyright 2023 H.Nakata All rights reserved.
 */

using UnityEngine;

namespace N3Utility.Attribute
{

    /// <summary> 条件付きシリアライズ化属性(intField) </summary>
    public class DisableIntFieldAttribute : PropertyAttribute
    {
        //-----------------------------------------------------------------------
        // 変数
        //-----------------------------------------------------------------------

        /// <summary>
        /// 比較元IntField名
        /// </summary>
        public string targetIntFieldName { get; private set; }

        /// <summary>
        /// 比較用IntField名
        /// </summary>
        public string valueIntFieldName { get; private set; }

        /// <summary>
        /// 比較演算子
        /// </summary>
        public CompareType type { get; private set; }

        /// <summary>
        /// 条件付きシリアライズ化属性(intField)
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
        /// <param name="valueIntFieldName">
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
        /// <param name="type">
        /// 比較演算子
        /// </param>
        public DisableIntFieldAttribute(string targetIntFieldName, string valueIntFieldName, CompareType type)
        {
            this.targetIntFieldName = targetIntFieldName;
            this.valueIntFieldName = valueIntFieldName;
            this.type = type;
        }
    }

}