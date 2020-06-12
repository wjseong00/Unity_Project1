using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public GameObject itemFactory;
    private void OnCollisionEnter(Collision collision)
    {
        GameObject item = Instantiate(itemFactory);
        item.transform.position = this.transform.position;

    }
}
