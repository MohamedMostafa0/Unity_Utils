using System;
using SocketIOClient;
using SocketIOClient.EventArguments;
using Unity_Utils_Lib;
using UnityEngine;

namespace Socket_IO_Lib.Managers
{
    public sealed class SocketIOManager : BaseSingleton<SocketIOManager>, IDisposable
    {
        [SerializeField] private string host;
        private SocketIO socket;
        protected override void OnAwake()
        {
            Init();
        }
        protected override void OnCallDestroy()
        {
            Dispose();
        }
        private void Init()
        {
            try
            {
                socket = new SocketIO(new Uri(host));
                socket.OnConnected += Socket_OnConnected;
                socket.OnDisconnected += Socket_OnDisconnected;
                socket.OnError += Socket_OnError;
                socket.OnReceivedEvent += Socket_OnReceivedEvent;
                socket.OnReconnecting += Socket_OnReconnecting;
                socket.OnReconnectFailed += Socket_OnReconnectFailed; ;
                socket.OnPing += Socket_OnPing;
                socket.OnPong += Socket_OnPong;
            }
            catch (Exception ex)
            {
                SocketIOEventManager.FireException(ex.Message);
            }
        }
        private void Socket_OnConnected(object sender, EventArgs e)
        {
            SocketIOEventManager.FireConnected();
        }
        private void Socket_OnDisconnected(object sender, string e)
        {
            SocketIOEventManager.FireDisconnected(e);
        }
        private void Socket_OnError(object sender, string e)
        {
            SocketIOEventManager.FireError(e);
        }
        private void Socket_OnReceivedEvent(object sender, ReceivedEventArgs e)
        {
            SocketIOEventManager.FireRecievedMessage(e.Event, e.Response);
        }
        private void Socket_OnReconnecting(object sender, int e)
        {
            SocketIOEventManager.FireReconnecting(e);
        }
        private void Socket_OnReconnectFailed(object sender, Exception e)
        {
            SocketIOEventManager.FireReconnectingFailed(e.Message);
        }
        private void Socket_OnPing(object sender, EventArgs e)
        {
            SocketIOEventManager.FirePing();
        }
        private void Socket_OnPong(object sender, TimeSpan e)
        {
            SocketIOEventManager.FirePong(e);
        }
        public async void Connect()
        {
            try
            {
                SocketIOEventManager.FireConnecting();
                await socket.ConnectAsync();
            }
            catch (Exception ex)
            {
                SocketIOEventManager.FireException(ex.Message);
            }
        }
        public async void Send(string method, params object[] data)
        {
            try
            {
                await socket.EmitAsync(method, (response) =>
                {
                    SocketIOEventManager.FireSentMessage(method, response);
                }, data);
            }
            catch (Exception ex)
            {
                SocketIOEventManager.FireException(ex.Message);
            }
        }
        public async void Disconnect()
        {
            try
            {
                if (socket != null)
                {
                    if (socket.Connected)
                    {
                        await socket.DisconnectAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                SocketIOEventManager.FireException(ex.Message);
            }
        }

        public void Dispose()
        {
            try
            {
                Disconnect();
                socket.OnConnected -= Socket_OnConnected;
                socket.OnDisconnected -= Socket_OnDisconnected;
                socket.OnError -= Socket_OnError;
                socket.OnReceivedEvent -= Socket_OnReceivedEvent;
                socket.OnReconnecting -= Socket_OnReconnecting;
                socket.OnReconnectFailed -= Socket_OnReconnectFailed; ;
                socket.OnPing -= Socket_OnPing;
                socket.OnPong -= Socket_OnPong;
                socket = null;
            }
            catch (Exception ex)
            {
                SocketIOEventManager.FireException(ex.Message);
            }
        }
    }
}
