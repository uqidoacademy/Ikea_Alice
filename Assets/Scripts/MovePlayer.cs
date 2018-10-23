using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {

    [SerializeField]
    private float moveSpeed;


    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, moveSpeed * Time.deltaTime);

        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -3 *40 * Time.deltaTime, 0 );
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 3*40 * Time.deltaTime, 0);
        }
        

    }

}
