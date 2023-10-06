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
    [SerializeField] private Button queueButton;

    LockedState currentChest;

    public void Open(int time, int gems, bool showTimer, bool showGems, bool showQueue, LockedState chest) {
        currentChest = chest;

        timeText.text = time.ToString();
        gemsText.text = gems.ToString();
        gemsButton.interactable = showGems;

        if (showTimer) {
            timerButton.gameObject.SetActive(true);
            timerButton.interactable = true;
            queueButton.gameObject.SetActive(false);

        } else {
            timerButton.gameObject.SetActive(false);
            queueButton.gameObject.SetActive(true);

            queueButton.interactable = showQueue;
        }

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

    public void OnAddToQueue() {
        currentChest.AddToQueue();
        OnClose();
    }

    public void OnClose() {
        currentChest = null;
        gameObject.SetActive(false);
    }

}
