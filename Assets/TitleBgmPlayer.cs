using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �^�C�g���V�[����BGM���Đ�����R���|�[�l���g
/// </summary>
public class TitleBgmPlayer : MonoBehaviour
{
    void Start()
    {
        SoundManager.Instance?.PlayBGM("�^�C�g��BGM");
    }
}
