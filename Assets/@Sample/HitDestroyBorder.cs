using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;

/// <summary>
/// 具材の削除ラインに引っかかったら削除されるようになるコンポーネント
/// StickToPlayerコンポーネントと一緒に使う前提
/// </summary>
[RequireComponent(typeof(StickToPlayer))]
public class HitDestroyBorder : MonoBehaviour
{
    void Start()
    {
        // 削除ラインに引っかかったらオブジェクトが削除されるようにする
        IDisposable disposable = this.OnTriggerEnter2DAsObservable()
                                     .Where(c => c.gameObject.CompareTag("Finish"))
                                     .Subscribe(c => Destroy(gameObject));

        // 親が変更された = プレイヤーにくっ付いたとみなして上記の処理をDisposeする
        this.OnBeforeTransformParentChangedAsObservable()
            .Subscribe(_ => disposable.Dispose());
    }
}
