using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barril : MonoBehaviour
{
	private Jogo controleJogo;
	private Rigidbody2D rBody;
	private bool pontuado; 
    // Start is called before the first frame update
    void Start(){
		controleJogo = FindObjectOfType(typeof(Jogo)) as Jogo;
		rBody = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update(){
        rBody.velocity = new Vector2(controleJogo.velocidadeObjetos, 0);
        //verifica se a posição x do barril é menor que a do personagem então chama a função de pontuação
        if(transform.position.x <= controleJogo.tPlayer.position.x && pontuado == false){
        	controleJogo.pontuar();
        	pontuado = true;
        }
    }
}
