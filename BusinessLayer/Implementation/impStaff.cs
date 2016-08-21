using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;
using DataLayer.EntityFramework;

namespace BusinessLayer.Implementation {
    public class impStaff : IStaff {

        private HPCareDBContext db;

        public impStaff(HPCareDBContext db) {
            this.db = db;
        }

        public void saveStaffInformations(List<Staff> staffInformation) {
            Staff staff = db.Users.Find(1) as Staff; //current logged user

            foreach(Staff s in staffInformation) {
                staff.Address = s.Address;
                staff.Email = s.Email;
                staff.gender = s.gender;
                staff.MaritalStatus = s.MaritalStatus;
                staff.Name = s.Name;
                staff.Telephone = s.Telephone;
            }

            db.SaveChanges();
        }

    }
}
