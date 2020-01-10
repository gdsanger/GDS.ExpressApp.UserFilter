// ***********************************************************************
// Assembly         : GDS.ExpressApp.MainImpl.Module
// Author           : angermeier
// Created          : 08-14-2019
//
// Last Modified By : angermeier
// Last Modified On : 08-14-2019
// ***********************************************************************
// <copyright file="CriteriaController.cs" company="">
//     Copyright © 2019
// </copyright>
// <summary></summary>
// ***********************************************************************
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Editors;
using GDS.ExpressApp.UserFilter.Module.BusinessObjects;

namespace GDS.ExpressApp.UserFilter.Module.Controllers
{
    /// <summary>
    /// Class CriteriaController.
    /// Implements the <see cref="DevExpress.ExpressApp.ObjectViewController" />
    /// </summary>
    /// <seealso cref="DevExpress.ExpressApp.ObjectViewController" />
    public class CriteriaController : ObjectViewController
    {
       
        private System.ComponentModel.IContainer components;

        /// <summary>
        /// The filtering criterion action
        /// </summary>
        private SingleChoiceAction filteringCriterionAction;
        /// <summary>
        /// Initializes a new instance of the <see cref="CriteriaController"/> class.
        /// </summary>
        public CriteriaController()
        {
            filteringCriterionAction = new SingleChoiceAction(
                this, "FilteringCriterion", PredefinedCategory.Filters);
            filteringCriterionAction.Execute += new SingleChoiceActionExecuteEventHandler(this.FilteringCriterionAction_Execute);
            TargetViewType = ViewType.ListView;
        }
        /// <summary>
        /// Called when the View is activated.
        /// </summary>
        protected override void OnActivated()
        {
            filteringCriterionAction.Items.Clear();
            foreach (FilteringCriterion criterion in ObjectSpace.GetObjects<FilteringCriterion>())
            {
                try
                {
                    if (criterion.Objekt.IsAssignableFrom(View.ObjectTypeInfo.Type) &&
                   (criterion.Public || criterion.User.UserName == SecuritySystem.CurrentUserName))
                    {
                        filteringCriterionAction.Items.Add(
                            new ChoiceActionItem(criterion.Beschreibung, criterion.FilterKriterium));
                    }
                }
                catch { }
            }
            if (filteringCriterionAction.Items.Count > 0)
                filteringCriterionAction.Items.Add(new ChoiceActionItem("Alle", null));
        }
        /// <summary>
        /// Handles the Execute event of the FilteringCriterionAction control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SingleChoiceActionExecuteEventArgs"/> instance containing the event data.</param>
        private void FilteringCriterionAction_Execute(
            object sender, SingleChoiceActionExecuteEventArgs e)
        {
            ((ListView)View).CollectionSource.BeginUpdateCriteria();
            ((ListView)View).CollectionSource.Criteria.Clear();
            ((ListView)View).CollectionSource.Criteria[e.SelectedChoiceActionItem.Caption] =
                CriteriaEditorHelper.GetCriteriaOperator(
                e.SelectedChoiceActionItem.Data as string, View.ObjectTypeInfo.Type, ObjectSpace);
            ((ListView)View).CollectionSource.EndUpdateCriteria();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
        

        }

       
    }
}
