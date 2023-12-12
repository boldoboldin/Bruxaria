using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItensAsset : MonoBehaviour
{
    public static ItensAsset Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Transform prefabItemWorld;

    public Sprite coracaoPartidoSprt;
    public Sprite dorDeBarrigaEternaSprt;
    public Sprite matadorDeColossoSprt;
    public Sprite sonoEternoSprt;
    public Sprite venenoDeCobraSprt;

    public Sprite caspaDePomboSprt;
    public Sprite verrugaDeSapoSprt;
    public Sprite olhoDeCobraCegaSprt;
    public Sprite cogumeloSprt;
    public Sprite mandiocaBrabaSprt;
    public Sprite adocanteSprt;
    public Sprite raboDeCalangoSprt;
    public Sprite pernaDeBarataSprt;
    public Sprite azeitonaSprt;
    public Sprite cabeloDeRaboDeRatoSprt;
    public Sprite luxuriaSprt;
    public Sprite olhoDePeixeSprt;
    public Sprite plutonioEnriquecidoSprt;
    public Sprite cacoDeVidroSprt;
    public Sprite amendoimSprt;
    public Sprite restoDeRaloDePiaSprt;
    public Sprite frutosDoMarSprt;
    public Sprite tuttiFrutiSprt;
    public Sprite almaDeLagostaSprt;
    public Sprite cheiroDeUnicornioSprt;
    public Sprite aUltimaLagrimaSprt;
    public Sprite cheiroDeCarroSprt;
    public Sprite unhaDeVelhoSprt;
    public Sprite suorDePomboSprt;
    public Sprite sacheDeMiojoSprt;
    public Sprite frutasVermelhasSprt;
    public Sprite amareloSprt;
    public Sprite pernaDeCobraSprt;
    public Sprite bundaDeTanajuraSprt;

    public Sprite pocaoZoadaSprt;
}
