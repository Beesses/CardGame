using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data", order = 2)]
public sealed class Data : ScriptableObject
{
    [SerializeField] private string CardPath;

    private static CardSO _card;
    private static Data _instance;

    private static T Load<T>(string resourcesPath) where T : Object =>
            Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));

    public static Data Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Resources.Load<Data>("Data/" + typeof(Data).Name);
            }
            return _instance;
        }
    }

    public static CardSO Card
    {
        get
        {
            if (_card == null)
            {
                _card = Resources.Load<CardSO>("Data/" + Instance.CardPath);
            }
            return _card;
        }
    }
}
