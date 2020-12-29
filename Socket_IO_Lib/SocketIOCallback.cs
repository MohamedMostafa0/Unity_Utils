using System;
using UnityEngine;
using SocketIOClient;
using Socket_IO_Lib.Events;
using Socket_IO_Lib.Managers;
using Socket_IO_Lib.Events.Args;
using Socket_IO_Lib.Helpers.Enums;

namespace Socket_IO_Lib
{
    public abstract class SocketIOCallback : MonoBehaviour
    {
        private void Awake()
        {
            SocketIOEventManager.SocketIOEventHandler += OnSocketIOEventHandler;
            OnAwake();
        }
        private void OnDestroy()
        {
            SocketIOEventManager.SocketIOEventHandler -= OnSocketIOEventHandler;
            OnCallDestroy();
        }
        private void OnSocketIOEventHandler(SocketIOBaseArgs args)
        {
            switch (args.SocketIOEventType)
            {
                case SocketIOEventTypeEnum.Exception:
                    HandleException((SocketIOExceptionEventArgs)args);
                    break;
                case SocketIOEventTypeEnum.Error:
                    HandleError((SocketIOErrorEventArgs)args);
                    break;
                case SocketIOEventTypeEnum.Connecting:
                    HandleConnecting((SocketIOConnectingEventArgs)args);
                    break;
                case SocketIOEventTypeEnum.Connected:
                    HandleConnected((SocketIOConnectedEventArgs)args);
                    break;
                case SocketIOEventTypeEnum.Disconnected:
                    HandleDisconnected((SocketIODisconnectedEventArgs)args);
                    break;
                case SocketIOEventTypeEnum.Reconnecting:
                    HandleReconnecting((SocketIOReconnectingEventArgs)args);
                    break;
                case SocketIOEventTypeEnum.ReconnectingFailed:
                    HandleReconnectingFailed((SocketIOReconnectingFailedEventArgs)args);
                    break;
                case SocketIOEventTypeEnum.ReceivedMessage:
                    HandleRecievedMessage((SocketIORecievedMessageEventArgs)args);
                    break;
                case SocketIOEventTypeEnum.SentMessage:
                    HandleSentMessage((SocketIOSentMessageEventArgs)args);
                    break;
                case SocketIOEventTypeEnum.Ping:
                    HandlePing((SocketIOPingEventArgs)args);
                    break;
                case SocketIOEventTypeEnum.Pong:
                    HandlePong((SocketIOPongEventArgs)args);
                    break;
                default:
                    break;
            }
        }

        private void HandleException(SocketIOExceptionEventArgs args)
        {
            OnException(args.ExceptionMessage);
        }
        private void HandleError(SocketIOErrorEventArgs args)
        {
            OnError(args.ErrorMessage);
        }
        private void HandleConnecting(SocketIOConnectingEventArgs args)
        {
            OnConnecting();
        }
        private void HandleConnected(SocketIOConnectedEventArgs args)
        {
            OnConnected();
        }
        private void HandleDisconnected(SocketIODisconnectedEventArgs args)
        {
            OnDisconnected(args.Reason);
        }
        private void HandleReconnecting(SocketIOReconnectingEventArgs args)
        {
            OnReconnecting(args.Attempt);
        }
        private void HandleReconnectingFailed(SocketIOReconnectingFailedEventArgs args)
        {
            OnReconnectingFailed(args.FailingMessage);
        }
        private void HandleRecievedMessage(SocketIORecievedMessageEventArgs args)
        {
            OnRecievedMessage(args.Method, args.Response);
        }
        private void HandleSentMessage(SocketIOSentMessageEventArgs args)
        {
            OnSentMessage(args.Method, args.Response);
        }
        private void HandlePing(SocketIOPingEventArgs args)
        {
            OnPing();
        }
        private void HandlePong(SocketIOPongEventArgs args)
        {
            OnPong(args.Time);
        }
        protected virtual void OnException(string exceptionMessage) { }
        protected virtual void OnError(string errorMessage) { }
        protected virtual void OnConnecting() { }
        protected virtual void OnConnected() { }
        protected virtual void OnDisconnected(string reason) { }
        protected virtual void OnReconnecting(int attempt) { }
        protected virtual void OnReconnectingFailed(string failingMessage) { }
        protected virtual void OnRecievedMessage(string method, SocketIOResponse response) { }
        protected virtual void OnSentMessage(string method, SocketIOResponse response) { }
        protected virtual void OnPing() { }
        protected virtual void OnPong(TimeSpan time) { }
        protected virtual void OnAwake() { }
        protected virtual void OnCallDestroy() { }
    }
}
