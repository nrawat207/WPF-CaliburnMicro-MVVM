using WPF_CaliburnMicro_MVVM.Messages;

namespace WPF_CaliburnMicro_MVVM.ViewModels
{
    public class UserMessageViewModel : ViewModelBase
    {

        private string message;
        private bool canClose;

        public UserMessageViewModel()
        {
            CanClose = true;
        }

        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                NotifyOfPropertyChange(() => Message);
            }
        }

        public void SetMessageType(UserMessageType type)
        {
            InformationVisible = type == UserMessageType.Information;
            WarningVisible = type == UserMessageType.Warning;
            ErrorVisible = type == UserMessageType.Error;
        }

        public new bool CanClose
        {
            get { return canClose; }
            set
            {
                if (value.Equals(canClose)) return;
                canClose = value;
                NotifyOfPropertyChange(() => CanClose);
            }
        }

        public void Close()
        {
            CanClose = false;
            //if(ErrorVisible)
            //  EventAggregator.PublishOnBackgroundThread(new CloseApplication());
            TryClose();

        }

        public bool InformationVisible { get; private set; }
        public bool WarningVisible { get; private set; }
        public bool ErrorVisible { get; private set; }

        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(true);
        }

        protected override void OnLoadedCore()
        {
            SubscribeToMessages();
        }
    }
}
