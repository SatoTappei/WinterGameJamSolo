using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Cinemachine;

/// <summary>
/// �w�肵���I�u�W�F�N�g�̑S�̂��f��悤��Cinemachine�𑀍삷��R���|�[�l���g
/// </summary>
public class ResultVcamController : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera _vcam;

    void Start()
    {
        // �S�̂��f�������I�u�W�F�N�g���K�w���̕����܂߂đS�Ď擾���Ĕz��Ɋi�[����
        GameObject go = GameObject.FindGameObjectWithTag(Utility.PlayerTag);
        Transform[] all = go.transform.GetComponentsInChildren<Transform>();

        // �K�w���̂��̂�S�����������̂ŁA�S�̂𒲂ׂ�ɂ�
        // ��x�z��Ɋi�[�������̂𑖍����Ȃ��Ă͂Ȃ�Ȃ�
        // ��ԍ����ʒu�ɂ���I�u�W�F�N�g��Y���W���擾
        float y = 0;
        foreach (Transform t in all)
            y = Mathf.Max(y, t.position.y);

        // �J�����̃T�C�Y��ǂ������ɒ���
        _vcam.m_Lens.OrthographicSize = (y / 2) + 2;
        // �S�̂��f��悤�ɃJ������Follow����I�u�W�F�N�g�̈ʒu��^�񒆂Ɏ����Ă���
        GameObject follower = new GameObject();
        follower.transform.position = Vector3.up * (y / 2);

        _vcam.Follow = follower.transform;
    }
}
