using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameController : MonoBehaviour
{

    [SerializeField]
    float timer = 120f;

    int points;
    float currentTime;

    [SerializeField]
    TMP_Text textoScore;
    [SerializeField]
    TMP_Text textoTimer;



    void Awake()
    {
        currentTime = timer;
    }
    private void OnEnable()
    {
        GemController.OnCollected += OnCOllectibleCollected;
    }
    private void OnDisable()
    {
        GemController.OnCollected -= OnCOllectibleCollected;
    }
    void OnCOllectibleCollected()
    {
        textoScore.text = (++points).ToString();
    }
    void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            GameOver();
        }
       
    }

    void FixedUpdate()
    {
        int roundedTime = Mathf.RoundToInt(currentTime);
        textoTimer.text = roundedTime.ToString();
        
    }


    public void GameOver()
    {
        SessionManager.Instance.AddScore(points);
        Destroy(gameObject);
        LevelManager scene = FindObjectOfType<LevelManager>();
        scene.NextScene();
    }

    public void GameWon()
    {
        SessionManager.Instance.AddScore(points);
        Destroy(gameObject);
        LevelManager scene = FindObjectOfType<LevelManager>();
        scene.LastScene();
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Portal"))
    //    {
    //        GameOver();
    //    }
    //}






}
