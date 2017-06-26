using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NaturaARBehaviour : MonoBehaviour, IPointerDownHandler
{
    [Header("Canvas Produto")]
    [Tooltip("Canvas do produto, objeto pai de todos os elementos do canvas")]
    public GameObject productCanvas;

    [Header("Elementos do canvas")]
    [Tooltip("Slogan do produto, elemento do Canvas")]
    public GameObject sloganObject;
    [Tooltip("Descrição do produto, elemento do Canvas")]
    public GameObject descProdutoObject;
    [Tooltip("Botao de compra, elemento do canvas")]
    public GameObject btnCompraObject;

    [Header("Elementos de UI")]
    public Text sloganText;
    public Text descProdutoText;

    [Header("Dados")]
    [Tooltip("Objeto que contem os dados do produto")]
    public ProductData dados;

    //produtoTocado: boolean que alterna entre true e false toda vez que o produto é tocado;
    private bool produtoTocado = false;


    //OnBecameVisible: Procedimento que é chamado toda vez que o produto é renderizado pela camera;
    void OnBecameVisible()
    {
        //Chame a funcao setText para setar os dados do prodtuo no Canvas
        SetText();

        //Ative o elemento productCanvas e slogan;
        productCanvas.SetActive(true);
        sloganObject.SetActive(true);

        //Desative os elementos descProdutoObject e btnCompraObject
        descProdutoObject.SetActive(false);
        btnCompraObject.SetActive(false);
    }


    //OnPointerDown: Procedimento que é chamado toda vez que o produto é tocado;
    public void OnPointerDown(PointerEventData eventData)
    {
        //produto Tocado recebe o inverso do estado em que ele esta (i.e. se ele estiver true recebe false, se estiver false, recebe true);
        produtoTocado = !produtoTocado;
        sloganObject.SetActive(!produtoTocado);

        //Ative o elemento descProdutoObject;
        descProdutoObject.SetActive(produtoTocado);

        //Ative o elemento botao de compra;
        btnCompraObject.SetActive(produtoTocado);
    }


    //OnBecameInvisible: Procedimento que é chamado toda vez que o produto deixa de ser renderizado pela câmera;
    void OnBecameInvisible()
    {
        //Desative o elemento productCanvas;
        productCanvas.SetActive(false);
    }


    //IrParaSite: Procedimento que é chamado quando o elemento btnCompraObject é apertado;
    public void IrParaSite()
    {
        //Abre o URL indicado
        Application.OpenURL(dados.url);
    }

    //SetText: Procedimento que é chamado para setar os dados do produto nos elementos do Canvas;
    void SetText()
    {
        sloganText.text = dados.slogan;
        descProdutoText.text = dados.nome + "\n" + dados.descriçao;
    }

}
