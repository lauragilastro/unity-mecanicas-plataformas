using UnityEngine;

public class QuestTrigger : MonoBehaviour 
{
    [Header("Configuración de la Quest")]
    public string tagRequerido = "Player"; // Qué tag debe pisar el trigger
    public GameObject objetoAApagar;
    public GameObject objetoAEncender;
    
    [Header("Sonido")]
    public AudioClip sonido;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider Col)
    {
        if (Col.CompareTag(tagRequerido))
        {
            if (objetoAApagar != null) objetoAApagar.SetActive(false);
            if (objetoAEncender != null) objetoAEncender.SetActive(true);
            
            if (audioSource != null && sonido != null)
            {
                audioSource.PlayOneShot(sonido, 1.0f);
            }
        }
    }
}