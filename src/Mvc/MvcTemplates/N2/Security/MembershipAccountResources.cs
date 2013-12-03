﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using N2.Engine;
using N2.Plugin;

namespace N2.Security
{
    /// <summary>
    /// User accounts management resources
    /// </summary>
    [Service(typeof(AccountResources))]
    public class MembershipAccountResources : AccountResources
	{
        public MembershipAccountResources()
		{
		}

        public override void Start()
        {
            base.Start();

            N2.Web.Url.SetToken(LoginPageUrlToken,        "{ManagementUrl}/Login.aspx");
            N2.Web.Url.SetToken(LogoutPageUrlToken,       "{ManagementUrl}/Login.aspx?logout=true");
            N2.Web.Url.SetToken(EditPasswordPageUrlToken, "{ManagementUrl}/Myself/EditPassword.aspx");

            N2.Web.Url.SetToken(UsersPageUrlToken,        "{ManagementUrl}/Users/Users.aspx");
            N2.Web.Url.SetToken(UsersEditPageUrlToken,    "{ManagementUrl}/Users/Edit.aspx");
            N2.Web.Url.SetToken(RolesPageUrlToken,        "{ManagementUrl}/Roles/Roles.aspx");

        }

        public virtual void Stop()
        {
            base.Stop();
        }

    }
}
