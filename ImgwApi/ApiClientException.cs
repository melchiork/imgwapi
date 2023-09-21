using System;

namespace ImgwApi
{
    /// <summary>
    /// Details of what went wrong when calling the API.
    /// </summary>
    public class ApiClientException : Exception
    {
        internal ApiClientException(string message) : base(message)
        {
        }

        internal ApiClientException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}