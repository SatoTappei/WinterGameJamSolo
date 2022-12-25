using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// �{�^���ɃV�[���J�ڂ̏�����o�^����R���|�[�l���g
/// </summary>
public class LoadSceneButtonRegister : MonoBehaviour
{
    [SerializeField] Button _button;
    [SerializeField] string _sceneName;
    [SerializeField] string _seName;

    void Start()
    {
        _button.onClick.AddListener(() => 
        {
            _button.interactable = false;

            // �{�^���̃N���b�N�����Đ�����BGM���t�F�[�h�A�E�g������
            SoundManager.Instance?.PlaySE(_seName);
            SoundManager.Instance?.FadeOutBGM();

            // ������I������^�C�~���O�Ńt�F�[�h�A�E�g���J�n����
            DOVirtual.DelayedCall(0.5f, () =>
            {
                FadeSystem.Instance?.FadeOut(_sceneName);
            });
        });
    }
}
