using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController {

    public event Action<ChestController> OnCollected;
    public event Action<ChestController, ChestState> OnEnterState;
    public event Action<ChestController, ChestState> OnExitState;

    private ChestModel chestModel;
    private ChestView chestView;

    private int gemsReward;
    public int GemsReward { get { return gemsReward; } }
    private int coinReward;
    public int CoinReward { get { return coinReward; } }

    public ChestState lockedState, unlockingState, unlockedState, collectedState, queuedState;
    private ChestState currentState;
    public ChestState CurrentState { get { return currentState; } }

    public ChestController(ChestModel model, ChestView view) {
        chestModel = model;
        chestView = view;
        view.controller = this;

        gemsReward = model.gemsRewardRange.Value;
        coinReward = model.coinRewardRange.Value;

        lockedState = new LockedState(this, model, view);
        unlockingState = new UnlockingState(this, model, view);
        unlockedState = new UnlockedState(this, model, view);
        collectedState = new CollectedState(this, model, view);
        queuedState = new QueuedState(this, model, view);

        ChangeState(lockedState);
    }

    public void Update() {
        currentState.Update();
    }

    public void ChangeState(ChestState newState) {
        if (currentState != null) {
            currentState.OnExit();
            OnExitState?.Invoke(this, currentState);
        }

        currentState = newState;
        currentState.OnEnter();
        OnEnterState?.Invoke(this, currentState);
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
