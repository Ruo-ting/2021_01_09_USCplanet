using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitBase : MonoBehaviour
{
    public Text m_ScaleText = null;
    private int m_ScaleValue = 1;
    public int m_ScoreBase = 1;
    public Rigidbody2D m_Rigidbody2D = null;

    private void Start()
    {
        RefreshScale();
    }

    private void RefreshScale()
    {
        m_ScaleText.text = "x" + m_ScaleValue;
    }

    public void Update()
    {
        if (transform.localPosition.y < -600)
        {
            Destroy(gameObject);
        }
    }
    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerControll pc = collision.transform.parent.GetComponent<PlayerControll>();
        if ( pc!= null )
        {
            if (collision.gameObject.name == "Bag")
            {
                pc.AddScore(m_ScoreBase * m_ScaleValue);
                Destroy(gameObject);
            }
            else if (collision.gameObject.name == "Head")
            {
                //Vector2 v1 = m_Rigidbody2D.velocity;
                //float magn = m_Rigidbody2D.velocity.magnitude;
                Vector2 v2 = m_Rigidbody2D.velocity.normalized;
                m_Rigidbody2D.velocity = v2 * 420;
                m_ScaleValue++;
                RefreshScale();
            }
        }
    }
}
