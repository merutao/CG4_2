using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UCScript : MonoBehaviour
{
    //アニメーターコントローラー
    public Animator animator;
    public Rigidbody rb;
    public GameObject bullet;
    public GameObject gameManager;

    private GameManagerScript gameManagerScript; //scriptが入る変数

    float bulletTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        //scriptを取得する
        gameManagerScript = gameManager.GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKey(KeyCode.LeftShift)&&Input.GetKey(KeyCode.W))
        //{

        //    Vector3 velocity = new Vector3(0, 0, 2.0f);
        //    transform.position += transform.rotation * velocity * Time.deltaTime;
        //    animator.SetBool("mode", true);
        //    animator.SetBool("wait", false);
        //}
        //else 
        //{
        //    animator.SetBool("mode", false);
        //}

        //if (Input.GetKey(KeyCode.W))
        //{
        //    Vector3 velocity = new Vector3(0, 0, 1.0f);
        //    transform.position += transform.rotation * velocity * Time.deltaTime;
        //    animator.SetBool("walk", true);
        //    animator.SetBool("wait", false);
        //}
        //else
        //{
        //    animator.SetBool("walk", false);
        //}

        //if ( Input.GetKey(KeyCode.RightArrow))
        //{
        //    Vector3 worldAngle = transform.eulerAngles;
        //    worldAngle.y += 3.0f;
        //    transform.eulerAngles = worldAngle;
        //}

        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    Vector3 worldAngle = transform.eulerAngles;
        //    worldAngle.y -= 3.0f;
        //    transform.eulerAngles = worldAngle;
        //}

        //if(Input.GetKey(KeyCode.Space))
        //{
        //    animator.SetBool("Jump", true);
        //}
        //else
        //{
        //    animator.SetBool("Jump", false);
        //}

        float moveSpeed = 2.0f;
        float stageMax = 4.0f;
        if(Input.GetKey(KeyCode.RightArrow))
        {
            if(transform.position.x < stageMax) 
            {
                rb.velocity = new Vector3(moveSpeed, 0,0);
            }
            animator.SetBool("walk", true);
            animator.SetBool("wait", false);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x > -stageMax)
            {
                rb.velocity = new Vector3(-moveSpeed, 0, 0);
            }
            animator.SetBool("walk", true);
            animator.SetBool("wait", false);
        }
        else 
        {
            rb.velocity = new Vector3(0, 0, 0);
            animator.SetBool("walk", false);
        }

        
       

    }

    private void FixedUpdate()
    {
        if (bulletTimer == 0)
        {
            Vector3 position = transform.position;
            position.y += 0.8f;
            position.z += 1.0f;
            bulletTimer = 1;

            Instantiate(bullet, position, Quaternion.identity);
        }
        else 
        {
            bulletTimer++;
            if (bulletTimer > 20) 
            {
                bulletTimer = 0;
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            gameManagerScript.GameOverStart();
        }
    }
}
