using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float m_moveSpeed = 5;

    private Vector2 m_inputVec;
    private Rigidbody2D m_rb;

    private Animator m_anim;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        m_rb.velocity = m_inputVec;
    }

    void Update()
    {
        m_inputVec = (Vector3.right * Input.GetAxisRaw("Horizontal") + Vector3.up * Input.GetAxisRaw("Vertical")).normalized * m_moveSpeed;

        m_anim.SetFloat("X", m_inputVec.x);
        m_anim.SetFloat("Y", m_inputVec.y);
        m_anim.SetFloat("Mag", m_inputVec.sqrMagnitude);

        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = -Mathf.Atan2(mousePos.x - transform.position.x, mousePos.y - transform.position.y) * Mathf.Rad2Deg;
        // m_rb.rotation = angle;
        m_rb.MoveRotation(Quaternion.Euler(0, 0, angle));
    }

    void LateUpdate()
    {
    }
}
