using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencyService : MonoSingleton<CurrencyService> {

    private int coins = 0;
    private int gems = 0;

    public int Coins { get { return coins; } }
    public int Gems { get { return gems; } }

    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private TextMeshProUGUI gemsText;

    public void AddGemsAndCoins(int g, int c) {
        AddCoins(c);
        AddGems(g);
    }

    public void AddCoins(int c) {
        coins += c;
        coinsText.text = coins.ToString();
    }

    public void AddGems(int g) {
        gems += g;
        gemsText.text = gems.ToString();
    }

    public void MinusCoins(int c) {
        coins -= c;
        coinsText.text = coins.ToString();
    }

    public void MinusGems(int g) {
        gems -= g;
        gemsText.text = gems.ToString();
    }

}
