using UnityEngine;
using TMPro;

public class GestorPuntaje3D : MonoBehaviour
{
    public static GestorPuntaje3D instancia;

    [Header("Referencias")]
    public TMP_Text textoScore;
    public Movimiento3D jugador;

    [Header("Progreso y Dificultad")]
    public int score = 0;
    public int highScore = 0;
    public float incrementoVelocidad = 0.5f;

    void Awake()
    {
        instancia = this;
    }

    void Start()
    {

        highScore = PlayerPrefs.GetInt("HighScore", 0);
        ActualizarUI();
    }

    public void SumarPuntos(int cantidad)
    {
        score += cantidad;


        if (jugador != null)
        {
            jugador.velocidad += incrementoVelocidad;
        }


        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
        
        if (score % 20 == 0 && GestorVisual3D.instancia != null)
        {
            GestorVisual3D.instancia.CambiarFondo();
            GestorVisual3D.instancia.CambiarColorJugadorAleatorio();
        }

        ActualizarUI();
    }

    void ActualizarUI()
    {
        if (textoScore != null)
        {
            float vel = jugador != null ? jugador.velocidad : 0f;
            textoScore.text = $"Score: {score}  |  HighScore: {highScore}\nVelocidad: {vel:F1}";
        }
    }
}