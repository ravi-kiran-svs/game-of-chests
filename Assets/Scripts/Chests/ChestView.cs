using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestView : MonoBehaviour {

    public ChestController controller;

    [SerializeField] private GameObject unlockButton;
    [SerializeField] private GameObject openButton;

    public void OnChestUnlock() {
        controller.UnlockChest();
    }

    public void Unlock() {
        unlockButton.SetActive(false);
        openButton.SetActive(true);
    }

    // UNLOCKED state
    public void OnChestOpen() {
        controller.OpenChest();
    }

}
