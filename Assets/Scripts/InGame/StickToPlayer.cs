using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using MessagePipe;
using VContainer;

/// <summary>
/// �����t�����ۂɔ��s����郁�b�Z�[�W�̃f�[�^
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
/// Player�^�O���t�����I�u�W�F�N�g�ɂ����t���悤�ɂȂ�R���|�[�l���g
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
                // �q�I�u�W�F�N�g�ɂ��邱�Ƃł����t�����\��������
                transform.SetParent(c.transform);

                _rb.isKinematic = true;
                _rb.velocity = Vector2.zero;
                _rb.angularVelocity = 0;

                // �����t�������W���f�[�^�Ƃ��ă��b�Z�[�W�𔭍s����
                _publisher.Publish(new StickData(transform));

                SoundManager.Instance?.PlaySE("SE_��ސڒ�");
            }).AddTo(this);
    }
}
