using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestService : MonoSingleton<ChestService> {

    [SerializeField] private ChestView ChestPrefab;

    [SerializeField] private GameObject slotsFullDialog;
    [SerializeField] private UnlockChestDialog unlockChestDialog;
    [SerializeField] private OpenChestDialog openChestDialog;

    private List<ChestController> controllers = new List<ChestController>();

    public void GenerateChest() {
        Slot slot = SlotService.Instance.GetFreeSlot();

        if (slot == null) {
            slotsFullDialog.SetActive(true);

        } else {
            ChestView chestView = Instantiate(ChestPrefab, transform);
            ChestController chest = new ChestController(chestView);
            slot.AddChest(chest);

            controllers.Add(chest);
            chest.OnCollected += OnChestClosed;
        }
    }

    public void ShowUnlockChestDialog(int time, int gems, bool showTimer, bool showGems, LockedState chest) {
        unlockChestDialog.Open(time, gems, showTimer, showGems, chest);
    }

    public void ShowOpenChestDialog(int gems, UnlockedState chest) {
        openChestDialog.Open(gems, chest);
    }

    public bool IsAnyTimerRunning() {
        foreach (ChestController chest in controllers) {
            if (chest.CurrentState == chest.unlockingState) {
                return true;
            }
        }
        return false;
    }

    private void OnChestClosed(ChestController chest) {
        controllers.Remove(chest);
    }

}
