using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;

/// <summary>
/// インゲームの流れを制御するコンポーネント
/// </summary>
public class InGameStream : MonoBehaviour
{
    [SerializeField] InGameStartEffect _inGameStartEffect;
    [SerializeField] InGameOverEffect _inGameOverEffect;
    [SerializeField] InGameBgmPlayer _inGameBgmPlayer;
    [SerializeField] InGameTimer _inGameTimer;
    [Header("ゲームの制限時間")]
    [SerializeField] int _timeLimit;

    public int TimeLimit { get => _timeLimit; }

    async UniTaskVoid Start()
    {
        // フェードが終わるまでちょっと待つ
        await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
        // BGMを再生する
        _inGameBgmPlayer?.Play();
        // スタート演出
        await _inGameStartEffect.EffectAsync();
        // ゲームスタート
        ManageableManager manageableManager = new ManageableManager(2);
        manageableManager.Start();
        // ゲーム中
        await _inGameTimer.Timer(_timeLimit, this.GetCancellationTokenOnDestroy());
        // ゲーム終了
        manageableManager.Stop();
        // がめおべら演出
        await _inGameOverEffect.EffectAsync();
        // リザルトシーンへ以降
        FadeSystem.Instance?.FadeOut("Result");
    }
}
