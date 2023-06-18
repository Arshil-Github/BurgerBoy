using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootbulllet : MonoBehaviour
{
    public Transform pfBullet;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            Instantiate(pfBullet, transform.position, Quaternion.identity);
        }
    }
}
