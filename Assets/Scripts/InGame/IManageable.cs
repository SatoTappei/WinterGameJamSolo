using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �Q�[���J�n���ƃQ�[���I�[�o�[���ɂ��ꂼ����s����鏈���̃C���^�[�t�F�[�X
/// </summary>
public interface IManageable
{
    /// <summary>�Q�[���J�n���ɌĂ΂�鏈��</summary>
    public void Boot();
    /// <summary>�Q�[���I�[�o�[���ɌĂ΂�鏈��</summary>
    public void Stop();
}
