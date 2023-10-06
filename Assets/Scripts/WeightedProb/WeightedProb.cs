using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightedProb {

    public static int GetWeightedProb(int[] weights) {
        int[] cummulativeWeights = new int[4];
        for (int i = 0, prevWeight = 0; i < weights.Length; i++) {
            cummulativeWeights[i] = prevWeight + weights[i];
            prevWeight = cummulativeWeights[i];
        }

        int value = Random.Range(0, cummulativeWeights[weights.Length - 1]);
        for (int i = 0; i < weights.Length; i++) {
            if (value < cummulativeWeights[i]) {
                return i;
            }
        }

        return 0;
    }

}