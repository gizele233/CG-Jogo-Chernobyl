using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlaSolo : MonoBehaviour
{
	private Jogo controleJogo;
	private Rigidbody2D rBody;
	private bool instanciado;
    // Start is called before the first frame update
    void Start()
    {
        controleJogo = FindObjectOfType(typeof(Jogo)) as Jogo;
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rBody.velocity = new Vector2(controleJogo.velocidadeObjetos, 0);

        if(transform.position.x <= 0 && instanciado == false){
        	instanciado = true;
        	controleJogo.instanciarSolo(transform.position.x);
        }
        if(transform.position.x <= -7){
        	Destroy(this.gameObject);
        }
    }
}
