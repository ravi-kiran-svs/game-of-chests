using System.Collections;
using UnityEngine;

public class UnlockingState : ChestState {

    IEnumerator timerRun;

    public UnlockingState(ChestController c) : base(c) {
        timerRun = StartTimer();
    }

    public override void OnEnter() {
        controller.View.StartCoroutine(timerRun);
    }

    public override void OnExit() {
    }

    public override void Update() {
        // controller.View.UpdateUnlockingTexts(int time, int gems, bool showGems);
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
