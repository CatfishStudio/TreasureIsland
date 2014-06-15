using UnityEngine;
using System;
using System.Collections;
//устанавливаем дополнительную систему для возможности работать с листингами
using System.Collections.Generic;

public class TreasureIsland : MonoBehaviour {
	
	public Texture2D cursorGame;			//курсор
	
	static public int shipsUser = 5;		//количество оставшихся кораблей у пользователя
	static public int shipsPC = 5;			//количество оставшихся кораблей у компьютера
	static public bool battleBegin = false;	//отметка начала сражения.
	static public bool soundPlay = true;	//определение включена ли музыка.
	static public bool cameraMove = true;	//разрешение движения камеры
	static public int LevelGame = 1;		//Пройденый уровень
	static public int ship = 5;				//количество доступных кораблей
	static public bool SelectShip = false;	//отметка выбора корабля
	static public bool shoot = true;		//разрешение на выстрел пользователю.
	static public string whoShoots = "User";//первый выстрел за пользователем
	static public string targetForBall = "Null";	//имя цели для огненного ядра.
	static public GameObject selectTarget;	//объект выбранная цель пользователем (клетка ПК).
	
	static public string[] ActionCellUser = new string[6];	//теги ячеек занятых под корабли Пользователя
	static public string[] ActionCellPC = new string[6];	//теги ячеек занятых под корабли ПК
	
	//Object pool ------------------------------------------------------------------
	static public List<Transform> poolCellsUser;			//список объектов
	static public List<Transform> poolCellsPC;				//список объектов
	static public List<Transform> poolShipsUser;			//список объектов
	static public List<Transform> poolShipsPC;				//список объектов
	static public Transform selectedObjectPool;		//Выбранный элемент пула
	//------------------------------------------------------------------------------
	
	void Awake() {
		//....
	}
	
	void Update () {
	
	}
	
	void Start () {
		//DontDestroyOnLoad(this);
		
		changeCursor(cursorGame); //Замена курсора
		
	}
	
	void changeCursor(Texture2D curTexture){
		//Замена курсора
		CursorMode cursorMode = CursorMode.Auto;
        Vector2 hotSpot = Vector2.zero;
		Cursor.SetCursor(curTexture, hotSpot, cursorMode);
		//------------------------------------------------
	}
	
	
}
