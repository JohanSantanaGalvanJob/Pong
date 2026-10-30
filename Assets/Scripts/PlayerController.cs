using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private float anguloObjetivo = 0;
    private float anguloActual = 0;

    private float originalSpeed;

    private void Start() {
        originalSpeed = speed;
    }

    // Update is called once per frame
    void Update() {

        //Aplicamos la velocidad en el eje vertical
        GetComponent<Rigidbody2D>().linearVelocityY = Input.GetAxisRaw("Vertical") * speed;
        if (Input.GetKeyDown(KeyCode.Space)) {
            anguloObjetivo -= 180f;
        }

        anguloActual = Mathf.MoveTowards(anguloActual, anguloObjetivo, 360f * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0,0,anguloActual);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision != null) {
            if (collision.collider.CompareTag("Ball") && speed <70) {
                speed *= 1.5f;
            }
        }
    }

    public void resetSpeed() {
        speed = originalSpeed;
    }
}
