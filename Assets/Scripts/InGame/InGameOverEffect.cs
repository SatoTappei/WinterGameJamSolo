using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using System;

/// <summary>
/// ゲームオーバー時の演出を行うコンポーネント
/// </summary>
public class InGameOverEffect : MonoBehaviour
{
    /// <summary>現在のカウントで待機する時間</summary>
    readonly float Wait = 1;

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
        await UniTask.Delay(TimeSpan.FromSeconds(Wait));
    }
}
