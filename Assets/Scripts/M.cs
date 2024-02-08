using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M : MonoBehaviour
{
    [SerializeField]
    private int _itemId = 0;

    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        if (_gameManager.IsCollected(_itemId))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _gameManager.CollectM(_itemId);

            StartCoroutine(PickCoroutine());
        }
    }

    IEnumerator PickCoroutine()
    {
        GetComponent<Animator>().SetTrigger("Picked");
        yield return new WaitForSeconds(0.75f);
        Destroy(gameObject);
    }
}
