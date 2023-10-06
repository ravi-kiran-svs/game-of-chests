public abstract class ChestState {

    protected ChestController controller;
    protected ChestModel model;
    protected ChestView view;

    public ChestState(ChestController c, ChestModel m, ChestView v) {
        controller = c;
        model = m;
        view = v;
    }

    public abstract void OnEnter();
    public abstract void OnExit();
    public abstract void Update();

}
