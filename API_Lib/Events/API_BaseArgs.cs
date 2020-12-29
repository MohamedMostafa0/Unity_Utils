using System;
using API_Lib.Helpers.Enums;

namespace API_Lib.Events
{
    public abstract class API_BaseArgs : EventArgs
    {
        public APIEventTypeEnum APIEventType { get; private set; }
        public API_BaseArgs(APIEventTypeEnum eventType) => APIEventType = eventType;
    }
}
