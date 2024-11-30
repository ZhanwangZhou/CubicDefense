using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretStandard : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    public GameObject bulletPrefab;
    public GameObject SparkPrefab;
    public Transform leftBulletPosition;
    public Transform rightBulletPosition;

    private bool lastAttack = false;
    public float attackRate = 0.5f;
    private float nextAttackTime;
    private Transform head;

    private void Start()
    {
        head = transform.Find("TurretObj");
    }

    private void Update()
    {
        Attack();
        DirectionControl();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            enemies.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Enemy")
        {
            enemies.Remove(other.gameObject);
        }
    }

    private void Attack()
    {
        if(enemies == null || enemies.Count == 0) return;
        if(nextAttackTime < Time.time)
        {
            Transform target = GetTarget();
            if(target != null && lastAttack)
            {
                GameObject bullet = GameObject.Instantiate(bulletPrefab, leftBulletPosition.position, Quaternion.identity);
                bullet.GetComponent<Projectile>().SetTarget(target);
                GameObject spark = GameObject.Instantiate(SparkPrefab, leftBulletPosition.position, Quaternion.identity);
                Destroy(spark, 0.2f);
                nextAttackTime = Time.time + attackRate;
                lastAttack = false;
            }else if(target != null)
            {
                GameObject bullet = GameObject.Instantiate(bulletPrefab, rightBulletPosition.position, Quaternion.identity);
                bullet.GetComponent<Projectile>().SetTarget(target);
                GameObject spark = GameObject.Instantiate(SparkPrefab, rightBulletPosition.position, Quaternion.identity);
                Destroy(spark, 0.2f);
                nextAttackTime = Time.time + attackRate;
                lastAttack = true;
            }
        }
    }

    public Transform GetTarget()
    {
        List<int> indexList = new List<int>();
        for(int i = 0; i < enemies.Count; ++i)
        {
            if(enemies[i] == null)
            {
                indexList.Add(i);
            }
        }
        for(int i = indexList.Count - 1; i >= 0; --i)
        {
            enemies.RemoveAt(indexList[i]);
        }
        if(enemies != null && enemies.Count > 0) return enemies[0].transform;
        return null;
    }

    private void DirectionControl()
    {
        Transform target = null;
        if(enemies != null && enemies.Count > 0 && enemies[0] != null)
        {
            target = enemies[0].transform;
        }
        if(target != null){
            head.LookAt(target.position);
        }
    }
}
