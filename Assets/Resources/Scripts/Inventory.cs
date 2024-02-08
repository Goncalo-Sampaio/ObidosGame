using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> characterItems = new List<Item>();
    public ItemDatabase itemDatabase;

    public void GiveItem(int id)
    {
        Item itemToAdd = itemDatabase.GetItem(id);
        characterItems.Add(itemToAdd);
        Debug.Log("Added " + itemToAdd.title + " to the inventory");

    }

    public Item CheckForItem(int id)
    {
        return characterItems.Find(item => item.id == id);
    }
    public void RemoveItem(int id)
    {
        Item item = CheckForItem(id);
        if (item != null)
        {
            characterItems.Remove(item);
            Debug.Log(item.title + " was removed from the inventory");
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        GiveItem(1);
        GiveItem(2);
        RemoveItem(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
