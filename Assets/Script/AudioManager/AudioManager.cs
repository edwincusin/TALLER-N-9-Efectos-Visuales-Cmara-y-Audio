using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Singleton: AudioManager.Instancia.ReproducirSfx(clip);
    public static AudioManager Instancia;

    [Header("Fuentes de audio")]
    public AudioSource fuenteMusica;   // Música en bucle
    public AudioSource fuenteSfx;      // Efectos de sonido

    [Header("Clips de sonido")]
    public AudioClip musicaFondo;
    public AudioClip clipSalto;
    public AudioClip clipAtaque;
    public AudioClip clipDano;
    public AudioClip clipMoneda;

    private void Awake()
    {
        if (Instancia == null)
        {
            Instancia = this;
            DontDestroyOnLoad(gameObject);   // El audio persiste entre escenas
        }
        else
        {
            Destroy(gameObject);             // Evita duplicados
        }
    }

    void Start()
    {
        if (musicaFondo != null && fuenteMusica != null)
        {
            fuenteMusica.clip = musicaFondo;
            fuenteMusica.loop = true;
            fuenteMusica.Play();
        }
    }

    public void ReproducirSfx(AudioClip clip)
    {
        if (clip != null && fuenteSfx != null)
        {
            fuenteSfx.PlayOneShot(clip);
        }
    }
}