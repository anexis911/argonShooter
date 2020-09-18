using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] GameObject blowFX = null;
    [SerializeField] Transform parent;
    [SerializeField] int scoreForHit = 10;
    ScoreBoard scoreBoard;
    private void Start()
    {
        AddNonTriggerBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddNonTriggerBoxCollider()
    {
        Collider enemyCollider = gameObject.AddComponent<BoxCollider>();
        enemyCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        GameObject blowf =  Instantiate(blowFX, transform.position, Quaternion.identity);
        blowf.transform.parent = parent;
        scoreBoard.ScoreHit(scoreForHit);
        scoreBoard.MakeNewScore();
        Destroy(gameObject);
    }
}
