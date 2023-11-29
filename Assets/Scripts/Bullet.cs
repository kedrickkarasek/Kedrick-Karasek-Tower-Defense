using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 70;
    public GameObject impactEffect;

    public int damage = 10;

    public void HitTarget(Transform _target) //function that will lock the bullet onto target
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null) //if the bullet loses its target so we destroy it
        {
            Destroy(gameObject);
            return; //breaking out
        }

        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(direction.magnitude <= distanceThisFrame) //check if the length of the direction vector is less than or equal to distance we move this frame then we hit something
        {
            Damage(target);
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);

    }

    void Damage(Transform _target)
    {
        Enemy e = _target.GetComponent<Enemy>();
        if (e != null)
        {
            e.TakeDamage(damage);
            GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(effectIns, 2f);
        }
    }
}
