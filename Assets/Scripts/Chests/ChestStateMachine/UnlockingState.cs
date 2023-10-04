using System.Collections;
using UnityEngine;

public class UnlockingState : ChestState {

    private IEnumerator timerRun;

    private float tStart;

    public UnlockingState(ChestController c) : base(c) {
        timerRun = StartTimer();
    }

    public override void OnEnter() {
        controller.View.StartCoroutine(timerRun);

        tStart = Time.time;
    }

    public override void OnExit() {
    }

    public override void Update() {
        float tPassed = Time.time - tStart;
        float tLeft = controller.Model.timeToUnlock - tPassed;
        int tInt = (int)(tLeft + 0.5);

        float gemsPerSec = (float)controller.Model.gemsToUnlock / controller.Model.timeToUnlock;
        float gemsToUnlock = tLeft * gemsPerSec;
        int gemsInt = (int)(gemsToUnlock + 1);

        controller.View.UpdateUnlockingTexts(tInt, gemsInt, CurrencyService.Instance.Gems >= gemsInt);
    }

    public void OpenChestNow() {
        controller.View.StopCoroutine(timerRun);

        float tPassed = Time.time - tStart;
        float tLeft = controller.Model.timeToUnlock - tPassed;
        float gemsPerSec = (float)controller.Model.gemsToUnlock / controller.Model.timeToUnlock;
        float gemsToUnlock = tLeft * gemsPerSec;
        int gemsInt = (int)(gemsToUnlock + 1);
        CurrencyService.Instance.MinusGems(gemsInt);

        controller.ChangeState(controller.unlockedState);
        controller.View.Unlock();
    }

    public IEnumerator StartTimer() {
        yield return new WaitForSeconds(controller.Model.timeToUnlock);
        OnTimerFinish();
    }

    public void OnTimerFinish() {
        controller.ChangeState(controller.unlockedState);
        controller.View.Unlock();
    }

}
