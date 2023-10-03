using UnityEngine;

public class UnlockedState : ChestState {

    public UnlockedState(ChestController c) : base(c) { }

    public override void OnEnter() {
    }

    public override void OnExit() {
    }

    public override void Update() {
    }

    public void OpenChest() {
        ChestService.Instance.ShowOpenChestDialog(0, this);
    }

    public void CollectGems() {
        CurrencyService.Instance.AddGems(controller.gemsReward);
        controller.ChangeState(controller.collectedState);
    }
}
