using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyDisplay : MonoBehaviour
{
    public LobbyManager Lob_Man;
    public GameObject PlayerObject;
    public List<GameObject> Mosquitoes;

    private bool oneHuman;
    private int tokendisplay = -1;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckForMosquitoes();
        CheckForPlayers(); 
        
    }

    void CheckForPlayers()
    {
        for (int i = 0; i < Lob_Man.teamJoins.Count; i++)
        {
            if (Lob_Man.teamJoins[i].TeamIndex == -1)
            {
                PlayerObject.SetActive(true);
                return;
            }

        }
        PlayerObject.SetActive(false);
    }

    void CheckForMosquitoes()
    {

        for (int i = 0; i < Lob_Man.teamJoins.Count; i++)
        {

            if (Lob_Man.teamJoins[i].TeamIndex == 1)
            {



                tokendisplay++;
                    
                
            }

        }
       
        if(tokendisplay <= 3)
        {
            for (int i = 0; i < Mosquitoes.Count; i++)
            {
                if (i < tokendisplay)
                {
                    Mosquitoes[i].SetActive(true);
                }


                if (i == tokendisplay)
                {
                    Mosquitoes[i].SetActive(false);
                }
            }
        }
           
        
       

      
        tokendisplay = 0;
      
        

    }
}
