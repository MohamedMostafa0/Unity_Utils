using API_Lib.Helpers.Enums;

namespace API_Lib.Events
{
    public class APIErrorEventArgs : API_BaseArgs
    {
        public string Method { get; private set; }
        public int Code { get; private set; }
        public string Error { get; private set; }
        public APIErrorEventArgs(string method, int code, string error) : base(APIEventTypeEnum.Error)
        {
            Method = method;
            Code = code;
            Error = error;
        }
    }
}
