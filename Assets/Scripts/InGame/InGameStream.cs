using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

/// <summary>
/// インゲームの流れを制御するコンポーネント
/// </summary>
public class InGameStream : MonoBehaviour
{
    [SerializeField] InGameStartEffect _inGameStartEffect;
    [SerializeField] InGameOverEffect _inGameOverEffect;

    async UniTaskVoid Start()
    {
        return;

        // スタート演出
        await _inGameStartEffect.EffectAsync();
        // ゲームスタート
        // ゲーム中
        // ゲーム終了
        await _inGameOverEffect.EffectAsync();
        // リザルトシーンへ以降
        FadeSystem.Instance?.FadeOut("Result");
    }

    void Update()
    {
        
    }
}
