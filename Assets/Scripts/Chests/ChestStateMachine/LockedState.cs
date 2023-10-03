public class LockedState : ChestState {

    public LockedState(ChestController c) : base(c) { }

    public override void OnEnter() {
    }

    public override void OnExit() {
        controller.View.Unlock();
    }

    public override void Update() {
    }

    public void UnlockChest() {
        ChestService.Instance.ShowUnlockChestDialog(0, 0, this);
    }

    // to UNLOCKING state
    public void StartTimer() {
        // coroutine shit - in state machine
    }

    // to UNLOCKED state
    public void UseGems() {
        CurrencyService.Instance.MinusGems(controller.gemsToUnlock);
        controller.ChangeState(controller.unlockedState);
    }

}
