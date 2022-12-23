using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Cysharp.Threading.Tasks;

/// <summary>
/// ゲームスタート時の演出を行うコンポーネント
/// </summary>
public class InGameStartEffect : MonoBehaviour
{
    /// <summary>現在のカウントで待機するフレーム数</summary>
    readonly int WaitFrame = 60;

    [SerializeField] Text _text;

    void Awake()
    {
        _text.text = "";
    }

    /// <summary>
    /// カウントダウンしてスタートの表示をする演出
    /// </summary>
    public async UniTask EffectAsync()
    {
        string[] strs = { "さん", "に", "いち" };

        for (int i = 0; i < strs.Length; i++)
        {
            _text.text = strs[i];
            await UniTask.DelayFrame(WaitFrame);
        }

        _text.text = "はじめ！";
        await UniTask.DelayFrame(WaitFrame);
        
        _text.text = "";
    }
}
