using UnityEngine;
using System.Collections;

public class Level1_locateShip : TreasureIsland {
	
	Color BackColor;//цвет поумолчанию.
	
	// Use this for initialization
	void Start () {
		BackColor = this.gameObject.renderer.material.color; //цвет по умолчанию.
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseEnter () {	//меняем цвет клетки
		if(SelectShip == true){
		this.gameObject.renderer.material.color = new Color(0.0f,0.0f,50.0f,10.0f);
		if(selectedObjectPool != null)
			selectedObjectPool.transform.position = new Vector3(this.transform.position.x, 40.0f, this.transform.position.z);
		}
	}
	
	void OnMouseExit () {	//возвращаем цвет клетки по умолчанию
		if(SelectShip == true)
		this.gameObject.renderer.material.color = BackColor;
		/*if(selectedObjectPool != null)
			selectedObjectPool.transform.position = new Vector3(-95.0f, 40.0f,-600.0f);*/
	}
	
	void OnMouseDown () {
		//проверка повтора выбора ячейки
		bool test = true;
		for(int iTest = 1; iTest < 6; iTest++){
			if(ActionCellUser[iTest] == this.gameObject.tag){
				test = false;
				break;
			}
		}
		//Установка корабля в клетке
		if(SelectShip == true && test == true){
			SelectShip = false;
			selectedObjectPool.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
		
			//запоминаем выбранную ячейку (имя её тега)
			ActionCellUser[ship] = this.gameObject.tag;
			selectedObjectPool = null;
			cameraMove = true;
			ship--;
			this.gameObject.renderer.material.color = BackColor;	//цвет клетки по умолчанию
		}
		//---------------------------------------
	}
}
