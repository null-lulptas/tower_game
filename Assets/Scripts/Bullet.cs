using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed =70f;
    public int damage = 50;
    public float explosionradius = 0f;
    public GameObject ImpactEffect;
    public void Seek(Transform _target)
    {
        target = _target;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }
    void HitTarget()
    {
       
        GameObject effectIns = (GameObject)Instantiate(ImpactEffect, transform.position, transform.rotation);
        
        Destroy(effectIns, 2f);
        
        if(explosionradius > 0f)
        {
            Explode();
        }
        else 
        {
            Damage(target);
        }
        Destroy(gameObject);
    }

    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
            e.TakeDamage(damage);
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionradius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }
}
