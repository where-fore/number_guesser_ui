using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoreGameTextManager : MonoBehaviour
{
    private TextMeshProUGUI textComponent = null;

    private string[] orcNames =
    {
        "Trurnug'tok Steelspirit",
        "Cithu'kush Rabidmane",
        "Buth Lowrunner",
        "Thruhlgul Hellmight",
        "Cugtak Bloodbones",
        "Udezast Firebones",
        "Krekk Dreambinder",
        "Dromzish Rabidbinder",
        "Thugg Longfall",
        "Umgamroz Clearbasher",
        "Krazarl Hellhorn",
        "Trilderg Clansmile",
        "Gozu Broadblood",
        "Sul Vicemight",
        "Urumvuld Deepcrusher",
        "Theth Silentspirit",
        "Hozkarndar Wildlock",
        "Guntost Nose-edge",
        "Crerl Deepsplitter",
        "Dumikk Irontusk",
        "Zug Zug",
        "Thurvosdukk Deadtooth",
        "Iggeld Strongforce",
        "Thast Hollowcleaver",
        "Trerl Womanhunter",
        "Bolarn Hellrest",
        "Ukzuzmokk Mandeath",
        "Brorduzroth Strongpack",
        "Zush Bloodsong",
        "Isoth Hellrunner",
        "Berdold Blackflame",
    };

    void Start()
    {
        textComponent = gameObject.GetComponent<TextMeshProUGUI>();

        textComponent.text = CreateText();
    }

    private string CreateText()
    {
        //string orcName = orcNames[Random.Range(0, orcNames.Length)].ToString();
        string orcName = orcNames[0].ToString();

        return orcName + " is a great guesser!";
    }

}
