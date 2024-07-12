using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;
using TMPro; 



public class MainMenu : MonoBehaviour
{
   
   

    public  Text totalpuantext;     
                                  
                                  
    public  Text enyuksekpuantext;
    public static int totalpuan;
    public static int enyuksekpuan;

    public static string secilenkategori;
    public static int secilenzorluk;

    public GameObject ayarlarpanel;
    public GameObject secimpanel;
    public GameObject puanpanel;
    

    public Dropdown dropdown;

    

    void Start()

    {
       

        ayarlarpanel.SetActive(false);
        secimpanel.SetActive(false);
        puanpanel.SetActive(false);


        if (PlayerPrefs.HasKey("totalpuan")) // yani daha önce kayýtlýysa
        {
           
            totalpuan = PlayerPrefs.GetInt("totalpuan"); // para verisini çektik
            totalpuantext.text = totalpuan.ToString();
        }
        else // ilk oyununa giriyorsa
        {
            PlayerPrefs.SetInt("totalpuan", 0); 
            totalpuantext.text = PlayerPrefs.GetInt("totalpuan").ToString();
        }

        if (PlayerPrefs.HasKey("enyuksekpuan")) // yani daha önce kayýtlýysa
        {
           
            enyuksekpuan = PlayerPrefs.GetInt("enyuksekpuan");
            enyuksekpuantext.text = enyuksekpuan.ToString(); 
        }
        else 
        {
            PlayerPrefs.SetInt("enyuksekpuan", 0);
            enyuksekpuantext.text = PlayerPrefs.GetInt("enyuksekpuan").ToString();
        }


        if (PlayerPrefs.HasKey("secilenzorluk"))
        {
           
            secilenzorluk = PlayerPrefs.GetInt("secilenzorluk"); 
            
        }
        else 
        {
            PlayerPrefs.SetInt("secilenzorluk", 0);
            
        }
        Debug.Log("secilen zorluk "+ secilenzorluk);



        dropdown.value = secilenzorluk; 

       


        totalpuantext.text = totalpuan.ToString();
        enyuksekpuantext.text = enyuksekpuan.ToString();  
        Debug.Log(totalpuan);  

    }

     
  

    public void PanelAyarlari(int x)
    {
    
        if(x==0)
        {
            ayarlarpanel.SetActive(true);
           
        }
        if (x == 1)
        {
            ayarlarpanel.SetActive(false);
        }
        if (x == 2)
        {
            secimpanel.SetActive(true);
        }
        if (x == 3)
        {
            secimpanel.SetActive(false);
        }
        if (x == 4)
        {
            puanpanel.SetActive(true);
        }
        if (x == 5)
        {
            puanpanel.SetActive(false);
        }

    }


    public void PlayGame() 
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1); 

    }


    public void QuitGame()
    {
        Debug.Log("Çýktýk");
        Application.Quit(); 
    }


    public void KategoriSec(string kategorisec)
    {

        secilenkategori = kategorisec;

    }

    public void ZorlukSec(int deger)
    {

        if(deger==0)
        {
            secilenzorluk =0;
            PlayerPrefs.SetInt("secilenzorluk", 0);

        }
        if (deger == 1)
        {
            secilenzorluk =1;
            PlayerPrefs.SetInt("secilenzorluk", 1);
        }
        if (deger == 2)
        {
            secilenzorluk =2;
            PlayerPrefs.SetInt("secilenzorluk", 2);
        }
    }



    public void MenuDon()
    {
       
    }




}
