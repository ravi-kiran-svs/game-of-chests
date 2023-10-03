using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChestDialog : MonoBehaviour {

    UnlockedState currentChest;

    public void Open(int gems, UnlockedState chest) {
        currentChest = chest;
        gameObject.SetActive(true);
    }

    public void OnCollectGems() {
        currentChest.CollectGems();
        OnClose();
    }

    public void OnClose() {
        currentChest = null;
        gameObject.SetActive(false);
    }
}
