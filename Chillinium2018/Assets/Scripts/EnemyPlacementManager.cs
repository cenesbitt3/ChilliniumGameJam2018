using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlacementManager : MonoBehaviour {

    int color;
    int placement;
    bool filled;

    public void FillValues(int setColor, int setPlacement, bool setFill) {
        color = setColor;
        placement = setPlacement;
        filled = setFill;
    }

    public int GetColor() {
        return color;
    }
}
