namespace StreamBotCsharp.Drivers
{
    #region Usings

    using System;

    #endregion

    public interface IDriver
    {
        public void Prepare();

        public void Start();
    }
}