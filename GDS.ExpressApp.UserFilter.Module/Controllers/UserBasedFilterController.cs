// ***********************************************************************
// Assembly         : GDS.ExpressApp.UserFilter.Module
// Author           : angermeier
// Created          : 01-09-2020
//
// Last Modified By : angermeier
// Last Modified On : 01-09-2020
// ***********************************************************************
// <copyright file="UserBasedFilterController.cs" company="GDS Innovations GmbH">
//     Copyright © 2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Persistent.Validation;
using GDS.ExpressApp.UserFilter.Module.BusinessObjects;

namespace GDS.ExpressApp.UserFilter.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    /// <summary>
    /// Class UserBasedFilterController.
    /// Implements the <see cref="DevExpress.ExpressApp.ViewController" />
    /// </summary>
    /// <seealso cref="DevExpress.ExpressApp.ViewController" />
    public partial class UserBasedFilterController : ViewController
    {
        /// <summary>
        /// The add filter
        /// </summary>
        private SimpleAction AddFilter;
        /// <summary>
        /// Initializes a new instance of the <see cref="UserBasedFilterController"/> class.
        /// </summary>
        public UserBasedFilterController()
        {
            InitializeComponent();
            this.AddFilter = new SimpleAction(this.components);
            this.Actions.Add(this.AddFilter);
            this.AddFilter.Caption = "Filter hinzufügen";
            this.AddFilter.Category = "Filters";
            this.AddFilter.ConfirmationMessage = null;
            this.AddFilter.Id = "AddFilter";
            this.AddFilter.ImageName = "Action_Filter";
            this.AddFilter.TargetViewType = ViewType.ListView;
            this.AddFilter.ToolTip = null;
            this.AddFilter.TypeOfView = typeof(ListView);
            this.AddFilter.Execute += new SimpleActionExecuteEventHandler(this.AddFilter_Execute);
        }
        /// <summary>
        /// Called when [activated].
        /// </summary>
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        /// <summary>
        /// Called when [view controls created].
        /// </summary>
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        /// <summary>
        /// Called when [deactivated].
        /// </summary>
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
        /// <summary>
        /// Handles the Execute event of the AddFilter control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SimpleActionExecuteEventArgs"/> instance containing the event data.</param>
        private void AddFilter_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            if (View.CurrentObject == null) return;

            IObjectSpace os = Application.CreateObjectSpace();
            object CurrentObject = View.CurrentObject;
            FilteringCriterion fc = os.CreateObject<FilteringCriterion>();
            fc.Public = true;
            fc.User = os.FindObject<PermissionPolicyUser>(new BinaryOperator("UserName", SecuritySystem.CurrentUserName));
            fc.Objekt = CurrentObject.GetType();
            DetailView view = Application.CreateDetailView(os, "FilteringCriterion_DetailView", true);
            view.CurrentObject = fc;
            view.ViewEditMode = ViewEditMode.Edit;
            e.ShowViewParameters.TargetWindow = TargetWindow.NewModalWindow;
            e.ShowViewParameters.CreatedView = view;
        }
    }
}
