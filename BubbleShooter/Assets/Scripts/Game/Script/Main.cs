using ICS;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Hanswu.bubble
{
    public class Main : MonoBehaviour
    {
        void Start()
        {
            GameObject.DontDestroyOnLoad(this.gameObject);
            StartCoroutine(_Main());
        }

        private static IEnumerator _Main()
        {
            var container = new DiContainer();
            LevelSelectInfo levelSelectInfo = new LevelSelectInfo();
            container.Bind<LevelSelectInfo>().FromInstance(levelSelectInfo);

            while(true)
            {
                yield return _Metagame(container.CreateSubContainer());
                yield return _GamePlay();
                yield return _Summary();
            }

        }

        private static IEnumerator _Metagame(DiContainer container)
        {
            GameObject.FindObjectOfType<MetagameInstaller>().Resolve(container);
            var menuPresenter = container.Resolve<MenuPresenter>();
            yield return menuPresenter.Run();
        }

        private static IEnumerator _GamePlay()
        {

            yield return null;
        }

        private static IEnumerator _Summary()
        {
            yield return null;
        }
    }
}