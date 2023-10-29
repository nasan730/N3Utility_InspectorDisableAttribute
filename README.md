# Unity InspectorDisableAttribute

## Introduction
- 条件によってUnityのInspectorで編集不可にさせる属性
- 属性の引数に渡された引数で判別し、編集状態を切り替える
- 動的な変数を使用して判別
    - [`SerializeField`](https://docs.unity3d.com/ScriptReference/SerializeField.html)属性を付与した変数を渡してください
        - インスペクターから隠したい変数の場合は[`HideInInspector`](https://docs.unity3d.com/ScriptReference/HideInInspector.html)を付与した変数を使用してください
    - `nameof`を使用して変数を渡してください

## Introduction
1. URLをコピー<br>```https://github.com/nasan730/N3Utility_InspectorDisableAttribute.git```<br>
2. Window → PackageManagerでPackageManagerをクリック
3. `+`アイコン → Add package from git URL... をクリック
4. URLをペースト<br>
> UnityDocumentation : [Install a package from a Git URL](https://docs.unity3d.com/ja/2022.3/Manual/upm-ui-giturl.html)

## Example
### boolField
| 引数名 | 説明 |
| ----- | ----- |
| string boolFieldName | bool型の変数名 |
| bool condition | 無効化する条件<br>`boolField == condition`の場合無効化します<br>デフォルト値は`true` |

```csharp
using UnityEngine;
using N3Utility.Attribute;

public class SampleComponent : MonoBehaviour
{
    [SerializeField]
    private bool m_flag = false;

    [SerializeField]
    [DisableBoolField(nameof(m_flag))]
    private string m_text = "Hello world!";
}
```

### int
| 引数名 | 説明 |
| ----- | ----- |
| string targetIntFieldName | 比較元 int型変数名 |
| int value | 比較用Int値 |
| CompareType type | 比較演算子<br> 渡された比較方法で判定し、`true`の場合無効化します |
```csharp
using UnityEngine;
using N3Utility.Attribute;

public class SampleComponent : MonoBehaviour
{
    [SerializeField]
    private int m_target = 0;

    [SerializeField]
    [DisableInt(nameof(m_target), 0, CompareType.Equal)]
    private string m_text = "Hello world!";
}
```

### intField
| 引数名 | 説明 |
| ----- | ----- |
| string targetIntFieldName | 比較元 int型変数名 |
| string valueIntFieldName | 比較用 int型変数名 |
| CompareType type | 比較演算子<br> 渡された比較方法で判定し、`true`の場合無効化します |
```csharp
using UnityEngine;
using N3Utility.Attribute;

public class SampleComponent : MonoBehaviour
{
    [SerializeField]
    private int m_target = 0;

    [SerializeField]
    private int m_value = 0;

    [SerializeField]
    [DisableIntField(nameof(m_target), nameof(m_value), CompareType.Equal)]
    private string m_text = "Hello world!";
}
```

### float
| 引数名 | 説明 |
| ----- | ----- |
| string targetFloatFieldName | 比較元 float型変数名 |
| float value | 比較用float値 |
| CompareType type | 比較演算子<br> 渡された比較方法で判定し、`true`の場合無効化します |
```csharp
using UnityEngine;
using N3Utility.Attribute;

public class SampleComponent : MonoBehaviour
{
    [SerializeField]
    private float m_target = 0.0f;

    [SerializeField]
    [DisableFloat(nameof(m_target), 0.0f, CompareType.Equal)]
    private string m_text = "Hello world!";
}
```

### floatField
| 引数名 | 説明 |
| ----- | ----- |
| string targetFloatFieldName | 比較元 float型変数名 |
| string valueFloatFieldName | 比較用 float型変数名 |
| CompareType type | 比較演算子<br> 渡された比較方法で判定し、`true`の場合無効化します |
```csharp
using UnityEngine;
using N3Utility.Attribute;

public class SampleComponent : MonoBehaviour
{
    [SerializeField]
    private float m_target = 0.0f;

    [SerializeField]
    private float m_value = 0.0f;

    [SerializeField]
    [DisableFloatField(nameof(m_target), nameof(m_value), CompareType.Equal)]
    private string m_text = "Hello world!";
}
```