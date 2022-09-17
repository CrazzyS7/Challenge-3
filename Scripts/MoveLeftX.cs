using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftX : MonoBehaviour
{
    private PlayerControllerX mPlayerControllerScript;
    private float mLeftBound = -10.0f;
    private float mSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        mPlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
    }

    // Update is called once per frame
    void Update()
    {
        // If game is not over, move to the left
        if (!mPlayerControllerScript.mIsGameOver)
        {
            transform.Translate(Vector3.left * mSpeed * Time.deltaTime, Space.World);
        }

        // If object goes off screen that is NOT the background, destroy it
        if (transform.position.x < mLeftBound && !gameObject.CompareTag("Background"))
        {
            Destroy(gameObject);
        }

    }
}
