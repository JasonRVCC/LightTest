using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour 
{
	public float speed;
	private int count;
	public float startingGlowInten;
	public float startingGlowRange;
	public float glowIntenIncrease;
	public float glowRangeIncrease;
	public float decreaseTime;
	public float glowIntenDecrease;
	public float glowRangeDecrease;
	private float currentTime = 0f;
	//public float colorIncrease;
	//private Material playerMaterial;
	//private float currentBlue;
	//private float currentGreen;

	public GUIText countText;
	public GUIText winText;
	public Light glow;

	void Start()
	{
		count = 0;
		SetCountText();
		winText.text = "";
		glow.intensity = startingGlowInten;
		glow.range = startingGlowRange;
		//playerMaterial = this.renderer.material;
		//currentGreen = this.renderer.material.color.g;
		//currentBlue = this.renderer.material.color.b;
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		rigidbody.AddForce(movement * speed * Time.deltaTime);

		DecreaseLight ();
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.tag == "PickUp") 
		{
			other.gameObject.SetActive(false);
			count += 1;
			IncreaseLight();
			SetCountText();
		}
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString();
		if (count >= 12) 
		{
			winText.text = "YOU WIN!";
		}
	}

	void IncreaseLight()
	{
		glow.intensity += glowIntenIncrease;
		glow.range += glowRangeIncrease;
		//currentBlue += colorIncrease;
		//currentGreen += colorIncrease;
		//playerMaterial.color = new Color(1.0f, currentGreen, currentBlue);
	}

	void DecreaseLight()
	{
		currentTime += Time.deltaTime;
		if (currentTime > decreaseTime) 
		{
			glow.intensity -= glowIntenDecrease;
			glow.range -= glowRangeDecrease;
			currentTime = 0;
		}
	}
}
