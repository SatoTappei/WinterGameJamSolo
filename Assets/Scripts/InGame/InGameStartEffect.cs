using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Cysharp.Threading.Tasks;
using System;

/// <summary>
/// ゲームスタート時の演出を行うコンポーネント
/// </summary>
public class InGameStartEffect : MonoBehaviour
{
    /// <summary>現在のカウントで待機する時間</summary>
    readonly float Wait = 1;

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
            await UniTask.Delay(TimeSpan.FromSeconds(Wait));
        }

        _text.text = "はじめ！";
        await UniTask.Delay(TimeSpan.FromSeconds(Wait));
        
        _text.text = "";
    }
}
