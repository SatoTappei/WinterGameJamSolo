using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �C���Q�[����BGM���Đ�����R���|�[�l���g
/// </summary>
public class InGameBgmPlayer : MonoBehaviour
{
    void Start()
    {
        SoundManager.Instance?.PlayBGM("�C���Q�[��BGM");
    }
}
