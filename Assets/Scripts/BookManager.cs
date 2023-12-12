using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookManager : MonoBehaviour
{
    [SerializeField] private GameObject pag1, pag2, pag3, pag4, pag5, pag6, pag7, pag8, pag9;
    private int pag = 1;

    private void Update()
    {
        switch (pag)
        {
            default:
            case 1:
                pag1.SetActive(true);
                pag2.SetActive(false);
                pag3.SetActive(false);
                pag4.SetActive(false);
                pag5.SetActive(false);
                pag6.SetActive(false);
                pag7.SetActive(false);
                pag8.SetActive(false);
                pag9.SetActive(false);
                break;
            case 2:
                pag1.SetActive(false);
                pag2.SetActive(true);
                pag3.SetActive(false);
                pag4.SetActive(false);
                pag5.SetActive(false);
                pag6.SetActive(false);
                pag7.SetActive(false);
                pag8.SetActive(false);
                pag9.SetActive(false);
                break;
            case 3:
                pag1.SetActive(false);
                pag2.SetActive(false);
                pag3.SetActive(true);
                pag4.SetActive(false);
                pag5.SetActive(false);
                pag6.SetActive(false);
                pag7.SetActive(false);
                pag8.SetActive(false);
                pag9.SetActive(false);
                break;
            case 4:
                pag1.SetActive(false);
                pag2.SetActive(false);
                pag3.SetActive(false);
                pag4.SetActive(true);
                pag5.SetActive(false);
                pag6.SetActive(false);
                pag7.SetActive(false);
                pag8.SetActive(false);
                pag9.SetActive(false);
                break;
            case 5:
                pag1.SetActive(false);
                pag2.SetActive(false);
                pag3.SetActive(false);
                pag4.SetActive(false);
                pag5.SetActive(true);
                pag6.SetActive(false);
                pag7.SetActive(false);
                pag8.SetActive(false);
                pag9.SetActive(false);
                break;
            case 6:
                pag1.SetActive(false);
                pag2.SetActive(false);
                pag3.SetActive(false);
                pag4.SetActive(false);
                pag5.SetActive(false);
                pag6.SetActive(true);
                pag7.SetActive(false);
                pag8.SetActive(false);
                pag9.SetActive(false);
                break;
            case 7:
                pag1.SetActive(false);
                pag2.SetActive(false);
                pag3.SetActive(false);
                pag4.SetActive(false);
                pag5.SetActive(false);
                pag6.SetActive(false);
                pag7.SetActive(true);
                pag8.SetActive(false);
                pag9.SetActive(false);
                break;
            case 8:
                pag1.SetActive(false);
                pag2.SetActive(false);
                pag3.SetActive(false);
                pag4.SetActive(false);
                pag5.SetActive(false);
                pag6.SetActive(false);
                pag7.SetActive(false);
                pag8.SetActive(true);
                pag9.SetActive(false);
                break;
            case 9:
                pag1.SetActive(false);
                pag2.SetActive(false);
                pag3.SetActive(false);
                pag4.SetActive(false);
                pag5.SetActive(false);
                pag6.SetActive(false);
                pag7.SetActive(false);
                pag8.SetActive(false);
                pag9.SetActive(true);
                break;
        }
    }

    public void GoToNextPag()
    {
        pag++;

        if (pag >= 10)
        {
            pag = 1;
        }
    }

    public void GoToPrevPag()
    {
        pag--;

        if (pag <= 0)
        {
            pag = 9;
        }
    }


}
