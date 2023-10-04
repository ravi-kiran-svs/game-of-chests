using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnlockChestDialog : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI gemsText;
    [SerializeField] private Button timerButton;
    [SerializeField] private Button gemsButton;

    LockedState currentChest;

    public void Open(int time, int gems, bool showTimer, bool showGems, LockedState chest) {
        currentChest = chest;

        timeText.text = time.ToString();
        gemsText.text = gems.ToString();
        timerButton.interactable = showTimer;
        gemsButton.interactable = showGems;

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
