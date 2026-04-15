using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Boss1Script : MonoBehaviour
{
    int direction = -1;
    float AttackDelay = 0f;
    public GameObject Turret;
    public GameObject ThePlayer;
    public GameObject laser;
    public GameObject laserwalls;
    public GameObject laserstun;
    public BossHealth HP;
    //public GameObject thebossitself;

    bool stuffplaced = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void StunningLaser()
    {
        Instantiate(laserstun, Turret.transform.position, Turret.transform.rotation);
    }

    void LaserBlast()
    {
        
        Instantiate(laser,Turret.transform.position,Turret.transform.rotation);
    
    }
    void LaserBurst()
    {
        GameObject angledshot = Instantiate(laser, Turret.transform.position, Turret.transform.rotation);
        GameObject angledshot1 = Instantiate(laser, Turret.transform.position, Turret.transform.rotation);
        angledshot1.transform.Rotate(0, -20, 0,Space.Self);
        GameObject angledshot2 = Instantiate(laser, Turret.transform.position, Turret.transform.rotation);
        angledshot2.transform.Rotate(0, 20, 0, Space.Self);

    }


    // Update is called once per frame
    void Update()
    {
        Turret.transform.LookAt(new Vector3(ThePlayer.transform.position.x, Turret.transform.position.y, ThePlayer.transform.position.z));
        this.transform.position += new Vector3(direction * Time.deltaTime, 0, 0);
        if (this.transform.position.x < -3 && direction == -1)
        {
            direction = 1;
        }
        if (this.transform.position.x > 3 && direction == 1)
        {
            direction = -1;
        }
        AttackDelay += Time.deltaTime;

        if (AttackDelay > 3f)
        {
            AttackDelay = 0f;

            if (HP.bossHP < 26)

            {
                float choiceofattacks = Random.Range(0, 100);
                if (choiceofattacks > 33 && choiceofattacks < 66)
                {
                    AttackDelay = -1f;
                    Invoke("LaserBurst", 0.2f);
                    Invoke("LaserBlast", 0.4f);
                    Invoke("LaserBlast", 0.6f);
                }
                else if (choiceofattacks > 65)
                {
                    Invoke("LaserBurst", 0.2f);

                    Invoke("LaserBurst", 0.6f);
                }
                else
                {
                    Invoke("StunningLaser", 0.2f);
                    Invoke("LaserBlast", 0.4f);
                    Invoke("LaserBlast", 0.6f);

                }
            }
            else
            {
                

                float choiceofattacks = Random.Range(0, 100);

                if (choiceofattacks > 33 && choiceofattacks < 66)
                {
                    AttackDelay = -1f;
                    Invoke("LaserBlast", 0.2f);
                    Invoke("LaserBlast", 0.4f);
                    Invoke("LaserBlast", 0.6f);
                }
                else if (choiceofattacks > 65)
                {
                    Invoke("LaserBurst", 0.2f);
                }
                else
                {
                    Invoke("StunningLaser", 0.2f);
                }



            }
            




        }
        if (HP.bossHP < 15 && !stuffplaced)
        {
            stuffplaced = true;
            Instantiate(laserwalls, new Vector3(2.62f,.3f,-3.61f), this.transform.rotation);
            Instantiate(laserwalls, new Vector3(-2.62f, .3f, -3.61f), this.transform.rotation);
        }

        if (HP.bossHP < 1)
        {
            SceneManager.LoadScene("SecondBoss");
        }



    }


  //  void OnTriggerEnter(Collider ouch)
   // {
      //  if (ouch.tag == "Bullet")
       // {
           // Destroy(ouch.gameObject);
           // bosshealth--;
          //  print(bosshealth);
       // }
    //}

}
