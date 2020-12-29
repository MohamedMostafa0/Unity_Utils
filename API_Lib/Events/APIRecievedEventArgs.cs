using API_Lib.Helpers.Enums;

namespace API_Lib.Events
{
    public class APIRecievedEventArgs : API_BaseArgs
    {
        public string Method { get; private set; }
        public string JsonData { get; private set; }
        public APIRecievedEventArgs(string method, string jsonData) : base(APIEventTypeEnum.Receieved)
        {
            Method = method;
            JsonData = JsonData;
        }
    }
}
