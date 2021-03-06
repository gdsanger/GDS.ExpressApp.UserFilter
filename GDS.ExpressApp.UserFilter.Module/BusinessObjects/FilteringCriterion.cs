﻿// ***********************************************************************
// Assembly         : GDS.ExpressApp.UserFilter.Module
// Author           : angermeier
// Created          : 01-09-2020
//
// Last Modified By : angermeier
// Last Modified On : 01-10-2020
// ***********************************************************************
// <copyright file="FilteringCriterion.cs" company="GDS Innovations GmbH">
//     Copyright © 2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Xpo;
using System;
using System.ComponentModel;

namespace GDS.ExpressApp.UserFilter.Module.BusinessObjects
{
    /// <summary>
    /// Class FilteringCriterion used to store Global Filter Seetings of BusinessObjects.
    /// Implements the <see cref="DevExpress.Persistent.BaseImpl.BaseObject" />
    /// </summary>
    /// <seealso cref="DevExpress.Persistent.BaseImpl.BaseObject" />
    [DefaultClassOptions, ImageName("Action_Filter")]
    [NavigationItem("Administration")]
    [XafDisplayNameAttribute("Benutzerdefinierte Filter")]
    [XafDefaultPropertyAttribute("Beschreibung")]
    public class FilteringCriterion : BaseObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FilteringCriterion" /> class.
        /// </summary>
        /// <param name="session">A DevExpress.Xpo.Session object which represents a persistent object's cache where the business object will be instantiated.</param>
        public FilteringCriterion(Session session) : base(session) { }

        /// <summary>
        /// Invoked when the current object is about to be initialized after its creation.
        /// </summary>
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            User = Session.FindObject<PermissionPolicyUser>(new BinaryOperator("UserName", SecuritySystem.CurrentUserName));
        }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Beschreibung
        {
            get { return GetPropertyValue<string>("Beschreibung"); }
            set { SetPropertyValue<string>("Beschreibung", value); }
        }
        /// <summary>
        /// Gets or sets the type of the filtered object.
        /// </summary>
        /// <value>The type of the object.</value>
        [ValueConverter(typeof(TypeToStringConverter)), ImmediatePostData]
        [TypeConverter(typeof(LocalizedClassInfoTypeConverter))]
        public Type Objekt
        {
            get { return GetPropertyValue<Type>("Objekt"); }
            set
            {
                SetPropertyValue<Type>("Objekt", value);
                FilterKriterium = String.Empty;
            }
        }
        /// <summary>
        /// Gets or sets the Criteria String.
        /// </summary>
        /// <value>The criterion.</value>
        [CriteriaOptions("Objekt"), Size(SizeAttribute.Unlimited)]
        [EditorAlias(EditorAliases.PopupCriteriaPropertyEditor)]
        public string FilterKriterium
        {
            get { return GetPropertyValue<string>("FilterKriterium"); }
            set { SetPropertyValue<string>("FilterKriterium", value); }
        }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="FilteringCriterion"/> is public.
        /// </summary>
        /// <value><c>true</c> if public; otherwise, <c>false</c>.</value>
        public bool Public
        {
            get { return GetPropertyValue<bool>("Public"); }
            set { SetPropertyValue<bool>("Public", value); }
        }
        //[Browsable(false)]
        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>The user.</value>
        public PermissionPolicyUser User
        {
            get { return GetPropertyValue<PermissionPolicyUser>("User"); }
            set { SetPropertyValue<PermissionPolicyUser>("User", value); }
        }

    }
}