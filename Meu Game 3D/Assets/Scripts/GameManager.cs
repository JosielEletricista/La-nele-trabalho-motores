using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI HUD, Vitoria;
    public int restantes;
    public AudioClip clipMoeda, clipVitoria;

    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out source);

        restantes = FindObjectsOfType<Moeda>().Length;

        HUD.text = $"Moedas restantes: {restantes}";
    }

    public void SubtrairMoedas(int valor)
        {
        restantes -= valor;
        HUD.text = $"Moedas restantes: {restantes}";
        source.PlayOneShot(clipMoeda);
         if (restantes <= 0)
             {
                 Vitoria.text = "Parabens Você venceu Skiper!";
                 source.Stop();
                 source.PlayOneShot(clipVitoria);
             }
        }
    // Update is called once per frame
    void Update()
    {
       
    }
}
