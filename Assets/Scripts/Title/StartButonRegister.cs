using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// �X�^�[�g�{�^���ɏ�����o�^����R���|�[�l���g
/// </summary>
public class StartButonRegister : MonoBehaviour
{
    [SerializeField] Button _startButton;

    void Start()
    {
        _startButton.onClick.AddListener(() => 
        {
            // �{�^���̃N���b�N�����Đ�����BGM���t�F�[�h�A�E�g������
            SoundManager.Instance?.PlaySE("�{�^���N���b�NSE");
            SoundManager.Instance?.FadeOutBGM();

            // ������I������^�C�~���O�Ńt�F�[�h�A�E�g���J�n����
            DOVirtual.DelayedCall(0.5f, () =>
            {
                FadeSystem.Instance?.FadeOut("InGame");
            });
        });
    }
}
