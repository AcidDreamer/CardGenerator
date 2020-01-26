using Assets.Scripts.Enums;
using Assets.Scripts.Helpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCost : MonoBehaviour
{
    public GameObject SingleItemCost;
    public List<GameObject> Items;
    public float MoveNext = 26.0f;
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void AddItemWithCost(List<ItemWithCost> itemsWithCosts)
    {
        foreach(var item in Items)
        {
            Destroy(item);
        }
        Items = new List<GameObject>();
        var prevItemsX = 0.0f;
        foreach (var item in itemsWithCosts)
        {
            var position = transform.position;
            position.x = position.x  + prevItemsX;

            var newItem = Instantiate(SingleItemCost, position, transform.rotation);
            var newItemScript = newItem.gameObject.GetComponent<SingleManaItem>();
            newItemScript.Allegiance = item.Allegiance;

            newItemScript.Cost = item.Cost;
            newItemScript.Apply();

            newItem.transform.SetParent(this.gameObject.transform);
            Debug.Log(newItem.transform.position.ToString());
            prevItemsX -= MoveNext;

            Items.Add(newItem);
        }
    }
}

