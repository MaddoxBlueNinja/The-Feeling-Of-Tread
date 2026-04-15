using UnityEngine;

public class BossHealth : MonoBehaviour
{


    public int bossHP = 50;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void takedamage()
    {
        bossHP--;
        print(bossHP);
    }
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
