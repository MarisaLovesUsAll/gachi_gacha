using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSourceLootbox;
    public AudioSource audioSourceP1;
    public AudioSource audioSourceP2;

    public AudioClip lootboxSpawned;
    public Operator currentOperator;

    public void LootboxSpawned()
    {
        audioSourceP1.Stop();
        audioSourceP2.Stop();
        audioSourceLootbox.PlayOneShot(lootboxSpawned);
    }

    public void Phrase1()
    {
        audioSourceP1.PlayOneShot(currentOperator.audio1);
    }

    public void Phrase2()
    {
        audioSourceP2.PlayOneShot(currentOperator.audio2);
    }

    public void SetInfo(Operator op)
    {
        currentOperator = op;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
