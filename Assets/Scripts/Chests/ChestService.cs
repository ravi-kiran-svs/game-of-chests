using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestService : MonoSingleton<ChestService> {

    // change type to ChestView
    [SerializeField] private GameObject ChestPrefab;

    public void GenerateChest() {
        Slot slot = SlotService.Instance.GetFreeSlot();

        if (slot == null) {
            // dialog box lol
            Debug.Log("NO MORE CHESTS!");

        } else {
            GameObject chest = Instantiate(ChestPrefab, transform);
            slot.AddChest(chest);
        }
    }

}
