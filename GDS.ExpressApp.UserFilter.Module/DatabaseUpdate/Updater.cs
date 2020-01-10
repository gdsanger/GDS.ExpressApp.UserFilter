// ***********************************************************************
// Assembly         : GDS.ExpressApp.UserFilter.Module
// Author           : angermeier
// Created          : 01-09-2020
//
// Last Modified By : angermeier
// Last Modified On : 01-09-2020
// ***********************************************************************
// <copyright file="Updater.cs" company="GDS Innovations GmbH">
//     Copyright © 2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;
using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.BaseImpl;

namespace GDS.ExpressApp.UserFilter.Module.DatabaseUpdate {
    // For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Updating.ModuleUpdater
    /// <summary>
    /// Class Updater.
    /// Implements the <see cref="DevExpress.ExpressApp.Updating.ModuleUpdater" />
    /// </summary>
    /// <seealso cref="DevExpress.ExpressApp.Updating.ModuleUpdater" />
    public class Updater : ModuleUpdater {
        /// <summary>
        /// Initializes a new instance of the <see cref="Updater"/> class.
        /// </summary>
        /// <param name="objectSpace">An <see cref="T:DevExpress.ExpressApp.IObjectSpace" /> object which represents the Object Space used to update the database. This parameter's value is assigned to the protected ObjectSpace property.</param>
        /// <param name="currentDBVersion">A <see cref="T:System.Version" /> object which represents the current database version. This parameter's value is assigned to the protected CurrentDBVersion property.</param>
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) :
            base(objectSpace, currentDBVersion) {
        }
        /// <summary>
        /// Performs a database update after the database schema is updated.
        /// </summary>
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();
            //string name = "MyName";
            //DomainObject1 theObject = ObjectSpace.FindObject<DomainObject1>(CriteriaOperator.Parse("Name=?", name));
            //if(theObject == null) {
            //    theObject = ObjectSpace.CreateObject<DomainObject1>();
            //    theObject.Name = name;
            //}

			//ObjectSpace.CommitChanges(); //Uncomment this line to persist created object(s).
        }
        /// <summary>
        /// Updates the database before update schema.
        /// </summary>
        public override void UpdateDatabaseBeforeUpdateSchema() {
            base.UpdateDatabaseBeforeUpdateSchema();
            //if(CurrentDBVersion < new Version("1.1.0.0") && CurrentDBVersion > new Version("0.0.0.0")) {
            //    RenameColumn("DomainObject1Table", "OldColumnName", "NewColumnName");
            //}
        }
    }
}
