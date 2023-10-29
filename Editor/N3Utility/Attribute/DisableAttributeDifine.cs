/**
 *  FileName    :   DisableAttributeDifine.cs
 *  Description :   条件付きシリアライズ化属性定義
 *
 *  Copyright 2023 H.Nakata All rights reserved.
 */

namespace N3Utility.Attribute
{
    /// <summary>
    /// 比較演算子
    /// </summary>
    public enum CompareType
    {
        /// <summary>
        /// ==
        /// </summary>
        Equal = 0,

        /// <summary>
        /// &lt;
        /// </summary>
        LessThan,

        /// <summary>
        /// &gt;
        /// </summary>
        GreaterThan,

        /// <summary>
        /// &lt;=
        /// </summary>
        LessThanOrEqual,

        /// <summary>
        /// &gt;=
        /// </summary>
        GreaterThanOrEqual
    }
}