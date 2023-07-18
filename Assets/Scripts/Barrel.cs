using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : Damageable
{
    public float BlastRadius = 5;

    private Rigidbody2D m_rb;
    [SerializeField] GameObject m_explosionPrefab;

    private void Start() {
        m_rb = GetComponent<Rigidbody2D>();

        OnDie += Explode;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.CompareTag("Bullet")) {
            m_rb.AddForce(other.collider.transform.forward * 10f);
            Damage(100);
        }
    } 

    void Explode() {
        Destroy(gameObject);
        var expl = Instantiate(m_explosionPrefab, transform.position, Quaternion.identity);
        Destroy(expl, 0.2f);

        var objs = Physics2D.OverlapCircleAll(transform.position, BlastRadius);
        
        foreach (var obj in objs) {
            if (obj.name == transform.name) return;

            if (obj.GetComponent<Rigidbody2D>()) {
                var rb = obj.GetComponent<Rigidbody2D>();
                rb.AddForce(transform.position - obj.transform.position * 50f);
            }

            if (obj.GetComponent<Damageable>()) {
                var dmg = obj.GetComponent<Damageable>();

                // print(dmg.name);
                dmg.Damage(100);
            }
        }
        
    }
}
