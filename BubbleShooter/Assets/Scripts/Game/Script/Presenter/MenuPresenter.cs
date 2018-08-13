using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hanswu.bubble
{
    public interface IMenuView
    {
        event Action<LevelSelectInfo> OnClickStart;
        event Action OnClickLeave;

        IEnumerator Enter();
        IEnumerator Leave();

    }

    public class MenuPresenter
    {
        private LevelSelectInfo _levelSelectInfo;
        private IMenuView _menuView;
        private bool _tryToLeaveMenu = false;
        
        MenuPresenter(IMenuView menuView,LevelSelectInfo levelSelectInfo)
        {
            _menuView = menuView;
            _levelSelectInfo = levelSelectInfo;
        }

        public IEnumerator Run()
        {
            _RegisterEvents();
            yield return _menuView.Enter();
            while(!_tryToLeaveMenu)
            {
                yield return null;
            }
            _UnRegisterEvents();
            yield return _menuView.Leave();
        }

        private void _RegisterEvents()
        {
            _menuView.OnClickStart += _HandleOnClickStart;
            _menuView.OnClickLeave += _HandleOnClickLeave;
        }

        private void _UnRegisterEvents()
        {
            _menuView.OnClickStart -= _HandleOnClickStart;
            _menuView.OnClickLeave -= _HandleOnClickLeave;
        }

        private void _HandleOnClickStart(LevelSelectInfo info)
        {
            _levelSelectInfo = info;
            _tryToLeaveMenu = true;
        }

        private void _HandleOnClickLeave()
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }

}