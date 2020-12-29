using API_Lib.Helpers.Enums;

namespace API_Lib.Events
{
    public class APIExceptionEventArgs : API_BaseArgs
    {
        public string ExceptionMessage { get; private set; }
        public APIExceptionEventArgs(string exceptionMessage) : base(APIEventTypeEnum.Exception)
           => ExceptionMessage = exceptionMessage;
    }
}
