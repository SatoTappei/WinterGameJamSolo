using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

/// <summary>
/// Player�^�O���t�����I�u�W�F�N�g�ɂ����t���悤�ɂȂ�R���|�[�l���g
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
                // �q�I�u�W�F�N�g�ɂ��邱�Ƃł����t�����\��������
                transform.SetParent(c.transform);

                _rb.isKinematic = true;
                _rb.velocity = Vector2.zero;
                _rb.angularVelocity = 0;
            });
    }
}
