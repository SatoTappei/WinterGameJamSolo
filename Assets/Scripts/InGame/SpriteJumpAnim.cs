using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// ���O�̉摜���W�����v������A�j���[�V����
/// </summary>
public class SpriteJumpAnim : MonoBehaviour
{
    void Start()
    {
        transform.DOJump(new Vector3(0, -0.5f, 0), 1.0f, 1, 0.5f)
                 .SetLoops(-1, LoopType.Restart)
                 .SetLink(gameObject);
    }
}
