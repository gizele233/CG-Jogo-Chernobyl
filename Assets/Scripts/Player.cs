using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private Jogo controleJogo;
	private Rigidbody2D rBody;
    // Start is called before the first frame update
    void Start()
    {
        controleJogo = FindObjectOfType(typeof(Jogo)) as Jogo;
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        float velocidade = controleJogo.velocidadePersonagem;
        rBody.velocity = new Vector2(horizontal * velocidade, vertical * velocidade);

        //verifica posição y do personagem e ajusta conforme limite definido
        if(transform.position.y > controleJogo.limiteYMaximo){
        	transform.position = new Vector3(transform.position.x, controleJogo.limiteYMaximo, 0);
        }else if(transform.position.y < controleJogo.limiteYMinimo){
        	transform.position = new Vector3(transform.position.x, controleJogo.limiteYMinimo, 0);

        }

        //verifica posição x do personagem e ajusta conforme limite definido
        if(transform.position.x > controleJogo.limiteXMaximo){
        	transform.position = new Vector3(controleJogo.limiteXMaximo, transform.position.y,  0);
        }else if(transform.position.y < controleJogo.limiteXMinimo){
        	transform.position = new Vector3(controleJogo.limiteXMinimo, transform.position.y,  0);

        }

    }
}
