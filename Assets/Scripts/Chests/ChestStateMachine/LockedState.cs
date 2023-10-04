public class LockedState : ChestState {

    public LockedState(ChestController c) : base(c) { }

    public override void OnEnter() {
    }

    public override void OnExit() {
    }

    public override void Update() {
    }

    public void UnlockChest() {
        bool showTimer = !ChestService.Instance.IsAnyTimerRunning();
        bool showGems = CurrencyService.Instance.Gems >= controller.Model.gemsToUnlock;
        ChestService.Instance.ShowUnlockChestDialog(controller.Model.timeToUnlock, controller.Model.gemsToUnlock, showTimer, showGems, this);
    }

    // to UNLOCKING state
    public void StartTimer() {
        controller.ChangeState(controller.unlockingState);
        controller.View.Unlocking();
    }

    // to UNLOCKED state
    public void UseGems() {
        CurrencyService.Instance.MinusGems(controller.Model.gemsToUnlock);
        controller.ChangeState(controller.unlockedState);
        controller.View.UnlockDirect();
    }

}
