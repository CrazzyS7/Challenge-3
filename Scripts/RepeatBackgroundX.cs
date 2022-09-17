using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackgroundX : MonoBehaviour
{
    private Vector3 mStartPos = new Vector3(0, 0, 0);
    private float mRepeatWidth = 0.0f;

    private void Start()
    {
        mStartPos = transform.position; // Establish the default starting position 
        mRepeatWidth = GetComponent<BoxCollider>().size.x / 2; // Set repeat width to half of the background
    }

    private void Update()
    {
        // If background moves left by its repeat width, move it back to start position
        if (transform.position.x < mStartPos.x - mRepeatWidth)
        {
            transform.position = mStartPos;
        }
    }


}


