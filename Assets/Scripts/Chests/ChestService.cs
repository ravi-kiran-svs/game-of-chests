using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestService : MonoSingleton<ChestService> {

    [SerializeField] private ChestView ChestPrefab;

    public void GenerateChest() {
        Slot slot = SlotService.Instance.GetFreeSlot();

        if (slot == null) {
            // dialog box lol
            Debug.Log("NO MORE CHESTS!");

        } else {
            ChestView chest = Instantiate(ChestPrefab, transform);
            slot.AddChest(chest);
        }
    }

}
