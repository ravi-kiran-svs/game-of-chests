public class QueuedState : ChestState {

    public QueuedState(ChestController c, ChestModel m, ChestView v) : base(c, m, v) { }

    public override void OnEnter() {
    }

    public override void OnExit() {
    }

    public override void Update() {
    }

    // to UNLOCKING state
    public void ForceUnlocking() {
        controller.ChangeState(controller.unlockingState);
        view.Dequeued();
    }
}
