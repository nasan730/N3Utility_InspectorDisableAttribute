/**
 *  FileName    :   DisableBoolFieldAttribute.cs
 *  Description :   条件付きシリアライズ化属性(boolField)
 *
 *  Copyright 2023 H.Nakata All rights reserved.
 */

using UnityEngine;

namespace N3Utility.Attribute
{

    /// <summary> 条件付きシリアライズ化属性(boolField) </summary>
    public class DisableBoolFieldAttribute : PropertyAttribute
    {
        //-----------------------------------------------------------------------
        // 変数
        //-----------------------------------------------------------------------

        /// <summary>
        /// boolField名
        /// </summary>
        public string boolFieldName { get; private set; }

        /// <summary>
        /// 無効化する条件
        /// </summary>
        public bool condition { get; private set; }

        /// <summary>
        /// 条件付きシリアライズ化属性(boolField)
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         UnityEngine.SerializeField属性を付与した変数に対し、
        ///         第一引数にに渡されたboolFieldが第二引数の条件を満たしている場合
        ///         Inspectorから編集が出来ないようにする属性
        ///     </para>
        /// </remarks>
        /// <param name="boolFieldName">
        /// bool型のField名
        /// <remarks>
        ///     <para>
        ///         ・UnityEngine.SerializeField属性を付けたbool型のField名を渡してください(必須)
        ///     </para>
        ///     <para>
        ///         ・nameofを使用してField名を渡してください(推奨)
        ///     </para>
        ///     <para>
        ///         ・Inspectorから隠したいFieldの場合、UnityEngine.HideInspectorを使用してください(任意)
        ///     </para>
        /// </remarks>
        /// </param>
        /// <param name="condition">
        /// 無効化する条件
        /// <remarks>
        ///     <para>
        ///          ・この引数で渡された条件になった場合無効化されます(デフォルトではtrueで無効化)
        ///     </para>
        /// </remarks>
        /// </param>
        public DisableBoolFieldAttribute(string boolFieldName, bool condition = true)
        {
            this.boolFieldName = boolFieldName;
        }
    }

}