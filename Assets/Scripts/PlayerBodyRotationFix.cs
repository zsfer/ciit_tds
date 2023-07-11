using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBodyRotationFix : MonoBehaviour
{
    private Quaternion m_startRotation;
    private RaycastHit2D m_hit;

    void Awake()
    {
        m_startRotation = transform.localRotation;
    }


    void Update()
    {
        m_hit = Physics2D.Raycast(transform.position, transform.right, 100f);
        Debug.DrawLine(transform.position, m_hit.point, Color.green);

        var angle = Mathf.Atan2(m_hit.transform.position.x - m_hit.transform.position.x, m_hit.transform.position.y - transform.position.y) * Mathf.Rad2Deg;
        print(angle);

        transform.localRotation = Quaternion.Euler(0, 0, m_startRotation.z);
    }
}
