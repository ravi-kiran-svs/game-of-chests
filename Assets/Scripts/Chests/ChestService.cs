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
            ChestView chest = Instantiate(ChestPrefab, transform);
            slot.AddChest(chest);
        }
    }

    public void ShowUnlockChestDialog(int time, int gems, ChestView chest) {
        unlockChestDialog.Open(time, gems, chest);
    }

    public void ShowOpenChestDialog(int gems, ChestView chest) {
        openChestDialog.Open(gems, chest);
    }

}
