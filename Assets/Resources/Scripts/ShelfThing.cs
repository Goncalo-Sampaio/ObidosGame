using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public int id;
    public string title;
    public string description;
    public Sprite icon;
    public Dictionary<string, int> bookPosition = new Dictionary<string, int>();    

    public Item(int id, string title, string description, Dictionary<string, int> bookPosition)
    {
        this.id = id;
        this.title = title;
        this.description = description;
        this.icon = Resources.Load<Sprite>("TempImages/" + title);
        this.bookPosition = bookPosition;
    }   
}
