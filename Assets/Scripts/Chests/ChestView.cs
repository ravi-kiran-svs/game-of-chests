using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestView : MonoBehaviour {

    public event Action OnClose;

    public void OnChestOpen() {
        CurrencyService.Instance.AddCoins(100);

        CloseChest();
    }

    private void CloseChest() {
        OnClose?.Invoke();
        Destroy(gameObject);
    }

}
