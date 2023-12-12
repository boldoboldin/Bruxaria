using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[Serializable]
public class ItensCtrl
{
    public enum ItemType
    {
        None,
        
        CoracaoPartido,
        DorDeBarrigaEterna,
        MatadorDeColosso,
        SonoEterno,
        VenenoDeCobra,

        CaspaDePombo,
        VerrugaDeSapo,
        OlhoDeCobraCega,
        Cogumelo,
        MandiocaBraba,
        Adocante,
        RaboDeCalango,
        PernaDeBarata,
        Azeitona,
        CabeloDeRaboDeRato,
        Luxuria,
        OlhoDePeixe,
        PlutonioEnriquecido,
        CacoDeVidro,
        Amendoim,
        RestoDeRaloDePia,
        FrutosDoMar,
        TuttiFruti,
        AlmaDeLagosta,
        CheiroDeUnicornio,
        AUltimaLagrima,
        CheiroDeCarro,
        UnhaDeVelho,
        SuorDePombo,
        SacheDeMiojo,
        FrutasVermelhas,
        Amarelo,
        PernaDeCobra,
        BundaDeTanajura,

        PocaoZoada,

        VenenoDeCobraFrutosDoMar,
        VenenoDeCobraAzeitona,
        MatadorDeColossoCastanha,
        MatadorDeColossoSacheDeMiojo,
        DorDeBarrigaEternaDoce,
        SonoEternoAdocante,
        SonoEternoFrutasVermelhas,
        CoracaoPartidoAUltimaLagrima,

        MatadorDeColossoPeloDeRaboDeRato,
    }

    public ItemType itemType;
    public int amount = 1;
    private IItemHolder itemHolder;

    public void SetItemHolder(IItemHolder itemHolder)
    {
        this.itemHolder = itemHolder;
    }

    public IItemHolder GetItemHolder()
    {
        return itemHolder;
    }

    public void RemoveFromItemHolder()
    {
        if (itemHolder != null)
        {
            itemHolder.RemoveItem(this);
        }
    }

    public void MoveToAnotherItemHolder(IItemHolder newItemHolder)
    {
        RemoveFromItemHolder();
        // Add to new Item Holder
        newItemHolder.AddItem(this);
    }

    public Sprite GetSprite()
    {
        return GetSprite(itemType);
    }

    public static Sprite GetSprite(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.CoracaoPartido: return ItensAsset.Instance.coracaoPartidoSprt;
            case ItemType.DorDeBarrigaEterna: return ItensAsset.Instance.dorDeBarrigaEternaSprt;
            case ItemType.MatadorDeColosso: return ItensAsset.Instance.matadorDeColossoSprt;
            case ItemType.SonoEterno: return ItensAsset.Instance.sonoEternoSprt;
            case ItemType.VenenoDeCobra: return ItensAsset.Instance.venenoDeCobraSprt;

            case ItemType.CaspaDePombo: return ItensAsset.Instance.caspaDePomboSprt;
            case ItemType.VerrugaDeSapo: return ItensAsset.Instance.verrugaDeSapoSprt;
            case ItemType.OlhoDeCobraCega: return ItensAsset.Instance.olhoDeCobraCegaSprt;
            case ItemType.Cogumelo: return ItensAsset.Instance.cogumeloSprt;
            case ItemType.MandiocaBraba: return ItensAsset.Instance.mandiocaBrabaSprt;
            case ItemType.Adocante: return ItensAsset.Instance.adocanteSprt;
            case ItemType.RaboDeCalango: return ItensAsset.Instance.raboDeCalangoSprt;
            case ItemType.PernaDeBarata: return ItensAsset.Instance.pernaDeBarataSprt;
            case ItemType.Azeitona: return ItensAsset.Instance.azeitonaSprt;
            case ItemType.CabeloDeRaboDeRato: return ItensAsset.Instance.cabeloDeRaboDeRatoSprt;
            case ItemType.Luxuria: return ItensAsset.Instance.luxuriaSprt;
            case ItemType.OlhoDePeixe: return ItensAsset.Instance.olhoDePeixeSprt;
            case ItemType.PlutonioEnriquecido: return ItensAsset.Instance.plutonioEnriquecidoSprt;
            case ItemType.CacoDeVidro: return ItensAsset.Instance.cacoDeVidroSprt;
            case ItemType.Amendoim: return ItensAsset.Instance.amendoimSprt;
            case ItemType.RestoDeRaloDePia: return ItensAsset.Instance.restoDeRaloDePiaSprt;
            case ItemType.FrutosDoMar: return ItensAsset.Instance.frutosDoMarSprt;
            case ItemType.TuttiFruti: return ItensAsset.Instance.tuttiFrutiSprt;
            case ItemType.AlmaDeLagosta: return ItensAsset.Instance.almaDeLagostaSprt;
            case ItemType.CheiroDeUnicornio: return ItensAsset.Instance.cheiroDeUnicornioSprt;
            case ItemType.AUltimaLagrima: return ItensAsset.Instance.aUltimaLagrimaSprt;
            case ItemType.CheiroDeCarro: return ItensAsset.Instance.cheiroDeCarroSprt;
            case ItemType.UnhaDeVelho: return ItensAsset.Instance.unhaDeVelhoSprt;
            case ItemType.SuorDePombo: return ItensAsset.Instance.suorDePomboSprt;
            case ItemType.SacheDeMiojo: return ItensAsset.Instance.sacheDeMiojoSprt;
            case ItemType.FrutasVermelhas: return ItensAsset.Instance.frutasVermelhasSprt;
            case ItemType.Amarelo: return ItensAsset.Instance.amareloSprt;
            case ItemType.PernaDeCobra: return ItensAsset.Instance.pernaDeCobraSprt;
            case ItemType.BundaDeTanajura:  return ItensAsset.Instance.bundaDeTanajuraSprt;

            case ItemType.PocaoZoada: return ItensAsset.Instance.pocaoZoadaSprt;

            case ItemType.VenenoDeCobraFrutosDoMar: return ItensAsset.Instance.venenoDeCobraSprt;
            case ItemType.VenenoDeCobraAzeitona: return ItensAsset.Instance.venenoDeCobraSprt;
            case ItemType.MatadorDeColossoCastanha: return ItensAsset.Instance.matadorDeColossoSprt;
            case ItemType.MatadorDeColossoSacheDeMiojo: return ItensAsset.Instance.matadorDeColossoSprt;
            case ItemType.DorDeBarrigaEternaDoce: return ItensAsset.Instance.dorDeBarrigaEternaSprt;
            case ItemType.SonoEternoAdocante: return ItensAsset.Instance.sonoEternoSprt;
            case ItemType.SonoEternoFrutasVermelhas: return ItensAsset.Instance.sonoEternoSprt;
            case ItemType.CoracaoPartidoAUltimaLagrima: return ItensAsset.Instance.coracaoPartidoSprt;
            case ItemType.MatadorDeColossoPeloDeRaboDeRato: return ItensAsset.Instance.matadorDeColossoSprt;
        }
    }

    public static string GetName(ItemType itemType)
    {
        string itemName;

        switch (itemType)
        {
            default:
            case ItemType.CoracaoPartido:
                itemName = "Poção do coração partido";
                break;      
            case ItemType.DorDeBarrigaEterna:
                itemName = "Poção da dor de barriga eterna";
                break;
            case ItemType.MatadorDeColosso: 
                itemName = "Poção do matador de colosso";
                break;
            case ItemType.SonoEterno:
                itemName = "Poção do sono eterno";
                break;
            case ItemType.VenenoDeCobra:
                itemName = "Poção de veneno de cobra";
                break;
            case ItemType.CaspaDePombo: 
                itemName = "Caspa de pombo";
                break;
            case ItemType.VerrugaDeSapo: 
                itemName = "Verruga de sapo";
                break;
            case ItemType.OlhoDeCobraCega: 
                itemName = "Olho de cobra cega";
                break;
            case ItemType.Cogumelo: 
                itemName = "Cogumelo";
                break;
            case ItemType.MandiocaBraba: 
                itemName = "Mandioca braba";
                break;
            case ItemType.Adocante: 
                itemName = "Adoçante";
                break;
            case ItemType.RaboDeCalango: 
                itemName = "Rabo de calango";
                break;
            case ItemType.PernaDeBarata: 
                itemName = "Perna de barata";
                break;
            case ItemType.Azeitona: 
                itemName = "Azeitona";
                break;
            case ItemType.CabeloDeRaboDeRato: 
                itemName = "Cabelo de rabo de rato";
                break;
            case ItemType.Luxuria: 
                itemName = "Luxúria";
                break;
            case ItemType.OlhoDePeixe:
                itemName = "Olho de peixe";
                break;
            case ItemType.PlutonioEnriquecido: 
                itemName = "Plutônio enriquecido";
                break;
            case ItemType.CacoDeVidro: 
                itemName = "Caco de vidro";
                break;
            case ItemType.Amendoim: 
                itemName = "Amendoim";
                break;
            case ItemType.RestoDeRaloDePia: 
                itemName = "Resto de ralo de pia";
                break;
            case ItemType.FrutosDoMar: 
                itemName = "Mexilhões";
                break;
            case ItemType.TuttiFruti: 
                itemName = "Cogumelo Tutti fruti";
                break;
            case ItemType.AlmaDeLagosta: 
                itemName = "Alma de lagosta";
                break;
            case ItemType.CheiroDeUnicornio: 
                itemName = "Cheiro de unicórnio";
                break;
            case ItemType.AUltimaLagrima: 
                itemName = "A ultima lágrima";
                break;
            case ItemType.CheiroDeCarro:
                itemName = "Cheiro de carro";
                break;
            case ItemType.UnhaDeVelho:
                itemName = "Unha de velho";
                break;
            case ItemType.SuorDePombo:
                itemName = "Leite de pombo";
                break;
            case ItemType.SacheDeMiojo:
                itemName = "Sachê de miojo";
                break;
            case ItemType.FrutasVermelhas:
                itemName = "Frutas vermelhas";
                break;
            case ItemType.Amarelo:
                itemName = "Amarelo";
                break;
            case ItemType.PernaDeCobra:
                itemName = "Perna de cobra";
                break;
            case ItemType.BundaDeTanajura:
                itemName = "Bunda de tanajura";
                break;
            case ItemType.PocaoZoada:
                itemName = "Poção zoada";
                break;
            case ItemType.VenenoDeCobraFrutosDoMar:
                itemName = "Poção de veneno de cobra";
                break;
            case ItemType.VenenoDeCobraAzeitona:
                itemName = "Poção de veneno de cobra";
                break;
            case ItemType.MatadorDeColossoCastanha:
                itemName = "Poção do matador de colosso";
                break;
            case ItemType.MatadorDeColossoSacheDeMiojo:
                itemName = "Poção do matador de colosso";
                break;
            case ItemType.DorDeBarrigaEternaDoce:
                itemName = "Poção da dor de barriga eterna";
                break;
            case ItemType.SonoEternoAdocante:
                itemName = "Poção do sono eterno";
                break;
            case ItemType.SonoEternoFrutasVermelhas:
                itemName = "Poção do sono eterno";
                break;
            case ItemType.CoracaoPartidoAUltimaLagrima:
                itemName = "Poção do coração partido";
                break;
            case ItemType.MatadorDeColossoPeloDeRaboDeRato:
                itemName = "Poção do matador de colosso";
                break;

        }
        return itemName;
    }

    public bool IsStackable()
    {
        return IsStackable(itemType);
    }

    public static bool IsStackable (ItemType itemType)
    {
        switch (itemType)
        {
            default:
            
            //case ItemType.Arrow:
           
                return false;
        }
    }
}
