using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool mIsGameOver = false;
    public bool mIsLowEnough = true;

    private float mGravityModifier = 1.5f;
    private float mFloatForce = 50.0f;
    private float mHeightLimit = 10.0f;
    private Rigidbody mPlayerRB;

    public ParticleSystem mFireworksPtcl;
    public ParticleSystem mExplosionPtcl;

    private AudioSource mPlayerAudio;
    public AudioClip mExplodeSFX;
    public AudioClip mGroundSFX;
    public AudioClip mMoneySFX;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= mGravityModifier;
        mPlayerRB = GetComponent<Rigidbody>();
        mPlayerAudio = GetComponent<AudioSource>();

        // Apply a small upward force at the start of the game
        mPlayerRB.AddForce(Vector3.up * mFloatForce, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        // While space is pressed and player is low enough, float up
        if (Input.GetKeyDown(KeyCode.Space) && !mIsGameOver && mIsLowEnough)
        {
            mPlayerRB.AddForce(Vector3.up * mFloatForce, ForceMode.Impulse);
            mIsLowEnough = false;
        }

        if (transform.position.y < mHeightLimit)
        {
            mIsLowEnough = true;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            mExplosionPtcl.Play();
            mPlayerAudio.PlayOneShot(mExplodeSFX, 1.0f);
            mIsGameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        }

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            mFireworksPtcl.Play();
            mPlayerAudio.PlayOneShot(mMoneySFX, 1.0f);
            Destroy(other.gameObject);
        }

        else if (other.gameObject.CompareTag("Ground") && !mIsGameOver)
        {
            mPlayerRB.AddForce(Vector3.up * mFloatForce * 2, ForceMode.Impulse);
            mPlayerAudio.PlayOneShot(mGroundSFX, 1.0f);
        }

    }

}
