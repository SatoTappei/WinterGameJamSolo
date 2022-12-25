using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;

/// <summary>
/// ��ނ̍폜���C���Ɉ�������������폜�����悤�ɂȂ�R���|�[�l���g
/// StickToPlayer�R���|�[�l���g�ƈꏏ�Ɏg���O��
/// </summary>
[RequireComponent(typeof(StickToPlayer))]
public class HitDestroyBorder : MonoBehaviour
{
    void Start()
    {
        // �폜���C���Ɉ�������������I�u�W�F�N�g���폜�����悤�ɂ���
        IDisposable disposable = this.OnTriggerEnter2DAsObservable()
                                     .Where(c => c.gameObject.CompareTag("Finish"))
                                     .Subscribe(c => Destroy(gameObject));

        // �e���ύX���ꂽ = �v���C���[�ɂ����t�����Ƃ݂Ȃ��ď�L�̏�����Dispose����
        this.OnBeforeTransformParentChangedAsObservable()
            .Subscribe(_ => disposable.Dispose());
    }
}
