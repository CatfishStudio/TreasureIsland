using UnityEngine;
using System.Collections;

public class Level1_FireBall : TreasureIsland {
	
	public GameObject CameraSound;
	public Level1_Sound L1s;
	
	public Transform target;
	public Transform targetDefault;
	public int moveSpeed;
	public int rotationSpeed;
	private Transform _myTransform;
	private Vector3 _vBall;
	private float _vbX, _vbY, _vbZ;
	bool targetDestroy = false;	//цель уничтожена
	float timer = 0.0f;	//таймер
	System.Random rnd = new System.Random();	//генерация случайных чисел.
	
	
	// до старта ----------------------------------------------------
	void Awake() {
		_myTransform = transform;	
	}
	
	void Start () {
		_vbX = -95.0f;
		_vbY = -10.0f;
		_vbZ = -600.0f;
		_vBall = new Vector3(_vbX, _vbY, _vbZ);
		_myTransform.transform.position = _vBall;
		_myTransform.particleSystem.Play();
		L1s = (Level1_Sound)CameraSound.GetComponent("Level1_Sound");
	}
	
	void Update () {
		
		//Выстрел компьютера ===========================================================
		if(whoShoots == "PC"){
			if(targetForBall != "Null"){
				Debug.DrawLine(target.position, _myTransform.position, Color.yellow);
				_myTransform.rotation = Quaternion.Slerp(_myTransform.rotation, Quaternion.LookRotation(target.position - _myTransform.position), rotationSpeed * Time.deltaTime);
				_myTransform.position += _myTransform.forward * moveSpeed * Time.deltaTime;
				
				if(target.gameObject.tag == "TargetBall"){	//промежуточная цель
					//Определение дистанции до промежуточной цели.
					if(Vector3.Distance(target.position, _myTransform.position) < 2.0f){
						target = selectTarget.transform;
					}
				}else{
					//Определение дистанции до клетки цели.
					if(Vector3.Distance(target.position, _myTransform.position) < 2.0f){
						//Определение: Цель или пусто.
						for (int i = 1; i < 6; i++){
							if(ActionCellUser[i] == targetForBall){
								this.gameObject.particleSystem.startSize = 100;	//взрыв
								this.gameObject.particleSystem.startLifetime = 1;
								int indexPool = i;
								if(i == 5) indexPool = 0;
								if(i == 4) indexPool = 1;
								if(i == 3) indexPool = 2;
								if(i == 2) indexPool = 3;
								if(i == 1) indexPool = 4;
								poolShipsUser[indexPool].transform.particleSystem.Play();
								targetDestroy = true;
								targetForBall = "Null";
								timer = 0.0f;
								//звук взрыва.
								L1s.Boom();
								//--------------
								break;
							}
						}
						
						//если цель не уничтожена.
						if(targetDestroy == false){
							timer = 0.0f;
							targetDestroy = false;
							whoShoots = "User";
							_myTransform.transform.position = new Vector3(-95.0f, -10.0f, -600.0f);
							target = targetDefault;
							targetForBall = "Null";
							shoot = true;
						}
					}
				}
			}
			//если цель уничтожена
			if(targetDestroy == true){
				timer += Time.deltaTime;
				if (timer >= 1.0f){
					
					this.gameObject.particleSystem.startSize = 25;	//взрыв
					this.gameObject.particleSystem.startLifetime = 0.1f;
					timer = 0.0f;
					targetDestroy = false;
					whoShoots = "Usel";
					
					_myTransform.transform.position = new Vector3(-95.0f, -10.0f, -600.0f);
					target = targetDefault;
				
					targetForBall = "Null";
					shoot = true;
					shipsUser--;
				}
			}
		}
		//==============================================================================
		
		//Выстрел пользователя =========================================================
		if(whoShoots == "User"){
			if(targetForBall != "Null"){
				
				Debug.DrawLine(target.position, _myTransform.position, Color.yellow);
				_myTransform.rotation = Quaternion.Slerp(_myTransform.rotation, Quaternion.LookRotation(target.position - _myTransform.position), rotationSpeed * Time.deltaTime);
				_myTransform.position += _myTransform.forward * moveSpeed * Time.deltaTime;
		
				
				if(target.gameObject.tag == "TargetBall"){	//промежуточная цель
					//Определение дистанции до промежуточной цели.
					if(Vector3.Distance(target.position, _myTransform.position) < 2.0f){
						target = selectTarget.transform;
					}
				}else{
					//Определение дистанции до клетки цели.
					if(Vector3.Distance(target.position, _myTransform.position) < 2.0f){
						//Определение: Цель или пусто.
						for (int i = 1; i < 6; i++){
							if(ActionCellPC[i] == targetForBall){
								this.gameObject.particleSystem.startSize = 100;	//взрыв
								this.gameObject.particleSystem.startLifetime = 1;
								int indexPool = i - 1;
								poolShipsPC[indexPool].transform.position = new Vector3(poolShipsPC[indexPool].transform.position.x, poolShipsPC[indexPool].transform.position.y + 50.0f, poolShipsPC[indexPool].transform.position.z);
								poolShipsPC[indexPool].transform.particleSystem.Play();
								targetDestroy = true;
								targetForBall = "Null";
								//звук взрыва.
								L1s.Boom();
								//--------------
								break;
							}
						}
						
						//если цель не уничтожена.
						if(targetDestroy == false){
							timer = 0.0f;
							targetDestroy = false;
							whoShoots = "PC";
							_myTransform.transform.position = new Vector3(90.0f, -10.0f, -600.0f);
							target = targetDefault;
							//Генерация случайного выстрела ПК -----------------------
							targetForBall = choicePC();	//генерация выбора выстрела ПК
							//--------------------------------------------------------
						}
					}
				}
			}
			
			//если цель уничтожена
			if(targetDestroy == true){
				timer += Time.deltaTime;
				if (timer >= 1.0f){
						
					this.gameObject.particleSystem.startSize = 25;	//взрыв
					this.gameObject.particleSystem.startLifetime = 0.1f;
					timer = 0.0f;
					targetDestroy = false;
					whoShoots = "PC";
					
					_myTransform.transform.position = new Vector3(90.0f, -10.0f, -600.0f);
					target = targetDefault;
					shipsPC--;
					
					//Генерация случайного выстрела ПК -----------------------
					targetForBall = choicePC();	//генерация выбора выстрела ПК
					//--------------------------------------------------------
				}
			}
		}
		//==============================================================================
	}
	
	//функция генерации выбора ячейки для выстрела компьютера. ---------
	private string choicePC(){
		//Определении количества оставшихся кораблей.
		int CellUser = 1;
		CellUser = rnd.Next(0, poolCellsUser.Count);
		
		//проверка ячейки на предыдущий в неё выстрел
		while(poolCellsUser[CellUser].gameObject.transform.renderer.enabled == false){
			CellUser = rnd.Next(0, poolCellsUser.Count);
		}
		
		selectTarget = poolCellsUser[CellUser].gameObject;
		poolCellsUser[CellUser].gameObject.transform.renderer.enabled = false;
			
		//звук выстрела.
		L1s.Fire();
		//--------------
				
		return poolCellsUser[CellUser].gameObject.tag;
	}
}
