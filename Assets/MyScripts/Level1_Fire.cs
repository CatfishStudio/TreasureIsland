using UnityEngine;
using System.Collections;

public class Level1_Fire: TreasureIsland {
	
	Color BackColor;//цвет поумолчанию.
	public GameObject CameraSound;
	
	void Start () {
		BackColor = this.gameObject.renderer.material.color; //цвет по умолчанию.
	}
	
	void Update () {
		
		
	}
	
	void OnMouseDown () {
		if(battleBegin == true && shoot == true && this.gameObject.transform.renderer.enabled == true){	//если сражение началось и разрешен выстрел
			//звук выстрела.
			Level1_Sound L1s = (Level1_Sound)CameraSound.GetComponent("Level1_Sound");
			L1s.Fire();
			//--------------
			targetForBall = this.gameObject.tag;
			selectTarget = this.gameObject;
			whoShoots = "User";	//выстрел пользователя
			this.gameObject.transform.renderer.enabled = false;
			shoot = false;
		}
	}
	
	void OnMouseEnter () {
		this.gameObject.renderer.material.color = new Color(0.0f,0.0f,50.0f,10.0f);
	}
	
	void OnMouseExit () {
		this.gameObject.renderer.material.color = BackColor;
	}
}
