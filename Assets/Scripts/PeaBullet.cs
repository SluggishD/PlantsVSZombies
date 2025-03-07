using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class PeaBullet : MonoBehaviour
{
    private float speed = 3;
    public int atkValue = 30;
    public GameObject PeaBulletHitPrefab;
    public void SetATKValue(int atkValue) 
    {
        this.atkValue = atkValue;
    }

    public void SetSpeed(float speed) 
    {
        this.speed = speed; 
    }  

    private void Start()
    {
        Destroy(gameObject,8);
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed*Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Zombie")
        {
            Destroy(this.gameObject);
            collision.GetComponent<Zombie>().TakeDamage(atkValue);
            GameObject go= GameObject.Instantiate(PeaBulletHitPrefab, transform.position,Quaternion.identity);
            Destroy(go,1);
        }
    }
}
