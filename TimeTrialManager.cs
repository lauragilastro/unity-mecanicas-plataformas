using UnityEngine;

public class TimeTrialManager : MonoBehaviour 
{
    [Header("Cubos del Desafío")]
    public GameObject cubo3;
    public GameObject cubo4;

    [Header("Temporizador")]
    public float tiempo = 0f;
    public float finalTiempo = 4.0f;
    public bool inicioTiempo = false;
    private bool masTiempo = false;

    [Header("Audio")]
    public AudioSource bgmusic;
    public AudioSource reloj;
    public AudioSource extraTime;
    public AudioClip sonidoFallo;
    private AudioSource localAudioSource;

    void Start()
    {
        localAudioSource = GetComponent<AudioSource>();
        if (bgmusic) bgmusic.Play();
        if (reloj) reloj.Stop();
        if (extraTime) extraTime.Stop();
    }

    void Update()
    {
        if (masTiempo)
        {
            finalTiempo = 9.0f;
        }

        if (inicioTiempo)
        {
            tiempo += Time.deltaTime;
            if (tiempo > finalTiempo)
            {
                ReiniciarDesafio();
            }
        }
    }

    void OnTriggerEnter(Collider Col)
    {
        // Iniciar el desafío al pisar el trigger amarillo
        if (Col.CompareTag("Player") && gameObject.CompareTag("amarillo"))
        {
            cubo3.SetActive(false);
            cubo4.SetActive(true);
            
            if (reloj) reloj.Play();
            if (bgmusic) bgmusic.Stop();
            
            inicioTiempo = true;
        }

        // Recoger tiempo extra
        if (Col.CompareTag("mas"))
        {
            masTiempo = true;
            if (extraTime) extraTime.Play();
            Destroy(Col.gameObject);
        }
    }

    void ReiniciarDesafio()
    {
        cubo3.SetActive(true);
        cubo4.SetActive(false);
        
        if (localAudioSource && sonidoFallo)
        {
            localAudioSource.PlayOneShot(sonidoFallo, 1.0f);
        }

        if (reloj) reloj.Stop();
        if (bgmusic) bgmusic.Play();

        tiempo = 0.0f;
        inicioTiempo = false;
    }
}