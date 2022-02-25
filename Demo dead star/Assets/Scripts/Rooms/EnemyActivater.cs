using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActivater : MonoBehaviour
{
    EnemyMoving[] m_enemyMoving;
    // Start is called before the first frame update
    void Start()
    {
        m_enemyMoving = transform.GetComponentsInChildren<EnemyMoving>();
        deactivateEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activateEnemy()
    {
        foreach (EnemyMoving eM in m_enemyMoving)
        {
            if (eM != null)
            {
                eM.gameObject.SetActive(true);
            }

        }
    }

    public void deactivateEnemy()
    {
        foreach (EnemyMoving eM in m_enemyMoving)
        {
            if (eM != null)
            {
                eM.gameObject.SetActive(false);
            }
        }
    }
}
