using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGController : MonoBehaviour
{
    public Sprite spriteBringing;
    public Sprite spriteOpening;
    public MeshRenderer renderer;

    public void BringingStarted()
    {
        renderer.material.mainTexture = spriteBringing.texture;
    }

    public void OpeningStarted()
    {
        renderer.material.mainTexture = spriteOpening.texture;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
