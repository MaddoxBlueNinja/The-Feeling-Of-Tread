using UnityEngine;

public class FireballScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    int Speed = 10;
    Vector3 BulletLook;
    GameObject Player;
    bool Whacked = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BulletLook = new Vector3(transform.forward.x, 0f, transform.forward.z);
        Player = GameObject.FindWithTag("Player");
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
        if (ouch.tag == "Player" && Whacked == false)
        {

            Whacked = true;
            PlayerScript Bossy = Player.GetComponent<PlayerScript>();
            Bossy.burn();
            Destroy(gameObject);
        }
    }
}
