﻿
using Serenity.ComponentModel;
using System.ComponentModel;

namespace MultiTenancy.Administration
{
    //[NestedPermissionKeys]
    //[DisplayName("Administration")]
    //public class PermissionKeys
    //{
    //    [Description("User, Role Management and Permissions")]
    //    public const string Security = "Administration:Security";

    //    [Description("Languages and Translations")]
    //    public const string Translation = "Administration:Translation";
    //}
    public class PermissionKeys
    {
        public const string Security = "Administration:Security";
        public const string Translation = "Administration:Translation";
        public const string Tenant = "Administration:Tenant";
    }
}
