using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FakeKI : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject player;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource aSource;
    [SerializeField] private GameObject blankImage;
    [SerializeField] private LightFlicker light;
    [SerializeField] private AudioClip Hit, Scream;
    // Update is called once per frame
    void FixedUpdate()
    {
        this.gameObject.transform.LookAt(new Vector3(player.transform.position.x,0, player.transform.position.z));
 
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject == player)
        {
            LightSupportClass.IsFlickering = false;
            light.SetOn();
            this.GetComponent<CapsuleCollider>().enabled = false;
            player.GetComponent<PlayerController>().Movable = false;
            player.transform.LookAt(new Vector3(this.gameObject.transform.position.x,2.5f, this.gameObject.transform.position.z));
            animator.SetBool("Triggered",true);

            StartCoroutine(EndingDelayEnumerator());

            
        }
    }

    private IEnumerator EndingDelayEnumerator()
    {
        yield return new WaitForSeconds(1f);
        aSource.PlayOneShot(Hit);
        yield return new WaitForSeconds(0.2f);
        aSource.PlayOneShot(Scream);
        yield return new WaitForSeconds(0.1f);
        blankImage.SetActive(true);
        gameManager.GameOver = true;
    }
}
