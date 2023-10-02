using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour {

    private bool isFree = true;
    public bool IsFree { get { return isFree; } }

    public void AddChest(GameObject chest) {
        chest.transform.SetParent(transform, false);
        isFree = false;
    }

}
