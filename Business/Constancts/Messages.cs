using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constancts
{
    public static class Messages
    {
        public static string UsersListed = "Kullanıcılar Listelendi.";
        public static string UserUpdate = "User güncellendi.";
        public static string UserAdd = "Kullanıcı eklendi.";
        public static string UserDelete = "Kullanıcı silindi.";
        public static string ToDoUpdate = "ToDo güncellendi.";
        public static string ToDoAdd = "ToDo eklendi.";
        public static string ToDoDelete = "ToDo silindi.";
        public static string DailyToAdd = "DailyToDo eklendi.";
        public static string DailyToUpdate = "DailyToDo güncellendi.";
        public static string DailyToAll = "DailyToDo listedlendi.";
        public static string DailyToDelete = "DailyToDo silindi.";
        public static string RoleAdd = "Role eklendi.";
        public static string RoleUpdate = "Role güncellendi.";
        public static string RoleDelete = "Role silindi.";
        public static string UserRoleDelete = "User Role silindi.";
        public static string GetAllUserRole = "Bütün kullanıcıların rolleri Listelendi.";
        public static string UserRoleUpdate = "Kullanıcı rolü güncellendi.";

        //-------------------------------error--------------------------------------------
        public static string ToDoAddFail = "ToDo eklenemedi.";
        public static string DailyToDoNotExist = "Belirtilen güne ait görev bulunamadı.";
        public static string AutrozationDenied = "Giris yetkisi yok";

        public static SerializationInfo AuthorizationDenied { get; internal set; }
    }
}
