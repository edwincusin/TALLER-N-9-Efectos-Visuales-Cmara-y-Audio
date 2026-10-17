using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    // Singleton: acceso desde cualquier script con CameraShake.Instancia
    public static CameraShake Instancia;

    private Vector3 posicionOriginal;


    // Unity lo ejecuta automáticamente al crearse el objeto,
    // antes de Start y antes de cualquier Update.
    private void Awake()
    {
        if (Instancia == null) //si Todavía nadie se ha registrado como "la instancia
        {
            Instancia = this; //Sí: este script se guarda a sí mismo
        }
    }

    // duracion: segundos que dura el temblor. fuerza: desplazamiento máximo de la cámara.
    public void Sacudir(float duracion, float fuerza)
    {
        // Inicia la corrutina, que corre a lo largo de varios frames sin congelar el juego.
        StartCoroutine(RutinaSacudida(duracion, fuerza));
    }

    IEnumerator RutinaSacudida(float duracion, float fuerza)
    {
        // Guarda dónde está la cámara ahora mismo (posición local respecto a su padre).
        posicionOriginal = transform.localPosition;

        float tiempoTranscurrido = 0f;         // Contador de cuánto tiempo lleva sacudiéndose.

        // Repite mientras no se haya cumplido la duración.
        while (tiempoTranscurrido < duracion)
        {
            // Desplazamiento aleatorio entre -fuerza y +fuerza en cada eje.
            float desplazamientoX = Random.Range(-1f, 1f) * fuerza;
            float desplazamientoY = Random.Range(-1f, 1f) * fuerza;

            // Mueve la cámara a su posición original + el desplazamiento aleatorio.
            // La Z no se toca para no alejar ni acercar la cámara.
            transform.localPosition = new Vector3(posicionOriginal.x + desplazamientoX,posicionOriginal.y + desplazamientoY,posicionOriginal.z);

            // Suma el tiempo que tardó el último frame.
            tiempoTranscurrido += Time.deltaTime;
            // Pausa aquí y continúa en el siguiente frame.
            yield return null;
        }

        transform.localPosition = posicionOriginal;
    }
}