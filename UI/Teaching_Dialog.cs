using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Teaching_Dialog : MonoBehaviour {

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
    [SerializeField]
    Transform enemy;
    //Transform player;

    float dis;

    bool con;
	// Use this for initialization
	void Start () {
        
        playerImage = GameObject.Find("Canvas").transform.Find("PlayerImage").GetComponent<Image>();
        enemyImage = GameObject.Find("Canvas").transform.Find("EnemyImage").GetComponent<Image>();
        dialogbox = GameObject.Find("Canvas").transform.Find("dialogbox").GetComponent<Image>();
        //controller= GameObject.Find("Canvas").transform.Find("Text").GetComponent<Text>();

        BGM=GameObject.Find("UIObject").GetComponent<AudioSource>();

        //------------------------------------
        //SE=GameObject.Find("Character").GetComponent<AudioSource>();
        Manager.instance.GetPlayer().SwordEnable(true);
        //tachi=GameObject.Find("Character").GetComponent<Tachi>();

        enemy=GameObject.Find("Enemy").transform;
        //player=GameObject.Find("Character").transform;

        playerImage.enabled = false;
        enemyImage.enabled = false;
        dialogbox.enabled = false;
        dialog=false;
        state=State.idle;
        StartCoroutine(Wait(2f));
        
        //tachi.enabled = false;
        
    }
	
	// Update is called once per frame
	void Update () {
        if(enemy!=null){
            dis=Vector2.Distance(enemy.position,Manager.instance.GetPlayer().transform.position);
        }else if(con==true && enemy==null){
            StartCoroutine(Wait(2f));
            con=false;
            
        }

        if(dis<=13 && dis>=10 && con==false){
            //enemy.GetComponent<EnemyController>().stop = true;
            StartCoroutine(Wait(0.5f));
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
            
            BGM.Pause();
            //SE.Pause();
            
            dialogbox.enabled = true;
            //controller.enabled= false;
            
            talk.text = talktext[dn];
            talk.enabled = true;
            if(dn==0){
                playerImage.enabled = true;
            }else if(dn==2){
                enemyImage.enabled = true;
            }else if(dn==10){
                playerImage.enabled = true;
            }
            

            if (Input.GetKeyUp(KeyCode.J))
            {   
                if(dn<=11){
                    dn++;
                
                
                
                talk.text = talktext[dn];
                }
                if (dn <= 1 || dn==3 || (dn>=5 && dn<=7) || (dn>=10 && dn<=11))
                {
                    playerImage.enabled = true;
                    enemyImage.enabled = false;
                }else{
                    enemyImage.enabled = true;
                    playerImage.enabled = false;
                }

                if (dn == 1)
                {
                    print(dn);
                    talk.text = talktext[dn];
                    dn++;
                    state = State.exit;
                    return;
                }else if(dn == 9) {
                    talk.text = talktext[dn];
                    dn++;
                    //controller.enabled= true;
                    state = State.exit;
                    return;
                }else if(dn == 11) {
                    
                    talk.text = talktext[dn];
                    
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
            //if(enemy != null)
            //    enemy.GetComponent<EnemyController>().stop = false;
            Time.timeScale=1;
            BGM.UnPause();
            //SE.UnPause();
            //tachi.enabled = true;
            
            if(dn == 11){
               // StartCoroutine(next(3f));
            }
        }
    }


    IEnumerator Wait(float time){
        
        yield return new WaitForSeconds(time);
        Time.timeScale=0;
        
        state = State.commu;
    }

    IEnumerator Next(float time){
        
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("Level_1");
    }
}
