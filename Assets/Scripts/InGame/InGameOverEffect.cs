using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

/// <summary>
/// ゲームオーバー時の演出を行うコンポーネント
/// </summary>
public class InGameOverEffect : MonoBehaviour
{
    /// <summary>現在のカウントで待機するフレーム数</summary>
    readonly int WaitFrame = 60;

    [SerializeField] Text _text;

    void Awake()
    {
        _text.text = "";
    }

    /// <summary>
    /// ゲームオーバーの表示をする演出
    /// </summary>
    public async UniTask EffectAsync()
    {
        _text.text = "しゅーりょー！";
        await UniTask.DelayFrame(WaitFrame);
    }
}
