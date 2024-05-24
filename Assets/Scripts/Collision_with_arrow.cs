/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_with_arrow : MonoBehaviour
{

    public delegate void ArrowDestroyedHandler();
    public static event ArrowDestroyedHandler OnArrowDestroyed;
    //private AudioSource audioSource;
    
    
    
    //void Start() {
        //audioSource = GetComponent<AudioSource>();

    //}


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Arrow")){
            OnArrowDestroyed?.Invoke();
            Destroy(collision.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Arrow"))
        {
            OnArrowDestroyed?.Invoke();
            Destroy(other.gameObject);
        }
    }

}
*/



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_with_arrow : MonoBehaviour
{
    // Define a delegate with a string parameter for side information
    public delegate void ArrowDestroyedHandler(string side);

    // Define an event using the delegate
    public static event ArrowDestroyedHandler OnArrowDestroyed;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Arrow"))
        {
            // Extract the side information from the arrow object, assuming it has a Side component
            string side = collision.gameObject.GetComponent<ArrowSide>().side;

            // Invoke the event and pass the side information
            OnArrowDestroyed?.Invoke(side);

            // Destroy the arrow
            Destroy(collision.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Arrow"))
        {
            // Extract the side information from the arrow object, assuming it has a Side component
            string side = other.gameObject.GetComponent<ArrowSide>().side;

            // Invoke the event and pass the side information
            OnArrowDestroyed?.Invoke(side);

            // Destroy the arrow
            Destroy(other.gameObject);
        }
    }
}
