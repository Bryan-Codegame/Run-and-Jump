using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    //RIGIDBODY
    private Rigidbody playerR;

    //PARTICLES
    public ParticleSystem[] particles;

    //ANIMATIONS PARAMS
    private Animator _animator;

    private const string SPEED_F = "Speed_f";
    private const string SPEED_MULTIPLY = "Speed_Multiply";
    private const string JUMP = "Jump_trig";
    private const string DEATH = "Death_b";
    private const string DEATH_TYPE = "DeathType_int";

    //AUDIO
    private AudioSource _audioSource;

    //Audioclip
    public AudioClip crashSound, jumpSound;
    [Range(0,1)]
    public float AudioVolumeJump = 1f;
    [Range(0,1)]
    public float AudioVolumeCrash = 1f;


    //Animaciones parámetros
    private float movingAnim = 1; //(//Idle = 0, walk > 0.01, run >0.5)
    private float speedAnim = 1;
    
    //Fuerza de salto
    public float jumpForce;

    //Manipulación de gravedad
    public float gravityChange;
    private bool isOnGround = true;

    //GameOver siendo privado pero usable en otras clases.
    private bool _gameOver;
    public bool GameOver {get => _gameOver;}

    //Particles index
    private int explosionParticle = 0;
    private int dirtWalkParticle = 1;

    // Start is called before the first frame update
    void Start()
    {   
        _audioSource = GetComponent<AudioSource>();

        playerR = GetComponent<Rigidbody>();

        //Cambiar la gravedad
        //Instrucción antigua:  Physics.gravity *= gravityChange Esto incrementaba cada vez que se reiniciaba entonces el personaje saltaba más bajo
        Physics.gravity = gravityChange*new Vector3(0, -9.81f, 0);

        //Animations Starts
        _animator = GetComponent<Animator>();
        _animator.SetFloat(SPEED_F, movingAnim);
        _animator.SetFloat(SPEED_MULTIPLY, speedAnim);
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetFloat(SPEED_MULTIPLY, speedAnim + Time.time/100);
        
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !_gameOver)
        {
            playerR.AddForce(Vector3.up*jumpForce, ForceMode.Impulse); //F = m*a la fuerza es de 1000 dividido para la masa del cuerpo es igual a la aceleración con la que se impulsa hacia arriba.
            isOnGround = false;
            _animator.SetTrigger(JUMP);
            particles[dirtWalkParticle].Stop();

            //Si el efecto de sonido al saltar no suena quizá es porque está al máximo el paráetro Spacial Blend del audioSource, este debería estar en 0 para que no simule un efecto de audio 3D.
            _audioSource.PlayOneShot(jumpSound, AudioVolumeJump );            
        }

    }

    private void OnCollisionEnter(Collision other) {
        if (!_gameOver)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                isOnGround = true;
                particles[dirtWalkParticle].Play();
            }

            if (other.gameObject.CompareTag("Obstacle"))
            {
                GameFinished();
                Invoke("RestartGame", 5.0f);
            }
        }

    }

    //Game Over
    void GameFinished()
    {
        _gameOver = true;
        isOnGround = false;

        //Animations
        _animator.SetInteger(DEATH_TYPE, Random.Range(1,3));
        _animator.SetBool(DEATH, true);

        //Particles
        particles[explosionParticle].Play();
        particles[dirtWalkParticle].Stop();

        //Audio
        _audioSource.PlayOneShot(crashSound, AudioVolumeCrash);

    }

    void RestartGame()
    {
        SceneManager.LoadScene("Prototype 3");
    }
}
