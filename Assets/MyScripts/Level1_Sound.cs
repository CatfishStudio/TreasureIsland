using UnityEngine;
using System.Collections;

public class Level1_Sound : MonoBehaviour {
	
	public AudioClip soundFire;
	public AudioClip soundBoom;
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	//воспроизведение звука выстрела
	public void Fire(){
		audio.PlayOneShot(soundFire);
	}
	
	//воспроизведение звука взрыва
	public void Boom(){
		audio.PlayOneShot(soundBoom);
	}
}
