using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class CardController: IAwake, IUpdate
{
    public int CardsAmount = 10;
    private MainController MainController;

    public CardController(MainController mainController)
    {
        MainController = mainController;
        for(int i =0; i < CardsAmount; i++)
        {
            new CardModel(Data.Card, mainController);
        }
    }

    public void OnAwake()
    {
        foreach(var model in MainController.CardsModels)
        {

        }
    }

    public void OnUpdate()
    {

    }
}
