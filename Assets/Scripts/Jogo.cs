using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Jogo : MonoBehaviour
{
	[Header("Personagem")]
	public Transform tPlayer;

	public float velocidadePersonagem;
	[Header("Configuração limite Movimento Personagem")]
	public float limiteYMaximo;
	public float limiteYMinimo;
	public float limiteXMaximo;
	public float limiteXMinimo;

	[Header("Configuração da GamePlay")]
	public float velocidadeObjetos;
	public float intervaloEntreSpawnBarril;
	public int pontosGanhosPorBarril;
	
	[Header("Configuração do solo")]
	public GameObject prefabSolo;
    public float tamPrefabSolo;

    [Header("Configuração do barril")]
    public GameObject prefabBarril;
    public float posicaoXBarril;
    public float[] posicaoYBarril;
    public int[] ordemExibicao;

    [Header("Visual")]
    public Text txtPontos;
    private int pontos;

    [Header("fx")]
    public AudioSource Sfx;
    public AudioClip fxPontos;


    public void instanciarSolo(float posicaoX){
    	GameObject tempSolo = Instantiate(prefabSolo);
    	tempSolo.transform.position = new Vector3(posicaoX + tamPrefabSolo, tempSolo.transform.position.y, 0); //mantem o y do prefab e altera o x
    }

    private void start(){
    	StartCoroutine("spawnBarril");
    }

    IEnumerator spawnBarril(){
    	yield return new WaitForSeconds(intervaloEntreSpawnBarril); //espera esse tempo passar e após isso instancia

    	GameObject tempBarril = Instantiate(prefabBarril);
    	int rand = Random.Range(0, 2); //0 e 1
    	tempBarril.transform.position = new Vector3(posicaoXBarril, posicaoYBarril[rand], 0);
    	tempBarril.GetComponent<SpriteRenderer>().sortingOrder = ordemExibicao[rand];

    	StartCoroutine("spawnBarril"); //inicializar a co rotina
    }

    public void pontuar(){
    	pontos += pontosGanhosPorBarril;
    	txtPontos.text = "PONTOS: " + pontos.ToString();
    	Sfx.PlayOneShot(fxPontos, 0.7f);
    }

    public void GameOver(){
        SceneManager.LoadScene("GameOver");
    }


}
