using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public bool isCollected=false;
    
    void ShowCoin(){
        this.GetComponent<SpriteRenderer>().enabled=true;
        this.GetComponent<CircleCollider2D>().enabled=true;
        isCollected=false;
    }
    //ocultar monedas una vez que se haya colisionado con ellas
    void HideCoin(){
        //obtener ambos componentes el sprite y el collider para desactivarlos
        this.GetComponent<SpriteRenderer>().enabled=false;
        this.GetComponent<CircleCollider2D>().enabled=false;
    }

    void CollectCoin(){
        //cambiar bandera a verdadero y ocultar moneda
        isCollected=true;
        HideCoin();
        GameManager.sharedInstance.CollectedCoins();
    }
    //evento de coalision del personaje con el objeto
    void OnTriggerEnter2D(Collider2D other){
        //si el hace colision con gameobject con tag de player se activa el metodo coleccionar moneda
        if (other.tag=="Player")
        {
            CollectCoin();            
        }

    }
}
