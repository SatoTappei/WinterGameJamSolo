using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �v���C���[�̈ʒu�������������̃o�[�̃R���|�[�l���g
/// </summary>
public class TranslucentBar : MonoBehaviour
{
    [SerializeField] Transform _target;

    void Update()
    {
        // �o�[�̑傫���̔����������炷
        Vector3 pos = _target.position;
        pos.y += 50;

        transform.position = pos;
    }
}
