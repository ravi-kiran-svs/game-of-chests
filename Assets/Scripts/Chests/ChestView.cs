using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestView : MonoBehaviour {

    public ChestController controller;

    [SerializeField] private GameObject unlockButton;
    [SerializeField] private GameObject openButton;
    [SerializeField] private GameObject openNowButton;

    private void Update() {
        controller.Update();
    }

    public void OnChestUnlock() {
        controller.UnlockChest();
    }

    public void OnChestOpen() {
        controller.OpenChest();
    }

    public void OnChestOpenNow() {
        controller.OpenChestNow();
    }

    // Locked -> Unlocked
    public void UnlockDirect() {
        unlockButton.SetActive(false);
        openButton.SetActive(true);
    }

    // Locked -> Unlocking
    public void Unlocking() {
        unlockButton.SetActive(false);
        openNowButton.SetActive(true);
    }

    // Unlocking -> Unlocked
    public void Unlock() {
        openNowButton.SetActive(false);
        openButton.SetActive(true);
    }

}
