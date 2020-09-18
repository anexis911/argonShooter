using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] GameObject blowFX = null;
    [SerializeField] Transform parent=null;
    [SerializeField] int scoreForHit = 10;
    [SerializeField] int hits = 3;
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

        hits--;
        scoreBoard.ScoreHit(scoreForHit);
        if (hits <= 0)
        {
            GameObject blowf = Instantiate(blowFX, transform.position, Quaternion.identity);
            blowf.transform.parent = parent;

            Destroy(gameObject);
        }
        

    }
}
