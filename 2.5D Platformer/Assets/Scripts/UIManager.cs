﻿using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private Text _coins;

    [SerializeField]
    private Text _lives;
    void Start()
    {
        _coins.text = "Coins: 0";
    }

    public void UpdateCoinsText(int coins)
    {
        _coins.text = $"Coins: {coins}";
    }

    public void UpdateLivesText(int lives)
    {
        _lives.text = $"Lives: {lives}";
    }
}
