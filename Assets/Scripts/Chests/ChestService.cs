using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestService : MonoSingleton<ChestService> {

    [SerializeField] private ChestView ChestPrefab;

    [SerializeField] private GameObject slotsFullDialog;

    public void GenerateChest() {
        Slot slot = SlotService.Instance.GetFreeSlot();

        if (slot == null) {
            slotsFullDialog.SetActive(true);

        } else {
            ChestView chest = Instantiate(ChestPrefab, transform);
            slot.AddChest(chest);
        }
    }

}
