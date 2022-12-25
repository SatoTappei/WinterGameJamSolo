using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// ���ז��L�����𐧌䂷��R���|�[�l���g
/// </summary>
public class TrapCharacter : MonoBehaviour
{
    /// <summary>���B������������ʊO��X���W</summary>
    readonly float _toEscapePosX = -20;

    [Header("�o�ꎞ�ɖ炷SE")]
    [SerializeField] string _toCenterSeName;
    [Header("��ʒ����ɗ���܂łɂ����鎞��")]
    [SerializeField] float _toCenterDuration;
    [Header("��ʒ����ɂƂǂ܂鎞��")]
    [SerializeField] float _waitScreenCenter;
    [Header("��ʒ����Ɉړ�����ۂ̃C�[�W���O")]
    [SerializeField] Ease _toCenterEase;
    [Space(10)]
    [Header("��ʊO�ɏ����鎞�ɖ炷SE")]
    [SerializeField] string _toEscapeSeName;
    [Header("��ʊO�ɏ�����܂łɂ����鎞��")]
    [SerializeField] float _toEscapeDuration;
    [Header("��ʊO�Ɉړ�����ۂ̃C�[�W���O")]
    [SerializeField] Ease _toEscapeEase;

    Sequence _seq;

    void Start()
    {
        SoundManager.Instance?.PlaySE(_toCenterSeName);

        _seq = DOTween.Sequence()
              .Append(transform.DOMoveX(0, _toCenterDuration).SetEase(_toCenterEase))
              .Append(transform.DOMoveX(_toEscapePosX, _toEscapeDuration).SetEase(_toEscapeEase).SetDelay(_waitScreenCenter))
              .InsertCallback(_toCenterDuration + _waitScreenCenter, () => SoundManager.Instance?.PlaySE(_toEscapeSeName))
              .AppendCallback(() => Destroy(gameObject));
    }

    void OnDestroy()
    {
        _seq?.Kill();
    }
}
