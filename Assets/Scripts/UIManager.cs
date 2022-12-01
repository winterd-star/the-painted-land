using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text coinText;
    public TMP_Text lifeText;
    private static UIManager _state;
    public static UIManager State
    {
        get
        {
            if (_state == null)
            {
                Debug.LogError("Game is uninitialized?");
            }
            return _state;
        }
    }

    void Awake()
    {
        _state = this;
    }

    public void UpdateCoinText(int _coin)
    {
        coinText.text = "Coins: " + _coin;
    }
    public void UpdateLifeText(int _life)
    {
        lifeText.text = "Lives: " + _life;
    }
}
