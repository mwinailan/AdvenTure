using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{

    public GameObject dialogBox;
    public Text dialogText;
    public string dialogTextString;
    private string currentText = ""; 
    public bool playerInRange;
    public float timeDelay = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && playerInRange) {
            if (dialogBox.activeInHierarchy) {
                dialogBox.SetActive(false);
            } else {
                dialogBox.SetActive(true);
                StartCoroutine(ShowText());
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            playerInRange = true;

        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            playerInRange = false;
            dialogBox.SetActive(false);
        }
    }

    IEnumerator ShowText() {
        for (int i = 0; i <= dialogTextString.Length; i++) {
            currentText = dialogTextString.Substring(0,i);
            dialogText.text = currentText;
            yield return new WaitForSeconds(timeDelay);
        }
    }

    
}

