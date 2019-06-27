using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2_Voice : MonoBehaviour {

	AudioSource sound;
    float musicVolume = 1f;

	public AudioClip [] Bgm;

	float distance;

	Transform player;
	Transform boss;
	bool isBoss;
	State state;
	enum State{
		Idle,
		bossAppear,
		bossDie,

	}
    // Start is called before the first frame update
    void Start()
    {
		player=GameObject.Find("Character").transform;
		boss=GameObject.Find("Boss").transform;

        sound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        sound.volume = musicVolume;

		if(boss!=null){
			distance=Vector2.Distance(boss.position,player.position);
		}
		
		if(boss==null && isBoss==true){
			state=State.bossDie;
			isBoss=false;
			distance=200;
		}
		
		if(distance<=16 && isBoss==false){
			state=State.bossAppear;
			isBoss=true;
		}


		switch (state){
			case State.bossAppear:
				sound.clip=Bgm[1];
				sound.Play();
				state=State.Idle;
				break;
			case State.bossDie:
				sound.clip=Bgm[2];
				sound.Play();
				state=State.Idle;
				break;
		}
    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }

    
}
