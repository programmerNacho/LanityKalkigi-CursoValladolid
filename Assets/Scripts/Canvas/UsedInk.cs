using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsedInk : MonoBehaviour
{
    public int maxInk;
    public int currentInk;

    public Image WithoutInk;
    public Image WithInk;

    public void InkUse(int currentInk, int maxInk)
    {
        float percentageInk = (float)currentInk / maxInk;
        WithInk.fillAmount = percentageInk;
    }
}
