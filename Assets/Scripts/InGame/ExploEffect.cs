using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// ���e�����������Ƃ��̃G�t�F�N�g�𐧌䂷��R���|�[�l���g
/// ��p�̃I�u�W�F�N�g�v�[���Ƀv�[�����O����Ă���
/// </summary>
public class ExploEffect : MonoBehaviour
{
    Tween _tween;

    [SerializeField] AnimationClip _clip;

    public ExploEffectPool Pool { get; set; }

    /// <summary>�������Ƀv�[��������Ă΂�鏉��������</summary>
    public void Init(ExploEffectPool pool)
    {
        Pool = pool;
        gameObject.SetActive(false);
    }

    /// <summary>�\������A�A�j���[�V�����Đ���ɏ�����</summary>
    public void Active(Vector3 pos)
    {
        gameObject.SetActive(true);
        transform.position = pos;

        _tween = DOVirtual.DelayedCall(_clip.length, () => 
        {
            Pool.ReturnPool(this);
            gameObject.SetActive(false);
        });
    }

    void OnDestroy()
    {
        _tween?.Kill();
    }
}
