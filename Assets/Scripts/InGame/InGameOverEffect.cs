using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

/// <summary>
/// �Q�[���I�[�o�[���̉��o���s���R���|�[�l���g
/// </summary>
public class InGameOverEffect : MonoBehaviour
{
    /// <summary>���݂̃J�E���g�őҋ@����t���[����</summary>
    readonly int WaitFrame = 60;

    [SerializeField] Text _text;

    void Awake()
    {
        _text.text = "";
    }

    /// <summary>
    /// �Q�[���I�[�o�[�̕\�������鉉�o
    /// </summary>
    public async UniTask EffectAsync()
    {
        _text.text = "����[���[�I";
        await UniTask.DelayFrame(WaitFrame);
    }
}
