using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float timeOfReloadLvl = 1f;
    [SerializeField] GameObject deathFX = null;
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided"+ other.gameObject.name);
        StartDeathSequence();
        deathFX.SetActive(true);
        //Invoke("ReloadScene", timeOfReloadLvl);

    }

    void StartDeathSequence()
    {
        
        
        //SendMessage("OnPlayerDeath");
    }
    private void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }
}
