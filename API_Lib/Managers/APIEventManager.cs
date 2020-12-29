using API_Lib.Events;
using API_Lib.Helpers.Delegates;

namespace API_Lib.Managers
{
    public static class APIEventManager
    {
        private static event APIEvent _apiEventHandler;
        public static event APIEvent APIEventHandler
        {
            add => _apiEventHandler += value;
            remove => _apiEventHandler -= value;
        }
        public static void FireAPIException(string exceptionMessage)
        {
            API_BaseArgs a = new APIExceptionEventArgs(exceptionMessage);
            FireEvent(a);
        }
        public static void FireAPIRecieved(string method , string jsonData)
        {
            API_BaseArgs a = new APIRecievedEventArgs(method , jsonData);
            FireEvent(a);
        }
        public static void FireAPIError(string method , int code, string error)
        {
            API_BaseArgs a = new APIErrorEventArgs(method , code , error);
            FireEvent(a);
        }
        private static void FireEvent(API_BaseArgs args)
        {
            _apiEventHandler?.Invoke(args);
        }
    }
}
