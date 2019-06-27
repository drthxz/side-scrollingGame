using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossDialog : MonoBehaviour {

    public State state;
    public enum State{
        idle,
        play,
        commu,
        exit,

    }
	Image playerImage;
    Image enemyImage;
    Image dialogbox;
    public Text talk;
    public string [] talktext;

	public bool dialog;

    public int dn = 0;

    AudioSource BGM;
    //AudioSource SE;

    Text controller;

    //public Tachi tachi;
    Transform enemy;
    //Transform player;

    float dis;

    bool con;
    [SerializeField]
    GameObject clearTitle;
	// Use this for initialization
	void Start () {
        
        playerImage = GameObject.Find("Canvas").transform.Find("PlayerImage").GetComponent<Image>();
        enemyImage = GameObject.Find("Canvas").transform.Find("EnemyImage").GetComponent<Image>();
        dialogbox = GameObject.Find("Canvas").transform.Find("dialogbox").GetComponent<Image>();
        controller= GameObject.Find("Canvas").transform.Find("Text").GetComponent<Text>();
        clearTitle= GameObject.Find("ClearTitle");

        BGM=GameObject.Find("UIObject").GetComponent<AudioSource>();
        //SE=GameObject.Find("Character").GetComponent<AudioSource>();

        //tachi=GameObject.Find("Character").GetComponent<Tachi>();

        enemy=GameObject.Find("Boss").transform;
        //player=GameObject.Find("Character").transform;

        playerImage.enabled = false;
        enemyImage.enabled = false;
        dialogbox.enabled = false;
        dialog=false;
        state=State.idle;
        clearTitle.SetActive(false);
        //tachi.enabled = false;
        
    }
	
	// Update is called once per frame
	void Update () {
        if(enemy!=null){
            dis=Vector2.Distance(enemy.position, Manager.instance.GetPlayer().transform.position);
        }else if(con==true && enemy==null){
            StartCoroutine(wait(3f));
            con=false;
            
        }

        if(dis<=16 && dis>=14 && con==false){
            StartCoroutine(wait(0.5f));
            con=true;
        }
        switch (state)
        {

            case State.commu:

                Commu();

                break;
            case State.exit:
                Exit();
                
                break;
	}
    }

    protected virtual void Commu(){
            
            //SE.Pause();
            
            dialogbox.enabled = true;
            controller.enabled= false;
            
            talk.text = talktext[dn];
            talk.enabled = true;
            if(dn==0){
                playerImage.enabled = true;
            }else if(dn==5){
                playerImage.enabled = true;
            }
            

            if (Input.GetKeyUp(KeyCode.J))
            {   
                if(dn<=7){
                    dn++;
                
                
                
                talk.text = talktext[dn];
                }
                if (dn <= 1 || dn==3 || dn>=5)
                {
                    playerImage.enabled = true;
                    enemyImage.enabled = false;
                }else{
                    enemyImage.enabled = true;
                    playerImage.enabled = false;
                }

                if (dn == 4)
                {
                    print(dn);
                    talk.text = talktext[dn];
                    dn++;
                    state = State.exit;
                    return;
                }else if(dn == 7) {
                    talk.text = talktext[dn];
                    dn++;
                    controller.enabled= true;
                    state = State.exit;
                    return;
                }
                
            }
            
        
    }


    protected virtual void Exit(){
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.J)){
            dialogbox.enabled = false;
            playerImage.enabled=false;
            enemyImage.enabled=false;
            talk.enabled = false;
            Time.timeScale=1;
            BGM.UnPause();
            //SE.UnPause();
            //tachi.enabled = true;
            
            if(dn == 8){
               StartCoroutine(next(0.5f));
               
            }
        }
    }


    IEnumerator wait(float time){
        
        yield return new WaitForSeconds(time);
        Time.timeScale=0;
        
        state = State.commu;
    }

    IEnumerator next(float time){
        
        yield return new WaitForSeconds(time);

        clearTitle.SetActive(true);
    }

}
