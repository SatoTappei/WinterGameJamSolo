using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ���̃V�[���Ɏ����z���I�u�W�F�N�g�ɕt����R���|�[�l���g
/// </summary>
public class CarryOverToNextScene : MonoBehaviour
{
    [Header("���̃V�[���Ɏ����z���ۂɔ������R���|�[�l���g")]
    [SerializeField] MonoBehaviour[] _removeComponents;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneUnloaded += Reset;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void Reset(Scene _)
    {
        foreach (MonoBehaviour mb in _removeComponents)
        {
            Destroy(mb);
        }

        // ���̃V�[������J�ڂ�����폜�����
        SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetActiveScene());
        SceneManager.sceneUnloaded -= Reset;
    }
}
