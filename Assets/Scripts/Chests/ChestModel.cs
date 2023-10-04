using UnityEngine;

[CreateAssetMenu(fileName = "ChestModel", menuName = "ScriptableObjects/CreateChestModel")]
public class ChestModel : ScriptableObject {

    [SerializeField] public int gemsToUnlock;
    [SerializeField] public int timeToUnlock;

    [SerializeField] public Range gemsRewardRange;
    [SerializeField] public Range coinRewardRange;

}
