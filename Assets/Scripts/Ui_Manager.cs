using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class Ui_Manager : MonoBehaviour
{
    public TMP_Text livesText;
    public TMP_Text wumpaFruitText; 

    public PlayerController1 playerController1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = "Lives: " + playerController1.lives;

        wumpaFruitText.text = "Fruits: " + playerController1.fruits;
    }
}
