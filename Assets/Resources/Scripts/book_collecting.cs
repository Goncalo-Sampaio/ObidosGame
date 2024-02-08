using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class book_collecting : MonoBehaviour
{
    [SerializeField]
    public int booksNumber;
    private bool iscollecting;
    private float _playerBorder;


    // Start is called before the first frame update
    void Start()
    {
        _playerBorder = GetComponent<Collider2D>().bounds.extents.x;
    }

    // Update is called once per frame
    void Update()
    {
        




    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "book" || collision.gameObject.tag == "book")
        {
            booksNumber += 1;
            Destroy(collision.gameObject);

        }
        
    }
    
}
