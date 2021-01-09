using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombUnit : UnitBase
{
    private void Awake()
    {
        m_ScaleText.gameObject.SetActive(false);
    }
    public override void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerControll pc = collision.transform.parent.GetComponent<PlayerControll>();
        if (pc != null)
        {
            if (collision.gameObject.name == "Bag")
            {
                pc.Die();
                Destroy(gameObject);
            }
            else if (collision.gameObject.name == "Head")
            {
                //Vector2 v1 = m_Rigidbody2D.velocity;
                //float magn = m_Rigidbody2D.velocity.magnitude;
                Vector2 v2 = m_Rigidbody2D.velocity.normalized;
                m_Rigidbody2D.velocity = v2 * 420;
                

            }
        }
    }
}
