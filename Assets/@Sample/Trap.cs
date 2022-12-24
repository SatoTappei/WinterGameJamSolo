using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

/// <summary>
/// トリガーとなるオブジェクトが通過したときに
/// お邪魔キャラを生成するコンポーネント
/// </summary>
public class Trap : MonoBehaviour
{
    /// <summary>良い感じに画面に収まるようにオフセットを付ける</summary>
    readonly float OffsetPosY = 1.5f;

    [SerializeField] Transform _trigger;
    [SerializeField] GameObject _charaPrefab;

    async UniTaskVoid Start()
    {
        // トリガーとなるオブジェクトがこのオブジェクトより高い位置に来るまで待つ
        await UniTask.WaitUntil(() => _trigger.position.y > transform.position.y, 
                                PlayerLoopTiming.Update, this.GetCancellationTokenOnDestroy());

        Vector3 pos = transform.position;
        pos.y += OffsetPosY;

        Instantiate(_charaPrefab, pos, Quaternion.identity);
    }
}
