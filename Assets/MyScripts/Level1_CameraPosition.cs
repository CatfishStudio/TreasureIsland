using UnityEngine;
using System.Collections;

public class Level1_CameraPosition : TreasureIsland {
	
	private float positionCamera_X = -3.690704f;	//позоция Камеры по оси X
	private float positionCamera_Z;	//позоция Камеры по оси Z
	
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI(){
		
		//перемещение камеры ударживая левую кнопку мыши.==========================================
		if (Input.GetMouseButton(0) && cameraMove == true && battleBegin == false){
			//Перемещение по оси Х------------------------------------------- 
			if(positionCamera_X > -13.0f && positionCamera_X < 13.0f){
				if(positionCamera_X > 13.0f){
					positionCamera_X = 13.0f;
					this.transform.position = new Vector3(positionCamera_X, this.transform.position.y, this.transform.position.z);
				} else {
					if(positionCamera_X < -13.0f){
						positionCamera_X = -13.0f;
						this.transform.position = new Vector3(positionCamera_X, this.transform.position.y, this.transform.position.z);
					}else {
						positionCamera_X = -3.690704f;
						this.transform.position = new Vector3(Input.mousePosition.x / 100, this.transform.position.y, this.transform.position.z);
						positionCamera_X = this.transform.position.x;
					}
				}
			}else{
				positionCamera_X = -3.690704f;
				this.transform.position = new Vector3(-3.690704f, 117.6656f, -982.3153f);
			}
			
			
			//===========================================================
		}
	}
}
