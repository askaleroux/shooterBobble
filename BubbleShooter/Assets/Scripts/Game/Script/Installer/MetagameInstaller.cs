using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Hanswu.bubble
{
    public class MetagameInstaller : MonoBehaviour
    {
        [SerializeField]
        private MenuView _menuView;


        private MenuPresenter menuPresenter = null;

        public void Resolve(DiContainer container)
        {
            container.Bind<MenuPresenter>().AsSingle();
            container.Bind<IMenuView>().FromInstance(_menuView);
        }
    }

}