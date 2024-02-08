using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositioner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Player>().PlayerPositioner();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
