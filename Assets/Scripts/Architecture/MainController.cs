using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class MainController : MonoBehaviour
{
    List<IAwake> OnAwakeList;
    List<IUpdate> OnUpdateList;
    public Dictionary<int, CardModel> CardsModels;
    private CardController CardController;

    private void Start()
    {

    }

    private void Awake()
    {
        OnAwakeList = new List<IAwake>();
        OnUpdateList = new List<IUpdate>();
        CardsModels = new Dictionary<int, CardModel>();
        CardController = new CardController(this);
        OnAwakeList.Add(CardController);
        foreach(var feature in OnAwakeList)
        {
            feature.OnAwake();
        }
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        
    }

    private void LateUpdate()
    {
        
    }
}
