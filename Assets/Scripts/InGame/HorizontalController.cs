using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;

/// <summary>
/// ���������ɂ̂ݓ��������Ƃ̏o����R���g���[���[
/// </summary>
public class HorizontalController : MonoBehaviour, IManageable
{
    [SerializeField] Rigidbody2D _rb;
    [Header("�v���C���[�̈ړ����x")]
    [SerializeField] int _speed;

    IDisposable _disposable;

    public void Boot()
    {
        // ���������̓��͂ɉ����ăv���C���[���ړ�������
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
