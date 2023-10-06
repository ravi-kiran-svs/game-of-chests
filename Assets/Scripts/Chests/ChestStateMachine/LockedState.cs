public class LockedState : ChestState {

    public LockedState(ChestController c, ChestModel m, ChestView v) : base(c, m, v) { }

    public override void OnEnter() {
    }

    public override void OnExit() {
    }

    public override void Update() {
    }

    public void UnlockChest() {
        bool showTimer = !ChestService.Instance.IsAnyTimerRunning();
        bool showGems = CurrencyService.Instance.Gems >= model.gemsToUnlock;
        ChestService.Instance.ShowUnlockChestDialog(model.timeToUnlock, model.gemsToUnlock, showTimer, showGems, this);
    }

    // to UNLOCKING state
    public void StartTimer() {
        controller.ChangeState(controller.unlockingState);
        view.Unlocking();
    }

    // to UNLOCKED state
    public void UseGems() {
        CurrencyService.Instance.MinusGems(model.gemsToUnlock);
        controller.ChangeState(controller.unlockedState);
        view.UnlockDirect();
    }

}
