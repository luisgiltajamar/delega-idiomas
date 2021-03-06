﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using MvcCompleto.Models;

namespace MvcCompleto.Seguridad
{
   public class ProveedorAutenticacion:MembershipProvider
    {
       public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer,
           bool isApproved, object providerUserKey, out MembershipCreateStatus status)
       {
           throw new NotImplementedException();
       }

       public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion,
           string newPasswordAnswer)
       {
           throw new NotImplementedException();
       }

       public override string GetPassword(string username, string answer)
       {
           throw new NotImplementedException();
       }

       public override bool ChangePassword(string username, string oldPassword, string newPassword)
       {
           throw new NotImplementedException();
       }

       public override string ResetPassword(string username, string answer)
       {
           throw new NotImplementedException();
       }

       public override void UpdateUser(MembershipUser user)
       {
           throw new NotImplementedException();
       }

       public override bool ValidateUser(string username, string password)
       {
           if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
               return false;

           using (var db=new DelegaEntities())
           {
               return db.Usuarios.Any(o => o.email == username && o.password == password);
           }
       }

       public override bool UnlockUser(string userName)
       {
           throw new NotImplementedException();
       }

       public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
       {
           throw new NotImplementedException();
       }

       public override MembershipUser GetUser(string username, bool userIsOnline)
       {
           using (var db = new DelegaEntities())
           {
               var us = db.Usuarios.FirstOrDefault(o => o.email == username);
               if (us != null)
               {
                   return new UsuarioMembership(us);
               }
           }
           return null;
       }

       public override string GetUserNameByEmail(string email)
       {
           throw new NotImplementedException();
       }

       public override bool DeleteUser(string username, bool deleteAllRelatedData)
       {
           throw new NotImplementedException();
       }

       public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
       {
           throw new NotImplementedException();
       }

       public override int GetNumberOfUsersOnline()
       {
           throw new NotImplementedException();
       }

       public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
       {
           throw new NotImplementedException();
       }

       public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
       {
           throw new NotImplementedException();
       }

       public override bool EnablePasswordRetrieval
       {
           get { throw new NotImplementedException(); }
       }

       public override bool EnablePasswordReset
       {
           get { throw new NotImplementedException(); }
       }

       public override bool RequiresQuestionAndAnswer
       {
           get { throw new NotImplementedException(); }
       }

       public override string ApplicationName { get; set; }

       public override int MaxInvalidPasswordAttempts
       {
           get { throw new NotImplementedException(); }
       }

       public override int PasswordAttemptWindow
       {
           get { throw new NotImplementedException(); }
       }

       public override bool RequiresUniqueEmail
       {
           get { throw new NotImplementedException(); }
       }

       public override MembershipPasswordFormat PasswordFormat
       {
           get { throw new NotImplementedException(); }
       }

       public override int MinRequiredPasswordLength
       {
           get { throw new NotImplementedException(); }
       }

       public override int MinRequiredNonAlphanumericCharacters
       {
           get { throw new NotImplementedException(); }
       }

       public override string PasswordStrengthRegularExpression
       {
           get { throw new NotImplementedException(); }
       }
    }
}
