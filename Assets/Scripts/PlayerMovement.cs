using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Random = System.Random;

[RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    private int coins;
    [SerializeField] private int helth = 3;
    
    [SerializeField] private float moveSpeed = 3;

    [SerializeField] TextMeshProUGUI coinText;
    [SerializeField] private TextMeshProUGUI healthText;

    [SerializeField] private AudioClip[] coinPickUpSounds;
    
    private Rigidbody2D myRigidbody2D;

    private AudioSource myAudioSource;
    
    private InputAction move;
    
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myRigidbody2D.gravityScale = 0;

        myAudioSource = GetComponent<AudioSource>();
        
        move = InputSystem.actions.FindAction("Move");
    }
    
    void Update()
    {
        myRigidbody2D.linearVelocity = move.ReadValue<Vector2>() * moveSpeed;
        
        if (move.ReadValue<Vector2>().x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (move.ReadValue<Vector2>().x < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            coins++;
            myAudioSource.clip = coinPickUpSounds[new Random().Next(0, coinPickUpSounds.Length - 1)];
            myAudioSource.Play();
            coinText.text = $"Coins:{coins}";
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Enemy"))
        {
            helth--;

            healthText.text = $"hp:{helth}";

            if (helth <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
