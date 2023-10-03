using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestService : MonoSingleton<ChestService> {

    [SerializeField] private ChestView ChestPrefab;

    [SerializeField] private GameObject slotsFullDialog;
    [SerializeField] private UnlockChestDialog unlockChestDialog;
    [SerializeField] private OpenChestDialog openChestDialog;

    public void GenerateChest() {
        Slot slot = SlotService.Instance.GetFreeSlot();

        if (slot == null) {
            slotsFullDialog.SetActive(true);

        } else {
            ChestView chestView = Instantiate(ChestPrefab, transform);
            ChestController chest = new ChestController(chestView);
            slot.AddChest(chest);
        }
    }

    public void ShowUnlockChestDialog(int time, int gems, ChestController chest) {
        unlockChestDialog.Open(time, gems, chest);
    }

    public void ShowOpenChestDialog(int gems, ChestController chest) {
        openChestDialog.Open(gems, chest);
    }

}
