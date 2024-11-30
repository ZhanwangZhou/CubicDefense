using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public int damage = 25;
    private List<GameObject> targets;

    private void Update()
    {
        if(targets != null && targets.Count > 0 && targets[0] != null)
        {
            transform.LookAt(targets[0].transform.position);
        }else{
            Destroy(this.gameObject, 0.2f);
            return;
        }
        Destroy(this.gameObject, 0.2f);

        /*if(Vector3.Distance(transform.position, target.position) < 0.5)
        {
            Destroy(this.gameObject, 2f);
            target.GetComponent<Enemy1>().TakeDamage(damage);
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy"){
            other.GetComponent<Enemy1>().TakeDamage(damage);
        }
    }

    public void SetTargets(List<GameObject> _targets)
    {
        targets = _targets;
    }
}
