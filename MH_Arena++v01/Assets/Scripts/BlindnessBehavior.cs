using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item3Behavior : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(this.transform.parent.gameObject);

            Debug.Log("Invincibility! You have become immune to enemy attacks for 1 minute!");
        }
    }
}