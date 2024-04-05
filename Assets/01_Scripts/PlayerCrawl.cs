using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCrawl : MonoBehaviour
{
    public bool crawling = false;


    private void Update()
    {
        Enemycrawl();
    }

    void Enemycrawl()
    {
        if(Input.GetKey(KeyCode.C))
        {
            transform.position = new Vector3(transform.position.x, 1.2f, transform.position.z);
            crawling = true;
            
        }

        else if(Input.GetKeyUp(KeyCode.C))
        {
            transform.position = new Vector3(transform.position.x, 1.7f, transform.position.z);
            crawling = false;
        }
    }
}
