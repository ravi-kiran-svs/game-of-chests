using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestView : MonoBehaviour {

    public void OnChestOpen() {
        CurrencyService.Instance.AddCoins(100);
    }

}
