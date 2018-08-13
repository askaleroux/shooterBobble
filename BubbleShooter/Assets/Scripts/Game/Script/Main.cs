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
        static Main _instance;

        void Start()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(this.gameObject);
                StartCoroutine(_Main());
            }
        }

        private static IEnumerator _Main()
        {
            var container = new DiContainer();
            while (true)
            {
                yield return _Metagame(container.CreateSubContainer());
                yield return _GamePlay();
            }
        }

        private static IEnumerator _Metagame(DiContainer container)
        {
            var load = SceneManager.LoadSceneAsync("Metagame");
            while(!load.isDone)
            {
                yield return null;
            }

            GameObject.FindObjectOfType<MetagameInstaller>().Resolve(container);
            LevelSelectInfo levelSelectInfo = new LevelSelectInfo();
            container.Bind<LevelSelectInfo>().FromInstance(levelSelectInfo);

            var menuPresenter = container.Resolve<MenuPresenter>();
            yield return menuPresenter.Run();
        }

        private static IEnumerator _GamePlay()
        {
            var load = SceneManager.LoadSceneAsync("GamePlay");
            while (!load.isDone)
            {
                yield return null;
            }
        }

      
    }
}