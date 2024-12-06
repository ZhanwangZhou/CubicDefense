using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public int damage = 50;
    public int scatterDamage = 25;
    public float scatterRadius = 20.0f;
    public float speed = 50;

    public GameObject SparkPrefab;
    
    private List<GameObject> targets;

    private void Update()
    {
        if(targets != null && targets.Count > 0 && targets[0] != null)
        {
            transform.LookAt(targets[0].transform.position);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }else{
            Die();
            return;
        }

        if(Vector3.Distance(transform.position, targets[0].transform.position) < 0.5)
        {
            for(int i = 1; i < targets.Count; ++i){
                if(targets[i] != null && Vector3.Distance(transform.position, targets[i].transform.position) < scatterRadius)
                {
                    targets[i].GetComponent<Enemy1>().TakeDamage(scatterDamage);
                }
            }
            Die();
            targets[0].GetComponent<Enemy1>().TakeDamage(damage);
        }
    }

    public void SetTargets(List<GameObject> _targets)
    {
        targets = _targets;
    }

    private void Die()
    {
        Destroy(this.gameObject);
        GameObject spark = GameObject.Instantiate(SparkPrefab, transform.position, Quaternion.identity);
        Destroy(spark, 1);
    }
}

