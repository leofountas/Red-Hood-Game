using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ButtonSpriteAssigner : MonoBehaviour
{
    public GameObject gridObject;   // Assign the grid object containing the buttons
    public Sprite[] buttonSprites;  // Assign 4 sprites in the inspector
    private Button[] buttonsArray;  // Array to store buttons

    void Start()
    {
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
            
        }
    }
}
