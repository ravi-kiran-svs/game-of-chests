using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController {

    // part of model class
    [SerializeField] private int gemsToUnlock = 5;
    [SerializeField] private int gemsReward = 10;

    // public ChestModel chestModel;
    private ChestView chestView;
    public ChestView View { get { return chestView; } }

    public ChestController(ChestView view) {
        // chestModel = model;
        chestView = view;
        view.controller = this;
    }

    // States - LOCKED , UNLOCKING , UNLOCKED

    public event Action OnCollected;

    // LOCKED state
    public void UnlockChest() {
        ChestService.Instance.ShowUnlockChestDialog(0, 0, this);
    }

    // to UNLOCKING state
    public void StartTimer() {
        // coroutine shit - in state machine
    }

    // to UNLOCKED state
    public void UseGems() {
        CurrencyService.Instance.MinusGems(gemsToUnlock);

        // change state logic
        chestView.Unlock();
    }

    // UNLOCKED state
    public void OpenChest() {
        ChestService.Instance.ShowOpenChestDialog(0, this);
    }

    public void CollectGems() {
        CurrencyService.Instance.AddGems(gemsReward);
        OnCollected?.Invoke();
        GameObject.Destroy(chestView.gameObject);
    }
}
