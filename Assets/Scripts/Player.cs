using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player : MonoBehaviour
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
    private float speed;
    public float step;

    // Start is called before the first frame update
    void Start()
    {
        _AudioController = FindObjectOfType(typeof(AudioController)) as AudioController;
        currentAnimal = dog;
        speed = dogSpeed;
    }

    // Update is called once per frame
    void Update()
    {  
        transform.position = new Vector3(currentAnimal.transform.position.x, 0, currentAnimal.transform.position.z);
        ChooseAnimal();
        CameraTarget();
        ControlAnimal(currentAnimal.transform, currentAnimal.GetComponent<Rigidbody>(), 0.2f);
    }

    void ChooseAnimal(){
        if(Input.GetKeyDown(KeyCode.Z)){
            currentAnimal = dog;
            speed = dogSpeed;
            _AudioController.ChangeMusic(_AudioController.dogAudio);
        }
        if(Input.GetKeyDown(KeyCode.X)){
            currentAnimal = cat;
            speed = catSpeed;
            _AudioController.ChangeMusic(_AudioController.catAudio);
        }
        if(Input.GetKeyDown(KeyCode.C)){
            currentAnimal = rat;
            speed = ratSpeed;
            _AudioController.ChangeMusic(_AudioController.ratAudio);
        }
    }

    void CameraTarget(){
        virtualCamera.LookAt = currentAnimal.transform;
        virtualCamera.Follow = currentAnimal.transform;
    }

    void ControlAnimal(Transform animal, Rigidbody rb, float speed){
        float inputx = Input.GetAxis("Horizontal");
        float inputz = Input.GetAxis("Vertical");
        float axisCombined = inputx / inputz;

        Vector3 lookDir = new Vector3(inputx, 0, inputz);

        if(rb.velocity.magnitude > 0.1f || lookDir == Vector3.zero) return;

        Quaternion lookRotation = Quaternion.LookRotation(lookDir, Vector3.up);
        animal.rotation = Quaternion.Slerp(animal.rotation, lookRotation, Time.deltaTime * step);
        transform.rotation = animal.rotation;

        animal.Translate(Vector3.forward * speed);
    }
}
