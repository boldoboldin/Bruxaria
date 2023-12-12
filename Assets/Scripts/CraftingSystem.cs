
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingSystem : IItemHolder
{
    public const int gridSizeX = 1;
    public const int gridSizeY = 3;

    public event EventHandler OnGridChanged;

    private Dictionary<ItensCtrl.ItemType, List<ItensCtrl.ItemType[,]>> recipeDictionary;

    private ItensCtrl[,] itemArray;
    private ItensCtrl outputItem;

    public CraftingSystem()
    {
        itemArray = new ItensCtrl[gridSizeX, gridSizeY];

        recipeDictionary = new Dictionary<ItensCtrl.ItemType, List<ItensCtrl.ItemType[,]>>();

        //CoracaoPartido Recipes
        List<ItensCtrl.ItemType[,]> coracaoPartidoRecipes = new List<ItensCtrl.ItemType[,]>();

        ItensCtrl.ItemType[,] recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.AUltimaLagrima; 
        recipe[0, 1] = ItensCtrl.ItemType.Luxuria; //Sentimental
        recipe[0, 2] = ItensCtrl.ItemType.VerrugaDeSapo; //Amargo
        coracaoPartidoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.AUltimaLagrima;
        recipe[0, 1] = ItensCtrl.ItemType.Luxuria; 
        recipe[0, 2] = ItensCtrl.ItemType.MandiocaBraba;
        coracaoPartidoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.AUltimaLagrima;
        recipe[0, 1] = ItensCtrl.ItemType.Luxuria;
        recipe[0, 2] = ItensCtrl.ItemType.PernaDeBarata;
        coracaoPartidoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.AUltimaLagrima;
        recipe[0, 1] = ItensCtrl.ItemType.Luxuria;
        recipe[0, 2] = ItensCtrl.ItemType.OlhoDePeixe;
        coracaoPartidoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.AUltimaLagrima;
        recipe[0, 1] = ItensCtrl.ItemType.Luxuria;
        recipe[0, 2] = ItensCtrl.ItemType.AlmaDeLagosta;
        coracaoPartidoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.AUltimaLagrima;
        recipe[0, 1] = ItensCtrl.ItemType.Luxuria;
        recipe[0, 2] = ItensCtrl.ItemType.CheiroDeCarro;
        coracaoPartidoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.AUltimaLagrima;
        recipe[0, 1] = ItensCtrl.ItemType.Luxuria;
        recipe[0, 2] = ItensCtrl.ItemType.Amarelo;
        coracaoPartidoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.AUltimaLagrima;
        recipe[0, 1] = ItensCtrl.ItemType.Luxuria;
        recipe[0, 2] = ItensCtrl.ItemType.BundaDeTanajura;
        coracaoPartidoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.AUltimaLagrima;
        recipe[0, 1] = ItensCtrl.ItemType.AlmaDeLagosta;
        recipe[0, 2] = ItensCtrl.ItemType.VerrugaDeSapo;
        coracaoPartidoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.AUltimaLagrima;
        recipe[0, 1] = ItensCtrl.ItemType.AlmaDeLagosta;
        recipe[0, 2] = ItensCtrl.ItemType.MandiocaBraba;
        coracaoPartidoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.AUltimaLagrima;
        recipe[0, 1] = ItensCtrl.ItemType.AlmaDeLagosta;
        recipe[0, 2] = ItensCtrl.ItemType.PernaDeBarata;
        coracaoPartidoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.AUltimaLagrima;
        recipe[0, 1] = ItensCtrl.ItemType.AlmaDeLagosta;
        recipe[0, 2] = ItensCtrl.ItemType.OlhoDePeixe;
        coracaoPartidoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.AUltimaLagrima;
        recipe[0, 1] = ItensCtrl.ItemType.AlmaDeLagosta;
        recipe[0, 2] = ItensCtrl.ItemType.CheiroDeCarro;
        coracaoPartidoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.AUltimaLagrima;
        recipe[0, 1] = ItensCtrl.ItemType.AlmaDeLagosta;
        recipe[0, 2] = ItensCtrl.ItemType.Amarelo;
        coracaoPartidoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.AUltimaLagrima;
        recipe[0, 1] = ItensCtrl.ItemType.AlmaDeLagosta;
        recipe[0, 2] = ItensCtrl.ItemType.BundaDeTanajura;
        coracaoPartidoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.AUltimaLagrima;
        recipe[0, 1] = ItensCtrl.ItemType.CheiroDeUnicornio;
        recipe[0, 2] = ItensCtrl.ItemType.MandiocaBraba;
        coracaoPartidoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.AUltimaLagrima;
        recipe[0, 1] = ItensCtrl.ItemType.CheiroDeUnicornio;
        recipe[0, 2] = ItensCtrl.ItemType.PernaDeBarata;
        coracaoPartidoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.AUltimaLagrima;
        recipe[0, 1] = ItensCtrl.ItemType.CheiroDeUnicornio;
        recipe[0, 2] = ItensCtrl.ItemType.OlhoDePeixe;
        coracaoPartidoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.AUltimaLagrima;
        recipe[0, 1] = ItensCtrl.ItemType.CheiroDeUnicornio;
        recipe[0, 2] = ItensCtrl.ItemType.AlmaDeLagosta;
        coracaoPartidoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.AUltimaLagrima;
        recipe[0, 1] = ItensCtrl.ItemType.CheiroDeUnicornio;
        recipe[0, 2] = ItensCtrl.ItemType.CheiroDeCarro;
        coracaoPartidoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.AUltimaLagrima;
        recipe[0, 1] = ItensCtrl.ItemType.CheiroDeUnicornio;
        recipe[0, 2] = ItensCtrl.ItemType.Amarelo;
        coracaoPartidoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.AUltimaLagrima;
        recipe[0, 1] = ItensCtrl.ItemType.CheiroDeUnicornio;
        recipe[0, 2] = ItensCtrl.ItemType.BundaDeTanajura;
        coracaoPartidoRecipes.Add(recipe);

        recipeDictionary[ItensCtrl.ItemType.CoracaoPartido] = coracaoPartidoRecipes;

        //DorDeBarrigaEterna Recipes
        List<ItensCtrl.ItemType[,]> dorDeBarrigaEternaRecipes = new List<ItensCtrl.ItemType[,]>();

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.SuorDePombo;
        recipe[0, 1] = ItensCtrl.ItemType.MandiocaBraba; // Potente
        recipe[0, 2] = ItensCtrl.ItemType.RaboDeCalango; // Salgado
        dorDeBarrigaEternaRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.SuorDePombo;
        recipe[0, 1] = ItensCtrl.ItemType.MandiocaBraba;
        recipe[0, 2] = ItensCtrl.ItemType.Azeitona;
        dorDeBarrigaEternaRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.SuorDePombo;
        recipe[0, 1] = ItensCtrl.ItemType.MandiocaBraba;
        recipe[0, 2] = ItensCtrl.ItemType.CabeloDeRaboDeRato;
        dorDeBarrigaEternaRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.SuorDePombo;
        recipe[0, 1] = ItensCtrl.ItemType.MandiocaBraba;
        recipe[0, 2] = ItensCtrl.ItemType.Amendoim;
        dorDeBarrigaEternaRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.SuorDePombo;
        recipe[0, 1] = ItensCtrl.ItemType.MandiocaBraba;
        recipe[0, 2] = ItensCtrl.ItemType.FrutosDoMar;
        dorDeBarrigaEternaRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.SuorDePombo;
        recipe[0, 1] = ItensCtrl.ItemType.MandiocaBraba;
        recipe[0, 2] = ItensCtrl.ItemType.UnhaDeVelho;
        dorDeBarrigaEternaRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.SuorDePombo;
        recipe[0, 1] = ItensCtrl.ItemType.MandiocaBraba;
        recipe[0, 2] = ItensCtrl.ItemType.SacheDeMiojo;
        dorDeBarrigaEternaRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.SuorDePombo;
        recipe[0, 1] = ItensCtrl.ItemType.PlutonioEnriquecido;
        recipe[0, 2] = ItensCtrl.ItemType.RaboDeCalango;
        dorDeBarrigaEternaRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.SuorDePombo;
        recipe[0, 1] = ItensCtrl.ItemType.PlutonioEnriquecido;
        recipe[0, 2] = ItensCtrl.ItemType.Azeitona;
        dorDeBarrigaEternaRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.SuorDePombo;
        recipe[0, 1] = ItensCtrl.ItemType.PlutonioEnriquecido;
        recipe[0, 2] = ItensCtrl.ItemType.CabeloDeRaboDeRato;
        dorDeBarrigaEternaRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.SuorDePombo;
        recipe[0, 1] = ItensCtrl.ItemType.PlutonioEnriquecido;
        recipe[0, 2] = ItensCtrl.ItemType.Amendoim;
        dorDeBarrigaEternaRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.SuorDePombo;
        recipe[0, 1] = ItensCtrl.ItemType.PlutonioEnriquecido;
        recipe[0, 2] = ItensCtrl.ItemType.FrutosDoMar;
        dorDeBarrigaEternaRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.SuorDePombo;
        recipe[0, 1] = ItensCtrl.ItemType.PlutonioEnriquecido;
        recipe[0, 2] = ItensCtrl.ItemType.UnhaDeVelho;
        dorDeBarrigaEternaRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.SuorDePombo;
        recipe[0, 1] = ItensCtrl.ItemType.PlutonioEnriquecido;
        recipe[0, 2] = ItensCtrl.ItemType.SacheDeMiojo;
        dorDeBarrigaEternaRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.SuorDePombo;
        recipe[0, 1] = ItensCtrl.ItemType.Azeitona;
        recipe[0, 2] = ItensCtrl.ItemType.RaboDeCalango;
        dorDeBarrigaEternaRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.SuorDePombo;
        recipe[0, 1] = ItensCtrl.ItemType.Azeitona;
        recipe[0, 2] = ItensCtrl.ItemType.CabeloDeRaboDeRato;
        dorDeBarrigaEternaRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.SuorDePombo;
        recipe[0, 1] = ItensCtrl.ItemType.Azeitona;
        recipe[0, 2] = ItensCtrl.ItemType.Amendoim;
        dorDeBarrigaEternaRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.SuorDePombo;
        recipe[0, 1] = ItensCtrl.ItemType.Azeitona;
        recipe[0, 2] = ItensCtrl.ItemType.FrutosDoMar;
        dorDeBarrigaEternaRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.SuorDePombo;
        recipe[0, 1] = ItensCtrl.ItemType.Azeitona;
        recipe[0, 2] = ItensCtrl.ItemType.UnhaDeVelho;
        dorDeBarrigaEternaRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.SuorDePombo;
        recipe[0, 1] = ItensCtrl.ItemType.Azeitona;
        recipe[0, 2] = ItensCtrl.ItemType.SacheDeMiojo;
        dorDeBarrigaEternaRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.SuorDePombo;
        recipe[0, 1] = ItensCtrl.ItemType.CacoDeVidro;
        recipe[0, 2] = ItensCtrl.ItemType.RaboDeCalango;
        dorDeBarrigaEternaRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.SuorDePombo;
        recipe[0, 1] = ItensCtrl.ItemType.CacoDeVidro;
        recipe[0, 2] = ItensCtrl.ItemType.Azeitona;
        dorDeBarrigaEternaRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.SuorDePombo;
        recipe[0, 1] = ItensCtrl.ItemType.CacoDeVidro;
        recipe[0, 2] = ItensCtrl.ItemType.CabeloDeRaboDeRato;
        dorDeBarrigaEternaRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.SuorDePombo;
        recipe[0, 1] = ItensCtrl.ItemType.CacoDeVidro;
        recipe[0, 2] = ItensCtrl.ItemType.Amendoim;
        dorDeBarrigaEternaRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.SuorDePombo;
        recipe[0, 1] = ItensCtrl.ItemType.CacoDeVidro;
        recipe[0, 2] = ItensCtrl.ItemType.FrutosDoMar;
        dorDeBarrigaEternaRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.SuorDePombo;
        recipe[0, 1] = ItensCtrl.ItemType.CacoDeVidro;
        recipe[0, 2] = ItensCtrl.ItemType.UnhaDeVelho;
        dorDeBarrigaEternaRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.SuorDePombo;
        recipe[0, 1] = ItensCtrl.ItemType.CacoDeVidro;
        recipe[0, 2] = ItensCtrl.ItemType.SacheDeMiojo;
        dorDeBarrigaEternaRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.SuorDePombo;
        recipe[0, 1] = ItensCtrl.ItemType.AUltimaLagrima;
        recipe[0, 2] = ItensCtrl.ItemType.RaboDeCalango;
        dorDeBarrigaEternaRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.SuorDePombo;
        recipe[0, 1] = ItensCtrl.ItemType.AUltimaLagrima;
        recipe[0, 2] = ItensCtrl.ItemType.Azeitona;
        dorDeBarrigaEternaRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.SuorDePombo;
        recipe[0, 1] = ItensCtrl.ItemType.AUltimaLagrima;
        recipe[0, 2] = ItensCtrl.ItemType.CabeloDeRaboDeRato;
        dorDeBarrigaEternaRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.SuorDePombo;
        recipe[0, 1] = ItensCtrl.ItemType.AUltimaLagrima;
        recipe[0, 2] = ItensCtrl.ItemType.Amendoim;
        dorDeBarrigaEternaRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.SuorDePombo;
        recipe[0, 1] = ItensCtrl.ItemType.AUltimaLagrima;
        recipe[0, 2] = ItensCtrl.ItemType.FrutosDoMar;
        dorDeBarrigaEternaRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.SuorDePombo;
        recipe[0, 1] = ItensCtrl.ItemType.AUltimaLagrima;
        recipe[0, 2] = ItensCtrl.ItemType.UnhaDeVelho;
        dorDeBarrigaEternaRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.SuorDePombo;
        recipe[0, 1] = ItensCtrl.ItemType.AUltimaLagrima;
        recipe[0, 2] = ItensCtrl.ItemType.SacheDeMiojo;
        dorDeBarrigaEternaRecipes.Add(recipe);

        recipeDictionary[ItensCtrl.ItemType.DorDeBarrigaEterna] = dorDeBarrigaEternaRecipes;

        //MatadorDeColosso Recipes
        List<ItensCtrl.ItemType[,]> matadorDeColossoRecipes = new List<ItensCtrl.ItemType[,]>();

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.MandiocaBraba;
        recipe[0, 1] = ItensCtrl.ItemType.RaboDeCalango; // Salgado
        recipe[0, 2] = ItensCtrl.ItemType.VerrugaDeSapo; // Anestésico
        matadorDeColossoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.MandiocaBraba;
        recipe[0, 1] = ItensCtrl.ItemType.RaboDeCalango; 
        recipe[0, 2] = ItensCtrl.ItemType.Adocante;
        matadorDeColossoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.MandiocaBraba;
        recipe[0, 1] = ItensCtrl.ItemType.RaboDeCalango;
        recipe[0, 2] = ItensCtrl.ItemType.RestoDeRaloDePia;
        matadorDeColossoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.MandiocaBraba;
        recipe[0, 1] = ItensCtrl.ItemType.RaboDeCalango;
        recipe[0, 2] = ItensCtrl.ItemType.TuttiFruti;
        matadorDeColossoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.MandiocaBraba;
        recipe[0, 1] = ItensCtrl.ItemType.RaboDeCalango;
        recipe[0, 2] = ItensCtrl.ItemType.CheiroDeCarro;
        matadorDeColossoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.MandiocaBraba;
        recipe[0, 1] = ItensCtrl.ItemType.RaboDeCalango;
        recipe[0, 2] = ItensCtrl.ItemType.PernaDeCobra;
        matadorDeColossoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.MandiocaBraba;
        recipe[0, 1] = ItensCtrl.ItemType.Azeitona;
        recipe[0, 2] = ItensCtrl.ItemType.VerrugaDeSapo; 
        matadorDeColossoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.MandiocaBraba;
        recipe[0, 1] = ItensCtrl.ItemType.Azeitona;
        recipe[0, 2] = ItensCtrl.ItemType.Adocante;
        matadorDeColossoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.MandiocaBraba;
        recipe[0, 1] = ItensCtrl.ItemType.Azeitona;
        recipe[0, 2] = ItensCtrl.ItemType.RestoDeRaloDePia;
        matadorDeColossoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.MandiocaBraba;
        recipe[0, 1] = ItensCtrl.ItemType.Azeitona;
        recipe[0, 2] = ItensCtrl.ItemType.TuttiFruti;
        matadorDeColossoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.MandiocaBraba;
        recipe[0, 1] = ItensCtrl.ItemType.Azeitona;
        recipe[0, 2] = ItensCtrl.ItemType.CheiroDeCarro;
        matadorDeColossoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.MandiocaBraba;
        recipe[0, 1] = ItensCtrl.ItemType.Azeitona;
        recipe[0, 2] = ItensCtrl.ItemType.PernaDeCobra;
        matadorDeColossoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.MandiocaBraba;
        recipe[0, 1] = ItensCtrl.ItemType.CabeloDeRaboDeRato;
        recipe[0, 2] = ItensCtrl.ItemType.VerrugaDeSapo;
        matadorDeColossoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.MandiocaBraba;
        recipe[0, 1] = ItensCtrl.ItemType.CabeloDeRaboDeRato;
        recipe[0, 2] = ItensCtrl.ItemType.Adocante;
        matadorDeColossoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.MandiocaBraba;
        recipe[0, 1] = ItensCtrl.ItemType.CabeloDeRaboDeRato;
        recipe[0, 2] = ItensCtrl.ItemType.RestoDeRaloDePia;
        matadorDeColossoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.MandiocaBraba;
        recipe[0, 1] = ItensCtrl.ItemType.CabeloDeRaboDeRato;
        recipe[0, 2] = ItensCtrl.ItemType.TuttiFruti;
        matadorDeColossoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.MandiocaBraba;
        recipe[0, 1] = ItensCtrl.ItemType.CabeloDeRaboDeRato;
        recipe[0, 2] = ItensCtrl.ItemType.CheiroDeCarro;
        matadorDeColossoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.MandiocaBraba;
        recipe[0, 1] = ItensCtrl.ItemType.CabeloDeRaboDeRato;
        recipe[0, 2] = ItensCtrl.ItemType.PernaDeCobra;
        matadorDeColossoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.MandiocaBraba;
        recipe[0, 1] = ItensCtrl.ItemType.Amendoim;
        recipe[0, 2] = ItensCtrl.ItemType.VerrugaDeSapo;
        matadorDeColossoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.MandiocaBraba;
        recipe[0, 1] = ItensCtrl.ItemType.Amendoim;
        recipe[0, 2] = ItensCtrl.ItemType.Adocante;
        matadorDeColossoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.MandiocaBraba;
        recipe[0, 1] = ItensCtrl.ItemType.Amendoim;
        recipe[0, 2] = ItensCtrl.ItemType.RestoDeRaloDePia;
        matadorDeColossoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.MandiocaBraba;
        recipe[0, 1] = ItensCtrl.ItemType.Amendoim;
        recipe[0, 2] = ItensCtrl.ItemType.TuttiFruti;
        matadorDeColossoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.MandiocaBraba;
        recipe[0, 1] = ItensCtrl.ItemType.Amendoim;
        recipe[0, 2] = ItensCtrl.ItemType.CheiroDeCarro;
        matadorDeColossoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.MandiocaBraba;
        recipe[0, 1] = ItensCtrl.ItemType.Amendoim;
        recipe[0, 2] = ItensCtrl.ItemType.PernaDeCobra;
        matadorDeColossoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.MandiocaBraba;
        recipe[0, 1] = ItensCtrl.ItemType.FrutosDoMar;
        recipe[0, 2] = ItensCtrl.ItemType.VerrugaDeSapo;
        matadorDeColossoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.MandiocaBraba;
        recipe[0, 1] = ItensCtrl.ItemType.FrutosDoMar;
        recipe[0, 2] = ItensCtrl.ItemType.Adocante;
        matadorDeColossoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.MandiocaBraba;
        recipe[0, 1] = ItensCtrl.ItemType.FrutosDoMar;
        recipe[0, 2] = ItensCtrl.ItemType.RestoDeRaloDePia;
        matadorDeColossoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.MandiocaBraba;
        recipe[0, 1] = ItensCtrl.ItemType.FrutosDoMar;
        recipe[0, 2] = ItensCtrl.ItemType.TuttiFruti;
        matadorDeColossoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.MandiocaBraba;
        recipe[0, 1] = ItensCtrl.ItemType.FrutosDoMar;
        recipe[0, 2] = ItensCtrl.ItemType.CheiroDeCarro;
        matadorDeColossoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.MandiocaBraba;
        recipe[0, 1] = ItensCtrl.ItemType.FrutosDoMar;
        recipe[0, 2] = ItensCtrl.ItemType.PernaDeCobra;
        matadorDeColossoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.MandiocaBraba;
        recipe[0, 1] = ItensCtrl.ItemType.UnhaDeVelho;
        recipe[0, 2] = ItensCtrl.ItemType.VerrugaDeSapo;
        matadorDeColossoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.MandiocaBraba;
        recipe[0, 1] = ItensCtrl.ItemType.UnhaDeVelho;
        recipe[0, 2] = ItensCtrl.ItemType.Adocante;
        matadorDeColossoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.MandiocaBraba;
        recipe[0, 1] = ItensCtrl.ItemType.UnhaDeVelho;
        recipe[0, 2] = ItensCtrl.ItemType.RestoDeRaloDePia;
        matadorDeColossoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.MandiocaBraba;
        recipe[0, 1] = ItensCtrl.ItemType.UnhaDeVelho;
        recipe[0, 2] = ItensCtrl.ItemType.TuttiFruti;
        matadorDeColossoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.MandiocaBraba;
        recipe[0, 1] = ItensCtrl.ItemType.UnhaDeVelho;
        recipe[0, 2] = ItensCtrl.ItemType.CheiroDeCarro;
        matadorDeColossoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.MandiocaBraba;
        recipe[0, 1] = ItensCtrl.ItemType.UnhaDeVelho;
        recipe[0, 2] = ItensCtrl.ItemType.PernaDeCobra;
        matadorDeColossoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.MandiocaBraba;
        recipe[0, 1] = ItensCtrl.ItemType.SacheDeMiojo;
        recipe[0, 2] = ItensCtrl.ItemType.VerrugaDeSapo;
        matadorDeColossoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.MandiocaBraba;
        recipe[0, 1] = ItensCtrl.ItemType.SacheDeMiojo;
        recipe[0, 2] = ItensCtrl.ItemType.Adocante;
        matadorDeColossoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.MandiocaBraba;
        recipe[0, 1] = ItensCtrl.ItemType.SacheDeMiojo;
        recipe[0, 2] = ItensCtrl.ItemType.RestoDeRaloDePia;
        matadorDeColossoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.MandiocaBraba;
        recipe[0, 1] = ItensCtrl.ItemType.SacheDeMiojo;
        recipe[0, 2] = ItensCtrl.ItemType.TuttiFruti;
        matadorDeColossoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.MandiocaBraba;
        recipe[0, 1] = ItensCtrl.ItemType.SacheDeMiojo;
        recipe[0, 2] = ItensCtrl.ItemType.CheiroDeCarro;
        matadorDeColossoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.MandiocaBraba;
        recipe[0, 1] = ItensCtrl.ItemType.SacheDeMiojo;
        recipe[0, 2] = ItensCtrl.ItemType.PernaDeCobra;
        matadorDeColossoRecipes.Add(recipe);

        recipeDictionary[ItensCtrl.ItemType.MatadorDeColosso] = matadorDeColossoRecipes;

        //SonoEterno recipes
        List<ItensCtrl.ItemType[,]> sonoEternoRecipes = new List<ItensCtrl.ItemType[,]>();

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.CheiroDeUnicornio;
        recipe[0, 1] = ItensCtrl.ItemType.Adocante; // Doce
        recipe[0, 2] = ItensCtrl.ItemType.VerrugaDeSapo; // Anestésico
        sonoEternoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.CheiroDeUnicornio;
        recipe[0, 1] = ItensCtrl.ItemType.Adocante;
        recipe[0, 2] = ItensCtrl.ItemType.RestoDeRaloDePia;
        sonoEternoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.CheiroDeUnicornio;
        recipe[0, 1] = ItensCtrl.ItemType.Adocante;
        recipe[0, 2] = ItensCtrl.ItemType.TuttiFruti;
        sonoEternoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.CheiroDeUnicornio;
        recipe[0, 1] = ItensCtrl.ItemType.Adocante;
        recipe[0, 2] = ItensCtrl.ItemType.CheiroDeCarro;
        sonoEternoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.CheiroDeUnicornio;
        recipe[0, 1] = ItensCtrl.ItemType.Adocante;
        recipe[0, 2] = ItensCtrl.ItemType.PernaDeCobra;
        sonoEternoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.CheiroDeUnicornio;
        recipe[0, 1] = ItensCtrl.ItemType.PlutonioEnriquecido;
        recipe[0, 2] = ItensCtrl.ItemType.VerrugaDeSapo;
        sonoEternoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.CheiroDeUnicornio;
        recipe[0, 1] = ItensCtrl.ItemType.PlutonioEnriquecido;
        recipe[0, 2] = ItensCtrl.ItemType.Adocante;
        sonoEternoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.CheiroDeUnicornio;
        recipe[0, 1] = ItensCtrl.ItemType.PlutonioEnriquecido;
        recipe[0, 2] = ItensCtrl.ItemType.RestoDeRaloDePia;
        sonoEternoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.CheiroDeUnicornio;
        recipe[0, 1] = ItensCtrl.ItemType.PlutonioEnriquecido;
        recipe[0, 2] = ItensCtrl.ItemType.TuttiFruti;
        sonoEternoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.CheiroDeUnicornio;
        recipe[0, 1] = ItensCtrl.ItemType.PlutonioEnriquecido;
        recipe[0, 2] = ItensCtrl.ItemType.CheiroDeCarro;
        sonoEternoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.CheiroDeUnicornio;
        recipe[0, 1] = ItensCtrl.ItemType.PlutonioEnriquecido;
        recipe[0, 2] = ItensCtrl.ItemType.PernaDeCobra;
        sonoEternoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.CheiroDeUnicornio;
        recipe[0, 1] = ItensCtrl.ItemType.TuttiFruti;
        recipe[0, 2] = ItensCtrl.ItemType.VerrugaDeSapo;
        sonoEternoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.CheiroDeUnicornio;
        recipe[0, 1] = ItensCtrl.ItemType.TuttiFruti;
        recipe[0, 2] = ItensCtrl.ItemType.Adocante;
        sonoEternoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.CheiroDeUnicornio;
        recipe[0, 1] = ItensCtrl.ItemType.TuttiFruti;
        recipe[0, 2] = ItensCtrl.ItemType.RestoDeRaloDePia;
        sonoEternoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.CheiroDeUnicornio;
        recipe[0, 1] = ItensCtrl.ItemType.TuttiFruti;
        recipe[0, 2] = ItensCtrl.ItemType.CheiroDeCarro;
        sonoEternoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.CheiroDeUnicornio;
        recipe[0, 1] = ItensCtrl.ItemType.TuttiFruti;
        recipe[0, 2] = ItensCtrl.ItemType.PernaDeCobra;
        sonoEternoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.CheiroDeUnicornio;
        recipe[0, 1] = ItensCtrl.ItemType.FrutasVermelhas;
        recipe[0, 2] = ItensCtrl.ItemType.VerrugaDeSapo;
        sonoEternoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.CheiroDeUnicornio;
        recipe[0, 1] = ItensCtrl.ItemType.FrutasVermelhas;
        recipe[0, 2] = ItensCtrl.ItemType.Adocante;
        sonoEternoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.CheiroDeUnicornio;
        recipe[0, 1] = ItensCtrl.ItemType.FrutasVermelhas;
        recipe[0, 2] = ItensCtrl.ItemType.RestoDeRaloDePia;
        sonoEternoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.CheiroDeUnicornio;
        recipe[0, 1] = ItensCtrl.ItemType.FrutasVermelhas;
        recipe[0, 2] = ItensCtrl.ItemType.TuttiFruti;
        sonoEternoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.CheiroDeUnicornio;
        recipe[0, 1] = ItensCtrl.ItemType.FrutasVermelhas;
        recipe[0, 2] = ItensCtrl.ItemType.CheiroDeCarro;
        sonoEternoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.CheiroDeUnicornio;
        recipe[0, 1] = ItensCtrl.ItemType.FrutasVermelhas;
        recipe[0, 2] = ItensCtrl.ItemType.PernaDeCobra;
        sonoEternoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.CheiroDeUnicornio;
        recipe[0, 1] = ItensCtrl.ItemType.Amarelo;
        recipe[0, 2] = ItensCtrl.ItemType.VerrugaDeSapo;
        sonoEternoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.CheiroDeUnicornio;
        recipe[0, 1] = ItensCtrl.ItemType.Amarelo;
        recipe[0, 2] = ItensCtrl.ItemType.Adocante;
        sonoEternoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.CheiroDeUnicornio;
        recipe[0, 1] = ItensCtrl.ItemType.Amarelo;
        recipe[0, 2] = ItensCtrl.ItemType.RestoDeRaloDePia;
        sonoEternoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.CheiroDeUnicornio;
        recipe[0, 1] = ItensCtrl.ItemType.Amarelo;
        recipe[0, 2] = ItensCtrl.ItemType.TuttiFruti;
        sonoEternoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.CheiroDeUnicornio;
        recipe[0, 1] = ItensCtrl.ItemType.Amarelo;
        recipe[0, 2] = ItensCtrl.ItemType.CheiroDeCarro;
        sonoEternoRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.CheiroDeUnicornio;
        recipe[0, 1] = ItensCtrl.ItemType.Amarelo;
        recipe[0, 2] = ItensCtrl.ItemType.PernaDeCobra;
        sonoEternoRecipes.Add(recipe);

        recipeDictionary[ItensCtrl.ItemType.SonoEterno] = sonoEternoRecipes;

        //VenenoDeCobra recipes
        List<ItensCtrl.ItemType[,]> venenoDeCobraRecipes = new List<ItensCtrl.ItemType[,]>();

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.OlhoDeCobraCega;
        recipe[0, 1] = ItensCtrl.ItemType.VerrugaDeSapo; // Amargo
        recipe[0, 2] = ItensCtrl.ItemType.MandiocaBraba; // Potente
        venenoDeCobraRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.OlhoDeCobraCega;
        recipe[0, 1] = ItensCtrl.ItemType.VerrugaDeSapo;
        recipe[0, 2] = ItensCtrl.ItemType.Azeitona;
        venenoDeCobraRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.OlhoDeCobraCega;
        recipe[0, 1] = ItensCtrl.ItemType.VerrugaDeSapo;
        recipe[0, 2] = ItensCtrl.ItemType.PlutonioEnriquecido;
        venenoDeCobraRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.OlhoDeCobraCega;
        recipe[0, 1] = ItensCtrl.ItemType.VerrugaDeSapo;
        recipe[0, 2] = ItensCtrl.ItemType.CacoDeVidro;
        venenoDeCobraRecipes.Add(recipe);
        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.OlhoDeCobraCega;
        recipe[0, 1] = ItensCtrl.ItemType.VerrugaDeSapo; 
        recipe[0, 2] = ItensCtrl.ItemType.AUltimaLagrima; 
        venenoDeCobraRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.OlhoDeCobraCega;
        recipe[0, 1] = ItensCtrl.ItemType.VerrugaDeSapo; 
        recipe[0, 2] = ItensCtrl.ItemType.SuorDePombo;
        venenoDeCobraRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.OlhoDeCobraCega;
        recipe[0, 1] = ItensCtrl.ItemType.PernaDeBarata;
        recipe[0, 2] = ItensCtrl.ItemType.MandiocaBraba;
        venenoDeCobraRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.OlhoDeCobraCega;
        recipe[0, 1] = ItensCtrl.ItemType.PernaDeBarata;
        recipe[0, 2] = ItensCtrl.ItemType.Azeitona;
        venenoDeCobraRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.OlhoDeCobraCega;
        recipe[0, 1] = ItensCtrl.ItemType.PernaDeBarata;
        recipe[0, 2] = ItensCtrl.ItemType.PlutonioEnriquecido;
        venenoDeCobraRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.OlhoDeCobraCega;
        recipe[0, 1] = ItensCtrl.ItemType.PernaDeBarata;
        recipe[0, 2] = ItensCtrl.ItemType.CacoDeVidro;
        venenoDeCobraRecipes.Add(recipe);
        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.OlhoDeCobraCega;
        recipe[0, 1] = ItensCtrl.ItemType.PernaDeBarata;
        recipe[0, 2] = ItensCtrl.ItemType.AUltimaLagrima;
        venenoDeCobraRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.OlhoDeCobraCega;
        recipe[0, 1] = ItensCtrl.ItemType.PernaDeBarata;
        recipe[0, 2] = ItensCtrl.ItemType.SuorDePombo;
        venenoDeCobraRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.OlhoDeCobraCega;
        recipe[0, 1] = ItensCtrl.ItemType.OlhoDePeixe;
        recipe[0, 2] = ItensCtrl.ItemType.MandiocaBraba;
        venenoDeCobraRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.OlhoDeCobraCega;
        recipe[0, 1] = ItensCtrl.ItemType.OlhoDePeixe;
        recipe[0, 2] = ItensCtrl.ItemType.Azeitona;
        venenoDeCobraRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.OlhoDeCobraCega;
        recipe[0, 1] = ItensCtrl.ItemType.OlhoDePeixe;
        recipe[0, 2] = ItensCtrl.ItemType.PlutonioEnriquecido;
        venenoDeCobraRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.OlhoDeCobraCega;
        recipe[0, 1] = ItensCtrl.ItemType.OlhoDePeixe;
        recipe[0, 2] = ItensCtrl.ItemType.CacoDeVidro;
        venenoDeCobraRecipes.Add(recipe);
        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.OlhoDeCobraCega;
        recipe[0, 1] = ItensCtrl.ItemType.OlhoDePeixe;
        recipe[0, 2] = ItensCtrl.ItemType.AUltimaLagrima;
        venenoDeCobraRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.OlhoDeCobraCega;
        recipe[0, 1] = ItensCtrl.ItemType.OlhoDePeixe;
        recipe[0, 2] = ItensCtrl.ItemType.SuorDePombo;
        venenoDeCobraRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.OlhoDeCobraCega;
        recipe[0, 1] = ItensCtrl.ItemType.AlmaDeLagosta;
        recipe[0, 2] = ItensCtrl.ItemType.MandiocaBraba;
        venenoDeCobraRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.OlhoDeCobraCega;
        recipe[0, 1] = ItensCtrl.ItemType.AlmaDeLagosta;
        recipe[0, 2] = ItensCtrl.ItemType.Azeitona;
        venenoDeCobraRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.OlhoDeCobraCega;
        recipe[0, 1] = ItensCtrl.ItemType.AlmaDeLagosta;
        recipe[0, 2] = ItensCtrl.ItemType.PlutonioEnriquecido;
        venenoDeCobraRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.OlhoDeCobraCega;
        recipe[0, 1] = ItensCtrl.ItemType.AlmaDeLagosta;
        recipe[0, 2] = ItensCtrl.ItemType.CacoDeVidro;
        venenoDeCobraRecipes.Add(recipe);
        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.OlhoDeCobraCega;
        recipe[0, 1] = ItensCtrl.ItemType.AlmaDeLagosta;
        recipe[0, 2] = ItensCtrl.ItemType.AUltimaLagrima;
        venenoDeCobraRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.OlhoDeCobraCega;
        recipe[0, 1] = ItensCtrl.ItemType.AlmaDeLagosta;
        recipe[0, 2] = ItensCtrl.ItemType.SuorDePombo;
        venenoDeCobraRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.OlhoDeCobraCega;
        recipe[0, 1] = ItensCtrl.ItemType.CheiroDeCarro;
        recipe[0, 2] = ItensCtrl.ItemType.MandiocaBraba;
        venenoDeCobraRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.OlhoDeCobraCega;
        recipe[0, 1] = ItensCtrl.ItemType.CheiroDeCarro;
        recipe[0, 2] = ItensCtrl.ItemType.Azeitona;
        venenoDeCobraRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.OlhoDeCobraCega;
        recipe[0, 1] = ItensCtrl.ItemType.CheiroDeCarro;
        recipe[0, 2] = ItensCtrl.ItemType.PlutonioEnriquecido;
        venenoDeCobraRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.OlhoDeCobraCega;
        recipe[0, 1] = ItensCtrl.ItemType.CheiroDeCarro;
        recipe[0, 2] = ItensCtrl.ItemType.CacoDeVidro;
        venenoDeCobraRecipes.Add(recipe);
        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.OlhoDeCobraCega;
        recipe[0, 1] = ItensCtrl.ItemType.CheiroDeCarro;
        recipe[0, 2] = ItensCtrl.ItemType.AUltimaLagrima;
        venenoDeCobraRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.OlhoDeCobraCega;
        recipe[0, 1] = ItensCtrl.ItemType.CheiroDeCarro;
        recipe[0, 2] = ItensCtrl.ItemType.SuorDePombo;
        venenoDeCobraRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.OlhoDeCobraCega;
        recipe[0, 1] = ItensCtrl.ItemType.Amarelo;
        recipe[0, 2] = ItensCtrl.ItemType.MandiocaBraba;
        venenoDeCobraRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.OlhoDeCobraCega;
        recipe[0, 1] = ItensCtrl.ItemType.Amarelo;
        recipe[0, 2] = ItensCtrl.ItemType.Azeitona;
        venenoDeCobraRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.OlhoDeCobraCega;
        recipe[0, 1] = ItensCtrl.ItemType.Amarelo;
        recipe[0, 2] = ItensCtrl.ItemType.PlutonioEnriquecido;
        venenoDeCobraRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.OlhoDeCobraCega;
        recipe[0, 1] = ItensCtrl.ItemType.Amarelo;
        recipe[0, 2] = ItensCtrl.ItemType.CacoDeVidro;
        venenoDeCobraRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.OlhoDeCobraCega;
        recipe[0, 1] = ItensCtrl.ItemType.Amarelo;
        recipe[0, 2] = ItensCtrl.ItemType.AUltimaLagrima;
        venenoDeCobraRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.OlhoDeCobraCega;
        recipe[0, 1] = ItensCtrl.ItemType.Amarelo;
        recipe[0, 2] = ItensCtrl.ItemType.SuorDePombo;
        venenoDeCobraRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.OlhoDeCobraCega;
        recipe[0, 1] = ItensCtrl.ItemType.BundaDeTanajura;
        recipe[0, 2] = ItensCtrl.ItemType.MandiocaBraba;
        venenoDeCobraRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.OlhoDeCobraCega;
        recipe[0, 1] = ItensCtrl.ItemType.BundaDeTanajura;
        recipe[0, 2] = ItensCtrl.ItemType.Azeitona;
        venenoDeCobraRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.OlhoDeCobraCega;
        recipe[0, 1] = ItensCtrl.ItemType.BundaDeTanajura;
        recipe[0, 2] = ItensCtrl.ItemType.PlutonioEnriquecido;
        venenoDeCobraRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.OlhoDeCobraCega;
        recipe[0, 1] = ItensCtrl.ItemType.BundaDeTanajura;
        recipe[0, 2] = ItensCtrl.ItemType.CacoDeVidro;
        venenoDeCobraRecipes.Add(recipe);
        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.OlhoDeCobraCega;
        recipe[0, 1] = ItensCtrl.ItemType.BundaDeTanajura;
        recipe[0, 2] = ItensCtrl.ItemType.AUltimaLagrima;
        venenoDeCobraRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.OlhoDeCobraCega;
        recipe[0, 1] = ItensCtrl.ItemType.BundaDeTanajura;
        recipe[0, 2] = ItensCtrl.ItemType.SuorDePombo;
        venenoDeCobraRecipes.Add(recipe);

        recipeDictionary[ItensCtrl.ItemType.SonoEterno] = sonoEternoRecipes;

    }

    public bool IsEmpty(int x, int y)
    {
        return itemArray[x, y] == null;
    }

    public ItensCtrl GetItem(int x, int y)
    {
        return itemArray[x, y];
    }

    public void SetItem (ItensCtrl item, int x, int y)
    {
        if (item != null)
        {
            item.RemoveFromItemHolder();
            item.SetItemHolder(this);
        }
        itemArray[x, y] = item;
        CreateOutput();
        OnGridChanged?.Invoke(this, EventArgs.Empty);
    }

    public void IncreaseItemAmount (int x, int y)
    {
        GetItem(x, y).amount++;
        OnGridChanged?.Invoke(this, EventArgs.Empty);
    }

    public void DecreaseItemAmount(int x, int y)
    {
        if (GetItem(x, y) != null)
        {
            GetItem(x, y).amount--;
            if (GetItem(x, y).amount == 0)
            {
                RemoveItem(x, y);
            }
            OnGridChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public void RemoveItem(int x, int y)
    {
        SetItem(null, x, y);
    }

    public bool TryAddItem(ItensCtrl item, int x, int y)
    {
        if (IsEmpty(x, y))
        {
            SetItem(item, x, y);
            return true;
        }
        else
        {
            if (item.itemType == GetItem(x, y).itemType)
            {
                IncreaseItemAmount(x, y);
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public void RemoveItem(ItensCtrl item)
    {
        if (item == outputItem)
        {
            // Removed output item
            ConsumeRecipeItems();
            CreateOutput();
            OnGridChanged?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            // Removed item from grid
            for (int x = 0; x < gridSizeX; x++)
            {
                for (int y = 0; y < gridSizeY; y++)
                {
                    if (GetItem(x, y) == item)
                    {
                        // Removed this one
                        RemoveItem(x, y);
                    }
                }
            }
        }
    }

    public void AddItem(ItensCtrl item) { }

    public bool CanAddItem() { return false; }

    private ItensCtrl.ItemType GetRecipeOutput()
    {
        foreach (ItensCtrl.ItemType recipeItemType in recipeDictionary.Keys)
        {
            List<ItensCtrl.ItemType[,]> recipeList = recipeDictionary[recipeItemType];

            foreach (ItensCtrl.ItemType[,] recipe in recipeList)
            {
                bool completeRecipe = true;

                for (int x = 0; x < gridSizeX; x++)
                {
                    for (int y = 0; y < gridSizeY; y++)
                    {
                        if (recipe[x, y] != ItensCtrl.ItemType.None)
                        {
                            // Recipe has Item in this position
                            if (IsEmpty(x, y) || GetItem(x, y).itemType != recipe[x, y])
                            {
                                // Empty position or different itemType
                                completeRecipe = false;
                            }
                        }
                    }
                }

                if (completeRecipe)
                {
                    return recipeItemType;
                }
            }
        }
        return ItensCtrl.ItemType.None;
    }

    private void CreateOutput()
    {
        ItensCtrl.ItemType recipeOutput = GetRecipeOutput();
        if (recipeOutput == ItensCtrl.ItemType.None)
        {
            outputItem = null;
        }
        else
        {
            outputItem = new ItensCtrl { itemType = recipeOutput };
            outputItem.SetItemHolder(this);
        }
    }

    public ItensCtrl GetOutputItem()
    {
        return outputItem;
    }

    public void ConsumeRecipeItems()
    {
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                DecreaseItemAmount(x, y);
            }
        }
    }
}
