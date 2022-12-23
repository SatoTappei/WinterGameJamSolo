using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;
using System.Threading.Tasks;
using MessagePipe;
using VContainer;
using VContainer.Unity;


/// <summary>
/// 具材オブジェクトを生成するコンポーネント
/// </summary>
public class Generator : MonoBehaviour, IManageable
{
    [Inject] IObjectResolver _resolver;

    [Header("生成箇所の左右の端")]
    [SerializeField] Transform _borderLeft;
    [SerializeField] Transform _borderRight;

    [SerializeField] GameObject[] _items;
    [SerializeField] GameObject _bom;
    [Header("ボムを生成する確率(%)")]
    [SerializeField] int _bomRate;
    [Header("生成する間隔")]
    [SerializeField] int _distance;

    CancellationTokenSource cts;

    async UniTaskVoid BootAsync(CancellationToken token)
    {
        while (true)
        {
            token.ThrowIfCancellationRequested();

            // 生成箇所をランダムで左右に振る
            float rx = Random.Range(_borderLeft.position.x, _borderRight.position.x);
            Vector3 pos = transform.position;
            pos.x += rx;

            // 具材とボムどちらを生成するかランダムで決定し
            // 具材の場合はどの具材を生成するかランダムで決定する
            GameObject go = Random.Range(0, 100) < _bomRate ? _bom : _items[Random.Range(0, _items.Length)];
            _resolver.Instantiate(go, pos, Quaternion.identity);

            // 生成ペースにランダム性を持たせる
            float rt = Random.Range(0.9f, 1.1f);
            await UniTask.Delay(System.TimeSpan.FromSeconds(_distance * rt));
        }
    }

    /// <summary>生成を開始する</summary>
    public void Boot() 
    {
        cts = new CancellationTokenSource();
        _ = BootAsync(cts.Token);
    }

    /// <summary>生成を止める</summary>
    public void Stop() => cts.Cancel();
}
