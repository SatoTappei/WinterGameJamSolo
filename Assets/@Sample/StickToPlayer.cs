using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

/// <summary>
/// Playerタグが付いたオブジェクトにくっ付くようになるコンポーネント
/// </summary>
public class StickToPlayer : MonoBehaviour
{
    readonly string HitTag = "Player";

    [SerializeField] Rigidbody2D _rb;

    void Start()
    {
        this.OnTriggerEnter2DAsObservable()
            .Where(c => c.gameObject.CompareTag(HitTag))
            .Subscribe(c => 
            {
                // 子オブジェクトにすることでくっ付いた表現をする
                transform.SetParent(c.transform);

                _rb.isKinematic = true;
                _rb.velocity = Vector2.zero;
                _rb.angularVelocity = 0;
            });
    }
}
