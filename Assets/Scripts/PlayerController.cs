using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController sharedInstance;
    public float jumpForce=25.0f;
    //capturamos el cuerpo rigido del personaje
    private Rigidbody2D rb;
    //capturando la capa del suelo 
    public LayerMask groundLayerMask;
    //animator 
    public Animator anim;
    public float runningSpeed=5.0f; 
    public AudioSource jumpSound;
    //posicion del jugador
    private Vector3 startPosition;
    private string highScoreKey="highscore";


    void Awake(){
        anim.SetBool("isAlive",true);
        rb=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        sharedInstance=this;
        startPosition=this.transform.position;
    }
    // Start is called before the first frame update
    public void StartGame()
    {
        anim.SetBool("isAlive",true);
        this.transform.position=startPosition;
        rb.velocity=new Vector2(0,0);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.sharedInstance.currentGameStates==GameState.inTheGame){
            //si click izquierdo
        if(Input.GetMouseButtonDown(0)){
            Debug.Log("Jump");
            
            Jump();
        }
        //si esta en el suelo cambiar el booleandoisGrounded segun el resultado del metodo isOnTheFloor
        anim.SetBool("isGrounded",IsOnTheFloor());
        }
        
    }

    void FixedUpdate(){
        if(GameManager.sharedInstance.currentGameStates==GameState.inTheGame){
           if(rb.velocity.x<runningSpeed){
            rb.velocity=new Vector2(runningSpeed,rb.velocity.y);
        } 
        }
        
    }

    void Jump(){
        /*le agregamos la fuerza al cuerpo rigido como 
        vector 2 es unitario se multiplica por la fuerza de salto definida*/
        if(IsOnTheFloor()){
            rb.AddForce(Vector2.up*jumpForce,ForceMode2D.Impulse);
            jumpSound.Play();
        }
        
    }

    //Lanzar un rayo para comprobar si el conejo esta en el suelo
    bool IsOnTheFloor(){
        /*accede al raycast mediante fisica2d , necesitando la posicion del 
        personaje, la direccion donde se lanza el rayo, la longitud del mismo y finalmente
        el valor de la capa usada*/
        if(Physics2D.Raycast(this.transform.position,Vector2.down,1.0f,groundLayerMask.value)){
            return true;
        }else{
            return false;
        }
    }

    public void KillPlayer(){
        GameManager.sharedInstance.GameOver();
        anim.SetBool("isAlive",false);

        if(PlayerPrefs.GetFloat(highScoreKey,0)<this.GetDistance()){
            PlayerPrefs.SetFloat(highScoreKey,this.GetDistance());
        }


    }

    //obtiene la distancia de viaje que lleva el jugador capturando starPosition y en donde va el jugador
    public float GetDistance(){
        float playerTraveler=Vector2.Distance(new Vector2(startPosition.x,0),new Vector2(this.transform.position.x,0));
        return playerTraveler;
    }
    
}
