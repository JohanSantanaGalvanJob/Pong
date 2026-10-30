using UnityEngine;

public class CPUController : MonoBehaviour
{
    public float CpuSpeed;
    public GameObject gameBall;

    private float originalSpeed;

    private void Start() {
        originalSpeed = CpuSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        if (gameBall.transform.position.y > this.transform.position.y) {
            GetComponent<Rigidbody2D>().AddForceY(CpuSpeed + 3);
        }

        if (gameBall.transform.position.y < this.transform.position.y) {
            GetComponent<Rigidbody2D>().AddForceY(-CpuSpeed -3);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision != null) {
            if (collision.collider.CompareTag("Ball") && CpuSpeed <70) {
                CpuSpeed *= 1.5f;
            }
        }
    }

    public void resetSpeed() {
        CpuSpeed = originalSpeed;
    }
}
