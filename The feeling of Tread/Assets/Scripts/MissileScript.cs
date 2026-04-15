using UnityEngine;

public class MissileScript : MonoBehaviour
{
    int Speed = 4;
    Vector3 BulletLook;
    GameObject Player;
    bool Whacked = false;
    float followingTime = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (followingTime < 5f)
        {
            transform.LookAt(new Vector3(Player.transform.position.x, transform.position.y, Player.transform.position.z));
            BulletLook = new Vector3(transform.forward.x, 0f, transform.forward.z);
            transform.position += BulletLook * Speed * Time.deltaTime;
        }
        else
        {
            Speed = 8;
            BulletLook = new Vector3(transform.forward.x, 0f, transform.forward.z);
            transform.position += BulletLook * Speed * Time.deltaTime;
        }
        followingTime += Time.deltaTime;


    }

    void OnTriggerEnter(Collider ouch)
    {
        if (ouch.tag == "Wall")
        {
            Destroy(gameObject);
        }
        if (ouch.tag == "Player" && Whacked == false)
        {

            Whacked = true;
            PlayerScript Bossy = Player.GetComponent<PlayerScript>();
            Bossy.takedamage();
            Destroy(gameObject);
        }
    }
}
