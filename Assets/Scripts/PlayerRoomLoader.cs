using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRoomLoader : MonoBehaviour
{

    
    public Animator transition;
    public int sceneToLoad;

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && !other.isTrigger) {
            LoadRoom();
        }
    }

    public void LoadRoom() {
        StartCoroutine(LoadScene(sceneToLoad));
    }

    IEnumerator LoadScene(int levelindex) {

        // Play loading animation
        transition.SetTrigger("Start");

        // Wait animation to finish
        yield return new WaitForSeconds(1f);
        
        // Load scene
        SceneManager.LoadScene(levelindex);


    }
}
