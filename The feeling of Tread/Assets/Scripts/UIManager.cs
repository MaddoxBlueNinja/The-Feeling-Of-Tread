using UnityEngine;

public class UIManager : MonoBehaviour
{
    GameObject stunUI;
    GameObject burnUI;
    GameObject playerHpUI;
    GameObject bossHpUI;

    public bool isStunned = false;
    public bool isBurning = true;
    public float playerHp = 8;
    public float bossHp = 50;

    void Start()
    {
        stunUI = GameObject.Find("Stun UI");
        burnUI = GameObject.Find("Burn UI");
        playerHpUI = GameObject.Find("Player HP");
        bossHpUI = GameObject.Find("Boss HP");

        TMPro.TextMeshProUGUI playerHpText = playerHpUI.GetComponent<TMPro.TextMeshProUGUI>();
        TMPro.TextMeshProUGUI bossHpText = bossHpUI.GetComponent<TMPro.TextMeshProUGUI>();
    }

    void Update()
    {
        
    }
}
