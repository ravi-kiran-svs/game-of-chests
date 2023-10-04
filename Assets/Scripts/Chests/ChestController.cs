using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController {

    public event Action<ChestController> OnCollected;

    private ChestModel chestModel;
    public ChestModel Model { get { return chestModel; } }
    private ChestView chestView;
    public ChestView View { get { return chestView; } }

    private int gemsReward;
    public int GemsReward { get { return gemsReward; } }
    private int coinReward;
    public int CoinReward { get { return coinReward; } }

    public ChestState lockedState, unlockingState, unlockedState, collectedState;
    private ChestState currentState;
    public ChestState CurrentState { get { return currentState; } }

    public ChestController(ChestModel model, ChestView view) {
        chestModel = model;
        chestView = view;
        view.controller = this;

        gemsReward = model.gemsRewardRange.Value;
        coinReward = model.coinRewardRange.Value;

        lockedState = new LockedState(this);
        unlockingState = new UnlockingState(this);
        unlockedState = new UnlockedState(this);
        collectedState = new CollectedState(this);

        ChangeState(lockedState);
    }

    public void Update() {
        currentState.Update();
    }

    public void ChangeState(ChestState newState) {
        if (currentState != null) {
            currentState.OnExit();
        }
        currentState = newState;
        currentState.OnEnter();
    }

    public void UnlockChest() {
        if (currentState is LockedState) {
            ((LockedState)currentState).UnlockChest();
        }
    }

    public void OpenChest() {
        if (currentState is UnlockedState) {
            ((UnlockedState)currentState).OpenChest();
        }
    }

    public void OpenChestNow() {
        if (currentState is UnlockingState) {
            ((UnlockingState)currentState).OpenChestNow();
        }
    }

    public void CloseChest() {
        OnCollected?.Invoke(this);
        GameObject.Destroy(chestView.gameObject);
    }
}
