using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed =70f;

    private int damage = 50;

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

    }
    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(ImpactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);
        Damage(target);      
        Destroy(gameObject);
    }

    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
            e.TakeDamage(damage);
    }
}
