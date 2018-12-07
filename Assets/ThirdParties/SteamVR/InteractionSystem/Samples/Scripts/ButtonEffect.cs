//======= Copyright (c) Valve Corporation, All rights reserved. ===============

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.Playables;

namespace Valve.VR.InteractionSystem.Sample
{
    public class ButtonEffect : MonoBehaviour
    {
        public GameObject Player;
        public GameObject Timeline;
        [SerializeField] Transform PositionToSpawnPlayer;
        [SerializeField] float TimeTospawn = 2f;
        public void OnButtonDown(Hand fromHand)
        {
            ColorSelf(Color.cyan);
            fromHand.TriggerHapticPulse(1000);
            StartGame();
        }

        public void OnButtonUp(Hand fromHand)
        {
            ColorSelf(Color.white);
        }

        private void ColorSelf(Color newColor)
        {
            Renderer[] renderers = this.GetComponentsInChildren<Renderer>();
            for (int rendererIndex = 0; rendererIndex < renderers.Length; rendererIndex++)
            {
                renderers[rendererIndex].material.color = newColor;
            }
        }

        public void StartGame()
        {
            var camera = GameObject.FindGameObjectWithTag("FollowHead");
            var fader = camera.GetComponent<FadeScreen>();
            fader.FadeEffectNow();
            Player.transform.DOMove(PositionToSpawnPlayer.position, 0).SetDelay(1.5f);
            Timeline.GetComponent<PlayableDirector>().Play();
        }
    }
}