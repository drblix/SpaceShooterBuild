using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    private float enemySpeed = 5f;

    private UIManagerScript _uiManagerScript;

    // Start is called before the first frame update
    void Start() 
    {
        _uiManagerScript = GameObject.Find("Canvas").GetComponent<UIManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * enemySpeed * Time.deltaTime);


        if (transform.position.y <= -1.83)
        {
            transform.position = new Vector3(Random.Range(-10.07f, 10.07f), 12, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collidingPart)
    {
        if (collidingPart.tag == "Laser")
        {
            Destroy(collidingPart.gameObject);
            Destroy(this.gameObject);
            _uiManagerScript.ScoreUpdate();
        }
        else if (collidingPart.tag == "Player")
        {
            PlayerScript playerScript = collidingPart.GetComponent<PlayerScript>();

            if (playerScript != null)
            {
                playerScript.Damage();

                Destroy(this.gameObject);
            }
        }
    }
}
