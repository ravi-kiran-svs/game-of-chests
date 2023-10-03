using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController {

    // part of model class
    [SerializeField] public int gemsToUnlock = 5;
    [SerializeField] public int gemsReward = 10;

    public event Action OnCollected;

    // public ChestModel chestModel;
    private ChestView chestView;
    public ChestView View { get { return chestView; } }

    // States - LOCKED , UNLOCKING , UNLOCKED
    public ChestState lockedState, unlockingState, unlockedState, collectedState;
    private ChestState currentState;

    public ChestController(ChestView view) {
        // chestModel = model;
        chestView = view;
        view.controller = this;

        //create all the states lol
        lockedState = new LockedState(this);
        //unlockingState = new UnlockingState(this);
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

    public void CloseChest() {
        Debug.Log("CLOSING");
        OnCollected?.Invoke();
        GameObject.Destroy(chestView.gameObject);
    }
}
