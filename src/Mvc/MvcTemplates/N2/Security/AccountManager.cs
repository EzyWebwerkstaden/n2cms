﻿using System;
using System.Collections.Generic;
using System.Linq;
using N2.Engine;
using N2.Plugin;

namespace N2.Security
{
    /// <summary>
    /// User accounts management resources
    /// </summary>
    public abstract class AccountManager : IAutoStart
	{
        public const int PageSize = 100;

        public AccountManager()
		{
		}

        public virtual void Start()
        {            
        }

        public virtual void Stop()
        {
        }

        public enum ManagerType
        {
            /// <summary> Account subsystem is not in use at all </summary>
            NONE,

            /// <summary> Accounts based on Membership subsystem </summary>
            MEMBERSHIP,

            /// <summary> Accounts based on Aspnet.Identity subsystem  </summary>
            ASPNET_IDENTITY
        }

        /// <summary> Type of account management subsystem </summary>
        public abstract ManagerType AccountType { get; }

        /// <summary> Are Accounts based on Membership subsystem? <seealso cref="AccountType"/> </summary>
        public bool IsMembershipAccountType() { return AccountType == ManagerType.MEMBERSHIP; }

        #region Users

        /// <summary> Returns user info, null: not found </summary>
        public abstract IAccountInfo FindUserByName(string userName);

        /// <summary> Returns all users in specified range </summary>
        /// <param name="startIndex"> Start index </param>
        /// <param name="max"> Maximum number of users returned </param>
        public abstract IList<IAccountInfo> GetUsers(int startIndex, int max);

        /// <summary> Count of all users </summary>
        public abstract int GetUsersCount();

        public abstract void UpdateUserEmail(string userName, string email);

        public abstract void UnlockUser(string userName);

        public abstract bool ChangePassword(string userName, string newPassword);

        /// <summary> Delete specified user </summary>
        public abstract void DeleteUser(string userName);

        #endregion

        #region Roles
        // see Mvc\MvcTemplates\N2\Roles

        /// <summary> N2 built-in roles </summary>
        protected static readonly string[] SystemRoles = new[] { "Administrators", "Editors", "Writers" };

        /// <summary> Is N2 built-in role? </summary>
        /// <remarks> Built-in roles always exist. Should not be removed. </remarks>
        public bool IsSystemRole(string roleName) { return SystemRoles.Contains(roleName, StringComparer.InvariantCultureIgnoreCase); }

        /// <summary> Is known role? <seealso cref="GetAllRoles"/></summary>
        public bool IsValidRole(string roleName) { return !GetAllRoles().Any(r => r.Equals(roleName, StringComparison.OrdinalIgnoreCase)); }

        /// <summary> Returns all known roles </summary>
        public abstract string[] GetAllRoles();

        /// <summary> Add role to list of known roles <seealso cref="GetAllRoles"/></summary>
        public abstract void CreateRole(string roleName);

        /// <summary> Delete role from list of known roles <seealso cref="GetAllRoles"/> </summary>
        public abstract bool DeleteRole(string roleName);

        #endregion

        #region User roles

        /// <summary> Exist one or more users in specified role? </summary>
        public abstract bool HasUsersInRole(string roleName);

        /// <summary> Returns users (UserNames) in specified role </summary>
        public abstract string[] GetUsersInRole(string roleName);

        /// <summary> Is specified user in specified role? </summary>
        public abstract bool IsUserInRole(string userName, string roleName);

        /// <summary> Add specified user in a role </summary>
        public abstract void AddUserToRole(string userName, string roleName);

        /// <summary> Removes specified user from role </summary>
        public abstract void RemoveUserFromRole(string userName, string roleName);

        #endregion

    }
}
