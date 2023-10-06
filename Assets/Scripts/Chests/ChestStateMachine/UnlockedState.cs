using UnityEngine;

public class UnlockedState : ChestState {

    public UnlockedState(ChestController c, ChestModel m, ChestView v) : base(c, m, v) { }

    public override void OnEnter() {
    }

    public override void OnExit() {
    }

    public override void Update() {
    }

    public void OpenChest() {
        ChestService.Instance.ShowOpenChestDialog(controller.GemsReward, this);
    }

    public void CollectGems() {
        CurrencyService.Instance.AddGems(controller.GemsReward);
        CurrencyService.Instance.AddCoins(controller.CoinReward);
        controller.ChangeState(controller.collectedState);
    }
}
