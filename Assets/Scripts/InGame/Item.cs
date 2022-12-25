using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MessagePipe;
using VContainer;
using System;

/// <summary>
/// ��ނ𐧌䂷��R���|�[�l���g
/// </summary>
public class Item : MonoBehaviour
{
    [Inject] ISubscriber<ExploData> _subscriber;
    [Header("������̐F")]
    [SerializeField] Color32 _exploColor;

    IDisposable _disposable;

    void Start()
    {
        // �w�ǂ������b�Z�[�W���甚�e�Ƃ̋����𔻒肵�ĉ摜�̐F��ς���
        _disposable = _subscriber.Subscribe(exploData =>
                                 {
                                     float dist = Vector3.Distance(transform.position, exploData.Trans.position);
                                     
                                     if (dist < exploData.Distance)
                                         GetComponent<SpriteRenderer>().color = _exploColor;
                                 });
    }

    void OnDestroy()
    {
        _disposable.Dispose();
    }
}
