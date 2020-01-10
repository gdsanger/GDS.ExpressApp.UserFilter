// ***********************************************************************
// Assembly         : GDS.ExpressApp.UserFilter.Module
// Author           : angermeier
// Created          : 01-09-2020
//
// Last Modified By : angermeier
// Last Modified On : 01-09-2020
// ***********************************************************************
// <copyright file="Module.cs" company="GDS Innovations GmbH">
//     Copyright © 2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Text;
using System.Linq;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using System.Collections.Generic;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Model.Core;
using DevExpress.ExpressApp.Model.DomainLogics;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.Xpo;

namespace GDS.ExpressApp.UserFilter.Module {
    // For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.ModuleBase.
    /// <summary>
    /// Class UserFilterModule. This class cannot be inherited.
    /// Implements the <see cref="DevExpress.ExpressApp.ModuleBase" />
    /// </summary>
    /// <seealso cref="DevExpress.ExpressApp.ModuleBase" />
    public sealed partial class UserFilterModule : ModuleBase {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserFilterModule"/> class.
        /// </summary>
        public UserFilterModule() {
            InitializeComponent();
			BaseObject.OidInitializationMode = OidInitializationMode.AfterConstruction;
        }
        /// <summary>
        /// Returns the list of <see cref="T:DevExpress.ExpressApp.Updating.ModuleUpdater" /> updaters that handle database updates for the <see cref="T:DevExpress.ExpressApp.ModuleBase" /> module.
        /// </summary>
        /// <param name="objectSpace">An <see cref="T:DevExpress.ExpressApp.IObjectSpace" /> object which represents the Object Space used to update the database.</param>
        /// <param name="versionFromDB">A System.Version object which represents the current database version.</param>
        /// <returns>An IEnumerable&lt;<see cref="T:DevExpress.ExpressApp.Updating.ModuleUpdater" />&gt; list of updaters that handle database updates for the <see cref="T:DevExpress.ExpressApp.ModuleBase" /> module.</returns>
        public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB) {
            ModuleUpdater updater = new DatabaseUpdate.Updater(objectSpace, versionFromDB);
            return new ModuleUpdater[] { updater };
        }
        /// <summary>
        /// Sets up a module after it has been added to the <see cref="P:DevExpress.ExpressApp.XafApplication.Modules" /> collection.
        /// </summary>
        /// <param name="application">An <see cref="T:DevExpress.ExpressApp.XafApplication" /> object that provides methods and properties to manage the current application. This parameter value is set for the <see cref="P:DevExpress.ExpressApp.ModuleBase.Application" /> property.</param>
        public override void Setup(XafApplication application) {
            base.Setup(application);
            // Manage various aspects of the application UI and behavior at the module level.
        }
        /// <summary>
        /// Customizes the types information.
        /// </summary>
        /// <param name="typesInfo">The types information.</param>
        public override void CustomizeTypesInfo(ITypesInfo typesInfo) {
            base.CustomizeTypesInfo(typesInfo);
            CalculatedPersistentAliasHelper.CustomizeTypesInfo(typesInfo);
        }
    }
}
