using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MessagePipe;
using VContainer;
using System;

/// <summary>
/// 具材を制御するコンポーネント
/// </summary>
public class Item : MonoBehaviour
{
    [Inject] ISubscriber<ExploData> _subscriber;
    [Header("爆発後の色")]
    [SerializeField] Color32 _exploColor;

    IDisposable _disposable;

    void Start()
    {
        // 購読したメッセージから爆弾との距離を判定して画像の色を変える
        _disposable = _subscriber.Subscribe(exploData =>
                                 {
                                     float dist = Vector3.Distance(transform.position, exploData.Trans.position);
                                     
                                     if (dist < exploData.Distance)
                                         GetComponent<SpriteRenderer>().color = _exploColor;
                                 });
    }

    void OnDestroy()
    {
        _disposable.Dispose();
    }
}
