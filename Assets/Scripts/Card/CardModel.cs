using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class CardModel
{
    public CardEnum CardEnum;
    public GameObject Card;
    public GameObject Sprite;
    public GameObject HealthText;

    public CardModel(CardSO Data, MainController mainController)
    {
        CardEnum = Data.CardEnum;
        CardEnum.MainController = mainController;
        CardEnum.SpawnPlace = GameObject.FindGameObjectWithTag("CardPosition").transform;
        Card = GameObject.Instantiate(CardEnum.Prefab, CardEnum.SpawnPlace);
        Card.transform.SetParent(CardEnum.SpawnPlace);
        CardEnum.MainController.CardsModels.Add(Card.GetInstanceID(), this);
        Sprite = Card.transform.Find("CardSprite").gameObject;
        Sprite.GetComponent<Image>().sprite = CardEnum.Sprite;
        HealthText = Card.transform.GetChild(1).transform.GetChild(1).transform.Find("HealthText").gameObject;
        CardEnum.Health = Random.Range(1, 5);
        HealthText.GetComponent<Text>().text = CardEnum.Health.ToString();
    }
}
