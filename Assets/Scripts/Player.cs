using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform[] waypoints;
    [SerializeField] float movementSpeed = 5.0f;
    [SerializeField] AudioClip deathSoundClip;
    [SerializeField] AudioClip winSoundClip;
    [SerializeField] GameObject winVFX;
    [SerializeField] GameObject deathVFX;

    [SerializeField] [Range(0, 1)] float playerDeathSoundVolume = 0.4f;
    [SerializeField] [Range(0, 1)] float playerWinSoundVolume = 0.4f;
    int waypointIndex = 0;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (waypointIndex == waypoints.Length)
        {
            Win();
            Debug.Log("Player reached the end");
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, movementSpeed * Time.deltaTime);
            
            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }
        }
    }

    public void Die()
    {
      
        AudioSource.PlayClipAtPoint(deathSoundClip, Camera.main.transform.position, playerDeathSoundVolume);
        Instantiate(deathVFX, new Vector3(0, 0, 0), transform.rotation);
        Destroy(gameObject);
    }

    public void Win()
    {
        
        AudioSource.PlayClipAtPoint(winSoundClip, Camera.main.transform.position, playerWinSoundVolume);
        Instantiate(winVFX, new Vector3(0, 0, 0), transform.rotation);
        Destroy(gameObject);
    }

}
