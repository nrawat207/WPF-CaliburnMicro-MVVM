namespace WPF_CaliburnMicro_MVVM.Messages
{
    public class ActivateUserMessageScreen
    {
        public ActivateUserMessageScreen(string message, UserMessageType type = UserMessageType.Information, bool closeCurrent = false)
        {
            Message = message;
            Type = type;
            CloseCurrent = closeCurrent;
        }

        public string Message { get; private set; }
        public UserMessageType Type { get; private set; }
        public bool CloseCurrent { get; private set; }
    }
}
