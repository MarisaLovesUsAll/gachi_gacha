using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OperatorViewController : MonoBehaviour
{
    public Image img;
    public TextMeshProUGUI name;
    public TextMeshProUGUI title;
    public TextMeshProUGUI dialog;
    public StarController starController;
    public GameObject dialogBG;

    private void Start()
    {
        Hide();
    }

    public void Hide()
    {
        img.enabled = false;
        name.enabled = false;
        title.enabled = false;
        dialog.enabled = false;
        dialogBG.SetActive(false);
        starController.gameObject.SetActive(false);
    }

    public void Show()
    {
        img.enabled = true;
        name.enabled = true;
        title.enabled = true;
        dialog.enabled = true;
        dialogBG.SetActive(true);
        starController.gameObject.SetActive(true);
    }

    public void SetInfo(Operator op)
    {
        img.sprite = op.sprite;
        name.text = op.name;
        title.text = op.title;
        dialog.text = op.dialog;
        starController.SetStars(op.rarity);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
