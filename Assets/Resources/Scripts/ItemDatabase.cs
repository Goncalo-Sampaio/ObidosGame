using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    private void Awake()
    {
        BuildDatabase();
    }

    public Item GetItem(int id)
    {
        return items.Find(item=>item.id == id);
    }
    public Item GetItem(string itemName)
    {
        return items.Find(item => item.title == itemName);
    }


    void BuildDatabase()
    {
        items = new List<Item>() {
            new Item(0, "The art of riding in the rain", "Book number: 142",
            new Dictionary<string, int>
            {
               {"correct position", 1 }
            }),
            new Item(1, "The long wait for The winds of winter", "Book number: 143",
            new Dictionary<string, int>
            {
               {"correct position", 2 }
            }),
            new Item(2, "Dear Sherlock", "Book number: 144",
            new Dictionary<string, int>
            {
               {"correct position", 3 }
            })

        };


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
