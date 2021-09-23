using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] // Allows editing in editor
    private GameObject laser; // Declaring the GameObject 'laser'
    [SerializeField]
    private float movementSpeed; // Declares 'movementSpeed' variable
    [SerializeField]
    private AudioSource laserShot;

    [SerializeField]
    private float coolDownTime;
    private float timeStamp;

    private int _lives = 3; // Sets lives amount to 3

    private SpawnManagerScript _spawnMangerScript;

    private UIManagerScript _uiManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0); // Sets player transform position to (0, 0, 0)
        _spawnMangerScript = GameObject.Find("SpawnManager").GetComponent<SpawnManagerScript>();
        _uiManagerScript = GameObject.Find("Canvas").GetComponent<UIManagerScript>();
    }
    
    // Update is called once per frame
    void Update()
    {

        PlayerMovement(); // Calls 'PlayerMovement' function (below)

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > timeStamp) // Instantiates 'laser' prefab and checks if timestamp is less than Time.time
        {
            timeStamp = Time.time + coolDownTime;

            Instantiate(laser, new Vector3(transform.position.x, transform.position.y + 0.844f, transform.position.z), Quaternion.identity);
            laserShot.Play();
        }
    }

    void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // Definies horizontal axis
        float verticalInput = Input.GetAxis("Vertical"); // Defines vertical axis

        // ^^Variables^^

        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * movementSpeed * Time.deltaTime); // General input script: up, down, left & right

        /*
         * max top = 10 
         * max left = -10.3
         * max right = 10.3
         * max bottom = -0.71
         */

        if (transform.position.y >= 10.5f) // Player boundaries, moves player back a bit if X or Y amount is passed
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.3f, 0);
        }
        else if (transform.position.y <= -0.71f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.3f, 0);
        }
        else if (transform.position.x >= 10.3f)
        {
            transform.position = new Vector3(transform.position.x - 0.3f, transform.position.y, 0);
        }
        else if (transform.position.x <= -10.3f)
        {
            transform.position = new Vector3(transform.position.x + 0.3f, transform.position.y, 0);
        }
    }

    public void Damage()
    {
        _lives--;
        _uiManagerScript.UpdateLives(_lives); // Links to UI manager to update lives

        if (_lives < 1)
        {
            _spawnMangerScript.OnPlayerDeath();
            Destroy(this.gameObject);
        }
    }


}
