using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestService : MonoSingleton<ChestService> {

    [SerializeField] private ChestView[] ChestPrefabs;
    [SerializeField] private ChestModel[] ChestModels;
    [SerializeField] private int[] probWeights;

    [SerializeField] private GameObject slotsFullDialog;
    [SerializeField] private UnlockChestDialog unlockChestDialog;
    [SerializeField] private OpenChestDialog openChestDialog;

    private ChestController activeChest;
    private Queue<ChestController> queue = new Queue<ChestController>();
    [SerializeField] private int maxQueueNum = 2;

    private List<ChestController> controllers = new List<ChestController>();

    public void GenerateChest() {
        Slot slot = SlotService.Instance.GetFreeSlot();

        if (slot == null) {
            slotsFullDialog.SetActive(true);

        } else {
            int type = WeightedProb.GetWeightedProb(probWeights);
            ChestView chestView = Instantiate(ChestPrefabs[type], transform);
            ChestModel chestModel = ChestModels[type];
            ChestController chest = new ChestController(chestModel, chestView);
            slot.AddChest(chest);
            chestView.transform.SetParent(slot.transform, false);

            controllers.Add(chest);
            chest.OnCollected += OnChestClosed;
            chest.OnEnterState += OnChestEnteredState;
            chest.OnExitState += OnChestExitState;
        }
    }

    public void ShowUnlockChestDialog(int time, int gems, bool showTimer, bool showGems, bool showQueue, LockedState chest) {
        unlockChestDialog.Open(time, gems, showTimer, showGems, showQueue, chest);
    }

    public void ShowOpenChestDialog(int gems, UnlockedState chest) {
        openChestDialog.Open(gems, chest);
    }

    public bool IsAnyTimerRunning() {
        foreach (ChestController chest in controllers) {
            if (chest.CurrentState == chest.unlockingState) {
                return true;
            }
        }
        return false;
    }

    public bool IsQueueFull() {
        return queue.Count >= maxQueueNum;
    }

    public void AddToQueue(ChestController chest) {
        if (!IsQueueFull()) {
            queue.Enqueue(chest);
        }
    }

    private void OnActiveChestUnlockingComplete() {
        if (queue.Count > 0) {
            ChestController chest = queue.Dequeue();
            ((QueuedState)chest.CurrentState).ForceUnlocking();
        }
    }

    private void OnChestEnteredState(ChestController chest, ChestState state) {
        if (state is UnlockingState) {
            activeChest = chest;
        }
    }

    private void OnChestExitState(ChestController chest, ChestState state) {
        if (chest == activeChest && state is UnlockingState) {
            activeChest = null;
            OnActiveChestUnlockingComplete();
        }
    }

    private void OnChestClosed(ChestController chest) {
        controllers.Remove(chest);
    }

}
