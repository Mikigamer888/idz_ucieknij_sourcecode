using UnityEngine;
using UnityEngine.SceneManagement; // Potrzebne do zarz¹dzania scenami

public class ResetOnSpike : MonoBehaviour
{
    public LayerMask spikeLayer; // Warstwa, któr¹ bêd¹ mia³y obiekty "Spike"

    void OnCollisionEnter2D(Collision2D collision)
    {
        // SprawdŸ, czy obiekt, z którym nast¹pi³a kolizja, znajduje siê na warstwie "Spike"
        if (((1 << collision.gameObject.layer) & spikeLayer) != 0)
        {
            Debug.Log("Gracz dotkn¹³ kolca! Resetujê scenê.");
            // Pobierz indeks bie¿¹cej sceny i za³aduj j¹ ponownie
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    // Mo¿esz równie¿ u¿yæ OnTriggerEnter2D, jeœli kolce s¹ triggerami (np. niewidzialne pu³apki)
    /*
    void OnTriggerEnter2D(Collider2D other)
    {
        if (((1 << other.gameObject.layer) & spikeLayer) != 0)
        {
            Debug.Log("Gracz dotkn¹³ triggera kolca! Resetujê scenê.");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    */
}