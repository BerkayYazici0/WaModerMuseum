using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Video;
public class InfoBoxClick : MonoBehaviour
{
    public Camera Camera;
    public GameObject cameraObj;
    public GameObject player;
    public GameObject ArtInfoCard;
    public Text TitleTextJP;
    public Text TitleTextEN;
    public Text SizeText;
    public Image Art;
    private GameObject highlightedObj;
    public AudioSource audioBack;
    private bool rayState = false;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 
    }
    private void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(ray, out hit, 15f))
            {
                if (hit.transform.CompareTag("InfoBox") && Vector3.Distance(transform.position, hit.transform.position) < 3f && !rayState)
                {
                    ArtInfoCard.transform.DOScale(new Vector3(1, 1, 1), 1f);
                    var artInfo = hit.transform.GetComponent<ArtInformation>();
                    ArtInfoCard.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    TitleTextJP.text = artInfo.artTitleJP;
                    TitleTextEN.text = artInfo.artTitleEN;
                    SizeText.text = artInfo.artSize;
                    Art.sprite = artInfo.art;
                    player.GetComponent<PlayerMovement>().enabled = false;
                    cameraObj.GetComponent<Movement>().enabled = false;
                    rayState = true;
                }
            }
        }

        if (Physics.Raycast(ray, out hit, 5f) && Vector3.Distance(transform.position, hit.transform.position) < 3f)
        {
            if (hit.transform.CompareTag("InfoBox"))
            {
                if (hit.transform.GetChild(0) != null)
                {
                    highlightedObj = hit.transform.GetChild(0).gameObject;
                    highlightedObj.SetActive(true);
                }
            }
            else
            {
                if (highlightedObj != null)
                    highlightedObj.SetActive(false);
            }
        }
    }

    public void CloseInfoCard()
    {
        ArtInfoCard.transform.localScale = new Vector3(.1f, .1f, .1f);
        ArtInfoCard.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        player.GetComponent<PlayerMovement>().enabled = true;
        cameraObj.GetComponent<Movement>().enabled = true;
        rayState = false;
    }
}
