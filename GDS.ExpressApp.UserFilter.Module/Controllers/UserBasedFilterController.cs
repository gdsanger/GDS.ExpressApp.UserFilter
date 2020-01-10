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
    public partial class UserBasedFilterController : ViewController
    {
        private SimpleAction AddFilter;
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
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
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
