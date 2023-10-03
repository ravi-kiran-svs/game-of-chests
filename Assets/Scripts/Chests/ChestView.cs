using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestView : MonoBehaviour {

    public ChestController controller;

    [SerializeField] private GameObject unlockButton;
    [SerializeField] private GameObject openButton;

    private void Update() {
        controller.Update();
    }

    public void OnChestUnlock() {
        controller.UnlockChest();
    }

    public void OnChestOpen() {
        controller.OpenChest();
    }

    public void Unlock() {
        unlockButton.SetActive(false);
        openButton.SetActive(true);
    }

}
