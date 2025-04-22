using TMPro;
using UnityEngine;

/*
 * Author: Omar Samu
 * Last Modified: 4/21/2025
 * Description: Handles TextMesh and manages the UI. 
*/

public class Ui_Manager : MonoBehaviour
{
	public static Ui_Manager Instance;

	PlayerController playerController;

	public TMP_Text livesText;
	public TMP_Text wumpaFruitText;

	[SerializeField] GameObject uiFruitPrefab;

	void Awake()
	{
		Instance = this;
	}
	
	void Start()
	{
		playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
	}

	// Update is called once per frame
	void Update()
	{
		livesText.text = "Lives: " + playerController.lives;
		
		wumpaFruitText.text = "Fruit: " + PlayerController.wumpaFruit;
	}

	public void DisplayFruit(int amount)
	{
		for (int i = 0; i < amount; i++)
		{
			Vector2 screenPos = new Vector2(Random.Range(0.15f, 0.85f), Random.Range(0.15f, 0.85f));

			RectTransform newFruit = Instantiate(uiFruitPrefab, transform).GetComponent<RectTransform>();
			newFruit.GetComponent<UIFruit>().Initialize(screenPos);
		}
	}
}
