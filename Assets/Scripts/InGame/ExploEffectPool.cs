using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using MessagePipe;
using VContainer;

/// <summary>
/// 爆弾が爆発したときのエフェクトのオブジェクトプール
/// </summary>
public class ExploEffectPool : MonoBehaviour
{
    [Inject] ISubscriber<ExploData> _subscriber;
    [SerializeField] ExploEffect _effectPrefab;
    [SerializeField] int _size;

    Stack<ExploEffect> _pool;

    void Awake()
    {
        _pool = new Stack<ExploEffect>();

        for (int i = 0; i < _size; i++)
        {
            ExploEffect ee = Instantiate(_effectPrefab);
            // 生成時にこのクラスへの参照を渡し、オブジェクト側からプールに戻るようにする
            ee.Init(this);

            _pool.Push(ee);
        }
    }

    void Start()
    {
        // プールが残っていれば購読したメッセージのデータの座標を渡して
        // オブジェクトをアクティブにする
        _subscriber.AsObservable()
            .Where(_ => _pool.Count > 0)       
            .Subscribe(exploData =>
            {
                ExploEffect ee = _pool.Pop();
                ee.Active(exploData.Trans.position);
            }).AddTo(this);
    }

    /// <summary>プールにオブジェクトを戻す</summary>
    public void ReturnPool(ExploEffect ee) => _pool.Push(ee);
}
