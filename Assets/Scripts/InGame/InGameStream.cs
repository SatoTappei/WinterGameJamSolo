using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;

/// <summary>
/// �C���Q�[���̗���𐧌䂷��R���|�[�l���g
/// </summary>
public class InGameStream : MonoBehaviour
{
    [SerializeField] InGameStartEffect _inGameStartEffect;
    [SerializeField] InGameOverEffect _inGameOverEffect;
    [SerializeField] InGameBgmPlayer _inGameBgmPlayer;
    [SerializeField] InGameTimer _inGameTimer;
    [Header("�Q�[���̐�������")]
    [SerializeField] int _timeLimit;

    public int TimeLimit { get => _timeLimit; }

    async UniTaskVoid Start()
    {
        // �t�F�[�h���I���܂ł�����Ƒ҂�
        await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
        // BGM���Đ�����
        _inGameBgmPlayer?.Play();
        // �X�^�[�g���o
        await _inGameStartEffect.EffectAsync();
        // �Q�[���X�^�[�g
        ManageableManager manageableManager = new ManageableManager(2);
        manageableManager.Start();
        // �Q�[����
        await _inGameTimer.Timer(_timeLimit, this.GetCancellationTokenOnDestroy());
        // �Q�[���I��
        manageableManager.Stop();
        // ���߂��ׂ牉�o
        await _inGameOverEffect.EffectAsync();
        // ���U���g�V�[���ֈȍ~
        FadeSystem.Instance?.FadeOut("Result");
    }
}
