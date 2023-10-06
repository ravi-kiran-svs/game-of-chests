using System;

public class LockedState : ChestState {

    public LockedState(ChestController c, ChestModel m, ChestView v) : base(c, m, v) { }

    public override void OnEnter() {
    }

    public override void OnExit() {
    }

    public override void Update() {
    }

    public void UnlockChest() {
        bool showTimerButton = !ChestService.Instance.IsAnyTimerRunning();
        bool showGemsButton = CurrencyService.Instance.Gems >= model.gemsToUnlock;
        bool showQueueButton = !ChestService.Instance.IsQueueFull();
        ChestService.Instance.ShowUnlockChestDialog(model.timeToUnlock, model.gemsToUnlock, showTimerButton, showGemsButton, showQueueButton, this);
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

    // to QUEUED state
    public void AddToQueue() {
        ChestService.Instance.AddToQueue(controller);
        controller.ChangeState(controller.queuedState);
        view.Queued();
    }
}
