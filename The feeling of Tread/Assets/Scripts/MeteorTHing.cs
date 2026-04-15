using UnityEngine;

public class MeteorTHing : MonoBehaviour
{
    bool droppeddown = false;
    GameObject Player;
    public GameObject debris;
    bool collided = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!droppeddown)
        {
            this.transform.position += new Vector3(0, .1f, 0);
            if (this.transform.position.y > 12)
            {
                droppeddown = true;
                this.transform.position = new Vector3(Player.transform.position.x,12, Player.transform.position.z);
            }
        }
        else
        {
            this.transform.position += new Vector3(0, -.1f, 0);
        }


    }

    void OnTriggerEnter(Collider ouch)
    {
        if (ouch.tag == "Ground" && !collided)
        {
            collided = true;
            Instantiate(debris, new Vector3(this.transform.position.x, 0.2f, this.transform.position.z), this.transform.rotation);
            Destroy(gameObject);
        
        }
    }




        }
