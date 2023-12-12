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
                orderText.text = "Apareceu um herói novo, gostaria de matá-lo com a poção de veneneno de cobra";

                order = "veneno de cobra";
            }

            if (rndOrder == 4)
            {
                orderText.text = "Apareceu um herói novo, gostaria de matá-lo com a poção de veneneno de cobra, mas sem frutos do mar, eu sou alérgica";

                order = "veneno de cobra s/ frutos do mar";
            }

            if (rndOrder == 5)
            {
                orderText.text = "Apareceu um herói novo, gostaria de matá-lo com a poção de veneneno de cobra, mas do jeitinho que minha avó fazia, com azeitona";

                order = "veneno de cobra c/ azeitona";
            }

            if (rndOrder == 6)
            {
                orderText.text = "Meu calabouço está infestado de ratos gigantes, gostaria de matá-los com a poção matador de colosso";

                order = "matador de colosso";
            }
        }

        if (customer == "super vilao")
        {
            if (rndOrder <=1)
            {
                orderText.text = "O Skatista de bronze tem sido um grande empecilho, preciso da poção matador de colosso";

                order = "matador de coloso";
            }

            if (rndOrder == 2)
            {
                orderText.text = "A Mulher Maromba tem sido um grande empecilho, preciso da poção matador de colosso";

                order = "matador de coloso";
            }

            if (rndOrder == 3)
            {
                orderText.text = "O Super Cara tem sido um grande empecilho, preciso da poção matador de colosso";

                order = "matador de coloso";
            }

            if (rndOrder == 4)
            {
                orderText.text = "A Mulher Maromba tem sido um grande empecilho, preciso da poção matador de colosso potencializado com castanhas ou nozes pois ela é alérgica";

                order = "matador de coloso c/ castanha";
            }

            if (rndOrder == 5)
            {
                orderText.text = "O Super Cara tem sido um grande empecilho, preciso da poção matador de colosso, mas do jeitinho que minha avó fazia, temperado com o tempero de miojo";

                order = "matador de coloso c/ sache de miojo";
            }

            if (rndOrder == 6)
            {
                orderText.text = "Os cães do meu vizinho não param de incomodar minha gata, gostaria de silencia-los com a poção do sono eterno, mas eles cortaram o açúcar então tem que ser com gotas de adoçante";

                order = "sono eterno c/ adocante";
            }
        }

        if (customer == "mamaco")
        {
            if (rndOrder <= 3)
            {
                orderText.text = "Estamos planejando uma macaquice, me vê uma poção de dor de barriga eterna";

                order = "dor de barriga eterna";
            }

            if (rndOrder == 4)
            {
                orderText.text = "Estamos planejando uma macaquice, me vê uma poção de dor de barriga eterna com uma pitada de plutônio enriquecido";

                order = "dor de barriga eterna";
            }

            if (rndOrder == 5)
            {
                orderText.text  = "Estamos planejando uma macaquice, me vê uma poção de dor de barriga eterna com algo doce no lugar do salgado";

                order = "dor de barriga eterna c/ doce";
            }

            if (rndOrder == 6)
            {
                orderText.text = "Estamos planejando uma macaquice, me vê uma poção do sono eterno";

                order = "sono eterno";
            }
        }

        if (customer == "ratos")
        {
            if (rndOrder <= 3)
            {
                orderText.text = "A única coisa que falta pro plano de dominação global é a poção do coração partido";

                order = "coração partido";
            }

            if (rndOrder == 4)
            {
                orderText.text = "A única coisa que falta pro plano de dominação global é a poção do coração partido feito com a ultima lágrima";

                order = "coração partido c/ a ultima lagrima";
            }

            if (rndOrder == 5)
            {
                orderText.text = "A única coisa que falta pro plano de dominação global é a poção do matador de colosso feita com pelo de rabo de rato";

                order = "matador de colosso c/ pelo de rato";
            }

            if (rndOrder == 6)
            {
                orderText.text = "A única coisa que falta pro plano de dominação global é a poção do matador de colosso";

                order = "matador de colosso";
            }
        }

        if (customer == "bruxa")
        {
            if (rndOrder <= 1)
            {
                orderText.text = "Tem porquinhos causando muita confusão, vou resolver com a poção do sono eterno";

                order = "sono eterno";
            }

            if (rndOrder == 2)
            {
                orderText.text = "Tem uma princesa causando muita confusão, vou resolver com a poção do sono eterno";

                order = "sono eterno";
            }

            if (rndOrder == 3)
            {
                orderText.text = "Tem um príncipe causando muita confusão, vou resolver com a poção do sono eterno";

                order = "sono eterno";
            }

            if (rndOrder == 4)
            {
                orderText.text = "Tem um príncipe causando muita confusão, vou resolver com a poção de veneno de cobra";

                order = "veneno de cobra";
            }

            if (rndOrder == 5)
            {
                orderText.text = "Tem uma princesa causando muita confusão, vou resolver com a poção do sono eterno feita com frutas vermelhas";

                order = "sono eterno c/ frutas vermelhas";
            }

            if (rndOrder == 6)
            {
                orderText.text = "Tem uma princesa causando muita confusão, vou resolver com a poção do coração partido";

                order = "coracao partido";
            }
        }

        
    }
}
