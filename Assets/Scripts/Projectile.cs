using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 25;
    public float speed = 50;

    public GameObject SparkPrefab;
    private Transform target;

    private void Update()
    {
        if(target != null)
        {
            transform.LookAt(target.position);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }else{
            Die();
            return;
        }

        if(Vector3.Distance(transform.position, target.position) < 0.5)
        {
            Die();
            target.GetComponent<Enemy1>().TakeDamage(damage);
        }
    }

    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    private void Die()
    {
        Destroy(this.gameObject);
        GameObject spark = GameObject.Instantiate(SparkPrefab, transform.position, Quaternion.identity);
        Destroy(spark, 1);
        if(target != null)
        {
            spark.transform.parent = target.transform;
        }
    }
}
