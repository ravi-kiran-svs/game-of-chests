using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour {

    private bool isFree = true;
    public bool IsFree { get { return isFree; } }

    public void AddChest(ChestView chest) {
        chest.OnClose += OnChestClose;
        chest.transform.SetParent(transform, false);
        isFree = false;
    }

    private void OnChestClose() {
        isFree = true;
    }

}
