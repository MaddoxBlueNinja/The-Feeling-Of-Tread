using UnityEngine;

public class BulletScript : MonoBehaviour
{
    int Speed = 20;
    Vector3 BulletLook;
    //GameObject BOSS;
    bool Whacked = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BulletLook = new Vector3(transform.forward.x, 0f, transform.forward.z);
      //  BOSS = GameObject.FindWithTag("Boss");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += BulletLook * Speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider ouch)
    {
        if (ouch.tag == "Wall")
        {
            Destroy(gameObject);
        }
        if (ouch.tag == "Boss" && Whacked == false)
        {

            Whacked = true;
            BossHealth Bossy = ouch.GetComponent<BossHealth>();
            Bossy.takedamage();
            Destroy(gameObject);
        }
    }
        
}
