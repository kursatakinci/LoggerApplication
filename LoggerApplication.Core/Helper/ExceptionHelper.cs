using System;

namespace LoggerApplication.Core.Helper
{
    public static class ExceptionHelper
    {
        public static string GetExceptionMessage(this Exception ex)
        {
            string message = ex.Message;

            if (ex.InnerException != null)
            {
                message += Environment.NewLine;

                message += ex.InnerException.GetExceptionMessage();
            }

            return message;
        }
    }
}
