using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    float moveSpeed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,5);
        transform.rotation = Quaternion.Euler(0,180,0);

        int r = Random.Range(0, 2);
        if(r == 0)
        {
            transform.rotation = Quaternion.Euler(0, 180 - 30, 0);
        }
        else 
        {
            transform.rotation = Quaternion.Euler(0, 180 + 30, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = new Vector3(0, 0, moveSpeed * Time.deltaTime);
        transform.position += transform.rotation * velocity;

        //ジグザグに
        if(transform.position.x > 4)
        {
            transform.rotation = Quaternion.Euler(0, 180 + 30, 0);
        }
        if(transform.position.x < -4)
        {
            transform.rotation = Quaternion.Euler(0, 180 - 30, 0);
        }
    }
}
