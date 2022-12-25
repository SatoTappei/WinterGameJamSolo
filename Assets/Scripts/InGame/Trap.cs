using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

/// <summary>
/// �g���K�[�ƂȂ�I�u�W�F�N�g���ʉ߂����Ƃ���
/// ���ז��L�����𐶐�����R���|�[�l���g
/// </summary>
public class Trap : MonoBehaviour
{
    /// <summary>�ǂ������ɉ�ʂɎ��܂�悤�ɃI�t�Z�b�g��t����</summary>
    readonly float OffsetPosY = 1.5f;

    [SerializeField] Transform _trigger;
    [SerializeField] GameObject _charaPrefab;

    async UniTaskVoid Start()
    {
        // �g���K�[�ƂȂ�I�u�W�F�N�g�����̃I�u�W�F�N�g��荂���ʒu�ɗ���܂ő҂�
        await UniTask.WaitUntil(() => _trigger.position.y > transform.position.y, 
                                PlayerLoopTiming.Update, this.GetCancellationTokenOnDestroy());

        Vector3 pos = transform.position;
        pos.y += OffsetPosY;

        Instantiate(_charaPrefab, pos, Quaternion.identity);
    }
}
