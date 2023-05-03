using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMechanics : MonoBehaviour
{
    float Bulldmg;
    string Bulleffect;
    private SphereCollider SC;

    
    public void Awake()
    {
        
        StartCoroutine(GetRidOfBullet(3));
        Physics.IgnoreCollision(gameObject.GetComponent<SphereCollider>(), GetComponent<SphereCollider>());
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetType() != typeof(SphereCollider))
        {
            BulletBehavior.Takeobj(gameObject);
        }
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyBehavior>().TakeDamage(Bulldmg, Bulleffect);
        }

        
    }

    IEnumerator GetRidOfBullet(int timer)
    {
        yield return new WaitForSeconds(timer);

        //Puts bullet back in pool just in case it goes out for too long
        BulletBehavior.Takeobj(gameObject);

    }

    public void ApplyEffect(float dmg, string effect)
    {
        Bulldmg = dmg;
        Bulleffect = effect;
    }
}
