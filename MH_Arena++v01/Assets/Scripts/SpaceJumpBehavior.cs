using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item2Behavior : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(this.transform.parent.gameObject);

            Debug.Log("Space Jump Obtained. Jump to activate");
        }
    }
}