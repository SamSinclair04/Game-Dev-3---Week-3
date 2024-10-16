using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace GameDevWithMarco.Player
{ 

    public class Player_BrokenArrow_Logic : MonoBehaviour
    {
        SpriteRenderer spriteRenderer;

        [SerializeField] float arrowShakeTime;
        [SerializeField] float arrowShakeStrength;
        [SerializeField] float arrowFadeTime;



        void Start()
        {
            //Gets and stores data

        spriteRenderer = GetComponent<SpriteRenderer>();

            //Start coroutine
            StartCoroutine(ShakeTheArrowOnCreation());
        }


        private IEnumerator ShakeTheArrowOnCreation()
        {
            if (spriteRenderer != null)
            {
                spriteRenderer.transform.DOShakeScale(arrowShakeTime, arrowShakeStrength);

                yield return new WaitForSeconds(arrowShakeTime);

                StartCoroutine(FadeThenDestroyLogic());
            }
        }


        private IEnumerator FadeThenDestroyLogic()
        {
            if (spriteRenderer != null)
            {
                spriteRenderer.DOFade(0, arrowFadeTime);

                yield return new WaitForSeconds(arrowFadeTime);

                Destroy(gameObject);
            }
        }




        // Update is called once per frame
        void Update()
        {
        
        }
    }
}

