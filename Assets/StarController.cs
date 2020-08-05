using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    public int count;

    private int childCount = 0;

    public Transform[] pool;


    // Start is called before the first frame update
    void Start()
    {
        childCount = transform.childCount;
        pool = new Transform[childCount];
        for (int i = 0; i < childCount; i++)
        {
            pool[i] = (transform.GetChild(i));
        }

        SetStars(Rarity.R4);
    }

    public void SetStars(Rarity rarity)
    {
        this.count = (int)rarity;

        for (int i = 0; i < childCount; i++)
        {
            var child = pool[i];
            if (i < count)
            {
                child.gameObject.SetActive(true);
                child.localPosition = new Vector3(0 + 50 * i, 0, 0);
            }
            else
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {


    }
}
