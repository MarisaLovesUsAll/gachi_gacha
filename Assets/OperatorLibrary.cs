using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Operator
{
    public Sprite sprite;
    public string name;
    public string title;
    public string dialog;
    public Rarity rarity;
    public AudioClip audio1;
    public AudioClip audio2;
}

public class OperatorLibrary : MonoBehaviour
{
    public List<Operator> dict;

    public Operator GetRandomOperator()
    {
        int index = Random.Range(0, dict.Count);
        return dict[index];
    }
}
