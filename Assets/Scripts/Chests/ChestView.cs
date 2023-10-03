using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestView : MonoBehaviour {

    public event Action OnCollected;

    public void OnChestUnlock() {
        CurrencyService.Instance.AddCoins(100);

        CollectChest();
    }

    private void CollectChest() {
        OnCollected?.Invoke();
        Destroy(gameObject);
    }

}
