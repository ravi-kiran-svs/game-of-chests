using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotService : MonoSingleton<SlotService> {

    [SerializeField] private Slot[] slots;

    public Slot GetFreeSlot() {
        foreach (Slot slot in slots) {
            if (slot.IsFree) {
                return slot;
            }
        }
        return null;
    }

}
