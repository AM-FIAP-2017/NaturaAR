using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Produto/Dados")]
public class ProductData : ScriptableObject
{
    [Tooltip("Nome do Produto")]
    public string nome;
    [Tooltip("Slogan do Produto")]
    public string slogan;

    [Tooltip("Imagem do Produto")]
    public Sprite imagem;

    [TextArea]
    [Tooltip("Descricao do Produto")]
    public string descriçao;

    [Tooltip("URL do Produto")]
    public string url;
}
