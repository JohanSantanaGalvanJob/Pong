using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BallMotion : MonoBehaviour
{
    public int ballSpeed;


    private Vector2 motion = Vector2.zero;

    public int cpuScore = 0;
    public int playerScore = 0;

    public CPUController cpu;

    public PlayerController player;

    [SerializeField] TextMeshProUGUI playerText;
    [SerializeField] TextMeshProUGUI cpuText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RandomDirection();  
    }

    private void RandomDirection () {
        int direction = Random.Range(0, 4);
        
        switch (direction) {
            case 0:
                motion = new Vector2(ballSpeed, ballSpeed);
                break;
            case 1:
                motion = new Vector2(ballSpeed, -ballSpeed);
                break;
            case 2:
                motion = new Vector2(-ballSpeed, ballSpeed);
                break;
            case 3:
                motion = new Vector2(-ballSpeed, -ballSpeed);
                break;
        }
        GetComponent<Rigidbody2D>().linearVelocity = motion;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision != null) {
            if (collision.collider.CompareTag("LeftLimit")) {
                cpuScore++;
                cpuText.text = cpuScore.ToString();
                RandomDirection();
                this.transform.position = Vector2.zero;
                cpu.resetSpeed();
                player.resetSpeed();
            }
            if (collision.collider.CompareTag("RightLimit")) {
                playerScore++;
                playerText.text = playerScore.ToString();
                RandomDirection();
                this.transform.position = Vector2.zero;
                player.resetSpeed();
                cpu.resetSpeed();

            }

            if (collision.collider.CompareTag("Paddle")) {
                GetComponent<Rigidbody2D>().linearVelocity *= 1.2f;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
