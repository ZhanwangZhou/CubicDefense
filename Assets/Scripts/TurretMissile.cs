using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMissile : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    public GameObject bulletPrefab;
    public Transform leftBulletPosition;
    public Transform rightBulletPosition;

    private bool lastAttack = false;
    public float attackRate = 1f;
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
            List<GameObject> targets = GetTargets();
            if(targets != null && targets.Count > 0 && lastAttack)
            {
                GameObject bullet = GameObject.Instantiate(bulletPrefab, leftBulletPosition.position, Quaternion.identity);
                bullet.GetComponent<Missile>().SetTargets(targets);
                nextAttackTime = Time.time + attackRate;
                lastAttack = false;
            }else if(targets != null && targets.Count > 0)
            {
                GameObject bullet = GameObject.Instantiate(bulletPrefab, rightBulletPosition.position, Quaternion.identity);
                bullet.GetComponent<Missile>().SetTargets(targets);
                nextAttackTime = Time.time + attackRate;
                lastAttack = true;
            }
        }
    }

    public List<GameObject> GetTargets()
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
        if(enemies != null && enemies.Count > 0) return enemies;
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
