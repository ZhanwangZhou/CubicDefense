using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    private int pointIndex = 0;
    private Vector3 targetPosition = Vector3.zero;

    public float speed = 10;

    public int healthPoint = 100;

    public GameObject deathEffect;

    private Transform head;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = PathPoints.Instance.GetPathPoint(pointIndex);
        head = transform.Find("Body");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((targetPosition - transform.position).normalized * speed * Time.deltaTime);
        head.LookAt(targetPosition);

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
        GameObject de = GameObject.Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(de, 2);
    }

    public void TakeDamage(int damage)
    {
        healthPoint -= damage;
        if(healthPoint <= 0)
        {
            Die();
        }
    }
}
