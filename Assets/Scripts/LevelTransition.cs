using UnityEngine;
using UnityEngine.SceneManagement; // Potrzebne do zarz¹dzania scenami

public class LevelTransition : MonoBehaviour
{
    public string nextSceneName; // Nazwa nastêpnej sceny, do której chcesz przejœæ
    public LayerMask winLayer; // Warstwa, któr¹ bêdzie mia³ obiekt "Win Trigger"

    void OnTriggerEnter2D(Collider2D other)
    {
        // SprawdŸ, czy obiekt, który wszed³ w trigger, znajduje siê na warstwie "Win"
        if (((1 << other.gameObject.layer) & winLayer) != 0)
        {
            Debug.Log("Gracz dotkn¹³ triggera 'Win'. Przechodzê do nastêpnej sceny: " + nextSceneName);
            SceneManager.LoadScene(nextSceneName); // £aduje scenê o podanej nazwie
        }
    }
}