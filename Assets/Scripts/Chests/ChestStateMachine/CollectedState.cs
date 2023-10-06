public class CollectedState : ChestState {

    public CollectedState(ChestController c, ChestModel m, ChestView v) : base(c, m, v) { }

    public override void OnEnter() {
        controller.CloseChest();
    }

    public override void OnExit() {
    }

    public override void Update() {
    }
}
