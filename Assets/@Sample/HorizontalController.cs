using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;

/// <summary>
/// 水平方向にのみ動かすことの出来るコントローラー
/// </summary>
public class HorizontalController : MonoBehaviour, IManageable
{
    [SerializeField] Rigidbody2D _rb;
    [Header("プレイヤーの移動速度")]
    [SerializeField] int _speed;

    IDisposable _disposable;

    public void Boot()
    {
        // 水平方向の入力に応じてプレイヤーを移動させる
        Vector3 input;
        _disposable = this.UpdateAsObservable()
                          .Select(_ => input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0).normalized)
                          .BatchFrame(0, FrameCountType.FixedUpdate)
                          .Subscribe(vec3List =>
                          {
                              Vector3 velo = vec3List[0] * _speed;
                              velo.y = _rb.velocity.y;
                              _rb.velocity = velo;
                          });
    }

    public void Stop()
    {
        _disposable.Dispose();
    }
}
