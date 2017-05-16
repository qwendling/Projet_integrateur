<<<<<<< HEAD
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerAnimation : NetworkBehaviour
{

    public float _runSpeed = 0.5f;
    public float _strafeSpeed = 0.5f;

    public Animator anim;
    // public float speed = 2.0f;
    // public float rotationSpeed = 75.0f;

    void Start ()
    {
    	anim = GetComponent<Animator>();
	}


    // Update is called once per frame
    void Update ()
    {

        // if(isLocalPlayer)
        // {
            // Get the input from up/down keys
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Advance...       in nose direction  by run speed * frame duration * input (-1/0/1)
        /*transform.position += transform.forward * _runSpeed * Time.deltaTime * verticalInput
                           + transform.right * _strafeSpeed * Time.deltaTime * horizontalInput;*/

        float translation = _runSpeed * verticalInput * Time.deltaTime;
        float rotation = _runSpeed * horizontalInput * Time.deltaTime;
        
        /*transform.Translate(0,0, translation);
        transform.Rotate(0,rotation,0);*/

        /*if(translation != 0)
        {
         anim.SetBool("walk", true);
         // anim.SetBool("ballattack", false);
        }
        else
        {
         anim.SetBool("walk", false);
         anim.SetBool("weapon", false);
        }*/

        // if(Input.GetKeyDown("z"))
        // {
        //     anim.SetBool("walk", true);
        //     // anim.SetBool("ballattack", false);
        // }
        // else
        // {
        //     anim.SetBool("walk", false);
        //     anim.SetBool("weapon", false);
        // }

        // if(Input.GetKeyDown("space"))
        // {
        //  anim.SetTrigger("attack");
        // }
        if(Input.GetKey("1"))
        {
            anim.SetBool("weapon", true);
            anim.SetBool("ak", false);
            anim.SetBool("ball", false);
        }
        if(Input.GetKeyDown("2"))
        {
            anim.SetBool("ak", true);
            anim.SetBool("weapon", false);
            anim.SetBool("ball", false);
        }

        if(Input.GetKeyDown("3"))
        {
            anim.SetBool("ball", true);
            anim.SetBool("weapon", false);
            anim.SetBool("ak", false);
            // anim.SetBool("ballattack", false);
        }

        if(Input.GetKeyDown("r"))
        {
            // anim.SetBool("ballattack", true);
            // anim.SetBool("walk", false);
            // animation["ballattack"].wrapMode = WrapMode.Once;
            anim.SetTrigger("w1attack");
            // anim.Play("ballattack");
        }
        // }
        
     
    }
}
=======
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerAnimation : NetworkBehaviour
{

    public float _runSpeed = 0.5f;
    public float _strafeSpeed = 0.5f;

    public Animator anim;
    // public float speed = 2.0f;
    // public float rotationSpeed = 75.0f;

    void Start ()
    {
    	anim = GetComponent<Animator>();
	}


    // Update is called once per frame
    void Update ()
    {

        // if(isLocalPlayer)
        // {
            // Get the input from up/down keys
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Advance...       in nose direction  by run speed * frame duration * input (-1/0/1)
        /*transform.position += transform.forward * _runSpeed * Time.deltaTime * verticalInput
                           + transform.right * _strafeSpeed * Time.deltaTime * horizontalInput;*/

        float translation = _runSpeed * verticalInput * Time.deltaTime;
        float rotation = _runSpeed * horizontalInput * Time.deltaTime;
        
        /*transform.Translate(0,0, translation);
        transform.Rotate(0,rotation,0);*/

        /*if(translation != 0)
        {
         anim.SetBool("walk", true);
         // anim.SetBool("ballattack", false);
        }
        else
        {
         anim.SetBool("walk", false);
         anim.SetBool("weapon", false);
        }*/

        // if(Input.GetKeyDown("z"))
        // {
        //     anim.SetBool("walk", true);
        //     // anim.SetBool("ballattack", false);
        // }
        // else
        // {
        //     anim.SetBool("walk", false);
        //     anim.SetBool("weapon", false);
        // }

        // if(Input.GetKeyDown("space"))
        // {
        //  anim.SetTrigger("attack");
        // }
        if(Input.GetKey("1"))
        {
            anim.SetBool("weapon", true);
            anim.SetBool("ak", false);
            anim.SetBool("ball", false);
        }
        if(Input.GetKeyDown("2"))
        {
            anim.SetBool("ak", true);
            anim.SetBool("weapon", false);
            anim.SetBool("ball", false);
        }

        if(Input.GetKeyDown("3"))
        {
            anim.SetBool("ball", true);
            anim.SetBool("weapon", false);
            anim.SetBool("ak", false);
            // anim.SetBool("ballattack", false);
        }

        if(Input.GetKeyDown("r"))
        {
            // anim.SetBool("ballattack", true);
            // anim.SetBool("walk", false);
            // animation["ballattack"].wrapMode = WrapMode.Once;
            anim.SetTrigger("w1attack");
            // anim.Play("ballattack");
        }
        // }
        
     
    }
}
>>>>>>> origin/master
