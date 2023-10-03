using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockChestDialog : MonoBehaviour {

    ChestController currentChest;

    public void Open(int time, int gems, ChestController chest) {
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
