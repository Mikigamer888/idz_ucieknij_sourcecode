using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 5f; // Si³a skoku
    public LayerMask groundLayer; // Warstwa "ziemi" (platform)

    private Rigidbody2D rb;
    private bool isGrounded; // Flaga wskazuj¹ca, czy gracz jest na ziemi

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Brak komponentu Rigidbody2D na tym obiekcie! Dodaj Rigidbody2D, aby skrypt dzia³a³ poprawnie.");
        }
    }

    void Update()
    {
        // Jeœli lewy przycisk myszy zosta³ klikniêty i gracz jest na ziemi, wykonaj skok
        if (Input.GetMouseButtonDown(0) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false; // Po skoku ustawiamy na false, ¿eby nie skakaæ w powietrzu
        }
    }

    // Metoda wywo³ywana, gdy ten kolider wejdzie w kolizjê z innym koliderem
    void OnCollisionEnter2D(Collision2D collision)
    {
        // SprawdŸ, czy obiekt, z którym nast¹pi³a kolizja, jest na warstwie "ziemi"
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            // Opcjonalnie: Upewnij siê, ¿e kolizja nastêpuje od do³u (aby gracz nie skaka³ po zderzeniu z bokiem platformy)
            // Mo¿esz to sprawdziæ, analizuj¹c normaln¹ wektora kolizji
            foreach (ContactPoint2D contact in collision.contacts)
            {
                // Jeœli normalna wektora kolizji wskazuje w górê (czyli kolizja nast¹pi³a od do³u),
                // oznacza to, ¿e gracz stoi na platformie.
                if (Vector2.Dot(contact.normal, Vector2.up) > 0.5f) // U¿yj wartoœci np. 0.5f jako próg
                {
                    isGrounded = true;
                    return; // Wystarczy jeden punkt styku od do³u, ¿eby uznaæ gracza za uziemionego
                }
            }
        }
    }

    // Metoda wywo³ywana, gdy ten kolider przestanie kolidowaæ z innym koliderem
    void OnCollisionExit2D(Collision2D collision)
    {
        // SprawdŸ, czy obiekt, z którym przestaliœmy kolidowaæ, by³ na warstwie "ziemi"
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            // Mo¿liwe, ¿e gracz zszed³ z platformy lub z niej zeskoczy³
            // Jeœli nie kolidujemy ju¿ z ¿adnym obiektem na warstwie groundLayer, ustawiamy isGrounded na false.
            // Wa¿ne: to uproszczenie. W bardziej z³o¿onych scenariuszach (np. ruchome platformy, wiele kontaktów)
            // lepszym rozwi¹zaniem jest sprawdzanie w OnCollisionStay2D lub OverlapCircle.
            // Dla prostego skakania ten scenariusz jest wystarczaj¹cy.
            isGrounded = false;
        }
    }

    // Dodatkowo, aby upewniæ siê, ¿e isGrounded jest zawsze poprawne, nawet gdy gracz jest "stabilny" na platformie,
    // mo¿esz u¿yæ OnCollisionStay2D.
    void OnCollisionStay2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                if (Vector2.Dot(contact.normal, Vector2.up) > 0.5f)
                {
                    isGrounded = true;
                    return;
                }
            }
        }
    }
}