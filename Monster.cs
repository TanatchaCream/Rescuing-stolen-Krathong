using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public GameObject itemToDropPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            DropItem();
        }
    }

    public void DropItem()
    {
        if (itemToDropPrefab != null)
        {
            Instantiate(itemToDropPrefab, transform.position, Quaternion.identity);
        }
    }
}
