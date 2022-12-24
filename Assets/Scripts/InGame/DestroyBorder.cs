using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

/// <summary>
/// �g���K�[�Ɉ�������������ނ��폜����
/// ���g�p
/// </summary>
public class DestroyBorder : MonoBehaviour
{
    void Start()
    {
        this.OnTriggerEnter2DAsObservable()
            .Where(c => c.gameObject.CompareTag(Utility.PlayerTag))
            .Subscribe(c =>
            {

                Destroy(c.gameObject);
            });
    }
}