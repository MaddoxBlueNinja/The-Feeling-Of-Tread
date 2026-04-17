using UnityEngine;
//using 
public class UIManager2 : MonoBehaviour
{
    public GameObject stunUI;
    public GameObject burnUI;
    GameObject playerHpUI;
    GameObject bossHpUI;
    GameObject bossHpUI2;
    public BossHealth TheBoss;
    public BossHealth TheBoss2;
    public PlayerScript ThePlayer;

   // public bool isStunned = false;
   // public bool isBurning = true;
    public float playerHp = 8;
    public float bossHp = 50;

    void Start()
    {
       // stunUI = GameObject.Find("Stun UI");
       // burnUI = GameObject.Find("Burn UI");
        playerHpUI = GameObject.Find("Player HP");
        bossHpUI = GameObject.Find("Boss HP");
        bossHpUI2 = GameObject.Find("Boss HP2");

    }

    void Update()
    {
        TMPro.TextMeshProUGUI playerHpText = playerHpUI.GetComponent<TMPro.TextMeshProUGUI>();
        TMPro.TextMeshProUGUI bossHpText = bossHpUI.GetComponent<TMPro.TextMeshProUGUI>();
        TMPro.TextMeshProUGUI bossHpText2 = bossHpUI2.GetComponent<TMPro.TextMeshProUGUI>();
        bossHpText.text = "Boss: " + TheBoss.bossHP + "/ 25";
        bossHpText2.text = "Boss: " + TheBoss2.bossHP + "/ 25";
        playerHpText.text = "Lives: " + ThePlayer.Lives + "/ 8";
        if (ThePlayer.unstunstage > 4.9f)
        {
            stunUI.SetActive(false);
        }
        else
        {
            stunUI.SetActive(true);
        }
        if (ThePlayer.burned > 2.9f)
        {
            burnUI.SetActive(false);
        }
        else
        {
            burnUI.SetActive(true);
        }
    }
}
