using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using DG.Tweening;
using MessagePipe;
using VContainer;

/// <summary>
/// ���������ۂɔ��s����郁�b�Z�[�W�̃f�[�^
/// </summary>
public struct ExploData
{
    float distance;

    public ExploData(float d)
    {
        distance = d;
    }

    /// <summary>�������͂������ǂ����𔻒肷�邽�߂̋����f�[�^</summary>
    public float Distance { get => distance; }
}

/// <summary>
/// ���e���������鏈���̃R���|�[�l���g
/// </summary>
public class Bom : MonoBehaviour
{
    readonly string HitTag = Utility.PlayerTag;

    [Inject] IPublisher<ExploData> _publisher;

    void Start()
    {
        this.OnTriggerEnter2DAsObservable()
            .Where(c => c.gameObject.CompareTag(HitTag))
            .Take(1)
            .Subscribe(c =>
            {
                DOVirtual.DelayedCall(0.5f, () =>
                {
                    SoundManager.Instance?.PlaySE("SE_����");

                    // ������������`���郁�b�Z�[�W�𔭍s����
                    // ��ޑ��͂�����w�ǂ���
                    _publisher.Publish(new ExploData(5));
                });
            }).AddTo(this);
    }
}
