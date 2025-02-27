using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;

public class LogicManager : MonoBehaviour

{
    public GameObject gridObject;   // grid object containing the buttons
    public Sprite[] buttonSprites;  // 4 sprites
    private Button[] buttonsArray;  // Array to store buttons

    public Image correctImg;
    public Button nextBtn;
    public AudioManager audioManager;
    public TextMeshProUGUI  txtAnimated;
    private Animator questionMark;

    void Start()
    {
    //***************************************Buttons Images  Randomize********************************************************************************************//
        questionMark = GameObject.Find("txtAnimated").GetComponent<Animator>();

        buttonsArray = gridObject.GetComponentsInChildren<Button>();

        // Convert the sprite array into a List to track available sprites
        List<Sprite> availableSprites = new List<Sprite>(buttonSprites);

        // Assign each button a unique sprite
        foreach (Button btn in buttonsArray)
        {
           Image childImage = btn.transform.Find("Image").GetComponent<Image>(); // Get child Image component
       
                int randomIndex = Random.Range(0, availableSprites.Count); // Pick a random available sprite
                childImage.sprite = availableSprites[randomIndex];  // Assign sprite

                availableSprites.RemoveAt(randomIndex); // Remove from list to avoid duplicates

                btn.onClick.AddListener(() => checkResponse(btn)); //add onClick event listener for each btn
            
        }
    
    }
    //***************************************Game Logic **********************************************************************************************************//
    private void checkResponse(Button clickedBtn) {
         Image childImage = clickedBtn.transform.Find("Image").GetComponent<Image>();
        if(childImage.sprite == correctImg.sprite) {

            txtAnimated.gameObject.SetActive(false);
            correctImg.gameObject.SetActive(true) ;
            audioManager.WinSound();
            nextBtn.gameObject.SetActive(true);
            foreach (Button btn in buttonsArray) {
                btn.interactable = false;
            }
        } else {
            questionMark.SetTrigger("highlight");
            audioManager.Wrongound();
        }
    }
}
