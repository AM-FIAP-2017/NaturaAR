using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Facebook.Unity;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;

    public GameObject touchParticlePrefab;

    public GameObject alertText;
    public GameObject product;


    public Image productImage;
    public Text produtctText;
    public Button facebookButton;
    public Button twitterButton;


    private ProductData data = null;
    private bool isConnected = false;


    void Awake()
    {
        if (instance == null)
            instance = this;


        if (!FB.IsInitialized)
        {
            FB.Init();    
        }
        else
        {
            FB.ActivateApp();
        }    
    }


    void Start()
    {
        DeactivateMenu();
    }

    void Update()
    {
        CheckConnection(Application.internetReachability);

        if (data != null)
        {
            ActivateMenu();
        }
        else
        {
            DeactivateMenu();
        }

    }

    private void ActivateMenu()
    {
        alertText.SetActive(false);
        product.SetActive(true);

        productImage.sprite = data.imagem;
        produtctText.text = data.descriçao;

        if (isConnected)
        {
            facebookButton.enabled = true;
            twitterButton.enabled = true;
        }
        
    }

    private void DeactivateMenu()
    {
        alertText.SetActive(true);

        productImage.sprite = null;
        produtctText.text = "";
        product.SetActive(false);
    }

    private void CheckConnection(NetworkReachability reach)
    {
        switch (reach)
        {
            case NetworkReachability.ReachableViaLocalAreaNetwork:
                Debug.Log("Usuario conectado via rede");
                isConnected = true;
                break;
            case NetworkReachability.ReachableViaCarrierDataNetwork:
                Debug.Log("Usuario conectado via 3G e afins");
                isConnected = true;
                break;
            case NetworkReachability.NotReachable:
                Debug.Log("Usuario nao conectado");
                isConnected = false;
                break;
        }
    }

    public void SetData(ProductData pData)
    {
        data = pData;
    }



    public void LogIn()
    {
        
    }


    public void Share()
    {
        FB.ShareLink(
            contentURL: new System.Uri(data.url),
            contentTitle: "Me dê um presente",
            contentDescription: "Eu quero um " + data.nome,
            photoURL: null,
            callback: OnShare);

        /*FB.FeedShare(
            link: new System.Uri(data.url),
            linkName: "Me dê um presente",
            linkCaption: "Eu quero um " + data.nome,
            linkDescription: "Nada melhor do que um produto com um toque de natureza",
            callback: OnShare
        );*/
    }

    public void GoToURL()
    {
        Application.OpenURL(data.url);
    }

    public void InstantiateParticle(Vector2 touchPosition)
    {
        GameObject particle = Instantiate(touchParticlePrefab, touchPosition, Quaternion.identity);
        particle.transform.parent = this.transform;
        Destroy(particle, 1.2f);
    }

    private void OnShare(IShareResult result)
    {
        if (result.Cancelled || !string.IsNullOrEmpty(result.Error))
        {
            Debug.Log("Share Link Error: " + result.Error);
        }
        else if (!string.IsNullOrEmpty(result.PostId))
        {
            Debug.Log(result.PostId);
        }
        else
        {
            Debug.Log("Conseguiu compartilhar");
        }
    }


}