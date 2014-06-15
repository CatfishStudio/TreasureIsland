using UnityEngine;
using System.Collections;

public class menu_game : TreasureIsland {
	
	public Texture2D mapShipTexture;
	public Texture2D menuGameTexture;
	public Texture2D menuSettingsTexture;
	public Texture2D menuMapTexture;

	
	private string _TextButton = "";
	private float _rb1_x1, _rb1_y1, _rb1_x2, _rb1_y2;
	private float _rb2_x1, _rb2_y1, _rb2_x2, _rb2_y2;
	private float _rb3_x1, _rb3_y1, _rb3_x2, _rb3_y2;
	private float _rb4_x1, _rb4_y1, _rb4_x2, _rb4_y2;
	private float _rb5_x1, _rb5_y1, _rb5_x2, _rb5_y2;
	private float _rb6_x1, _rb6_y1, _rb6_x2, _rb6_y2;
	private float _rb7_x1, _rb7_y1, _rb7_x2, _rb7_y2;
	private float _rL1_x1, _rL1_y1, _rL1_x2, _rL1_y2;
	private Rect _rectButton1;
	private Rect _rectButton2;
	private Rect _rectButton3;
	private Rect _rectButton4;
	private Rect _rectButton5;
	private Rect _rectButton6;
	private Rect _rectButton7;
	private Rect _rectLabel1;
	private Rect _fon;
	
	private string _actionCameraName = "Camera1";
	private float timer = 0.0f;
	
	void Start () {
		_rb1_x1 = Screen.width / 2 - Screen.width / 6;
		_rb1_y1 = Screen.height / 8;
		_rb1_x2 = Screen.width  / 2 - Screen.width / 6;
		_rb1_y2 = Screen.height / 10;
		_rectButton1 = new Rect(_rb1_x1, _rb1_y1, _rb1_x2, _rb1_y2);
		_rb2_x1 = Screen.width  / 2 - Screen.width / 6;
		_rb2_y1 = Screen.height / 8 + Screen.height / 6;
		_rb2_x2 = Screen.width  / 2 - Screen.width / 6;
		_rb2_y2 = Screen.height / 10;
		_rectButton2 = new Rect(_rb2_x1, _rb2_y1, _rb2_x2, _rb2_y2);
		_rb3_x1 = Screen.width  / 2 - Screen.width / 6;
		_rb3_y1 = Screen.height / 8 + Screen.height / 3;
		_rb3_x2 = Screen.width  / 2 - Screen.width / 6;
		_rb3_y2 = Screen.height / 10;
		_rectButton3 = new Rect(_rb3_x1, _rb3_y1, _rb3_x2, _rb3_y2);
		_rb4_x1 = Screen.width  / 2;
		_rb4_y1 = Screen.height / 8 + Screen.height / 6;
		_rb4_x2 = Screen.width  / 4;
		_rb4_y2 = Screen.height / 10;
		_rectButton4 = new Rect(_rb4_x1, _rb4_y1, _rb4_x2, _rb4_y2);
		_rb5_x1 = Screen.width  / 2;
		_rb5_y1 = Screen.height / 8 + Screen.height / 3;
		_rb5_x2 = Screen.width  / 4;
		_rb5_y2 = Screen.height / 10;
		_rectButton5 = new Rect(_rb5_x1, _rb5_y1, _rb5_x2, _rb5_y2);
		_rb6_x1 = Screen.width / 20;
		_rb6_y1 = Screen.height - Screen.height / 12 * 2;
		_rb6_x2 = Screen.width / 10;
		_rb6_y2 = Screen.height - Screen.height / 12 * 11;
		_rectButton6 = new Rect(_rb6_x1, _rb6_y1, _rb6_x2, _rb6_y2);
		_rb7_x1 = Screen.width / 6;
		_rb7_y1 = Screen.height - Screen.height / 12 * 2;
		_rb7_x2 = Screen.width / 3;
		_rb7_y2 = Screen.height - Screen.height / 12 * 11;
		_rectButton7 = new Rect(_rb7_x1, _rb7_y1, _rb7_x2, _rb7_y2);
		_rL1_x1 = Screen.width / 4;
		_rL1_y1 = Screen.height / 8;
		_rL1_x2 = 128.0f;
		_rL1_y2 = 128.0f;
		_rectLabel1 = new Rect(_rL1_x1, _rL1_y1, _rL1_x2, _rL1_y2);
		_fon = new Rect(0.0f, 0.0f, Screen.width, Screen.height);
		
	}
	
	void Update () {
		timer += Time.deltaTime;
		if(timer > 0.4f){
			_rectLabel1 = new Rect(_rL1_x1 + 10, _rL1_y1, _rL1_x2 + 10, _rL1_y2);
			timer = -0.4f;
		}else{
			if(timer > 0.0f)
			_rectLabel1 = new Rect(_rL1_x1, _rL1_y1, _rL1_x2, _rL1_y2);
		}
	}
	
	void OnGUI(){
		if(_actionCameraName == "Camera1"){
			GUI.color = Color.white;
			GUI.DrawTexture(_fon, menuGameTexture);
			GUI.color = Color.yellow;
			if(GUI.Button(_rectButton1, "Новая игра.")){ 
				_actionCameraName = "Camera3";
			} 
			if(GUI.Button(_rectButton2,"Настройки.")){ 
				
				_actionCameraName = "Camera2";
			} 
			if(GUI.Button(_rectButton3,"Выход из игры.")){ 
				Application.Quit();
			} 
		}
		
		if(_actionCameraName == "Camera2"){
			GUI.color = Color.white;
			GUI.DrawTexture(_fon, menuSettingsTexture);
			GUI.color = Color.yellow;
			if(soundPlay){
				_TextButton = "Музыка включена.";
			}else _TextButton = "Музыка выключена.";
			if(GUI.Button(_rectButton4, _TextButton)){ 
				if(soundPlay){
					soundPlay = false;
					this.audio.Stop();
				}else{
					soundPlay = true;
					this.audio.Play();
				}
			} 
			if(GUI.Button(_rectButton5,"Назад.")){ 
				
				_actionCameraName = "Camera1";
			} 
			
		}
		
		if(_actionCameraName == "Camera3"){
			GUI.color = Color.white;
			GUI.DrawTexture(_fon, menuMapTexture);
			GUI.color = Color.white;
			if(GUI.Button(_rectButton6,"Назад.")){ 
				
				_actionCameraName = "Camera1";
			} 
			
			if(LevelGame == 1) _TextButton = "Начать 1-й уровень.";
			if(LevelGame == 2) _TextButton = "Начать 2-й уровень.";
			if(LevelGame == 3) _TextButton = "Начать 3-й уровень.";
			if(LevelGame == 4) _TextButton = "Начать 4-й уровень.";
			if(LevelGame == 5) _TextButton = "Начать 5-й уровень.";
							
			if(GUI.Button(_rectButton7, _TextButton)){ 
				Application.LoadLevel("Level1");
			} 
			
			GUI.Label(_rectLabel1,mapShipTexture);
			
			
		}
	}
}
