using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleDescription : MonoBehaviour
{
    public GameObject[] DescriptionScreen;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Description_Open()
    {
        if(DescriptionScreen[0].activeSelf == true)
        {
            DescriptionScreen[0].SetActive(false);
            DescriptionScreen[1].SetActive(true);
        }else if(DescriptionScreen[1].activeSelf == true)
        {
            DescriptionScreen[1].SetActive(false);
            DescriptionScreen[2].SetActive(true);
        }
        else if(DescriptionScreen[2].activeSelf == true)
        {
            DescriptionScreen[2].SetActive(false);
        }
        else
        {
            DescriptionScreen[0].SetActive(true);
        }
    } 
}
