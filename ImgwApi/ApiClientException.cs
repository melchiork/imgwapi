using System;

namespace ImgwApi
{
    public class ApiClientException : Exception
    {
        public ApiClientException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}