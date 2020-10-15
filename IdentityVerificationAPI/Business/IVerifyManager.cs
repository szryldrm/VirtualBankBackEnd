using IdentityVerificationAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityVerificationAPI.Business
{
    public interface IVerifyManager
    {
        public Task<bool> VerifyPerson(Person person);
    }
}
