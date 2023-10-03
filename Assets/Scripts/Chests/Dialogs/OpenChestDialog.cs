using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OpenChestDialog : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI gemsText;

    UnlockedState currentChest;

    public void Open(int gems, UnlockedState chest) {
        currentChest = chest;
        gemsText.text = gems.ToString();
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
