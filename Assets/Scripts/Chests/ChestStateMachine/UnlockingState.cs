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
        float tLeft = controller.timeToWait - tPassed;
        int tInt = (int)(tLeft + 0.5);

        controller.View.UpdateUnlockingTexts(tInt, 0, true);
    }

    public void OpenChestNow() {
        controller.View.StopCoroutine(timerRun);

        // not gemsToUnlock - calculated minus timer thing
        //CurrencyService.Instance.MinusGems(controller.gemsToUnlock);

        controller.ChangeState(controller.unlockedState);
        controller.View.Unlock();
    }

    public IEnumerator StartTimer() {
        yield return new WaitForSeconds(controller.timeToWait);
        OnTimerFinish();
    }

    public void OnTimerFinish() {
        controller.ChangeState(controller.unlockedState);
        controller.View.Unlock();
    }

}
