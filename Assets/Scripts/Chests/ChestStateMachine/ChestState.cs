public abstract class ChestState {

    protected ChestController controller;

    public ChestState(ChestController c) {
        controller = c;
    }

    public abstract void OnEnter();
    public abstract void OnExit();
    public abstract void Update();

}
