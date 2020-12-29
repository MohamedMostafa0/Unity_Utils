using UnityEngine;
using API_Lib.Events;
using API_Lib.Managers;
using API_Lib.Helpers.Enums;

namespace API_Lib
{
    public abstract class APICallback : MonoBehaviour
    {
        private void Awake()
        {
            APIEventManager.APIEventHandler += OnApiEventHandler;
            OnAwake();
        }
        private void OnDestroy()
        {
            APIEventManager.APIEventHandler -= OnApiEventHandler;
            OnCallDestroy();
        }
        private void OnApiEventHandler(API_BaseArgs args)
        {
            switch (args.APIEventType)
            {
                case APIEventTypeEnum.Exception:
                    HandleException((APIExceptionEventArgs)args);
                    break;
                case APIEventTypeEnum.Error:
                    HandleError((APIErrorEventArgs)args);
                    break;
                case APIEventTypeEnum.Receieved:
                    HandleRecieve((APIRecievedEventArgs)args);
                    break;
                default:
                    break;
            }
        }

        private void HandleException(APIExceptionEventArgs args)
        {
            OnException(args.ExceptionMessage);
        }
        private void HandleError(APIErrorEventArgs args)
        {
            OnError(args.Method, args.Code, args.Error);
        }
        private void HandleRecieve(APIRecievedEventArgs args)
        {
            OnRecieve(args.Method, args.JsonData);
        }
        protected virtual void OnException(string exceptionMessage) { }
        protected virtual void OnError(string method, int code, string error) { }
        protected virtual void OnRecieve(string method, string jsonData) { }
        protected virtual void OnAwake() { }
        protected virtual void OnCallDestroy() { }
    }
}
