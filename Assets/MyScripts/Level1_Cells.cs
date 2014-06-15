using UnityEngine;
using System.Collections;
//устанавливаем дополнительную систему для возможности работать с листингами
using System.Collections.Generic;

public class Level1_Cells : TreasureIsland {
	
	System.Random rnd = new System.Random();	//генерация случайных чисел.
	
	public Texture2D arrowTexture;
	private float timer = 0.0f;
	
	public Texture2D YouWin;
	public Texture2D YouLose;
	
	private Vector3 _vPosCell;
	private float _vpX, _vpY, _vpZ;
	public Texture2D panelTexture;
	public GameObject objectCellUser;
	public GameObject objectCellPC;
	public GameObject objectShipUser;
	public GameObject objectShipPC;
	
	
	private Rect _Panel;
	private Rect _rectLabel1;	//стрелка
	//private Rect _rectWindow1;
	bool helpArrow = true;		//отображение стрелки помощи
	private Rect _rectButton1;	//+
	private Rect _rectButton2;	//-
	private Rect _rectButton3;	//Установить корабль
	private Rect _rectButton4;	//Сбросить
	private Rect _rectButton5;	//Начать сражение
	private Rect _rectButtonExit;	//кнопка выхода из игры
	private Rect _rectButtonBackMenu;	//кнопка возврата в меню
	private Rect _labelShipsUser;	//количество кораблей пользователя
	private Rect _labelShipsPC;	//количество кораблей ПК
	private Rect _labelEndGame;	//Результат сражения
	private float _rb1_x1, _rb1_y1, _rb1_x2, _rb1_y2;
	private float _rb2_x1, _rb2_y1, _rb2_x2, _rb2_y2;
	private float _rb3_x1, _rb3_y1, _rb3_x2, _rb3_y2;
	private float _rb4_x1, _rb4_y1, _rb4_x2, _rb4_y2;
	private float _rb5_x1, _rb5_y1, _rb5_x2, _rb5_y2;
	private float _rL1_x1, _rL1_y1, _rL1_x2, _rL1_y2;
	private float _rLEG_x1, _rLEG_y1, _rLEG_x2, _rLEG_y2;
	//private float _rW1_x1, _rW1_y1, _rW1_x2, _rW1_y2;
	private float _tpZ, _tpY;
	
	
	void Awake() {
		//назначаем новой переменной первое значение - пустой листинг
		poolCellsUser = new List<Transform>();	//инициализация
		poolCellsPC = new List<Transform>();	//инициализация
		poolShipsUser = new List<Transform>();	//инициализация
		poolShipsPC = new List<Transform>();	//инициализация
		//Создаём объекты уровня и записываем их в объектный пул. (Object pool)
		AddCellsUserInObjectPool();
		AddCellsPCInObjectPool();
		AddShipsPCInObjectPool();
	}
	
	void Start () {
		_Panel = new Rect(0.0f, 0.0f, Screen.width, Screen.height);
		_labelShipsUser = new Rect(Screen.width / 12, Screen.height / 8, 200.0f, 40.0f);
		_labelShipsPC = new Rect(Screen.width - Screen.width / 6, Screen.height / 8, 200.0f, 40.0f);
		_rectButtonExit = new Rect(Screen.width - 100, 0.0f, 100.0f, Screen.height / 10);
		_labelEndGame = new Rect(Screen.width / 2 - 200 ,Screen.height / 2 - 100, 400, 200);
		_rectButtonBackMenu = new Rect(Screen.width / 2 - 100, Screen.height / 2 + 100,200,50);
		_rb1_x1 = 5.0f;
		_rb1_y1 = Screen.height / 80;
		_rb1_x2 = Screen.width / 20;
		_rb1_y2 = Screen.height / 10;
		_rectButton1 = new Rect(_rb1_x1, _rb1_y1, _rb1_x2, _rb1_y2);
		_rb2_x1 = 5.0f;
		_rb2_y1 = Screen.height / 80 + Screen.height / 10 + Screen.width / 80;
		_rb2_x2 = Screen.width / 20;
		_rb2_y2 = Screen.height / 10;
		_rectButton2 = new Rect(_rb2_x1, _rb2_y1, _rb2_x2, _rb2_y2);
		_rb3_x1 = Screen.width  / 24;
		_rb3_y1 = Screen.height - Screen.height / 16;
		_rb3_x2 = Screen.width  / 2 - Screen.width / 4;
		_rb3_y2 = Screen.height - Screen.height / 2 - Screen.height / 2.2f;
		_rectButton3 = new Rect(_rb3_x1, _rb3_y1, _rb3_x2, _rb3_y2);
		_rb4_x1 = Screen.width  / 3;
		_rb4_y1 = Screen.height - Screen.height / 16;
		_rb4_x2 = Screen.width  / 2 - Screen.width / 3;
		_rb4_y2 = Screen.height - Screen.height / 2 - Screen.height / 2.2f;
		_rectButton4 = new Rect(_rb4_x1, _rb4_y1, _rb4_x2, _rb4_y2);
		_rb5_x1 = Screen.width  / 2 - Screen.width / 8;
		_rb5_y1 = Screen.height / 2.2f;
		_rb5_x2 = Screen.width  / 4;
		_rb5_y2 = Screen.height / 10;
		_rectButton5 = new Rect(_rb5_x1, _rb5_y1, _rb5_x2, _rb5_y2);
		_rL1_x1 = Screen.width  / 8;
		_rL1_y1 = Screen.height - Screen.height / 8;
		_rL1_x2 = Screen.width  / 4 - Screen.width / 6;
		_rL1_y2 = Screen.height - Screen.height / 4;
		_rectLabel1 = new Rect(_rL1_x1, _rL1_y1, _rL1_x2, _rL1_y2);
		//_rW1_x1 = Screen.width  / 4;
		//_rW1_y1 = Screen.height / 4;
		//_rW1_x2 = Screen.width  / 4 * 2;
		//_rW1_y2 = Screen.height / 4 * 2;
		//_rectWindow1 = new Rect(_rW1_x1, _rW1_y1, _rW1_x2, _rW1_y2);
		
		_tpZ = this.transform.position.z;
		_tpY = this.transform.position.y;
		
		//Музыка
		if(soundPlay == true){
			this.audio.Play ();
		}else this.audio.Stop();

	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if(timer > 0.4f){
			_rectLabel1 = new Rect(_rL1_x1, _rL1_y1 + 10, _rL1_x2, _rL1_y2 + 10);
			timer = -0.4f;
		}else{
			if(timer > 0.0f)
			_rectLabel1 = new Rect(_rL1_x1, _rL1_y1, _rL1_x2, _rL1_y2);
		}
	}
	
	void OnGUI(){
		GUI.color = Color.white;
		GUI.DrawTexture(_Panel, panelTexture);
		
		if(shipsPC < 1){
			//Выиграл пользователь
			GUI.Label(_labelEndGame, YouWin);
			whoShoots = "";
			if(GUI.Button(_rectButtonBackMenu, "Назад в меню.")){
				ClearScene();
			}
		}
		if(shipsUser < 1){
			//Выиграл ПК
			GUI.Label(_labelEndGame, YouLose);
			whoShoots = "";
			if(GUI.Button(_rectButtonBackMenu, "Назад в меню.")){
				ClearScene();
			}
		}
		
		//Перемещение по оси Z ---------------------------------------------------------------
		GUI.color = Color.yellow;
		if(GUI.Button(_rectButton1, "+")){
			if(_tpZ < - 700.0f){
			_tpZ += 30.0f;
			_tpY -= 10.0f;
			this.transform.position = new Vector3(this.transform.position.x, _tpY, _tpZ);
			}
		}
		if(GUI.Button(_rectButton2, "-")){
			if(_tpZ > - 1100.0f){
				_tpZ -= 30.0f;
				_tpY += 10.0f;
				this.transform.position = new Vector3(this.transform.position.x, _tpY, _tpZ);
			}
		}
		
		if(GUI.Button(_rectButtonExit, "Выход")){
			Application.Quit();	
		}
		
		if(battleBegin == false){	//если сражение еще не начато
			//Установка кораблей пользователя
			if(GUI.Button(_rectButton3, "Кораблей доступно: " + ship)){
				AddShipsUserInObjectPool();
			}
		
		
			if(GUI.Button(_rectButton4, "Сбросить.")){
				ship = 5;
				SelectShip = false;
				for(int iClear = 0; iClear < poolShipsUser.Count; iClear++)
					Destroy(poolShipsUser[iClear].gameObject);
				for(int iClear = 1; iClear < 6; iClear++)
					ActionCellUser[iClear] = "";
				poolShipsUser.Clear();
			}
		}else{
			GUI.color = Color.black;
			GUI.Label(_labelShipsUser, "Осталось: " + shipsUser);
			GUI.Label(_labelShipsPC, "Осталось: " + shipsPC);
			GUI.color = Color.yellow;
		}
		
		
		if(helpArrow){
			GUI.color = Color.white;
			GUI.Label(_rectLabel1, arrowTexture);
		}
		
		if(ship == 0){
			GUI.color = Color.yellow;
			if(GUI.Button(_rectButton5, "Начать сражение.")){
				battleBegin = true;
				ship = 5;
				Destroy(objectShipUser);
			}
		}
	}
	
	//Создание сетки пользователя
	void AddCellsUserInObjectPool(){
		_vpX = -185.0f;
		_vpY = 0.15f; //1.65f
		_vpZ = -692.0f;
		_vPosCell = new Vector3(_vpX, _vpY, _vpZ);
		for ( int i = 1; i < 6; i++){
			_vpX = _vpX + 30.0f;
			_vpZ = - 692.0f;
			for ( int n = 1; n < 6; n++)
        	{
				_vpZ = _vpZ + 30.0f;
				_vPosCell = new Vector3(_vpX, _vpY, _vpZ);
              	GameObject newObj = Instantiate(objectCellUser) as GameObject;
				newObj.transform.position = _vPosCell;
              	newObj.name = objectCellUser.name;
				newObj.tag = "CellUser" + i + "" + n;
			
				//Записать элемент в пул
				poolCellsUser.Add(newObj.transform);
        	}
		}
		Destroy(objectCellUser);	//удаляем шаблоны
	}
	
	//Создание сетки компьютера
	void AddCellsPCInObjectPool(){
		_vpX = 0.0f;
		_vpY = 0.15f;
		_vpZ = -692.0f;
		_vPosCell = new Vector3(_vpX, _vpY, _vpZ);
		for (int i = 1; i < 6; i++){
			_vpX = _vpX + 30.0f;
			_vpZ = - 692.0f;
			for (int n = 1; n < 6; n++){
				_vpZ = _vpZ + 30.0f;
				_vPosCell = new Vector3(_vpX, _vpY, _vpZ);
              	GameObject newObj = Instantiate(objectCellPC) as GameObject;
				newObj.transform.position = _vPosCell;
              	newObj.name = objectCellPC.name;
				newObj.tag = "CellPC" + i + "" + n;
				
				//Записать элемент в пул
				poolCellsPC.Add(newObj.transform);
			}
		}
		Destroy(objectCellPC);	//удаляем шаблоны
	}
	
	//Создание кораблей компьютера
	void AddShipsPCInObjectPool(){
		for (int i = 1; i < 6; i++){
			
			GameObject newObj = Instantiate(objectShipPC) as GameObject;
			newObj.name = objectShipPC.name;
			newObj.tag = "ShipPC" + i;
            ActionCellPC[i] = "CellPC" + choiceCellForShipPC(i);
			
			for(int iPool = 0; iPool < poolCellsPC.Count; iPool++){
				if(poolCellsPC[iPool].tag == ActionCellPC[i]){
					_vPosCell = new Vector3(poolCellsPC[iPool].transform.position.x, poolCellsPC[iPool].transform.position.y - 50.0f, poolCellsPC[iPool].transform.position.z);
					break;
				}
			}
			newObj.transform.position = _vPosCell;
			
			//Записать элемент в пул
			poolShipsPC.Add(newObj.transform);
		}
		Destroy(objectShipPC);	//удаляем шаблоны
	}
	
	//Размещение кормаблей пользователя
	void AddShipsUserInObjectPool(){
		
		
		if(ship > 0 && SelectShip == false){
			SelectShip = true;			//корабль выбран.
			cameraMove = false;			//запрещаем двигать камеру.
			helpArrow = false;			//убираем подсказку
			GameObject newObj = Instantiate(objectShipUser) as GameObject;
			newObj.name = objectShipUser.name;
			newObj.tag = "ShipUser" + ship;
			newObj.transform.position = new Vector3(-95.0f, 40.0f,-600.0f);
			selectedObjectPool = newObj.transform;
						
			//Записать элемент в пул
			poolShipsUser.Add(newObj.transform);
		}
	}
	
	//функция генерации выбора ячейки для корабля компьютера. ***********
	private string choiceCellForShipPC(int iPC){
		int rCellUser = 1;
		int cCellUser = 1;
		string TagCell = "";
		rCellUser = rnd.Next(1, 6);
		cCellUser = rnd.Next(1, 6);
		TagCell = "CellPC" + rCellUser + "" + cCellUser;
		while (ActionCellPC[1] == TagCell || ActionCellPC[2] == TagCell || ActionCellPC[3] == TagCell || ActionCellPC[4] == TagCell || ActionCellPC[5] == TagCell){
			rCellUser = rnd.Next(1,6);
			cCellUser = rnd.Next(1,6);
			TagCell = "CellPC" + rCellUser + "" + cCellUser;
		}
		return "" + rCellUser + "" + cCellUser;
	}
	//*******************************************************************
	
	private void ClearScene(){
		Application.LoadLevel("Start_Menu_Map");
		shipsUser = 5;
		shipsUser = 5;		//количество оставшихся кораблей у пользователя
		shipsPC = 5;			//количество оставшихся кораблей у компьютера
		battleBegin = false;	//отметка начала сражения.
		cameraMove = true;	//разрешение движения камеры
		LevelGame = 1;		//Пройденый уровень
		ship = 5;				//количество доступных кораблей
		SelectShip = false;	//отметка выбора корабля
		shoot = true;		//разрешение на выстрел пользователю.
		whoShoots = "User";//первый выстрел за пользователем
		targetForBall = "Null";	//имя цели для огненного ядра.
		for(int i = 0;	i < 6; i++){
			ActionCellUser[i] = "";
			ActionCellPC[i] = "";
		}
	}
}
