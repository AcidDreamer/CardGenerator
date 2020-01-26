using Assets.Scripts.Enums;
using Assets.Scripts.Helpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCost : MonoBehaviour
{
    public GameObject SingleItemCost;
    public List<GameObject> Items;
    
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
        foreach(var item in itemsWithCosts)
        {
            var spawnAtY = gameObject.transform.position.y;
            var spawnAtX = gameObject.transform.right.x;
            var newItem = Instantiate(SingleItemCost, transform.position, transform.rotation);
            var newItemScript = newItem.gameObject.GetComponent<SingleManaItem>();
            newItemScript.Allegiance = item.Allegiance;
            newItemScript.Cost = item.Cost;
            newItemScript.Apply();
            newItem.transform.SetParent(this.gameObject.transform);

            Items.Add(newItem);
        }
    }
}

