using System.Collections;
using UnityEngine;

public class UnlockingState : ChestState {

    private IEnumerator timerRun;

    private float tStart;

    public UnlockingState(ChestController c, ChestModel m, ChestView v) : base(c, m, v) {
        timerRun = StartTimer();
    }

    public override void OnEnter() {
        view.StartCoroutine(timerRun);

        tStart = Time.time;
    }

    public override void OnExit() {
    }

    public override void Update() {
        float tPassed = Time.time - tStart;
        float tLeft = model.timeToUnlock - tPassed;
        int tInt = (int)(tLeft + 0.5);

        float gemsPerSec = (float)model.gemsToUnlock / model.timeToUnlock;
        float gemsToUnlock = tLeft * gemsPerSec;
        int gemsInt = (int)(gemsToUnlock + 1);

        view.UpdateUnlockingTexts(tInt, gemsInt, CurrencyService.Instance.Gems >= gemsInt);
    }

    public void OpenChestNow() {
        view.StopCoroutine(timerRun);

        float tPassed = Time.time - tStart;
        float tLeft = model.timeToUnlock - tPassed;
        float gemsPerSec = (float)model.gemsToUnlock / model.timeToUnlock;
        float gemsToUnlock = tLeft * gemsPerSec;
        int gemsInt = (int)(gemsToUnlock + 1);
        CurrencyService.Instance.MinusGems(gemsInt);

        controller.ChangeState(controller.unlockedState);
        view.Unlock();
    }

    public IEnumerator StartTimer() {
        yield return new WaitForSeconds(model.timeToUnlock);
        OnTimerFinish();
    }

    public void OnTimerFinish() {
        controller.ChangeState(controller.unlockedState);
        view.Unlock();
    }

}
