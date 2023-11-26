using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;

    [Header("Attributes")]

    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public float turnSpeed = 10f;

    public GameObject bulletPrefab;
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f); //We want to call update target a few times a second not every frame.
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag); //Find all enemies with enemyTag and store them into the array

        float shortestDistance = Mathf.Infinity; //storing shortest distance to enemy found so far

        GameObject nearestEnemy = null; //nearest enemy found so far

        foreach(GameObject enemy in enemies) //looping through enemies
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position); //return the distance and then store in float

            if(distanceToEnemy < shortestDistance)// if our distance to enemy is less than our shortest distance then found an enemy closer than any we have found prevously
            {
                shortestDistance = distanceToEnemy; 
                nearestEnemy = enemy; //the nearest enemy we have found this far is this enemy
            }
        }

        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null) //if we dont have a target 
        {
            return; //reutrn and do nothing
        }

        //target lock on stuff here
        Vector3 dir = target.position - transform.position; //direction to face toward target
        Quaternion lookRotation = Quaternion.LookRotation(dir); //how to turn to look that toward target
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles; //we only want to rotate on y-axis so we need to convert to euler angles, need lerp so that it doesnt insta snap to target
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f); //rotating turret to face target

        if(fireCountdown <= 0) //if its time to fire
        {
            Fire();
            fireCountdown = 1f / fireRate; 
        }

        fireCountdown -= Time.deltaTime; // every second fire countdown will be reduced by 1


    }

    void Fire()
    {
        GameObject bulletObj = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); //teporarily store bullet into bulletObj, we cast the instantiated bullet to a game object to be stored
        Bullet bullet = bulletObj.GetComponent<Bullet>();

        if(bullet != null) //as long as the bullet object exist
        {
            bullet.HitTarget(target); //bullet will go hit the target the turret locked onto
        }
    }

    void OnDrawGizmosSelected() //drawing range of turret when turret is selected
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
