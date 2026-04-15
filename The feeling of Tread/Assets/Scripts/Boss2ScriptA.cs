using UnityEngine;
using UnityEngine.SceneManagement;
public class Boss2ScriptA : MonoBehaviour
{

    int direction = -1;
    float AttackDelay = 0f;
    public GameObject Turret;
    public GameObject ThePlayer;
    public BossHealth HP;
    public GameObject Missile;
    public GameObject Focusfireball;
    public BossHealth OtherHP;
    public GameObject myself;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void FireShot()
    {
        Instantiate(Focusfireball, Turret.transform.position, Turret.transform.rotation);
    }
    void MissileShot()
    {
        Instantiate(Missile, Turret.transform.position, Turret.transform.rotation);
    }
    // Update is called once per frame
    void Update()
    {
        if (HP.bossHP < 1 && OtherHP.bossHP < 1)
        {
            SceneManager.LoadScene("Victory");
        }



        if (HP.bossHP > 0)
        {


            if (OtherHP.bossHP > 0)
            {
                Turret.transform.LookAt(new Vector3(ThePlayer.transform.position.x, Turret.transform.position.y, ThePlayer.transform.position.z));
                this.transform.position += new Vector3(0, 0, direction * Time.deltaTime * 3);
                if (this.transform.position.z < -12 && direction == -1)
                {
                    direction = 1;
                }
                if (this.transform.position.z > 12 && direction == 1)
                {
                    direction = -1;
                }
                AttackDelay += Time.deltaTime;

                if (AttackDelay > 4f)
                {
                    AttackDelay = 0f;
                    MissileShot();
                }
            }
            else
            {
                Turret.transform.LookAt(new Vector3(ThePlayer.transform.position.x, Turret.transform.position.y, ThePlayer.transform.position.z));
                this.transform.position += new Vector3(0, 0, direction * Time.deltaTime * 3);
                if (this.transform.position.z < -12 && direction == -1)
                {
                    direction = 1;
                }
                if (this.transform.position.z > 12 && direction == 1)
                {
                    direction = -1;
                }
                AttackDelay += Time.deltaTime;

                if (AttackDelay > 2f)
                {
                    AttackDelay = 0f;
                    MissileShot();
                    Invoke("FireShot", 0.2f);
                    Invoke("FireShot", 0.5f);
                    Invoke("FireShot", 0.8f);
                    Invoke("FireShot", 1.1f);
                }
            }
        }
        else
        {
           myself.SetActive(false);  
        }

    }
}
