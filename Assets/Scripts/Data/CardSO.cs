using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "CardData", order = 1)]
public sealed class CardSO : ScriptableObject
{
    public CardEnum CardEnum;
}
