using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public UnityEngine.UI.Image menu;
    public UnityEngine.UI.Button start;
    public UnityEngine.UI.Text scoreText;
    public int score = 0;
    public bool isStarted = false;

    public static GameControllerScript instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        start.onClick.AddListener(delegate
        {
            menu.gameObject.SetActive(false);
            isStarted = true;
        });
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = $"Счет: {score}";
    }
}
