using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform FirePosition;
    public AudioSource ShootingSound;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject bullet = Instantiate(BulletPrefab, FirePosition.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
            ShootingSound.Play();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
