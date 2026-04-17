using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class PlayerScript : MonoBehaviour
{
    Vector2 moveInput;
    public int Lives = 8;
    public GameObject bullet;
   // GameObject Tank;
    public GameObject Turretpiece;
    float ReloadTime = 0f;
    public Transform player;
    float burnstuff = 0f;
    public float unstunstage = 5f;
    public float burned = 3f;
    public bool stunned = false;
   // float cameraVerticalRotation = 0f;
    // float horizontalMove;
    //  float verticalMove;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Tank = GameObject.Find("PlayerTank");
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (burned < 3f)
        {
            burned += Time.deltaTime;
            burnstuff += Time.deltaTime;
            if (burnstuff > 1f)
            {
                burnstuff = 0f;
                Lives--;

                if (Lives < 1)
                {
                    SceneManager.LoadScene("GameOver");
                }
            }
        }



        if (unstunstage > 4.9f)
        {
            Vector3 pos = this.transform.position;
            pos += new Vector3(moveInput.x * 0.02f, 0, moveInput.y * 0.02f);
            this.transform.position = pos;
        }

        if (unstunstage < 5f)
        {
            unstunstage += Time.deltaTime;
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (ReloadTime > 0.5f)
            {
                ReloadTime = 0f;
                Instantiate(bullet, Turretpiece.transform.position, Turretpiece.transform.rotation);
            }
        }
        ReloadTime += Time.deltaTime;
      //  print(unstunstage);

     
        // print(ReloadTime);
        //  transform.position += new Vector3(horizontalMove,0,verticalMove);


        float inputX = Input.GetAxis("Mouse X") * 2;
        //float inputY = Input.GetAxis("Mouse Y") * -2;

        // cameraVerticalRotation -= inputY;
        //cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);
        transform.localEulerAngles = Vector3.right;

        player.Rotate(Vector3.up * inputX);
    }
    public void takedamageandteleport()
    {
        Lives--;
       // print(Lives);
        this.transform.position = new Vector3(0,0.435f,0);

        if (Lives < 1)
        {
            SceneManager.LoadScene("GameOver");
        }

    }
    public void burn()
    {
        burned = 0f;
    }



    public void stun()
    {
        unstunstage = 0f;
        print("Stunned");
          
    }
    public void takedamage()
    {
        Lives--;
      //  print(Lives);
        if (Lives < 1)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

        void OnMove(InputValue val)
    {
        if (unstunstage > 4.9f)
        {
            moveInput = val.Get<Vector2>();
        }
    }
}
