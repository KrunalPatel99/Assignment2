using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZeusSystem.Models
{

    public class IDataEmployees : IMockEmployees
    {
        private ZeusDB db = new ZeusDB();
        public IQueryable<EmplyeeInfo> EmplyeeInfos { get { return db.EmplyeeInfoes; } }

        public void Delete(EmplyeeInfo emplyeeInfo)
        {
            db.EmplyeeInfoes.Remove(emplyeeInfo);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public EmplyeeInfo Save(EmplyeeInfo emplyeeInfo)
        {
            if (emplyeeInfo.EmployeeID == 0)
            {
                db.EmplyeeInfoes.Add(emplyeeInfo);
            }
            else
            {
                db.Entry(emplyeeInfo).State = System.Data.Entity.EntityState.Modified;
            }

            db.SaveChanges();
            return emplyeeInfo;
        }
    }
}