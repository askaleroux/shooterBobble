using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Hanswu.bubble
{

    public class MenuView : MonoBehaviour, IMenuView
    {
        [SerializeField]
        private Button _startButton;

        [SerializeField]
        private Button _LeaveButton;

        public event Action<LevelSelectInfo> OnClickStart;
        public event Action OnClickLeave;

        private LevelSelectInfo _levelSelectInfo;

        [Zenject.Inject]
        MenuView(LevelSelectInfo levelSelectInfo)
        {
            _levelSelectInfo = levelSelectInfo;
        }

        void OnEnable()
        {
            _UnRegisterButtons();
            _RegisterButtons();
        }

        void OnDisable()
        {
            _UnRegisterButtons();
        }

        public IEnumerator Enter()
        {
            this.gameObject.SetActive(true);
            var cg = GetComponent<CanvasGroup>();
            float duration = 0;
            while(duration<0.8f)
            {
                duration += Time.deltaTime;
                var alpha = Mathf.Lerp(0f, 1f, duration);
                cg.alpha = alpha;
                yield return null;
            }

            cg.alpha = 1;
        }

        public IEnumerator Leave()
        {
            this.gameObject.SetActive(true);
            yield return null;
            var cg = GetComponent<CanvasGroup>();
            float duration = 0;
            while (duration < 0.8f)
            {
                duration += Time.deltaTime;
                var alpha = Mathf.Lerp(1f, 0f, duration);
                cg.alpha = alpha;
                yield return null;
            }
            cg.alpha = 0;
        }

        private void _RegisterButtons()
        {
            _startButton.onClick.AddListener(()=>
            {
                if (OnClickStart != null)
                {
                    OnClickStart(_levelSelectInfo);
                }
            });

            _LeaveButton.onClick.AddListener(() =>
            {
                if (OnClickLeave != null)
                {
                    OnClickLeave();
                }
            });
        }

        private void _UnRegisterButtons()
        {
            _startButton.onClick.RemoveAllListeners();
            _LeaveButton.onClick.RemoveAllListeners();
        }
    }
}