using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManagerScript : MonoBehaviour
{
    [SerializeField]
    private Image _livesImg;
    [SerializeField]
    private Sprite[] _liveSprites;
    [SerializeField]
    private Text _gameOverText;
    [SerializeField]
    private Text _scoreText;

    private int _scoreAmount = 0;

    // Start is called before the first frame update
    void Start()
    {
        _gameOverText.gameObject.SetActive(false);
        _scoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(2);
        }
    }

    public void UpdateLives(int currentLives)
    {
        //Access display image and assign a new one based on current lives amount
        _livesImg.sprite = _liveSprites[currentLives];

        if (currentLives == 0)
        {
            _gameOverText.gameObject.SetActive(true);
        }
    }

    public void ScoreUpdate()
    {
        _scoreAmount++;
        _scoreText.text = System.Convert.ToString(_scoreAmount);
    }
}
