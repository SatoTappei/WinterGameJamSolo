using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲームマネージャー
/// Singleton,DDOL
/// </summary>
public class GameManager : MonoBehaviour
{
    static GameManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            Application.targetFrameRate = 60;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
