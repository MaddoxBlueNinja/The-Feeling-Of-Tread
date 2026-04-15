using UnityEngine;

public class HazardScript : MonoBehaviour
{

    GameObject Player;
    bool Whacked = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }
    void ResetWhack()
    {
        Whacked = false;
    }

    void OnTriggerEnter(Collider ouch)
    {
        
        if (ouch.tag == "Player" && Whacked == false)
        {

            Whacked = true;
            PlayerScript Bossy = Player.GetComponent<PlayerScript>();
            Bossy.takedamageandteleport();
            Invoke("ResetWhack",0.5f);
           // Destroy(gameObject);
        }
    }
}
