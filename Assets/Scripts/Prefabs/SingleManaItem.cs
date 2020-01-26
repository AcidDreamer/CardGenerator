using Assets.Scripts.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingleManaItem : MonoBehaviour
{
    public Image Image;
    public Text CostTxt;

    public Sprite Chaos;
    public Sprite Order;
    public Sprite Death;
    public Sprite Life;
    public Sprite Control;
    public Sprite Generic;

    public Allegiance Allegiance;
    public string Cost;

    // Start is called before the first frame update
    void Start()
    {
        Apply();
    }

    public void Apply()
    {
        CostTxt.text = Cost;
        switch (Allegiance)
        {
            case Allegiance.Chaos:
                Image.sprite = Chaos;
                break;
            case Allegiance.Order:
                Image.sprite = Order;
                break;
            case Allegiance.Control:
                Image.sprite = Control;
                break;
            case Allegiance.Death:
                Image.sprite = Death;
                break;
            case Allegiance.Life:
                Image.sprite = Life;
                break;
            case Allegiance.Generic:
                Image.sprite = Generic;
                break;
        }
        if (Allegiance == Allegiance.Order)
            CostTxt.color = Color.black;
        else
            CostTxt.color = Color.white;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
