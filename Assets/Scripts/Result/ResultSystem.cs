using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �����_���ŕ]�����\�������V�X�e���̃R���|�[�l���g
/// </summary>
public class ResultSystem : MonoBehaviour
{
    string[] titles = 
        { "�h����",
          "������",
          "�����������傤������",
          "�΂�����񂷂�����",
          "����肠��������",
          "�����[��񂨂���",
          "�ӂ��񂽂��Ă�����������",
          "���񂵂񂨂���",
        };

    [SerializeField] Text _text;

    void Start()
    {
        // �����_���ɏ̍���\������
        int r = Random.Range(0, titles.Length);
        _text.text = titles[r];
    }
}
