using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using MessagePipe;
using VContainer;

/// <summary>
/// くっ付いた際に発行されるメッセージのデータ
/// </summary>
public struct StickData
{
    Transform trans;

    public StickData(Transform t)
    {
        trans = t;
    }

    public Transform Trans { get => trans; }
}

/// <summary>
/// Playerタグが付いたオブジェクトにくっ付くようになるコンポーネント
/// </summary>
public class StickToPlayer : MonoBehaviour
{
    readonly string HitTag = Utility.PlayerTag;

    [Inject] IPublisher<StickData> _publisher;
    [SerializeField] Rigidbody2D _rb;

    void Start()
    {
        this.OnTriggerEnter2DAsObservable()
            .Where(c => c.gameObject.CompareTag(HitTag))
            .Take(1)
            .Subscribe(c => 
            {
                // 子オブジェクトにすることでくっ付いた表現をする
                transform.SetParent(c.transform);

                _rb.isKinematic = true;
                _rb.velocity = Vector2.zero;
                _rb.angularVelocity = 0;

                // くっ付いた座標をデータとしてメッセージを発行する
                _publisher.Publish(new StickData(transform));

                SoundManager.Instance?.PlaySE("SE_具材接着");
            }).AddTo(this);
    }
}
