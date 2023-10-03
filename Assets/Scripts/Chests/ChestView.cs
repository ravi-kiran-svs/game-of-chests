using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestView : MonoBehaviour {

    [SerializeField] private int gemsToUnlock = 5;
    [SerializeField] private int gemsReward = 10;

    public event Action OnCollected;

    [SerializeField] private GameObject unlockButton;
    [SerializeField] private GameObject openButton;

    public void OnChestUnlock() {
        ChestService.Instance.ShowUnlockChestDialog(0, 0, this);
    }

    public void StartTimer() {
        // coroutine shit - in state machine
    }

    public void UseGems() {
        CurrencyService.Instance.MinusGems(gemsToUnlock);

        Unlock();
    }

    private void Unlock() {
        unlockButton.SetActive(false);
        openButton.SetActive(true);
    }

    public void OnChestOpen() {
        ChestService.Instance.ShowOpenChestDialog(0, this);
    }

    public void CollectGems() {
        CurrencyService.Instance.AddGems(gemsReward);
        OnCollected?.Invoke();
        Destroy(gameObject);
    }

}
