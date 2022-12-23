using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleController : MonoBehaviour
{
    /// <summary>
    /// �V�[����ɔz�u�����IManageable�C���^�[�t�F�[�X�����������R���|�[�l���g�̐��ɉ�����
    /// ���X�g�̃L���p�V�e�B��ݒ肵�Ă���
    /// </summary>
    const int ManageableListCap = 2;
    List<IManageable> _manageableList = new List<IManageable>(ManageableListCap);

    void Start()
    {
        // MonoBehaviour���p�������N���X����������
        // IManageable�ɃL���X�g�o������Ǘ����邽�߂Ƀ��X�g�ɒǉ�����
        foreach (MonoBehaviour c in FindObjectsOfType<MonoBehaviour>())
        {
            IManageable iManageable = c as IManageable;
            if (c as IManageable != null)
            {
                _manageableList.Add(iManageable);

                // �I�u�W�F�N�g�̏������J�n����
                iManageable.Boot();
            }
        }
    }

    void Update()
    {
        // ���X�g���̗v�f�S����Stop()���Ă�ł�邱�ƂŎ~�߂邱�Ƃ��o����B
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _manageableList.ForEach(im => im.Stop());
        }
    }
}
