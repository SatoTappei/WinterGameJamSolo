using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// ���U���g��ʂ̉��o���s���R���|�[�l���g
/// </summary>
public class ResultEffectPlayer : MonoBehaviour
{
    void Start()
    {
        // �t�F�[�h���I���̂�҂���SE��炷
        DOVirtual.DelayedCall(0.5f, () => SoundManager.Instance?.PlaySE("�t�@���t�@�[��SE"))
                 .SetLink(gameObject);
    }
}
