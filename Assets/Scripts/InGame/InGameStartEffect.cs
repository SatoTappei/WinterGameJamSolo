using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Cysharp.Threading.Tasks;
using System;

/// <summary>
/// �Q�[���X�^�[�g���̉��o���s���R���|�[�l���g
/// </summary>
public class InGameStartEffect : MonoBehaviour
{
    /// <summary>���݂̃J�E���g�őҋ@���鎞��</summary>
    readonly float Wait = 1;

    [SerializeField] Text _text;

    void Awake()
    {
        _text.text = "";
    }

    /// <summary>
    /// �J�E���g�_�E�����ăX�^�[�g�̕\�������鉉�o
    /// </summary>
    public async UniTask EffectAsync()
    {
        string[] strs = { "����", "��", "����" };

        for (int i = 0; i < strs.Length; i++)
        {
            _text.text = strs[i];
            await UniTask.Delay(TimeSpan.FromSeconds(Wait));
        }

        _text.text = "�͂��߁I";
        await UniTask.Delay(TimeSpan.FromSeconds(Wait));
        
        _text.text = "";
    }
}