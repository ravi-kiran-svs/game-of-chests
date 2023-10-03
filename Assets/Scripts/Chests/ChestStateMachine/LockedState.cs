public class LockedState : ChestState {

    public LockedState(ChestController c) : base(c) { }

    public override void OnEnter() {
    }

    public override void OnExit() {
    }

    public override void Update() {
    }

    public void UnlockChest() {
        ChestService.Instance.ShowUnlockChestDialog(0, 0, this);
    }

    // to UNLOCKING state
    public void StartTimer() {
        controller.ChangeState(controller.unlockingState);
        controller.View.Unlocking();
    }

    // to UNLOCKED state
    public void UseGems() {
        CurrencyService.Instance.MinusGems(controller.gemsToUnlock);
        controller.ChangeState(controller.unlockedState);
        controller.View.UnlockDirect();
    }

}
