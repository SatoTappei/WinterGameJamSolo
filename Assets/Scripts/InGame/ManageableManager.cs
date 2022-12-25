using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// IManageable�C���^�[�t�F�[�X�����������R���|�[�l���g���Ǘ�����N���X
/// </summary>
public class ManageableManager
{
    List<IManageable> _manageableList;

    public ManageableManager(int capacity)
    {
        // �V�[����ɔz�u�����IManageable�C���^�[�t�F�[�X�����������R���|�[�l���g�̐��ɉ�����
        // ���X�g�̃L���p�V�e�B��ݒ肵�Ă���
        _manageableList = new List<IManageable>(capacity);
    }

    public void Start()
    {
        // �ėp�I�����������d�������Ȃ̂ŕۗ�
        // MonoBehaviour���p�������N���X���������AIManageable�ɃL���X�g�o������Ǘ����邽�߂Ƀ��X�g�ɒǉ�����
        //foreach (Component c in Object.FindObjectsOfType<Component>())
        //{
        //    IManageable iManageable = c as IManageable;
        //    if (c as IManageable != null)
        //    {
        //        _manageableList.Add(iManageable);

        //        // �I�u�W�F�N�g�̏������J�n����
        //        iManageable.Boot();
        //    }
        //}

        // �C���^�[�t�F�[�X�����������R���|�[�l���g���蓮�Ŏ擾����
        // ����I�����������̂ق����y���̂ō��̂Ƃ��낱����g��
        // �擾&Boot()���ĂԂ����Ȃ̂ő��̃��\�b�h��R���|�[�l���g�Ɋ����Ă��Ȃ�
        Generator generator = Object.FindObjectOfType<Generator>();
        HorizontalController horiCon = Object.FindObjectOfType<HorizontalController>();
        generator.Boot();
        horiCon.Boot();
        _manageableList.Add(generator);
        _manageableList.Add(horiCon);
    }

    public void Stop()
    {
        _manageableList.ForEach(im => im.Stop());
    }
}
