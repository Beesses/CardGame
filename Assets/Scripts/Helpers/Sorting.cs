using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Sorting : MonoBehaviour
{
    public MainController MainController;

    public void SortBy()
    {
        int i = 0;
        foreach (var item in MainController.CardsModels.OrderByDescending(r => r.Key).Take(MainController.CardsModels.Count))
        {
            item.Value.Card.transform.SetSiblingIndex(i);
            i++;
        }
    }
}
