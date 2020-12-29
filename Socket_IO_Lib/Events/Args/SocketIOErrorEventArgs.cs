using Socket_IO_Lib.Helpers.Enums;

namespace Socket_IO_Lib.Events.Args
{
    public class SocketIOErrorEventArgs : SocketIOBaseArgs
    {
        public string ErrorMessage { get; private set; }
        public SocketIOErrorEventArgs(string errorMessage) : base(SocketIOEventTypeEnum.Error)
            => ErrorMessage = errorMessage;
    }
}
