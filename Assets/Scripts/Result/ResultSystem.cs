using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ランダムで評価が表示されるシステムのコンポーネント
/// </summary>
public class ResultSystem : MonoBehaviour
{
    string[] titles = 
        { "ドせち",
          "おせち",
          "だいおうじょうおせち",
          "ばいおれんすおせち",
          "ぐろりあすおせち",
          "おんりーわんおせち",
          "ふぁんたすてぃっくおせち",
          "ざんしんおせち",
        };

    [SerializeField] Text _text;

    void Start()
    {
        // ランダムに称号を表示する
        int r = Random.Range(0, titles.Length);
        _text.text = titles[r];
    }
}
