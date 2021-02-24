namespace StreamBotCsharp.Drivers
{
    #region Usings
    
    using System;
    
    #endregion
    
    public interface IDriver : IDisposable
    {
        public void Listen();
        
        
        public bool Connect();
        
        
        public bool IsConnected();
        
        
        public bool Disconnect();
    }
}