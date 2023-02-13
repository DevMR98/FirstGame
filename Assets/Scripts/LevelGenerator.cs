using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    //singleton
    public static LevelGenerator sharedInstance;
    //almacenar los niveles creados
    public List<LevelBlock> allTheLevelBlocks=new List<LevelBlock>();
    //almacenar los bloques actuales 
    public List<LevelBlock> currentLevelBlocks=new List<LevelBlock>();
    //punto inicial donde se empezaran a crear el primer nivel de todos
    public Transform levelIniatialPoint;
    private bool isGenerateInitialBlocks=false;

    void Awake(){
        sharedInstance=this;
    }
    // Start is called before the first frame update
    void Start()
    {
       GenerateInitialBlocks();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateInitialBlocks(){
        isGenerateInitialBlocks=true;
        for (int i = 0; i < 3; i++)
        {
            AddNewBlock();
        }
        isGenerateInitialBlocks=false;
    }

    public void AddNewBlock(){
        //seleccionar un bloque aleatorio de los que tenemos disponibles
        int indexRandom=Random.Range(0,allTheLevelBlocks.Count);
        /*instantiate hacer una copia de un objeto*/
        LevelBlock block=(LevelBlock)Instantiate(allTheLevelBlocks[indexRandom]);

        if (isGenerateInitialBlocks)
        {
            indexRandom=0;            
        }

        block.transform.SetParent(this.transform,false);
        Vector3 blockPosition=Vector3.zero;

        if(currentLevelBlocks.Count==0){
            //vamos a colocar el primer bloque en pantalla
            blockPosition=levelIniatialPoint.position;
        }else{
            //ya tengo bloques disponibles tomare el final del anterior para generar el siguiente apartir de ahi 
            blockPosition=currentLevelBlocks[currentLevelBlocks.Count - 1].exitPoint.position;
        }

        block.transform.position=blockPosition;
        currentLevelBlocks.Add(block);
    }
    public void RemoveOldBlock(){
        LevelBlock block=currentLevelBlocks[0];
        currentLevelBlocks.Remove(block);
        Destroy(block.gameObject);
        //PlayerController.sharedInstance.runningSpeed+=0.2f;
        
    }

    public void RemoveAllTheBlock(){
        while (currentLevelBlocks.Count>0)
        {
            RemoveOldBlock();
        }
    }
}
