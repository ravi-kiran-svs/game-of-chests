using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockChestDialog : MonoBehaviour {

    LockedState currentChest;

    public void Open(int time, int gems, LockedState chest) {
        currentChest = chest;
        gameObject.SetActive(true);
    }

    public void OnStartTimer() {
        currentChest.StartTimer();
        OnClose();
    }

    public void OnUseGems() {
        currentChest.UseGems();
        OnClose();
    }

    public void OnClose() {
        currentChest = null;
        gameObject.SetActive(false);
    }

}
