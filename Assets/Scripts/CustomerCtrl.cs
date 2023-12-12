using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CustomerCtrl : MonoBehaviour
{
    [SerializeField] TMP_Text orderText;

    public string order, customer;
    [SerializeField] private GameObject dragoa, superVilao, mamaco, ratos, bruxa;

   

    public void EndDialogue(string fala)
    {
        orderText.text = fala;
    }
    
    
    public void SetCustomer()
    {
        int rndCustumer = Random.Range(0, 5);
        int rndOrder = Random.Range(0, 7);

        if (rndCustumer == 0)
        {
            dragoa.SetActive(true);
            superVilao.SetActive(false);
            mamaco.SetActive(false);
            ratos.SetActive(false);
            bruxa.SetActive(false);

            customer = "dragoa";
        }

        if (rndCustumer == 1)
        {
            dragoa.SetActive(false);
            superVilao.SetActive(true);
            mamaco.SetActive(false);
            ratos.SetActive(false);
            bruxa.SetActive(false);

            customer = "super vilao";
        }

        if (rndCustumer == 2)
        {
            dragoa.SetActive(false);
            superVilao.SetActive(false);
            mamaco.SetActive(true);
            ratos.SetActive(false);
            bruxa.SetActive(false);

            customer = "mamaco";
        }

        if (rndCustumer == 3)
        {
            dragoa.SetActive(false);
            superVilao.SetActive(false);
            mamaco.SetActive(false);
            ratos.SetActive(true);
            bruxa.SetActive(false);

            customer = "ratos";
        }

        if (rndCustumer == 4)
        {
            dragoa.SetActive(false);
            superVilao.SetActive(false);
            mamaco.SetActive(false);
            ratos.SetActive(false);
            bruxa.SetActive(true);

            customer = "bruxa";
        }

        SetOrder(customer, rndOrder);
    }


    private void SetOrder(string customer, int rndOrder)
    {
        

        if (customer == "dragoa")
        {
            if (rndOrder <= 3)
            {
                orderText.text = "Apareceu um her�i novo, gostaria de mat�-lo com a po��o de veneneno de cobra";

                order = "veneno de cobra";
            }

            if (rndOrder == 4)
            {
                orderText.text = "Apareceu um her�i novo, gostaria de mat�-lo com a po��o de veneneno de cobra, mas sem frutos do mar, eu sou al�rgica";

                order = "veneno de cobra s/ frutos do mar";
            }

            if (rndOrder == 5)
            {
                orderText.text = "Apareceu um her�i novo, gostaria de mat�-lo com a po��o de veneneno de cobra, mas do jeitinho que minha av� fazia, com azeitona";

                order = "veneno de cobra c/ azeitona";
            }

            if (rndOrder == 6)
            {
                orderText.text = "Meu calabou�o est� infestado de ratos gigantes, gostaria de mat�-los com a po��o matador de colosso";

                order = "matador de colosso";
            }
        }

        if (customer == "super vilao")
        {
            if (rndOrder <=1)
            {
                orderText.text = "O Skatista de bronze tem sido um grande empecilho, preciso da po��o matador de colosso";

                order = "matador de coloso";
            }

            if (rndOrder == 2)
            {
                orderText.text = "A Mulher Maromba tem sido um grande empecilho, preciso da po��o matador de colosso";

                order = "matador de coloso";
            }

            if (rndOrder == 3)
            {
                orderText.text = "O Super Cara tem sido um grande empecilho, preciso da po��o matador de colosso";

                order = "matador de coloso";
            }

            if (rndOrder == 4)
            {
                orderText.text = "A Mulher Maromba tem sido um grande empecilho, preciso da po��o matador de colosso potencializado com castanhas ou nozes pois ela � al�rgica";

                order = "matador de coloso c/ castanha";
            }

            if (rndOrder == 5)
            {
                orderText.text = "O Super Cara tem sido um grande empecilho, preciso da po��o matador de colosso, mas do jeitinho que minha av� fazia, temperado com o tempero de miojo";

                order = "matador de coloso c/ sache de miojo";
            }

            if (rndOrder == 6)
            {
                orderText.text = "Os c�es do meu vizinho n�o param de incomodar minha gata, gostaria de silencia-los com a po��o do sono eterno, mas eles cortaram o a��car ent�o tem que ser com gotas de ado�ante";

                order = "sono eterno c/ adocante";
            }
        }

        if (customer == "mamaco")
        {
            if (rndOrder <= 3)
            {
                orderText.text = "Estamos planejando uma macaquice, me v� uma po��o de dor de barriga eterna";

                order = "dor de barriga eterna";
            }

            if (rndOrder == 4)
            {
                orderText.text = "Estamos planejando uma macaquice, me v� uma po��o de dor de barriga eterna com uma pitada de plut�nio enriquecido";

                order = "dor de barriga eterna";
            }

            if (rndOrder == 5)
            {
                orderText.text  = "Estamos planejando uma macaquice, me v� uma po��o de dor de barriga eterna com algo doce no lugar do salgado";

                order = "dor de barriga eterna c/ doce";
            }

            if (rndOrder == 6)
            {
                orderText.text = "Estamos planejando uma macaquice, me v� uma po��o do sono eterno";

                order = "sono eterno";
            }
        }

        if (customer == "ratos")
        {
            if (rndOrder <= 3)
            {
                orderText.text = "A �nica coisa que falta pro plano de domina��o global � a po��o do cora��o partido";

                order = "cora��o partido";
            }

            if (rndOrder == 4)
            {
                orderText.text = "A �nica coisa que falta pro plano de domina��o global � a po��o do cora��o partido feito com a ultima l�grima";

                order = "cora��o partido c/ a ultima lagrima";
            }

            if (rndOrder == 5)
            {
                orderText.text = "A �nica coisa que falta pro plano de domina��o global � a po��o do matador de colosso feita com pelo de rabo de rato";

                order = "matador de colosso c/ pelo de rato";
            }

            if (rndOrder == 6)
            {
                orderText.text = "A �nica coisa que falta pro plano de domina��o global � a po��o do matador de colosso";

                order = "matador de colosso";
            }
        }

        if (customer == "bruxa")
        {
            if (rndOrder <= 1)
            {
                orderText.text = "Tem porquinhos causando muita confus�o, vou resolver com a po��o do sono eterno";

                order = "sono eterno";
            }

            if (rndOrder == 2)
            {
                orderText.text = "Tem uma princesa causando muita confus�o, vou resolver com a po��o do sono eterno";

                order = "sono eterno";
            }

            if (rndOrder == 3)
            {
                orderText.text = "Tem um pr�ncipe causando muita confus�o, vou resolver com a po��o do sono eterno";

                order = "sono eterno";
            }

            if (rndOrder == 4)
            {
                orderText.text = "Tem um pr�ncipe causando muita confus�o, vou resolver com a po��o de veneno de cobra";

                order = "veneno de cobra";
            }

            if (rndOrder == 5)
            {
                orderText.text = "Tem uma princesa causando muita confus�o, vou resolver com a po��o do sono eterno feita com frutas vermelhas";

                order = "sono eterno c/ frutas vermelhas";
            }

            if (rndOrder == 6)
            {
                orderText.text = "Tem uma princesa causando muita confus�o, vou resolver com a po��o do cora��o partido";

                order = "coracao partido";
            }
        }

        
    }
}
