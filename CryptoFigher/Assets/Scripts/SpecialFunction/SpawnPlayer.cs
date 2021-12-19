using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField]private GameObject playerPerfab;
    [SerializeField]private GameObject swapnPlayerEffectPerfab;
    [SerializeField]private float playerSpawnEffectTime;



    private IEnumerator SpwanPlayerCoroutine()
    {
        SpwanPlayer();


        Instantiate(swapnPlayerEffectPerfab, transform.position, Quaternion.identity);

    
        yield break;
    }

    public void SpwanPlayer()
    {
        Instantiate(playerPerfab, transform.position, Quaternion.identity);
    }

    public void ResetPlayerPos()
    {
        StartCoroutine(ResetPlayerPosCoroutine());
    }

    private IEnumerator ResetPlayerPosCoroutine()
    {
        

        PlayerPunk playerPunk = FindObjectOfType<PlayerPunk>();

        if(playerPunk != null)
        {
            playerPunk.transform.position = transform.position;

            playerPunk.gameObject.SetActive(false);


            PlaySwapnPlayerEffect();

            yield return new WaitForSeconds(playerSpawnEffectTime);


            playerPunk.gameObject.SetActive(true);


        }
        yield break;
    }

    public void PlaySwapnPlayerEffect()
    {
        Vector3 offset = Vector3.right *0.5f;
        Instantiate(swapnPlayerEffectPerfab, transform.position + offset, Quaternion.Euler(90,0,0));

    }
}
    