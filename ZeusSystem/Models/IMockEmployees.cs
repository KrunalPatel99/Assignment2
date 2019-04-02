using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeusSystem.Models
{
    public interface IMockEmployees
    {
        IQueryable<EmplyeeInfo> EmplyeeInfos { get; }
        EmplyeeInfo Save(EmplyeeInfo emplyeeInfo);
        void Delete(EmplyeeInfo emplyeeInfo);
        void Dispose();
    }
}
