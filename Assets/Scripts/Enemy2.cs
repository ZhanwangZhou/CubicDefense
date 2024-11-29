using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    private int pointIndex = 0;
    private Vector3 targetPosition = Vector3.zero;

    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = PathPoints.Instance.GetPathPoint(pointIndex);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((targetPosition - transform.position).normalized * speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, targetPosition) < 0.2f)
        {
            MoveNextPoint();
        }
    }

    private void MoveNextPoint(){
        ++pointIndex;
        if(pointIndex > PathPoints.Instance.GetLength() - 1)
        {
            Die();
            return;
        }
        targetPosition = PathPoints.Instance.GetPathPoint(pointIndex);
    }

    void Die()
    {
        Destroy(gameObject);
        EnemySpawner.Instance.DecreaseEnemyCount();
    }
}
