public class CollectedState : ChestState {

    public CollectedState(ChestController c) : base(c) { }

    public override void OnEnter() {
        controller.CloseChest();
    }

    public override void OnExit() {
    }

    public override void Update() {
    }
}
