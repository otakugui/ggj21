using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    private AudioController _AudioController;

    [Header("Câmera")]
    public CinemachineVirtualCamera virtualCamera;

    [Header("Game Objects")]
    public GameObject dog;
    public GameObject cat;
    public GameObject rat;
    public GameObject currentAnimal;

    [Header("Movimentação")]
    public float dogSpeed;
    public float catSpeed;
    public float ratSpeed;
    public float dogJumpHeight;
    public float catJumpHeight;
    public float ratJumpHeight;
    private float height;
    private float speed;
    public float step;
    public bool onGround;

    [Header("Animação")]
    public Animator dogAnim;
    public Animator catAnim;
    public Animator ratAnim;

    // Start is called before the first frame update
    void Start()
    {
        _AudioController = FindObjectOfType(typeof(AudioController)) as AudioController;
        currentAnimal = rat;
        speed = ratSpeed;
        height = ratJumpHeight;
        _AudioController.ChangeMusic(_AudioController.ratAudio);
    }

    // Update is called once per frame
    void Update()
    {  
        Debug.Log(speed);
        transform.position = new Vector3(currentAnimal.transform.position.x, 0, currentAnimal.transform.position.z);
        ChooseAnimal();
        AnimateAnimal();    
        CameraTarget();
        ControlAnimal(currentAnimal.transform, currentAnimal.GetComponent<Rigidbody>(), 0.2f, height);
        
    }

    void ChooseAnimal(){
        if(Input.GetKeyDown(KeyCode.Z)){
            currentAnimal = dog;
            speed = dogSpeed;
            height = dogJumpHeight;
            _AudioController.ChangeMusic(_AudioController.dogAudio);
        }
        if(Input.GetKeyDown(KeyCode.X)){
            currentAnimal = cat;
            speed = catSpeed;
            height = catJumpHeight;
            _AudioController.ChangeMusic(_AudioController.catAudio);
        }
        if(Input.GetKeyDown(KeyCode.C)){
            currentAnimal = rat;
            speed = ratSpeed;
            height = ratJumpHeight;
            _AudioController.ChangeMusic(_AudioController.ratAudio);
        }
    }

    void CameraTarget(){
        virtualCamera.LookAt = currentAnimal.transform;
        virtualCamera.Follow = currentAnimal.transform;
    }

    void ControlAnimal(Transform animal, Rigidbody rb, float speed, float height){
        float inputx = Input.GetAxis("Horizontal");
        float inputz = Input.GetAxis("Vertical");
        float axisCombined = inputx / inputz;

        Vector3 lookDir = new Vector3(inputx, 0, inputz);

        if(rb.velocity.magnitude > 0.1f || lookDir == Vector3.zero) return;

        Quaternion lookRotation = Quaternion.LookRotation(lookDir, Vector3.up);
        animal.rotation = Quaternion.Slerp(animal.rotation, lookRotation, Time.deltaTime * step);
        transform.rotation = animal.rotation;

        animal.Translate(Vector3.forward * speed);

        if(Input.GetKeyDown(KeyCode.Space)){
            rb.AddForce(new Vector3(0, height, 0), ForceMode.Impulse);
            Debug.Log("jump");
        }
    }

    void AnimateAnimal(){
        if(currentAnimal == rat){
            if(Input.GetAxis("Horizontal") < -0.1f || Input.GetAxis("Horizontal") > 0.1f || Input.GetAxis("Vertical") < -0.1f || Input.GetAxis("Vertical") > 0.1f){
                ratAnim.SetFloat("Speed", 10);
            } else {
                ratAnim.SetFloat("Speed", 0);
            }
        }
    }

    public void Teleport(Transform id){
        //
    }
}
