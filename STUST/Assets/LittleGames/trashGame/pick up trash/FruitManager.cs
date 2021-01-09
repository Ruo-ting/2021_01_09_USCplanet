using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitManager : MonoBehaviour
{
    public UnitBase[] m_Clone = null;

    public Transform m_FruitNode = null;

    public PlayerControll m_Player = null;


    private float m_Delay = 0;
    private int m_TimeRank = 0;
    private float m_AddTime = 10;

    private const float m_MathTime = 10;
    private const int m_BombProBase = 5;

    private void Start()
    {
        m_Delay = Time.time + 1;
        m_AddTime = m_MathTime;

    }

    private void Update()
    {
        if (m_Delay < Time.time)
        {
            m_Delay = Time.time + 1;
            CreateFruit();
        }

        if (m_Player.GetNowTime() > m_AddTime)
        {
            m_TimeRank++;
            m_AddTime += m_MathTime;
            Time.timeScale = 1 + m_TimeRank * 0.2f;
        }
    }

    private void CreateFruit()
    {
        
        UnitBase unit = GetCreateObj();
         UnitBase createUnit = Instantiate<UnitBase>(unit,m_FruitNode);
        createUnit.transform.localPosition = new Vector3(Random.Range(-550f, 550f),550, 0);
    }

    private UnitBase GetCreateObj()
    {
        int r = Random.Range(0, 100);//0-99

        int mathBombPro = m_BombProBase + m_TimeRank*3;
        int fruit1 = m_TimeRank > 0 ? 5 : 0;
        int fruit2 = m_TimeRank > 1 ? 5 : 0;
        int fruit3 = m_TimeRank > 2 ? 5 : 0;
        int fruit4 = m_TimeRank > 3 ? 5 : 0;
        int fruit5 = m_TimeRank > 4 ? 5 : 0;
        int fruit6 = m_TimeRank > 5 ? 5 : 0;
        

        r -= mathBombPro;
        if (r < 0)
        {
            return m_Clone[1];
        }
        r -= fruit1;
        if (r < 0)
        {
            return m_Clone[2];
        }
        r -= fruit2;
        if (r < 0)
        {
            return m_Clone[3];
        }
        r -= fruit3;
        if (r < 0)
        {
            return m_Clone[4];
        }
        r -= fruit4;
        if (r < 0)
        {
            return m_Clone[5];
        }
        r -= fruit5;
        if (r < 0)
        {
            return m_Clone[6];
        }
        r -= fruit6;
        if (r < 0)
        {
            return m_Clone[7];
        }
        
        return m_Clone[0];
    }
}
