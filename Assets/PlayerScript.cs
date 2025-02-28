using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float birdstrength = 10;
    public float birdspeed = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Debug.Log("coo coo!");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true /*&& true*/)
        {
            rigidbody.linearVelocity = Vector2.up * birdstrength;
        }
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) == true /*&& true*/)
        {
            rigidbody.linearVelocity = Vector2.right * birdspeed;
        }
    }
    
    }

    
}
