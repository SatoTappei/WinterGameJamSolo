using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

/// <summary>
/// �C���Q�[���̗���𐧌䂷��R���|�[�l���g
/// </summary>
public class InGameStream : MonoBehaviour
{
    [SerializeField] InGameStartEffect _inGameStartEffect;
    [SerializeField] InGameOverEffect _inGameOverEffect;

    async UniTaskVoid Start()
    {
        return;

        // �X�^�[�g���o
        await _inGameStartEffect.EffectAsync();
        // �Q�[���X�^�[�g
        // �Q�[����
        // �Q�[���I��
        await _inGameOverEffect.EffectAsync();
        // ���U���g�V�[���ֈȍ~
        FadeSystem.Instance?.FadeOut("Result");
    }

    void Update()
    {
        
    }
}
