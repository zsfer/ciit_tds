using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;

    [SerializeField]
    private float m_lerpSpeed = 10;

    private Vector3 m_offset;

    void Start()
    {
        m_offset = transform.position;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, Target.position + m_offset, m_lerpSpeed * Time.deltaTime);
    }
}
