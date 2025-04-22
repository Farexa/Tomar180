using UnityEngine;

public class UIFruit : MonoBehaviour
{
	RectTransform rt;
	Vector2 startPos;
	
	Vector2 endPos = new Vector2(0, 1);

	float lifePercent = 0;
	float lifeTime = 1;

	[SerializeField] AnimationCurve positionCurve;
	[SerializeField] AnimationCurve sizeCurve;
	
	public void Initialize(Vector2 screenPos)
	{
		rt = GetComponent<RectTransform>();
		startPos = screenPos;

		SetPosition(Vector2.Lerp(startPos, endPos, positionCurve.Evaluate(lifePercent)));
		SetScale(sizeCurve.Evaluate(lifePercent));
	}
	
	void Update()
	{
		lifePercent += Time.deltaTime / lifeTime;
		if (lifePercent > 1)
		{
			Destroy(gameObject);
		}

		SetPosition(Vector2.Lerp(startPos, endPos, positionCurve.Evaluate(lifePercent)));
		SetScale(sizeCurve.Evaluate(lifePercent));
	}
	
	void SetPosition(Vector2 pos)
	{
		rt.anchorMin = pos;
		rt.anchorMax = pos;
	}
	
	void SetScale(float size)
	{
		rt.localScale = new Vector3(size, size, size);
	}
}