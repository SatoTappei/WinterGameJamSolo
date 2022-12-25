using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;
using System;
using System.Threading;

/// <summary>
/// インゲーム中の残り時間を制御する
/// </summary>
public class InGameTimer : MonoBehaviour
{
    ReactiveProperty<int> _count = new ReactiveProperty<int>();

    public IReadOnlyReactiveProperty<int> Count { get => _count; }

    int _penalty;

    void Start()
    {
        //_ = Timer(5, this.GetCancellationTokenOnDestroy());
    }

    /// <summary>
    /// 1秒ごとに時間が減っていくタイマー、カウントが0になると処理を抜ける
    /// </summary>
    public async UniTask Timer(int max, CancellationToken token)
    {
        _count.Value = max;

        await Observable.Timer(TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(1))
                        .Select(count => 
                        {
                            token.ThrowIfCancellationRequested();

                            // _count.Valueは0より小さくなることがあるので購読する側で丸めこむこと
                            // 最大値 - 現在値 - 爆弾にぶつかったペナルティ
                            int time = (int)(max - count);
                            _count.Value = time - _penalty;

                            return _count.Value;
                        })
                        .TakeWhile(i => i > 0);
    }

    /// <summary>爆弾が爆発したときに残り時間を減らす</summary>
    public void SetPenalty(int value)
    {
        _penalty += value;
    }
}
