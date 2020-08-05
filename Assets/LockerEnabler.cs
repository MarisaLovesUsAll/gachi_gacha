using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerEnabler : MonoBehaviour
{
    Transform kiddo;
    // Start is called before the first frame update
    void Start()
    {
        kiddo = transform.GetChild(0);
        kiddo.GetComponent<LockerController>().mod = 0;
    }

    public void EnableKiddo()
    {
        kiddo.gameObject.SetActive(true);
    }
    public void DisableKiddo()
    {
        kiddo.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
