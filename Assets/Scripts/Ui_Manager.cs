using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class Ui_Manager : MonoBehaviour
{
    public TMP_Text livesText;
    public TMP_Text wumpaFruitText; 

    public PlayerController playerController;

    // Update is called once per frame
    void Update()
    {
        livesText.text = "Lives: " + playerController.lives;

        wumpaFruitText.text = "Fruits: " + PlayerController.wumpaFruit;
    }
}
