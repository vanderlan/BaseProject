using System;

namespace VBaseProject.Service.Exceptions
{
    [Serializable]
    public class UnauthorizedUserException : BusinessException
    {
        public UnauthorizedUserException(string msg) : base(msg)
        {

        }
    }
}
