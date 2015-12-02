
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace BanHang.Models
{
    public class DALKhachHang
    {
        private static ServiceUser.UserClient sUser = new ServiceUser.UserClient();
        private static ServiceRole.RoleClient sRole = new ServiceRole.RoleClient();
        
        public static List<User> GetAllKhachHang()
        {
           
            List<ServiceUser.user> lu = sUser.GetAllUser().ToList();
            return ConvertListUser(lu).ToList();
        }

        public static User GetKhachHangById(int id)
        {          
            ServiceUser.user u = sUser.GetUserById(id);
            return ConvertUser(u);
        }

        public static ServiceUser.user GetKhachHangByEmail(string email)
        {         
            ServiceUser.user u = sUser.GetUserByEmail(email);
            return u;
        }

        public static List<User> GetLKhachHangByEmail(string email)
        {         
            List<ServiceUser.user> lu = sUser.FindUserByEmail(email).ToList();
            return ConvertListUser(lu).ToList();
        }

        public static List<User> GetKhachHangByName(string ten)
        {          
            List<ServiceUser.user> lu = sUser.GetUserByName(ten).ToList();
            return ConvertListUser(lu).ToList();
        }

        public static bool CheckEmailAndPass(string email,string pass)
        {
           
            bool checkUser = sUser.CheckUser(email, pass);
            return checkUser;
        }

        public static bool CheckEmailExisted(string email)
        {
            
            return sUser.CheckEmailExisted(email);         
        }


        public static bool Insert(ServiceUser.user kh)
        {          
            return sUser.AddUser(kh);
        }

        public static bool Update(ServiceUser.user kh)
        {           
            return sUser.UpdateUser(kh);
        }

        public bool DeleteUser(int id)
        {
            return sUser.DeleteUser(id);              
        }

        private static List<User> ConvertListUser(List<ServiceUser.user> myUser)
        {
            List<User> lUser = new List<User>();
            foreach (var item in myUser)
            {
                User u = new User();
                u.id = item.id;
                u.id_role = item.id_role;
                u.name = item.name;
                u.name_role = sRole.GetRoleWithId(item.id_role).name;
                u.email = item.email;
                u.password = item.password;
                u.phone_number = item.phone_number;
                u.address = item.address;
                lUser.Add(u);
            }
            return lUser;
        }
        private static User ConvertUser(ServiceUser.user item)
        {

            User u = new User();
            u.id = item.id;
            u.id_role = item.id_role;
            u.name = item.name;
            u.name_role = sRole.GetRoleWithId(item.id_role).name;
            u.email = item.email;
            u.password = item.password;
            u.phone_number = item.phone_number;
            u.address = item.address;
            return u;
        }
    }
}