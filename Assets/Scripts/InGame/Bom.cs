using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using DG.Tweening;
using MessagePipe;
using VContainer;

/// <summary>
/// 爆発した際に発行されるメッセージのデータ
/// </summary>
public struct ExploData
{
    Transform trans;
    float distance;

    public ExploData(Transform t, float d)
    {
        trans = t;
        distance = d;
    }

    public Transform Trans { get => trans; }
    /// <summary>爆風が届いたかどうかを判定するための距離データ</summary>
    public float Distance { get => distance; }
}

/// <summary>
/// 爆弾が爆発する処理のコンポーネント
/// </summary>
public class Bom : MonoBehaviour
{
    readonly string HitTag = Utility.PlayerTag;

    [Inject] IPublisher<ExploData> _publisher;

    Tween _tween;

    void Start()
    {
        this.OnTriggerEnter2DAsObservable()
            .Where(c => c.gameObject.CompareTag(HitTag))
            .Take(1)
            .Subscribe(c =>
            {
                _tween = DOVirtual.DelayedCall(0.5f, () =>
                         {
                             SoundManager.Instance?.PlaySE("SE_爆発");

                             // 爆発した事を伝えるメッセージを発行する
                             // 具材とプール側はこれを購読する
                             _publisher.Publish(new ExploData(transform, 5));
                         });
            });
    }

    void OnDestroy()
    {
        _tween?.Kill();
    }
}
