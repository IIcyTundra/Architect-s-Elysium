using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int DMG;
    public Player_SO P_Ref;

    void Awake()
    {
        StartCoroutine(GetRidOfBullet(5));
        Physics.IgnoreCollision(gameObject.GetComponent<SphereCollider>(), GetComponent<SphereCollider>());
    }

    IEnumerator GetRidOfBullet(int timer)
    {
        yield return new WaitForSeconds(timer);

        //Puts bullet back in pool just in case it goes out for too long
        BulletBehavior.Takeobj(gameObject);

    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetType() != typeof(SphereCollider) && !collision.gameObject.tag.Contains("Enemy"))
        {
            Debug.Log("D Here");
            BulletBehavior.Takeobj(gameObject);
        }
        
        if(collision.gameObject.tag.Contains("Player"))
        {
            Debug.Log("D there");
            BulletBehavior.Takeobj(gameObject);
            P_Ref.Health -= DMG;
        }
    }
}
