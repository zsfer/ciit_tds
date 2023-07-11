using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject m_bulletPrefab;

    [SerializeField]
    private Transform m_bulletSpawn;

    [SerializeField]
    private float m_bulletSpeed;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var bullet = Instantiate(m_bulletPrefab, m_bulletSpawn.transform.position, m_bulletSpawn.transform.rotation);

            bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.up * m_bulletSpeed * 1000);
        }
    }
}
